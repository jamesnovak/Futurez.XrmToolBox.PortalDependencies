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
using Futurez.XrmToolBox.Properties;

namespace Futurez.XrmToolBox
{
    /// <summary>
    /// User control class for this Tool
    /// </summary>
    public partial class PortalDependenciesControl : PluginControlBase, IStatusBarMessenger, IGitHubPlugin, IHelpPlugin, IPayPalPlugin
    {
        #region Interfaces
        public string RepositoryName => "Futurez.XrmToolBox.PortalDependencies";

        public string UserName => "jamesnovak";

        public string HelpUrl => "https://github.com/jamesnovak/Futurez.XrmToolBox.PortalDependencies/issues";

        public string DonationDescription => "Thanks for the Portals Dependencies Checker!";

        public string EmailAccount => "james@jamesnovak.com";

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;
        #endregion

        private Settings _settings;
        private Utility _utility;
        private bool _showPortalInstallMessage = true;
        private string _baseServerUrl = null;
        private Panel _infoPanel = null;
        bool _initialResizeDone = false;

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
            // set up the active tab
            panelCDSControls.Visible = true;
            panelPortalConfig.Visible = false;

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

            // Portal Config apps
            ListViewWebTemplates.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("adx_name", 1, "Name") { Width = 250 },
                 new ListViewColumnDef("adx_mimetype", 2, "Mime Type") { Width = 100 },
                 new ListViewColumnDef("adx_websiteid", 3, "Website") { Width = 150, IsGroupColumn = true }
            };

            ListViewEntityForms.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("adx_name", 1, "Name") { Width = 250 },
                 new ListViewColumnDef("adx_entityname", 2, "Entity Name") { Width = 100 },
                 new ListViewColumnDef("adx_websiteid", 3, "Website") { Width = 150, IsGroupColumn = true }
            };

            ListViewSiteSettings.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("adx_name", 1, "Name") { Width = 250 },
                 new ListViewColumnDef("adx_value", 2, "Value") { Width = 100 },
                 new ListViewColumnDef("adx_websiteid", 3, "Website") { Width = 150, IsGroupColumn = true }
            };

            ListViewWebForms.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("adx_name", 1, "Name") { Width = 250 },
                 new ListViewColumnDef("adx_startstep", 2, "Start Step") { Width = 100 },
                 new ListViewColumnDef("adx_websiteid", 3, "Website") { Width = 150, IsGroupColumn = true }
            };

            ListViewContentSnippets.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("adx_name", 1, "Name") { Width = 250 },
                 new ListViewColumnDef("adx_type", 2, "Type") { Width = 100 },
                 new ListViewColumnDef("adx_websiteid", 3, "Website") { Width = 150, IsGroupColumn = true }
            };

            ListViewEntityLists.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("adx_name", 1, "Name") { Width = 250 },
                 new ListViewColumnDef("adx_entityname", 2, "Entity Name") { Width = 100 },
                 new ListViewColumnDef("adx_websiteid", 3, "Website") { Width = 150, IsGroupColumn = true }
            };

            ListViewWebLinks.ListViewColDefs = new ListViewColumnDef[] {
                 new ListViewColumnDef("adx_name", 1, "Name") { Width = 250 },
                 new ListViewColumnDef("adx_weblinksetid", 2, "WebLink Set") { Width = 100 },
                 new ListViewColumnDef("site.adx_websiteid", 3, "Website") { Width = 150, IsGroupColumn = true }
            };

            UpdatePortalsInstallMessage();

            splitContainerMain.SplitterDistance = ClientSize.Width / 3;
            ListViewDependencies.Height = ClientSize.Height / 2;

            splitContainerMain.Enabled = false;
        }

        /// <summary>
        /// Load the CDS related controls 
        /// </summary>
        /// <param name="newConnection"></param>
        private void LoadCDSControls(bool newConnection = true)
        {
            if (SolutionsDropdown.AllSolutions.Count > 0 && !newConnection)
                return;

            // show message panel
            InitializeMessagePanel("Loading Solutions list", 1);

            SolutionsDropdown.Enabled = false;
            SolutionsDropdown.LoadData();

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

        /// <summary>
        /// Load the controls that show Portal config related info
        /// </summary>
        private void LoadPortalConfigControls(bool newConnection = true)
        {
            ResizePortalConfigControls();

            // only reload if we need to
            if (ListViewWebTemplates.Items.Count > 0 && !newConnection)
                return;

            ListViewWebTemplates.Enabled = false;
            ListViewEntityForms.Enabled = false;
            ListViewContentSnippets.Enabled = false;
            ListViewWebForms.Enabled = false;
            ListViewEntityLists.Enabled = false;
            ListViewWebLinks.Enabled = false;
            ListViewSiteSettings.Enabled = false;

            InitializeMessagePanel("Loading Portal Configruation Records", 7);

            string selSiteId = GetSelecetedPortal();
            var fetch = updateFetch(selSiteId, "web_templates");
            ListViewWebTemplates.LoadData(fetch);

            fetch = updateFetch(selSiteId, "entity_forms");
            ListViewEntityForms.LoadData(fetch);

            fetch = updateFetch(selSiteId, "web_forms");
            ListViewWebForms.LoadData(fetch);

            fetch = updateFetch(selSiteId, "site_settings");
            ListViewSiteSettings.LoadData(fetch);

            fetch = updateFetch(selSiteId, "content_snippet");
            ListViewContentSnippets.LoadData(fetch);

            fetch = updateFetch(selSiteId, "entity_list");
            ListViewEntityLists.LoadData(fetch);

            fetch = updateFetch(selSiteId, "web_link");
            ListViewWebLinks.LoadData(fetch);

            // reload the related forms and views for portal config info
            string updateFetch(string siteId, string templateName)
            {
                var fetchElement = _utility.GetFetchXmlElement(templateName);

                var filter = fetchElement
                    .Descendants("condition")
                    .Where(c => c.Attribute("attribute").Value == "adx_websiteid" &&
                                c.Attribute("value").Value == "{adx_websiteid}")
                    .FirstOrDefault();

                if (siteId != null)
                {
                    filter.SetAttributeValue("value", siteId);
                }
                else
                {
                    filter.Remove();
                }

                return fetchElement.ToString();
            };
        }

        /// <summary>
        /// Reload the controls based on the active control
        /// </summary>
        /// <param name="newConnection">Flag indicating whether this is a connection update</param>
        private void ReloadControls(bool newConnection = true)
        {
            ListViewDependencies.ClearData();
            RichTextSummary.Text = "";

            if (panelCDSControls.Visible) {
                LoadCDSControls(newConnection);
                ResizeCDSControls();
            }
            else {
                LoadPortalConfigControls(newConnection);
                ResizePortalConfigControls();
            }

            SolutionsDropdown.Enabled = panelCDSControls.Visible;
            EntitiesDropdown.Enabled = panelCDSControls.Visible;
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            // updating connection, so clear out controls
            ClearMainControls();

            // CDS
            SolutionsDropdown.UpdateConnection(newService);
            EntitiesDropdown.UpdateConnection(newService);
            ListViewAttributes.UpdateConnection(newService);
            ListViewForms.UpdateConnection(newService);
            ListViewViews.UpdateConnection(newService);

            // Portal config
            ListViewWebTemplates.UpdateConnection(newService);
            ListViewEntityForms.UpdateConnection(newService);
            ListViewContentSnippets.UpdateConnection(newService);
            ListViewWebForms.UpdateConnection(newService);
            ListViewEntityLists.UpdateConnection(newService);
            ListViewWebLinks.UpdateConnection(newService);
            ListViewSiteSettings.UpdateConnection(newService);

            if (Service != null)
            {
                _showPortalInstallMessage = !_utility.PortalsInstalled(Service);
            }

            UpdatePortalsInstallMessage();

            // change in connection, update UI, lock it down!
            splitContainerMain.Enabled = false;

            if ((Service != null) && !_showPortalInstallMessage)
            {
                ReloadControls();
                ReloadPortalSites();
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
        #endregion

        #endregion

        #region Main Methods

        /// <summary>
        /// Load the list of portal sites to filter 
        /// </summary>
        private void ReloadPortalSites()
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
                            ColumnSet = new ColumnSet("adx_parentwebsiteid", "adx_websiteid", "adx_name", "adx_primarydomainname", "adx_partialurl")
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

                        sites.Entities.ToList().ForEach(ent =>
                        {
                            var name = ent["adx_name"].ToString();

                            var domain = (ent.Attributes.ContainsKey("adx_primarydomainname")) ?
                                    ent["adx_primarydomainname"].ToString() :
                                    "no domain";

                            items.Add(new ListDisplayItem()
                            {
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

        /// <summary>
        /// Reload the list of Entities based on the selected Solution
        /// </summary>
        private void ReloadEntitiesList()
        {
            EntitiesDropdown.ClearData();

            ReloadEntityRelatedInfo(null);

            var solution = SolutionsDropdown?.SelectedSolution;
            if (solution != null)
            {
                InitializeMessagePanel("Loading Entities list", 1);

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

            ToggleMainControlsEnabled(false);
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
                ToggleMainControlsEnabled(true);
            }
        }

        /// <summary>
        /// Shared helper method to process dependencies for Entity child items
        /// </summary>
        /// <param name="depends"></param>
        /// <param name="listItems"></param>
        private void ProcessPortalDependencies(IDependenciesProcessor processor, List<Entity> listItems, string loadingMessage, bool searchNameOnly = true)
        {
            RichTextSummary.Text = "";
            textBoxEntitiesSearched.Text = "";

            ToggleSearchLinksEnabled(false);

            // Check for the Website ID Filter
            string siteId = GetSelecetedPortal();

            // Make the async query call
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Loading Dependencies - {loadingMessage}",
                Work = (worker, args) =>
                {
                    var list = processor.ProcessDependencies(siteId, listItems, searchNameOnly);
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

        /// <summary>
        /// Shared helper method to process dependencies for Entity child items
        /// </summary>
        /// <param name="depends"></param>
        /// <param name="listItems"></param>
        private void ProcessCDSDependencies(IDependenciesProcessor processor, List<object> listItems, string loadingMessage)
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
            string siteId = GetSelecetedPortal();

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
        private void SolutionsDropdown_SelectedItemChanged(object sender, EventArgs e)
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
        private void SolutionsDropdown_LoadDataComplete(object sender, EventArgs e)
        {
            DisposeMessagePanel();

            SolutionsDropdown.Enabled = true;
            splitContainerMain.Enabled = (SolutionsDropdown.AllSolutions.Count > 0);

            ReloadEntitiesList();
        }
        /// <summary>
        /// Handle the reload button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SolutionsDropdown_BeginLoadData(object sender, EventArgs e)
        {
            SolutionsDropdown.Enabled = false;
        }

        /// <summary>
        /// Selected Entity changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntitiesDropdown_SelectedItemChanged(object sender, EventArgs e)
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
        private void EntitiesDropdown_LoadDataComplete(object sender, EventArgs e)
        {
            EntitiesDropdown.Enabled = true;

            DisposeMessagePanel();

            ReloadEntityRelatedInfo(EntitiesDropdown.SelectedEntity);
        }
        /// <summary>
        /// The begin load data started, user clicked button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntitiesDropdown_BeginLoadData(object sender, EventArgs e)
        {
            EntitiesDropdown.Enabled = false;
        }

        /// <summary>
        /// Find the selected Attribute items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkSearchAttributes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var attribs = ListViewAttributes.CheckedAttributes.ConvertAll<object>(i => i as object);
            ProcessCDSDependencies(new AttributeDependencies(Service, _utility, _baseServerUrl), attribs, "Attributes");
        }

        /// <summary>
        /// Find records for the selected views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkSearchViews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var views = ListViewViews.CheckedEntities.ConvertAll<object>(i => i as object);
            ProcessCDSDependencies(new ViewDependencies(Service, _utility, _baseServerUrl), views, "Views");
        }

        /// <summary>
        /// Find the selected Forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkSearchForms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forms = ListViewForms.CheckedEntities.ConvertAll<object>(i => i as object);
            ProcessCDSDependencies(new FormDependencies(Service, _utility, _baseServerUrl), forms, "Forms");
        }

        #region Search Result control events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListDependencyItems_LoadDataComplete(object sender, EventArgs e)
        {
            ToggleSearchLinksEnabled();
        }

        private void ListDependencyItems_BeginLoadData(object sender, EventArgs e)
        {
            ToggleSearchLinksEnabled(false);
        }
        /// <summary>
        /// Search for the dependencies for the selected entity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkSearchEntitites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var processor = new EntityDependencies(Service, _utility, _baseServerUrl);
            ProcessCDSDependencies(processor, null, "Entity");
        }
        #endregion

        /// <summary>
        /// Open the selected record 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListDependencyItems_DoubleClick(object sender, EventArgs e)
        {
            var item = ListViewDependencies.GetSelectedItem<DependencyItem>();
            OpenRecord(item?.EntityReferenceUrl);
        }

        /// <summary>
        /// Update the selection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListDependencyItems_SelectedItemChanged(object sender, EventArgs e)
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
        #endregion

        #region Portal Config Links
        /// <summary>
        /// Search for the items based on the link clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkSearchWebTemplates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var entites = ListViewWebTemplates.CheckedEntities;
            ProcessPortalDependencies(new WebTemplateDependency(Service, _utility, _baseServerUrl), entites, "Web Templates");
        }

        private void LinkSearchEntityForms_Click(object sender, EventArgs e)
        {
            var entites = ListViewEntityForms.CheckedEntities;
            ProcessPortalDependencies(new EntityFormDependency(Service, _utility, _baseServerUrl), entites, "Entity Forms", false);
        }

        private void LinkSearchEntityLists_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var entites = ListViewEntityLists.CheckedEntities;
            ProcessPortalDependencies(new EntityListDependency(Service, _utility, _baseServerUrl), entites, "Entity Lists", false);
        }

        private void LinkSearchContentSnippets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var entites = ListViewContentSnippets.CheckedEntities;
            ProcessPortalDependencies(new ContentSnippetsDependency(Service, _utility, _baseServerUrl), entites, "Content Snippets");
        }

        private void LinkSearchWebLinks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var entites = ListViewWebLinks.CheckedEntities;
            ProcessPortalDependencies(new WebLinkSetDependency(Service, _utility, _baseServerUrl), entites, "Web Links", false);
        }

        private void LinkSearchWebForms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var entites = ListViewWebForms.CheckedEntities;
            ProcessPortalDependencies(new WebFormDependency(Service, _utility, _baseServerUrl), entites, "Web Forms", false);
        }

        private void LinkSearchSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var entites = ListViewSiteSettings.CheckedEntities;
            ProcessPortalDependencies(new SiteSettingsDependency(Service, _utility, _baseServerUrl), entites, "Site Settings");
        }
        #endregion

        #region Search Item loads and change events
        /// <summary>
        /// Common method for handling load data complete and reenabling control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_LoadDataComplete(object sender, EventArgs e)
        {
            ((Control)sender).Enabled = true;
            DisposeMessagePanel();
        }

        /// <summary>
        /// Shared event handler to update links
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ItemsChanged(object sender, EventArgs e)
        {
            ToggleSearchLinksEnabled();
        }

        #endregion

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

        /// <summary>
        /// Open the selected link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolButtonOpen_Click(object sender, EventArgs e)
        {
            OpenRecord(linkOpenRecord.Tag?.ToString());
        }

        /// <summary>
        /// Toggle the display of the controls for search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuCDS_Click(object sender, EventArgs e)
        {
            toolMenuPortalConfig.Checked = false;
            SwitchTabs(panelCDSControls, panelPortalConfig);
        }

        /// <summary>
        /// Toggle the display of the controls for search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuPortalConfig_Click(object sender, EventArgs e)
        {
            toolMenuCDS.Checked = false;
            SwitchTabs(panelPortalConfig, panelCDSControls);
        }
        #region Collapsible stuff - toggle collapse/expand of the search controls 
        private void buttonMaxWebTemplates_Click(object sender, EventArgs e)
        {
            TogglePortalConfigPanelExpanded(sender as Button, ListViewWebTemplates);
        }

        private void buttonMaxEntityForms_Click(object sender, EventArgs e)
        {
            TogglePortalConfigPanelExpanded(sender as Button, ListViewEntityForms);
        }

        private void buttonMaxContentSnippet_Click(object sender, EventArgs e)
        {
            TogglePortalConfigPanelExpanded(sender as Button, ListViewContentSnippets);
        }

        private void buttonMaxEntityLists_Click(object sender, EventArgs e)
        {
            TogglePortalConfigPanelExpanded(sender as Button, ListViewEntityLists);
        }

        private void buttonMaxWebLinks_Click(object sender, EventArgs e)
        {
            TogglePortalConfigPanelExpanded(sender as Button, ListViewWebLinks);
        }

        private void buttonMaxWebForms_Click(object sender, EventArgs e)
        {
            TogglePortalConfigPanelExpanded(sender as Button, ListViewWebForms);
        }

        private void buttonMaxSiteSettings_Click(object sender, EventArgs e)
        {
            TogglePortalConfigPanelExpanded(sender as Button, ListViewSiteSettings);
        }

        /// <summary>
        /// Helper method for toggling the panel expanded for Portal Config Controls
        /// </summary>
        /// <param name="button"></param>
        /// <param name="control"></param>
        private void TogglePortalConfigPanelExpanded(Button button = null, EntitiesCollectionListView control = null) 
        {
            var tag = button?.Tag;

            // reset button text and tags
            new List<Button>() { 
                buttonMaxContentSnippets,
                buttonMaxEntityForms,
                buttonMaxEntityLists,
                buttonMaxSiteSettings,
                buttonMaxWebForms,
                buttonMaxWebLinks,
                buttonMaxWebTemplates}
            .ForEach(b => {
                    b.Text = "u";
                    b.Tag = false;
                });

            if (control == null)
                return;

            var expanded = (tag != null) ? bool.Parse(tag.ToString()) : false;
            if (!expanded)
            {
                int count = 7;
                var delta = panelHeaderContentSnippet.Height * count + splitterWebTemplates.Height * count;
                var height = splitContainerMain.Panel1.ClientSize.Height - delta;

                control.Height = height;
                var controls = new List<EntitiesCollectionListView>() {
                    ListViewWebTemplates,
                    ListViewEntityForms,
                    ListViewContentSnippets,
                    ListViewEntityLists,
                    ListViewWebForms,
                    ListViewWebLinks,
                    ListViewSiteSettings
                };
                controls.ForEach(lv => {
                    lv.Visible = (lv.Name == control.Name);
                });
            }
            else {
                ResizePortalConfigControls();
            }

            button.Text = (expanded) ? "u": "q";
            button.Tag = !expanded;
        }

        private void buttonMaxForms_Click(object sender, EventArgs e)
        {
            ToggleCDSPanelExpanded(sender as Button, ListViewForms);
        }

        private void buttonMaxViews_Click(object sender, EventArgs e)
        {
            ToggleCDSPanelExpanded(sender as Button, ListViewViews);
        }

        private void buttonMaxAttributes_Click(object sender, EventArgs e)
        {
            ToggleCDSPanelExpanded(sender as Button, ListViewAttributes);
        }

        private void ToggleCDSPanelExpanded(Button button = null, Control control = null)
        {
            // grab tag before reset
            var tag = button?.Tag;

            // reset button text and tags
            new List<Button>() {
                buttonMaxForms,
                buttonMaxViews,
                buttonMaxAttributes}
            .ForEach(b => {
                b.Text = "u";
                b.Tag = false;
            });

            if (control == null)
                return;

            var expanded = (tag != null) ? bool.Parse(tag.ToString()) : false;
            if (!expanded)
            {
                var delta = panelHeaderForms.Bottom + panelHeaderViews.Height + panelHeaderAttributes.Height + splitterForms.Height * 3;
                var height = splitContainerMain.Panel1.ClientSize.Height - delta;

                control.Height = height;

                new List<Control>() {
                ListViewForms,
                ListViewViews,
                ListViewAttributes
            }
                .ForEach(lv => {
                    lv.Visible = (lv.Name == control.Name);
                });
            }
            else
            {
                ResizeCDSControls();
            }
            button.Text = (expanded) ? "u" : "q";
            button.Tag = !expanded;
        }
        #endregion
        #endregion

        #region Helper stuff
        /// <summary>
        /// Adjust sizing of the Portal Config Controls
        /// </summary>
        private void ResizePortalConfigControls()
        {
            splitContainerMain.Panel1.SuspendLayout();

            // set heights based on available space in 
            int count = 7;
            var delta = panelHeaderContentSnippet.Height * count + splitterWebTemplates.Height * count;
            var height = (splitContainerMain.Panel1.ClientSize.Height - delta) / count;

            var controls = new List<EntitiesCollectionListView>() {
                ListViewWebTemplates,
                ListViewEntityForms,
                ListViewContentSnippets,
                ListViewEntityLists,
                ListViewWebForms,
                ListViewWebLinks,
                ListViewSiteSettings
            };
            controls.ForEach(lv => {
                lv.SuspendLayout();
            });

            controls.ForEach(lv => {
                lv.Visible = true;
                lv.Height = height;
            });
            controls.ForEach(lv => {
                lv.ResumeLayout();
            });

            // make sure we reset the buttons
            TogglePortalConfigPanelExpanded();

            splitContainerMain.Panel1.ResumeLayout();
        }

        /// <summary>
        /// Even out the height of the CDS controls.
        /// </summary>
        private void ResizeCDSControls()
        {
            splitContainerMain.Panel1.SuspendLayout();

            // determine height minus the offset 
            var delta = panelHeaderEntities.Height * 7 + splitterForms.Height * 3;
            var height = (splitContainerMain.Panel1.ClientSize.Height - delta) / 3;

            ListViewForms.Height = 
            ListViewViews.Height = 2 * height/3;

            ListViewForms.Visible =
            ListViewViews.Visible =
            ListViewAttributes.Visible = true;
            
            // make sure we reset the buttons
            ToggleCDSPanelExpanded();
            splitContainerMain.Panel1.ResumeLayout();
        }

        /// <summary>
        /// Show notification to the user that the environment does not have portals installed
        /// </summary>
        private void UpdatePortalsInstallMessage()
        {
            // ShowNotification/HideNotification will show a5n error message if the control is not fully loaded
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
        /// Get the selected Website ID if we are supposed to fiter by it
        /// </summary>
        /// <returns></returns>
        private string GetSelecetedPortal()
        {
            string siteId = null;
            if (checkWebsiteFilter.Checked)
            {
                var item = activeSitesDropdown.SelectedItem as ListDisplayItem;
                siteId = ((Entity)item.Object).Id.ToString();
            }
            return siteId;
        }

        /// <summary>
        /// Helper to activate the correct panel and update selected buttons 
        /// </summary>
        /// <param name="panelFront"></param>
        /// <param name="panelBack"></param>
        /// <param name="activeButton"></param>
        /// <param name="inActiveButton"></param>
        private void SwitchTabs(Panel panelFront, Panel panelBack)
        {
            panelFront.BringToFront();
            panelFront.Visible = true;

            panelBack.SendToBack();
            panelBack.Visible = false;

            ReloadControls(false);

            UpdateStatusPanel();
        }

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

            ListViewWebTemplates.ClearData();
            ListViewEntityForms.ClearData();
            ListViewContentSnippets.ClearData();
            ListViewWebForms.ClearData();
            ListViewEntityLists.ClearData();
            ListViewWebLinks.ClearData();
            ListViewSiteSettings.ClearData();

            ListViewDependencies.ClearData();
            RichTextSummary.Text = "";

            ToggleSearchLinksEnabled(false);
        }

        /// <summary>
        /// Helper method to toggle main controls enabled state
        /// </summary>
        private void ToggleMainControlsEnabled(bool enabled)
        {
            splitContainerMain.Enabled = enabled;
            toolStripMenu.Enabled = enabled;

            UpdateStatusPanel();
        }

        private void UpdateStatusPanel()
        {
            toolLabelMessage.Text = (panelCDSControls.Visible) ? Resources.CDS_Message : Resources.Config_Message;
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
                LinkSearchViews.Enabled =

                LinkSearchWebTemplates.Enabled = 
                LinkSearchWebForms.Enabled =
                LinkSearchContentSnippets.Enabled =
                LinkSearchEntityForms.Enabled =
                LinkSearchEntityLists.Enabled =
                LinkSearchSettings.Enabled =
                LinkSearchWebLinks.Enabled = enabled.Value;
            }
            else {
                LinkSearchEntitites.Enabled = (EntitiesDropdown.SelectedEntity != null);
                LinkSearchAttributes.Enabled = (ListViewAttributes.CheckedAttributes?.Count > 0);
                LinkSearchForms.Enabled = (ListViewForms.CheckedEntities?.Count > 0);
                LinkSearchViews.Enabled = (ListViewViews.CheckedEntities?.Count > 0);

                LinkSearchWebTemplates.Enabled = (ListViewWebTemplates.CheckedEntities?.Count > 0);
                LinkSearchWebForms.Enabled = (ListViewWebForms.CheckedEntities?.Count > 0);
                LinkSearchContentSnippets.Enabled = (ListViewContentSnippets.CheckedEntities?.Count > 0);
                LinkSearchEntityForms.Enabled = (ListViewEntityForms.CheckedEntities?.Count > 0);
                LinkSearchEntityLists.Enabled = (ListViewEntityLists.CheckedEntities?.Count > 0);
                LinkSearchSettings.Enabled = (ListViewSiteSettings.CheckedEntities?.Count > 0);
                LinkSearchWebLinks.Enabled = (ListViewWebLinks.CheckedEntities?.Count > 0);
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
                    int wordstartIndex = RichTextSummary.Find(findItem, startindex, RichTextBoxFinds.MatchCase);
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
        #endregion

        private void activeSitesDropdown_LoadDataComplete(object sender, EventArgs e)
        {
            if (_initialResizeDone)
                return;

            splitContainerMain.SplitterDistance = ClientSize.Width / 3;
            ListViewDependencies.Height = splitContainerMain.Panel2.ClientSize.Height / 3;

            _initialResizeDone = true;
        }
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
