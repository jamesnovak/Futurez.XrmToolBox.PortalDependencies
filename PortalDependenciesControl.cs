using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

using XrmToolBox.Extensibility;
using McTools.Xrm.Connection;

using xrmtb.XrmToolBox.Controls;
using Microsoft.Xrm.Sdk.Query;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;
using System.ServiceModel;
using System.Linq;
using System.Resources;

namespace Futurez.XrmToolBox
{
    /// <summary>
    /// User control class for this Tool
    /// </summary>
    public partial class PortalDependenciesControl : PluginControlBase, IStatusBarMessenger, IGitHubPlugin, IHelpPlugin, IPayPalPlugin
    {
        private Settings _settings;
        private Utility _utility;
        private bool _showPortalInstallMessage = true;
        private string _baseServerUrl = null;

        public string RepositoryName => "Futurez.XrmToolBox.PortalDependencies";

        public string UserName => "jamesnovak";

        public string HelpUrl => "https://github.com/jamesnovak/Futurez.XrmToolBox.PortalDependencies/issues";

        public string DonationDescription => "Thanks for the Portals Dependencies Checker!";

        public string EmailAccount => "james@jamesnovak.com";

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        public PortalDependenciesControl()
        {
            InitializeComponent();

            _utility = new Utility();
        }

        #region Toolbox methods and events
        /// <summary>
        /// Main load for the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortalDependenciesControl_Load(object sender, EventArgs e)
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out _settings))
            {
                _settings = new Settings();
                LogInfo("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            listViewForms.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("name", 1, "Display Name") { Width = 250 },
                 new ListViewColumnDef("type", 2, "Form Type") { IsGroupColumn = true },
                 new ListViewColumnDef("description", 3, "Description") { Width = 250 }
            };
            listViewViews.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("name", 1, "Display Name") { Width = 250 },
                 // new ListViewColumnDef("querytype", 2, "Query Type") { IsGroupColumn = true },
                 new ListViewColumnDef("description", 3, "Description") { Width = 250 }
            };

            listViewDependencies.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("LogicalName", 1, "Logical Name") { Width = 250 },
                 new ListViewColumnDef("DisplayName", 2, "Display Name") { IsGroupColumn = true },
                 new ListViewColumnDef("RecordPrimaryField", 1, "Record Name") { Width = 250 },
                 new ListViewColumnDef("DependencySummary", 3, "Summary") { Width = 250 }
            };

            UpdatePortalsInstallMessage();

            splitContainerMain.Enabled = false;

            splitContainerMain.SplitterDistance = ClientSize.Width / 3;
            listViewDependencies.Height = ClientSize.Height / 2;
        }

        /// <summary>
        /// Save splitter positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortalDependenciesControl_Resize(object sender, EventArgs e)
        {
            if (_settings != null)
            {
                _settings.HSplitterPos = splitContainerMain.SplitterDistance;
                _settings.VSplitterPos = listViewDependencies.Height;
            }
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            // updating connection, so clear out controls
            ClearMainControls();

            solutionsDropdown.UpdateConnection(Service);
            entitiesDropdown.UpdateConnection(Service);
            listViewAttributes.UpdateConnection(Service);
            listViewForms.UpdateConnection(Service);
            listViewViews.UpdateConnection(Service);

            if (Service != null)
            {
                _showPortalInstallMessage = !_utility.PortalsInstalled(Service);
            }

            UpdatePortalsInstallMessage();

            // change in connection, update UI, lock it down!
            splitContainerMain.Enabled = false;

            if ((Service != null) && !_showPortalInstallMessage)
            {
                solutionsDropdown.LoadData();
                LoadPortalSites();

                var url = ConnectionDetail.WebApplicationUrl;
                if (string.IsNullOrEmpty(url))
                {
                    url = string.Concat(ConnectionDetail.ServerName, "/", ConnectionDetail.Organization);
                    if (!url.ToLower().StartsWith("http"))
                    {
                        url = string.Concat("http://", url);
                    }
                }
                _baseServerUrl = url;

                splitContainerMain.Enabled = true;
            }
        }

        #region Toolbar events
        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortalDependenciesControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), _settings);
        }
        #endregion
        
        #endregion
        /// <summary>
        /// Show notification to the user that the environment does not have portals installed
        /// </summary>
        private void UpdatePortalsInstallMessage() 
        {   
            // ShowNotification/HideNotification will show an error message if the control is not fully loaded
            try
            {
                HideNotification();

                if (_showPortalInstallMessage)
                {
                    ShowErrorNotification("The current environment does not have Power Apps Portals installed.  Check out the link under Learn More to find out about Power Apps Portals", 
                        new Uri("https://powerapps.microsoft.com/en-us/portals/"));
                }
            }
            catch (NullReferenceException)
            {
            }
        }

        /// <summary>
        /// Load the list of portal sites to filter 
        /// </summary>
        private void LoadPortalSites()
        {
            WorkAsync(
                new WorkAsyncInfo()
                {
                    AsyncArgument = null,
                    Message = "Loading Active Portal Website Records",
                    MessageWidth = 340,
                    MessageHeight = 150,
                    Work = (w, e) =>
                    {
                        w.ReportProgress(0);

                        var query = new QueryExpression("adx_website")
                        {
                            ColumnSet = new ColumnSet(
                                "adx_parentwebsiteid",
                                "adx_websiteid",
                                "adx_name",
                                "adx_primarydomainname",
                                "adx_partialurl")
                        };

                        try
                        {
                            var sites = Service.RetrieveMultiple(query);
                            e.Result = sites;
                        }
                        catch (FaultException ex)
                        {
                            e.Result = ex;
                        }
                        finally
                        {
                            w.ReportProgress(100);
                        }

                    },
                    ProgressChanged = e =>
                    {
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState?.ToString()));
                    },
                    PostWorkCallBack = e =>
                    {
                        activeSitesDropdown.ClearData();

                        var err = e.Result as FaultException;
                        if (err != null)
                        {
                            MessageBox.Show(this, $"An error occured attempting to load the list of Active Website Records. Has Portals been deployed to this tenant?\n\n{err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var sites = e.Result as EntityCollection;
                        var items = new List<ListDisplayItem>();

                        foreach (var ent in sites.Entities)
                        {
                            var name = ent["adx_name"].ToString();
                            var domain = (ent.Attributes.ContainsKey("adx_primarydomainname")) ? 
                                    ent["adx_primarydomainname"].ToString() : "no domain";

                            items.Add(new ListDisplayItem()
                            {
                                Name = name,
                                DisplayName = $"{name} ({domain})",
                                Description = "",
                                Object = ent
                            });
                        }

                        activeSitesDropdown.LoadData(items);
                    }
                });
        }
        /// <summary>
        /// Clear data from the main controls
        /// </summary>
        private void ClearMainControls()
        {
            listViewForms.ClearData();
            listViewViews.ClearData();
            listViewAttributes.ClearData();
            entitiesDropdown.ClearData();
            solutionsDropdown.ClearData();
            activeSitesDropdown.ClearData();

            listViewDependencies.ClearData();
            richTextSummary.Text = "";

            ToggleFindButtonsEnabled(false);
        }

        /// <summary>
        /// Reload the list of Entities based on the selected Solution
        /// </summary>
        private void ReloadEntitiesList() 
        {
            entitiesDropdown.ClearData();
            
            ReloadEntityRelatedInfo(null);

            var solution = solutionsDropdown?.SelectedSolution;
            if (solution != null)
            {
                // update the entities control selected solution 
                entitiesDropdown.SolutionFilter = solutionsDropdown?.SelectedSolution.Attributes["uniquename"].ToString();
                entitiesDropdown.LoadData();
                entitiesDropdown.Enabled = true;
            }
        }

        /// <summary>
        /// Helper method to load the items 
        /// </summary>
        /// <param name="entMeta"></param>
        private void ReloadEntityRelatedInfo(EntityMetadata entMeta) 
        {
            listViewAttributes.ClearData();
            listViewViews.ClearData();
            listViewForms.ClearData();

            listViewAttributes.Enabled =
            listViewForms.Enabled =
            listViewViews.Enabled = false;

            listViewAttributes.ParentEntity = entMeta;
            
            if (entMeta != null)
            {
                // reload the entities for the current Entity
                listViewAttributes.LoadData();

                var otc = entMeta.ObjectTypeCode.Value;

                // reload the related forms and views 
                var fetchXml = _utility.GetFetchXml("views_for_entity");
                fetchXml = fetchXml.Replace("{otc}", otc.ToString());
                listViewViews.LoadData(fetchXml);

                fetchXml = _utility.GetFetchXml("forms_for_entity");
                fetchXml = fetchXml.Replace("{otc}", otc.ToString());
                listViewForms.LoadData(fetchXml);
            }
        }

        /// <summary>
        /// Helper method to toggle main controls enabled state
        /// </summary>
        private void DisableMainControls()
        {
            this.splitContainerMain.Enabled = false;
        }

        #region UI Event Handlers
        
        #region Shared Control events

        /// <summary>
        /// Selected Solution Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solutionsDropdown_SelectedItemChanged(object sender, EventArgs e)
        {
            ReloadEntitiesList();
        }

        /// <summary>
        /// Load Data complete for Solutions Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solutionsDropdown_LoadDataComplete(object sender, EventArgs e)
        {
            solutionsDropdown.Enabled = true;
            splitContainerMain.Enabled = (solutionsDropdown.AllSolutions.Count > 0);

        }

        /// <summary>
        /// Selected Entity changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entitiesDropdown_SelectedItemChanged(object sender, EventArgs e)
        {
            ReloadEntityRelatedInfo(entitiesDropdown.SelectedEntity);
        }

        /// <summary>
        /// Load Data Complete for Entities List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entitiesDropdown_LoadDataComplete(object sender, EventArgs e)
        {
            entitiesDropdown.Enabled = true;
        }

        /// <summary>
        /// Load Data complete for Attribute List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attributeList_LoadDataComplete(object sender, EventArgs e)
        {
            listViewAttributes.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attributeList_ItemsChanged(object sender, EventArgs e)
        {
            ToggleFindButtonsEnabled();

        }

        /// <summary>
        /// Load Data complete for List View - Views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewViews_LoadDataComplete(object sender, EventArgs e)
        {
            listViewViews.Enabled = true;
        }

        /// <summary>
        /// Enable / Disable 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewViews_ItemsChanged(object sender, EventArgs e)
        {
            ToggleFindButtonsEnabled();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindViews_Click(object sender, EventArgs e)
        {
            var views = listViewViews.CheckedEntities.ConvertAll<object>(i => i as object);

            ProcessDependencies(new ViewDependencies(Service, _utility, _baseServerUrl), views);

        }
        
        /// <summary>
        /// Load Data complete for List View - Forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewForms_LoadDataComplete(object sender, EventArgs e)
        {
            listViewForms.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewForms_ItemsChanged(object sender, EventArgs e)
        {
            ToggleFindButtonsEnabled();
        }

        #endregion 

        /// <summary>
        /// Search for the dependencies for the selected entity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindEntities_Click(object sender, EventArgs e)
        {
            var selEntity = entitiesDropdown.SelectedEntity;
            richTextSummary.Text = "";

            string siteId = null;
            if (checkWebsiteFilter.Checked)
            {
                var item = activeSitesDropdown.SelectedItem as ListDisplayItem;
                siteId = ((Entity)item.Object).Id.ToString();
            }

            ToggleFindButtonsEnabled(false);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Entity Dependencies",
                AsyncArgument = selEntity,
                Work = (worker, args) =>
                {
                    var entity = args.Argument as EntityMetadata;
                    var entDep = new EntityDependencies(Service, _utility, _baseServerUrl);
                    var list = entDep.LoadDependencies(entity, siteId);

                    args.Result = list;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as List<DependencyItem>;
                    if (result != null)
                    {
                        listViewDependencies.LoadData<DependencyItem>(result);
                    }
                }
            });
        }

        /// <summary>
        /// Shared helper method to process dependencies for Entity items
        /// </summary>
        /// <param name="depends"></param>
        /// <param name="listItems"></param>
        private void ProcessDependencies(IChildDependencies depends, List<object> listItems)
        {
            richTextSummary.Text = "";

            ToggleFindButtonsEnabled(false);

            var ent = entitiesDropdown?.SelectedEntity;
            if (ent == null) {
                return;
            }

            string siteId = null;
            if (checkWebsiteFilter.Checked) {
                var item = activeSitesDropdown.SelectedItem as ListDisplayItem;
                siteId = ((Entity)item.Object).Id.ToString();
            }
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Dependencies",
                Work = (worker, args) =>
                {
                    var list = depends.ProcessDependencies(listItems, ent.LogicalName, siteId);

                    args.Result = list;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as List<DependencyItem>;
                    if (result != null)
                    {
                        listViewDependencies.LoadData<DependencyItem>(result);
                    }
                }
            });
        }

        /// <summary>
        /// Find the selected Forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindForms_Click(object sender, EventArgs e)
        {
            var forms = listViewForms.CheckedEntities.ConvertAll<object>(i => i as object);

            ProcessDependencies(new FormDependencies(Service, _utility, _baseServerUrl), forms);
        }

        /// <summary>
        /// Find the selected Attribute items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindAttribs_Click(object sender, EventArgs e)
        {
            var attribs = listViewAttributes.CheckedAttributes.ConvertAll<object>(i => i as object);

            ProcessDependencies(new AttributeDependencies(Service, _utility, _baseServerUrl), attribs);
        }

        private void listDependencyItems_DoubleClick(object sender, EventArgs e)
        {
            var item = listViewDependencies.GetSelectedItem<DependencyItem>();
            OpenRecord(item?.EntityReferenceUrl);
        }

        /// <summary>
        /// Update the selection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDependencyItems_SelectedItemChanged(object sender, EventArgs e)
        {
            richTextSummary.Text = "";
            var item = listViewDependencies.GetSelectedItem<DependencyItem>();
            
            if (item == null)
                return;

            richTextSummary.SuspendLayout();
            linkOpenRecord.Tag = item.EntityReferenceUrl;
            var search = new List<string>();
            foreach (var f in item.FindResults)
            {
                search.AddRange(f.SearchValues.Select(s =>  s)
                    .Where(s=> !search.Contains(s)));
            }

            var searchItemSummary = $"Searching for: {string.Join(", ", search.ToArray())}";
            richTextSummary.Text = $"{searchItemSummary}{Environment.NewLine}{Environment.NewLine}{item.DependencySummary}";

            HighlightSelections(search, searchItemSummary.Length);

            richTextSummary.ResumeLayout();
        }

        /// <summary>
        /// Open the record on double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkOpenRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenRecord(linkOpenRecord.Tag?.ToString());
        }

        /// <summary>
        /// Copy the link to the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemCopyLinktoRecord_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(linkOpenRecord.Tag?.ToString());
        }
        #endregion

        #region Helper stuff

        /// <summary>
        /// Toggle the main find buttons 
        /// </summary>
        /// <param name="enabled"></param>
        private void ToggleFindButtonsEnabled(bool? enabled = null)
        {
            if (enabled.HasValue) {
                buttonFindEntities.Enabled = 
                buttonFindAttribs.Enabled = 
                buttonFindForms.Enabled = 
                buttonFindViews.Enabled = enabled.Value;
            }
            else {
                buttonFindEntities.Enabled = (entitiesDropdown.SelectedEntity != null);
                buttonFindAttribs.Enabled = (listViewAttributes.CheckedAttributes?.Count > 0);
                buttonFindForms.Enabled = (listViewForms.CheckedEntities?.Count > 0);
                buttonFindViews.Enabled = (listViewViews.CheckedEntities?.Count > 0);
            }
        }

        /// <summary>
        /// Open the entity record using the system handler
        /// </summary>
        /// <param name="url"></param>
        private void OpenRecord(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }

        /// <summary>
        /// Highlight the selected test in the Rich Text box
        /// </summary>
        /// <param name="findItems"></param>
        private void HighlightSelections(List<string> findItems, int startOffset = 0)
        {
            int startindex = startOffset;

            richTextSummary.SelectionStart = 0;
            richTextSummary.SelectionLength = startOffset;
            richTextSummary.SelectionFont = new Font(richTextSummary.Font, FontStyle.Bold);

            var counter = 0;
            foreach (var findItem in findItems) 
            {
                var highlight = _utility.GetHighlightColor(counter++);

                while (startindex < richTextSummary.TextLength)
                {
                    int wordstartIndex = richTextSummary.Find(findItem, startindex, RichTextBoxFinds.None);
                    if (wordstartIndex != -1)
                    {
                        richTextSummary.SelectionStart = wordstartIndex;
                        richTextSummary.SelectionLength = findItem.Length;
                        richTextSummary.SelectionFont = new Font(richTextSummary.Font, FontStyle.Bold | FontStyle.Italic);
                        richTextSummary.SelectionColor = highlight.ForeColor;
                        richTextSummary.SelectionBackColor = highlight.BackColor;
                    }
                    else
                        break;
                    startindex += wordstartIndex + findItem.Length;
                }
            }
            richTextSummary.Select(0, 0);
            richTextSummary.ScrollToCaret();
        }

        private void listDependencyItems_LoadDataComplete(object sender, EventArgs e)
        {
            ToggleFindButtonsEnabled();
        }

        private void listDependencyItems_BeginLoadData(object sender, EventArgs e)
        {
            ToggleFindButtonsEnabled(false);
        }
        #endregion
    }

    #region Template stuff

    //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

    //// Loads or creates the settings for the plugin
    //if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
    //{
    //    mySettings = new Settings();

    //    LogWarning("Settings not found => a new settings file has been created!");
    //}
    //else
    //{
    //    LogInfo("Settings found and loaded");
    //}
    //private void GetAccounts()
    //{
    //    WorkAsync(new WorkAsyncInfo
    //    {
    //        Message = "Getting accounts",
    //        Work = (worker, args) =>
    //        {
    //            args.Result = Service.RetrieveMultiple(new QueryExpression("account")
    //            {
    //                TopCount = 50
    //            });
    //        },
    //        PostWorkCallBack = (args) =>
    //        {
    //            if (args.Error != null)
    //            {
    //                MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            }
    //            var result = args.Result as EntityCollection;
    //            if (result != null)
    //            {
    //                MessageBox.Show($"Found {result.Entities.Count} accounts");
    //            }
    //        }
    //    });
    //}
    #endregion
}
