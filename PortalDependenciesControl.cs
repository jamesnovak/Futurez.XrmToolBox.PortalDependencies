using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.ServiceModel;
using System.Linq;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Metadata;

using McTools.Xrm.Connection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

using xrmtb.XrmToolBox.Controls;
using System.Threading;

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
        private Panel _infoPanel = null;

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
            ListViewForms.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("name", 1, "Display Name") { Width = 250 },
                 new ListViewColumnDef("type", 2, "Form Type") { IsGroupColumn = true },
                 new ListViewColumnDef("description", 3, "Description") { Width = 250 }
            };
            ListViewViews.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("name", 1, "Display Name") { Width = 250 },
                 // new ListViewColumnDef("querytype", 2, "Query Type") { IsGroupColumn = true },
                 new ListViewColumnDef("description", 3, "Description") { Width = 250 }
            };

            ListViewDependencies.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("LogicalName", 1, "Logical Name") { Width = 250 },
                 new ListViewColumnDef("DisplayName", 2, "Display Name") { IsGroupColumn = true },
                 new ListViewColumnDef("RecordPrimaryField", 1, "Record Name") { Width = 250 },
                 new ListViewColumnDef("DependencySummary", 3, "Summary") { Width = 250 }
            };

            UpdatePortalsInstallMessage();

            splitContainerMain.Enabled = false;

            splitContainerMain.SplitterDistance = ClientSize.Width / 3;
            ListViewDependencies.Height = ClientSize.Height / 2;
        }

        /// <summary>
        /// Save splitter positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortalDependenciesControl_Resize(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            // updating connection, so clear out controls
            ClearMainControls();

            SolutionsDropdown.UpdateConnection(Service);
            EntitiesDropdown.UpdateConnection(Service);
            ListViewAttributes.UpdateConnection(Service);
            ListViewForms.UpdateConnection(Service);
            ListViewViews.UpdateConnection(Service);

            if (Service != null)
            {
                _showPortalInstallMessage = !_utility.PortalsInstalled(Service);
            }

            UpdatePortalsInstallMessage();

            // change in connection, update UI, lock it down!
            splitContainerMain.Enabled = false;

            if ((Service != null) && !_showPortalInstallMessage)
            {
                // show message panel
                InitializeMessagePanel("Loading Solutions list", 1);

                SolutionsDropdown.Enabled = false;
                SolutionsDropdown.LoadData();
                
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
        /// <summary>
        /// Handle the Close Tool event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                        var query = new QueryExpression("adx_website") {
                            ColumnSet = new ColumnSet( "adx_parentwebsiteid", "adx_websiteid", "adx_name", "adx_primarydomainname", "adx_partialurl")
                        };

                        try
                        {
                            var sites = Service.RetrieveMultiple(query);
                            e.Result = sites;
                        }
                        catch (FaultException ex) {
                            e.Result = ex;
                        }
                        finally {
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

                        sites.Entities.ToList().ForEach(ent => 
                            {
                                var name = ent["adx_name"].ToString();

                                var domain = (ent.Attributes.ContainsKey("adx_primarydomainname")) ?
                                        ent["adx_primarydomainname"].ToString() :
                                        "no domain";

                                items.Add(new ListDisplayItem() {
                                    Name = $"Domain: {domain}",
                                    DisplayName = name,
                                    // SummaryName = $"Domain: {domain}",
                                    Object = ent
                                });
                            }
                        );
                        activeSitesDropdown.LoadData(items);
                    }
                });
        }

        #region Main Methods 
        /// <summary>
        /// Reload the list of Entities based on the selected Solution
        /// </summary>
        private void ReloadEntitiesList()
        {
            InitializeMessagePanel("Loading Entities list", 1);

            EntitiesDropdown.ClearData();

            ReloadEntityRelatedInfo(null);

            var solution = SolutionsDropdown?.SelectedSolution;
            if (solution != null)
            {
                EntitiesDropdown.Enabled = false;

                // update the entities control selected solution 
                EntitiesDropdown.SolutionFilter = SolutionsDropdown?.SelectedSolution.Attributes["uniquename"].ToString();
                EntitiesDropdown.LoadData();
            }
        }

        /// <summary>
        /// Helper method to load the items 
        /// </summary>
        /// <param name="entMeta"></param>
        private void ReloadEntityRelatedInfo(EntityMetadata entMeta)
        {
            ListViewAttributes.ClearData();
            ListViewViews.ClearData();
            ListViewForms.ClearData();

            ListViewAttributes.Enabled =
            ListViewForms.Enabled =
            ListViewViews.Enabled = false;

            ListViewAttributes.ParentEntity = entMeta;

            if (entMeta != null)
            {
                InitializeMessagePanel("Loading Entity related info", 3);

                // reload the entities for the current Entity
                ListViewAttributes.LoadData();

                var otc = entMeta.ObjectTypeCode.Value;

                // reload the related forms and views 
                var fetchXml = _utility.GetFetchXml("views_for_entity");
                fetchXml = fetchXml.Replace("{otc}", otc.ToString());
                ListViewViews.LoadData(fetchXml);

                fetchXml = _utility.GetFetchXml("forms_for_entity");
                fetchXml = fetchXml.Replace("{otc}", otc.ToString());
                ListViewForms.LoadData(fetchXml);

            }
        }

        /// <summary>
        /// Init a new InformationPanel with message and counter
        /// </summary>
        /// <param name="message"></param>
        /// <param name="count"></param>
        private void InitializeMessagePanel(string message, int count) 
        {
            _infoPanel = InformationPanel.GetInformationPanel(this, message, 340, 150);
            _infoPanel.BringToFront();
            Refresh();
            _infoPanel.Tag = count;
        }

        /// <summary>
        /// Check the counter to see if we can dispose of the InformationPanel
        /// </summary>
        private void DisposeMessagePanel()
        {
            if (_infoPanel == null)
                return;

            int count = (int)_infoPanel.Tag;
            _infoPanel.Tag = --count;

            if (count == 0) {
                if (Controls.Contains(_infoPanel)) {
                    Controls.Remove(_infoPanel);
                    _infoPanel.Dispose();
                    _infoPanel = null;
                }
            }
        }

        /// <summary>
        /// Shared helper method to process dependencies for Entity child items
        /// </summary>
        /// <param name="depends"></param>
        /// <param name="listItems"></param>
        private void ProcessDependencies(IDependenciesProcessor processor, List<object> listItems, string loadingMessage)
        {
            RichTextSummary.Text = "";
            textBoxEntitiesSearched.Text = "";
            
            ToggleSearchLinksEnabled(false);

            // if no selected entity, bail
            var ent = EntitiesDropdown?.SelectedEntity;
            if (ent == null)
            {
                return;
            }

            // Check for the Website ID Filter
            string siteId = null;
            if (checkWebsiteFilter.Checked)
            {
                var item = activeSitesDropdown.SelectedItem as ListDisplayItem;
                siteId = ((Entity)item.Object).Id.ToString();
            }

            // Make the async query call
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Loading Dependencies - {loadingMessage}",
                Work = (worker, args) =>
                {
                    var list = processor.ProcessDependencies(ent.LogicalName, siteId, listItems);
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
                        ListViewDependencies.LoadData<DependencyItem>(result);
                        textBoxEntitiesSearched.Text = $"Portal Configuration Entities Searched: {string.Join(", ", ((DependencyBase)processor).EntitiesSearched.ToArray())}";
                    }
                }
            });
        }
        #endregion

        #region UI Event Handlers

        #region Shared Control events

        /// <summary>
        /// Selected Solution Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solutionsDropdown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (!SolutionsDropdown.Enabled) {
                return;
            }

            ReloadEntitiesList();
        }

        /// <summary>
        /// Load Data complete for Solutions Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solutionsDropdown_LoadDataComplete(object sender, EventArgs e)
        {
            DisposeMessagePanel();

            SolutionsDropdown.Enabled = true;
            splitContainerMain.Enabled = (SolutionsDropdown.AllSolutions.Count > 0);

            ReloadEntitiesList();

        }

        /// <summary>
        /// Selected Entity changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entitiesDropdown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (!EntitiesDropdown.Enabled)
                return;

            ReloadEntityRelatedInfo(EntitiesDropdown.SelectedEntity);
        }

        /// <summary>
        /// Load Data Complete for Entities List.  Reenable, dispose of loading message, and load related info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entitiesDropdown_LoadDataComplete(object sender, EventArgs e)
        {
            EntitiesDropdown.Enabled = true;

            DisposeMessagePanel();

            ReloadEntityRelatedInfo(EntitiesDropdown.SelectedEntity);

        }

        /// <summary>
        /// Load Data complete for Attribute List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attributeList_LoadDataComplete(object sender, EventArgs e)
        {
            ListViewAttributes.Enabled = true;
            DisposeMessagePanel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attributeList_ItemsChanged(object sender, EventArgs e)
        {
            ToggleSearchLinksEnabled();
        }

        /// <summary>
        /// Find the selected Attribute items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkSearchAttributes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var attribs = ListViewAttributes.CheckedAttributes.ConvertAll<object>(i => i as object);
            ProcessDependencies(new AttributeDependencies(Service, _utility, _baseServerUrl), attribs, "Attributes");
        }

        /// <summary>
        /// Load Data complete for List View - Views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewViews_LoadDataComplete(object sender, EventArgs e)
        {
            ListViewViews.Enabled = true;
            DisposeMessagePanel();
        }

        /// <summary>
        /// Enable / Disable 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewViews_ItemsChanged(object sender, EventArgs e)
        {
            ToggleSearchLinksEnabled();
        }

        /// <summary>
        /// Find records for the selected views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkSearchViews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var views = ListViewViews.CheckedEntities.ConvertAll<object>(i => i as object);
            ProcessDependencies(new ViewDependencies(Service, _utility, _baseServerUrl), views, "Views");
        }

        /// <summary>
        /// Load Data complete for List View - Forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewForms_LoadDataComplete(object sender, EventArgs e)
        {
            ListViewForms.Enabled = true;
            DisposeMessagePanel();
        }

        /// <summary>
        /// Find the selected Forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkSearchForms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forms = ListViewForms.CheckedEntities.ConvertAll<object>(i => i as object);
            ProcessDependencies(new FormDependencies(Service, _utility, _baseServerUrl), forms, "Forms");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewForms_ItemsChanged(object sender, EventArgs e)
        {
            ToggleSearchLinksEnabled();
        }

        /// <summary>
        /// Search for the dependencies for the selected entity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkSearchEntitites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var processor = new EntityDependencies(Service, _utility, _baseServerUrl);
            ProcessDependencies(processor, null, "Entity");
        }

        #endregion

        private void toolButtonOpen_Click(object sender, EventArgs e)
        {
            OpenRecord(linkOpenRecord.Tag?.ToString());
        }
        /// <summary>
        /// Open the selected record 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDependencyItems_DoubleClick(object sender, EventArgs e)
        {
            var item = ListViewDependencies.GetSelectedItem<DependencyItem>();
            OpenRecord(item?.EntityReferenceUrl);
        }

        /// <summary>
        /// Update the selection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDependencyItems_SelectedItemChanged(object sender, EventArgs e)
        {
            RichTextSummary.Text = "";
            var item = ListViewDependencies.GetSelectedItem<DependencyItem>();
            
            if (item == null)
                return;

            RichTextSummary.SuspendLayout();
            linkOpenRecord.Tag = item.EntityReferenceUrl;
            var search = new List<string>();
            foreach (var f in item.FindResults)
            {
                search.AddRange(f.SearchValues.Select(s =>  s)
                    .Where(s=> !search.Contains(s)));
            }

            var searchItemSummary = $"Searching for: {string.Join(", ", search.ToArray())}";
            RichTextSummary.Text = $"{searchItemSummary}{Environment.NewLine}{Environment.NewLine}{item.DependencySummary}";

            HighlightSelections(search, searchItemSummary.Length);

            RichTextSummary.ResumeLayout();
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
        /// Clear data from the main controls
        /// </summary>
        private void ClearMainControls()
        {
            ListViewForms.ClearData();
            ListViewViews.ClearData();
            ListViewAttributes.ClearData();
            EntitiesDropdown.ClearData();
            SolutionsDropdown.ClearData();
            activeSitesDropdown.ClearData();

            ListViewDependencies.ClearData();
            RichTextSummary.Text = "";

            ToggleSearchLinksEnabled(false);
        }
        /// <summary>
        /// Helper method to toggle main controls enabled state
        /// </summary>
        private void DisableMainControls()
        {
            this.splitContainerMain.Enabled = false;
        }
        /// <summary>
        /// Toggle the main find buttons 
        /// </summary>
        /// <param name="enabled"></param>
        private void ToggleSearchLinksEnabled(bool? enabled = null)
        {
            if (enabled.HasValue) {
                LinkSearchEntitites.Enabled =
                LinkSearchAttributes.Enabled =
                LinkSearchForms.Enabled =
                LinkSearchViews.Enabled = enabled.Value;
            }
            else {
                LinkSearchEntitites.Enabled = (EntitiesDropdown.SelectedEntity != null);
                LinkSearchAttributes.Enabled = (ListViewAttributes.CheckedAttributes?.Count > 0);
                LinkSearchForms.Enabled = (ListViewForms.CheckedEntities?.Count > 0);
                LinkSearchViews.Enabled = (ListViewViews.CheckedEntities?.Count > 0);
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
            
            RichTextSummary.SelectionStart = 0;
            RichTextSummary.SelectionLength = startOffset;
            RichTextSummary.SelectionFont = new Font(RichTextSummary.Font, FontStyle.Bold);

            var counter = 0;
            foreach (var findItem in findItems) 
            {
                int startindex = startOffset;

                var highlight = _utility.GetHighlightColor(counter++);

                while (startindex < RichTextSummary.TextLength)
                {
                    int wordstartIndex = RichTextSummary.Find(findItem, startindex, RichTextBoxFinds.None);
                    if (wordstartIndex != -1)
                    {
                        RichTextSummary.SelectionStart = wordstartIndex;
                        RichTextSummary.SelectionLength = findItem.Length;
                        RichTextSummary.SelectionFont = new Font(RichTextSummary.Font, FontStyle.Bold | FontStyle.Italic);
                        RichTextSummary.SelectionColor = highlight.ForeColor;
                        RichTextSummary.SelectionBackColor = highlight.BackColor;
                    }
                    else
                        break;
                    startindex += wordstartIndex + findItem.Length;
                }
            }
            RichTextSummary.Select(0, 0);
            RichTextSummary.ScrollToCaret();
            RichTextSummary.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
        }

        private void listDependencyItems_LoadDataComplete(object sender, EventArgs e)
        {
            ToggleSearchLinksEnabled();
        }

        private void listDependencyItems_BeginLoadData(object sender, EventArgs e)
        {
            ToggleSearchLinksEnabled(false);
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
