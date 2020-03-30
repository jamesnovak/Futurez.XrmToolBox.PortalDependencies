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
using System.Runtime.InteropServices;
using System.Web.Configuration;

namespace Futurez.XrmToolBox
{
    /// <summary>
    /// User control class for this Tool
    /// </summary>
    public partial class PortalDependenciesControl : PluginControlBase
    {
        // private Settings mySettings;
        private Utility _utility;
        private bool _suspendEvents = false;
        private bool _showPortalInstallMessage = true;
        private string _baseServerUrl = null;

        public PortalDependenciesControl()
        {
            InitializeComponent();

            _utility = new Utility();
        }

        /// <summary>
        /// Main load for the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortalDependenciesControl_Load(object sender, EventArgs e)
        {
            listViewForms.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("name", 1, "Display Name") { Width = 250 },
                 new ListViewColumnDef("type", 2, "Form Type") { IsGroupColumn = true },
                 new ListViewColumnDef("description", 3, "Description") { Width = 250 }
            };
            listViewViews.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("name", 1, "Display Name") { Width = 250 },
                 new ListViewColumnDef("querytype", 2, "Query Type") { IsGroupColumn = true },
                 new ListViewColumnDef("description", 3, "Description") { Width = 250 }
            };

            listDependencyItems.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("LogicalName", 1, "Logical Name") { Width = 250 },
                 new ListViewColumnDef("DisplayName", 2, "Display Name") { IsGroupColumn = true },
                 new ListViewColumnDef("RecordPrimaryField", 1, "Record Name") { Width = 250 },
                 new ListViewColumnDef("DependencySummary", 3, "Summary") { Width = 250 }
            };

            UpdatePortalsInstallMessage();

            DisableMainControls();

            // set splitter
            this.splitContainerMain.SplitterDistance = this.ClientSize.Width / 3;
        }

        /// <summary>
        /// Show notification to the user that the environment does not have portals installed
        /// </summary>
        private void UpdatePortalsInstallMessage() 
        {
            return;
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
        /// Clear data from the main controls
        /// </summary>
        private void ClearMainControls()
        {
            _suspendEvents = true;

            listViewForms.ClearData();
            listViewViews.ClearData();
            attributeList.ClearData();
            entitiesDropdown.ClearData();
            solutionsDropdown.ClearData();

            listDependencyItems.ClearData();
            richTextSummary.Text = "";

            _suspendEvents = false;
        }

        /// <summary>
        /// Reload the list of Entities based on the selected Solution
        /// </summary>
        private void ReloadEntitiesList() {

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
            attributeList.ClearData();
            listViewViews.ClearData();
            listViewForms.ClearData();

            attributeList.Enabled =
            listViewForms.Enabled =
            listViewViews.Enabled = false;

            attributeList.ParentEntity = entMeta;
            
            if (entMeta != null)
            {
                // reload the entities for the current Entity
                attributeList.LoadData();

                var otc = entMeta.ObjectTypeCode.Value;

                // reload the related forms and views 
                var fetchXml = _utility.GetFetchXml("views_for_entity");
                fetchXml = fetchXml.Replace("{otc}", otc.ToString());
                listViewViews.LoadData(fetchXml);

                fetchXml = _utility.GetFetchXml("forms_for_entity");
                fetchXml = fetchXml.Replace("{otc}", otc.ToString());
                listViewForms.LoadData(fetchXml);

                listViewForms.Enabled = true;
                listViewViews.Enabled = true;
            }
        }

        /// <summary>
        /// Helper method to toggle main controls enabled state
        /// </summary>
        private void DisableMainControls()
        {
            entitiesDropdown.Enabled =
            attributeList.Enabled = 
            listViewForms.Enabled = 
            listViewViews.Enabled = 
            solutionsDropdown.Enabled = false;
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
            if (_suspendEvents)
                return;
            ReloadEntitiesList();
        }

        /// <summary>
        /// Selected Entity changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entitiesDropdown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (_suspendEvents)
                return;
            ReloadEntityRelatedInfo(entitiesDropdown.SelectedEntity);
        }

        /// <summary>
        /// Load Data complete for Attribute List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attributeList_LoadDataComplete(object sender, EventArgs e)
        {
            attributeList.Enabled = true;
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
        /// Load Data complete for List View - Forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewForms_LoadDataComplete(object sender, EventArgs e)
        {
            listViewForms.Enabled = true;
        }

        /// <summary>
        /// Load Data Complete for Entities List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entitiesDropdown_LoadDataComplete(object sender, EventArgs e)
        {
            entitiesDropdown.Enabled = true;
            ReloadEntityRelatedInfo(entitiesDropdown.SelectedEntity);
        }

        /// <summary>
        /// Load Data complete for Solutions Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solutionsDropdown_LoadDataComplete(object sender, EventArgs e)
        {
            solutionsDropdown.Enabled = true;

            ReloadEntitiesList();

            _suspendEvents = false;
        }
        #endregion 

        /// <summary>
        /// Search for the dependencies for the selected entity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEntities_Click(object sender, EventArgs e)
        {
            var selEntity = entitiesDropdown.SelectedEntity;
            richTextSummary.Text = "";

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Entity Dependencies",
                AsyncArgument = selEntity,
                Work = (worker, args) =>
                {
                    var entity = args.Argument as EntityMetadata;
                    var entDep = new EntityDependencies(Service, _utility, _baseServerUrl);
                    var list = entDep.LoadDependencies(entity);
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
                        listDependencyItems.LoadData<DependencyItem>(result);
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

        }

        /// <summary>
        /// Find the selected Attribute items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindAttribs_Click(object sender, EventArgs e)
        {
            // get the list of selected attributes
            richTextSummary.Text = "";
            var attribs = attributeList.CheckedAttributes;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Attribute Dependencies",
                AsyncArgument = attribs,
                Work = (worker, args) =>
                {
                    var attList= args.Argument as List<AttributeMetadata>;
                    
                    var attDep = new AttributeDependencies(Service, _utility, _baseServerUrl);
                    var list = attDep.LoadDependencies(attList);

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
                        listDependencyItems.LoadData<DependencyItem>(result);
                    }
                }
            });
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
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            // SettingsManager.Instance.Save(GetType(), mySettings);
        }

        #endregion 

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
            attributeList.UpdateConnection(Service);
            listViewForms.UpdateConnection(Service);
            listViewViews.UpdateConnection(Service);

            if (Service != null)
            {
                _showPortalInstallMessage = !_utility.PortalsInstalled(Service);
            }
            
            UpdatePortalsInstallMessage();

            // change in connection, update UI, lock it down!
            DisableMainControls();

            if ((Service != null) && !_showPortalInstallMessage)
            {
                _suspendEvents = true;
                solutionsDropdown.LoadData();
            }

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
        }

        private void listDependencyItems_DoubleClick(object sender, EventArgs e)
        {
            var item = listDependencyItems.GetSelectedItem<DependencyItem>();
            OpenRecord(item?.EntityReferenceUrl);
        }

        /// <summary>
        /// Update the selection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDependencyItems_SelectedItemChanged(object sender, EventArgs e)
        {
            var item = listDependencyItems.GetSelectedItem<DependencyItem>();
            if (item == null)
                return;

            richTextSummary.SuspendLayout();
            richTextSummary.Text = item.DependencySummary;
            linkOpenRecord.Tag = item.EntityReferenceUrl;
            foreach (var f in item.FindResults)
            {
                HighlightSelections(f?.SearchValues);
            }
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
        private void HighlightSelections(List<string> findItems)
        {
            foreach (var findItem in findItems) {

                int startindex = 0;
                while (startindex < richTextSummary.TextLength)
                {
                    int wordstartIndex = richTextSummary.Find(findItem, startindex, RichTextBoxFinds.None);
                    if (wordstartIndex != -1)
                    {
                        richTextSummary.SelectionStart = wordstartIndex;
                        richTextSummary.SelectionLength = findItem.Length;
                        richTextSummary.SelectionColor = Color.White;
                        richTextSummary.SelectionBackColor = Color.Navy;
                        richTextSummary.SelectionFont = new Font(richTextSummary.Font, FontStyle.Bold);
                    }
                    else
                        break;
                    startindex += wordstartIndex + findItem.Length;
                }
            }
            richTextSummary.Select(0, 0);
            richTextSummary.ScrollToCaret();
        }

    }
    #endregion

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
