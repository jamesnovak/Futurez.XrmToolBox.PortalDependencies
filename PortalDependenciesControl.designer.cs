namespace Futurez.XrmToolBox
{
    partial class PortalDependenciesControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortalDependenciesControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.ListViewAttributes = new xrmtb.XrmToolBox.Controls.AttributeListControl();
            this.panelAttributes = new System.Windows.Forms.Panel();
            this.LinkSearchAttributes = new System.Windows.Forms.LinkLabel();
            this.labelAttributes = new System.Windows.Forms.Label();
            this.splitterAttribs = new System.Windows.Forms.Splitter();
            this.ListViewViews = new xrmtb.XrmToolBox.Controls.EntitiesCollectionListView();
            this.panelViews = new System.Windows.Forms.Panel();
            this.LinkSearchViews = new System.Windows.Forms.LinkLabel();
            this.labelViews = new System.Windows.Forms.Label();
            this.splitterForms = new System.Windows.Forms.Splitter();
            this.ListViewForms = new xrmtb.XrmToolBox.Controls.EntitiesCollectionListView();
            this.panelForms = new System.Windows.Forms.Panel();
            this.LinkSearchForms = new System.Windows.Forms.LinkLabel();
            this.labelForms = new System.Windows.Forms.Label();
            this.EntitiesDropdown = new xrmtb.XrmToolBox.Controls.EntitiesDropdownControl();
            this.panelEntities = new System.Windows.Forms.Panel();
            this.LinkSearchEntitites = new System.Windows.Forms.LinkLabel();
            this.labelEntities = new System.Windows.Forms.Label();
            this.SolutionsDropdown = new xrmtb.XrmToolBox.Controls.SolutionsDropdownControl();
            this.labelSolutions = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.RichTextSummary = new System.Windows.Forms.RichTextBox();
            this.panelSummaryInfo = new System.Windows.Forms.Panel();
            this.tableSearchDetails = new System.Windows.Forms.TableLayoutPanel();
            this.linkOpenRecord = new System.Windows.Forms.LinkLabel();
            this.labelSummary = new System.Windows.Forms.Label();
            this.textBoxEntitiesSearched = new System.Windows.Forms.TextBox();
            this.splitterDependencySummary = new System.Windows.Forms.Splitter();
            this.ListViewDependencies = new xrmtb.XrmToolBox.Controls.BoundListViewControl();
            this.contextMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemOpenRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopyLinktoRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.panelWebsites = new System.Windows.Forms.Panel();
            this.activeSitesDropdown = new xrmtb.XrmToolBox.Controls.BoundDropdownControl();
            this.checkWebsiteFilter = new System.Windows.Forms.CheckBox();
            this.labelDetails = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelAttributes.SuspendLayout();
            this.panelViews.SuspendLayout();
            this.panelForms.SuspendLayout();
            this.panelEntities.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.panelSummaryInfo.SuspendLayout();
            this.tableSearchDetails.SuspendLayout();
            this.contextMenuList.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.panelWebsites.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.toolButtonOpen,
            this.toolStripSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1729, 44);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStripMain";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(83, 38);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // toolButtonOpen
            // 
            this.toolButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonOpen.Image")));
            this.toolButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonOpen.Name = "toolButtonOpen";
            this.toolButtonOpen.Size = new System.Drawing.Size(154, 38);
            this.toolButtonOpen.Text = "Open Record";
            this.toolButtonOpen.Click += new System.EventHandler(this.toolButtonOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 44);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.ListViewAttributes);
            this.splitContainerMain.Panel1.Controls.Add(this.panelAttributes);
            this.splitContainerMain.Panel1.Controls.Add(this.splitterAttribs);
            this.splitContainerMain.Panel1.Controls.Add(this.ListViewViews);
            this.splitContainerMain.Panel1.Controls.Add(this.panelViews);
            this.splitContainerMain.Panel1.Controls.Add(this.splitterForms);
            this.splitContainerMain.Panel1.Controls.Add(this.ListViewForms);
            this.splitContainerMain.Panel1.Controls.Add(this.panelForms);
            this.splitContainerMain.Panel1.Controls.Add(this.EntitiesDropdown);
            this.splitContainerMain.Panel1.Controls.Add(this.panelEntities);
            this.splitContainerMain.Panel1.Controls.Add(this.SolutionsDropdown);
            this.splitContainerMain.Panel1.Controls.Add(this.labelSolutions);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelDetails);
            this.splitContainerMain.Panel2.Controls.Add(this.splitterDependencySummary);
            this.splitContainerMain.Panel2.Controls.Add(this.ListViewDependencies);
            this.splitContainerMain.Panel2.Controls.Add(this.panelSummary);
            this.splitContainerMain.Size = new System.Drawing.Size(1729, 979);
            this.splitContainerMain.SplitterDistance = 650;
            this.splitContainerMain.SplitterWidth = 9;
            this.splitContainerMain.TabIndex = 5;
            // 
            // ListViewAttributes
            // 
            this.ListViewAttributes.AutoLoadData = false;
            this.ListViewAttributes.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.ListViewAttributes.Checkboxes = true;
            this.ListViewAttributes.DisplayToolbar = false;
            this.ListViewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewAttributes.LanguageCode = 1033;
            this.ListViewAttributes.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[] {
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("ListViewAttributes.ListViewColDefs"))),
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("ListViewAttributes.ListViewColDefs1"))),
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("ListViewAttributes.ListViewColDefs2"))),
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("ListViewAttributes.ListViewColDefs3")))};
            this.ListViewAttributes.Location = new System.Drawing.Point(0, 915);
            this.ListViewAttributes.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ListViewAttributes.Name = "ListViewAttributes";
            this.ListViewAttributes.ParentEntity = null;
            this.ListViewAttributes.ParentEntityLogicalName = null;
            this.ListViewAttributes.Service = null;
            this.ListViewAttributes.Size = new System.Drawing.Size(650, 64);
            this.ListViewAttributes.TabIndex = 13;
            this.ListViewAttributes.SelectedItemChanged += new System.EventHandler(this.attributeList_ItemsChanged);
            this.ListViewAttributes.CheckedItemsChanged += new System.EventHandler(this.attributeList_ItemsChanged);
            this.ListViewAttributes.LoadDataComplete += new System.EventHandler(this.attributeList_LoadDataComplete);
            // 
            // panelAttributes
            // 
            this.panelAttributes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelAttributes.Controls.Add(this.LinkSearchAttributes);
            this.panelAttributes.Controls.Add(this.labelAttributes);
            this.panelAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttributes.Location = new System.Drawing.Point(0, 865);
            this.panelAttributes.Margin = new System.Windows.Forms.Padding(4);
            this.panelAttributes.Name = "panelAttributes";
            this.panelAttributes.Padding = new System.Windows.Forms.Padding(6);
            this.panelAttributes.Size = new System.Drawing.Size(650, 50);
            this.panelAttributes.TabIndex = 17;
            // 
            // LinkSearchAttributes
            // 
            this.LinkSearchAttributes.Dock = System.Windows.Forms.DockStyle.Right;
            this.LinkSearchAttributes.Location = new System.Drawing.Point(551, 6);
            this.LinkSearchAttributes.Name = "LinkSearchAttributes";
            this.LinkSearchAttributes.Size = new System.Drawing.Size(93, 38);
            this.LinkSearchAttributes.TabIndex = 9;
            this.LinkSearchAttributes.TabStop = true;
            this.LinkSearchAttributes.Text = "Search";
            this.LinkSearchAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkSearchAttributes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSearchAttributes_LinkClicked);
            // 
            // labelAttributes
            // 
            this.labelAttributes.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttributes.Location = new System.Drawing.Point(6, 6);
            this.labelAttributes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAttributes.Name = "labelAttributes";
            this.labelAttributes.Size = new System.Drawing.Size(293, 38);
            this.labelAttributes.TabIndex = 6;
            this.labelAttributes.Text = "Attributes";
            this.labelAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitterAttribs
            // 
            this.splitterAttribs.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitterAttribs.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterAttribs.Location = new System.Drawing.Point(0, 856);
            this.splitterAttribs.Margin = new System.Windows.Forms.Padding(4);
            this.splitterAttribs.Name = "splitterAttribs";
            this.splitterAttribs.Size = new System.Drawing.Size(650, 9);
            this.splitterAttribs.TabIndex = 15;
            this.splitterAttribs.TabStop = false;
            // 
            // ListViewViews
            // 
            this.ListViewViews.AutoLoadData = false;
            this.ListViewViews.AutoRefresh = false;
            this.ListViewViews.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.ListViewViews.CheckBoxes = true;
            this.ListViewViews.DisplayCheckBoxes = true;
            this.ListViewViews.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListViewViews.FullRowSelect = true;
            this.ListViewViews.HideSelection = false;
            this.ListViewViews.LanguageCode = 1033;
            this.ListViewViews.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[0];
            this.ListViewViews.Location = new System.Drawing.Point(0, 585);
            this.ListViewViews.Margin = new System.Windows.Forms.Padding(4);
            this.ListViewViews.Name = "ListViewViews";
            this.ListViewViews.Service = null;
            this.ListViewViews.ShowFriendlyNames = true;
            this.ListViewViews.ShowLocalTimes = true;
            this.ListViewViews.Size = new System.Drawing.Size(650, 271);
            this.ListViewViews.TabIndex = 14;
            this.ListViewViews.UseCompatibleStateImageBehavior = false;
            this.ListViewViews.View = System.Windows.Forms.View.Details;
            this.ListViewViews.LoadDataComplete += new System.EventHandler(this.ListViewViews_LoadDataComplete);
            this.ListViewViews.SelectedItemChanged += new System.EventHandler(this.ListViewViews_ItemsChanged);
            this.ListViewViews.CheckedItemsChanged += new System.EventHandler(this.ListViewViews_ItemsChanged);
            // 
            // panelViews
            // 
            this.panelViews.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelViews.Controls.Add(this.LinkSearchViews);
            this.panelViews.Controls.Add(this.labelViews);
            this.panelViews.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelViews.Location = new System.Drawing.Point(0, 535);
            this.panelViews.Margin = new System.Windows.Forms.Padding(4);
            this.panelViews.Name = "panelViews";
            this.panelViews.Padding = new System.Windows.Forms.Padding(6);
            this.panelViews.Size = new System.Drawing.Size(650, 50);
            this.panelViews.TabIndex = 19;
            // 
            // LinkSearchViews
            // 
            this.LinkSearchViews.Dock = System.Windows.Forms.DockStyle.Right;
            this.LinkSearchViews.Location = new System.Drawing.Point(551, 6);
            this.LinkSearchViews.Name = "LinkSearchViews";
            this.LinkSearchViews.Size = new System.Drawing.Size(93, 38);
            this.LinkSearchViews.TabIndex = 9;
            this.LinkSearchViews.TabStop = true;
            this.LinkSearchViews.Text = "Search";
            this.LinkSearchViews.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkSearchViews.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSearchViews_LinkClicked);
            // 
            // labelViews
            // 
            this.labelViews.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelViews.Location = new System.Drawing.Point(6, 6);
            this.labelViews.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelViews.Name = "labelViews";
            this.labelViews.Size = new System.Drawing.Size(293, 38);
            this.labelViews.TabIndex = 6;
            this.labelViews.Text = "Views";
            this.labelViews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitterForms
            // 
            this.splitterForms.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitterForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterForms.Location = new System.Drawing.Point(0, 526);
            this.splitterForms.Margin = new System.Windows.Forms.Padding(4);
            this.splitterForms.Name = "splitterForms";
            this.splitterForms.Size = new System.Drawing.Size(650, 9);
            this.splitterForms.TabIndex = 16;
            this.splitterForms.TabStop = false;
            // 
            // ListViewForms
            // 
            this.ListViewForms.AutoLoadData = false;
            this.ListViewForms.AutoRefresh = false;
            this.ListViewForms.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.ListViewForms.CheckBoxes = true;
            this.ListViewForms.DisplayCheckBoxes = true;
            this.ListViewForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListViewForms.FullRowSelect = true;
            this.ListViewForms.HideSelection = false;
            this.ListViewForms.LanguageCode = 1033;
            this.ListViewForms.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[0];
            this.ListViewForms.Location = new System.Drawing.Point(0, 236);
            this.ListViewForms.Margin = new System.Windows.Forms.Padding(4);
            this.ListViewForms.Name = "ListViewForms";
            this.ListViewForms.Service = null;
            this.ListViewForms.ShowFriendlyNames = true;
            this.ListViewForms.ShowLocalTimes = true;
            this.ListViewForms.Size = new System.Drawing.Size(650, 290);
            this.ListViewForms.TabIndex = 11;
            this.ListViewForms.UseCompatibleStateImageBehavior = false;
            this.ListViewForms.View = System.Windows.Forms.View.Details;
            this.ListViewForms.LoadDataComplete += new System.EventHandler(this.ListViewForms_LoadDataComplete);
            this.ListViewForms.SelectedItemChanged += new System.EventHandler(this.ListViewForms_ItemsChanged);
            this.ListViewForms.CheckedItemsChanged += new System.EventHandler(this.ListViewForms_ItemsChanged);
            // 
            // panelForms
            // 
            this.panelForms.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelForms.Controls.Add(this.LinkSearchForms);
            this.panelForms.Controls.Add(this.labelForms);
            this.panelForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForms.Location = new System.Drawing.Point(0, 186);
            this.panelForms.Margin = new System.Windows.Forms.Padding(4);
            this.panelForms.Name = "panelForms";
            this.panelForms.Padding = new System.Windows.Forms.Padding(6);
            this.panelForms.Size = new System.Drawing.Size(650, 50);
            this.panelForms.TabIndex = 18;
            // 
            // LinkSearchForms
            // 
            this.LinkSearchForms.Dock = System.Windows.Forms.DockStyle.Right;
            this.LinkSearchForms.Location = new System.Drawing.Point(551, 6);
            this.LinkSearchForms.Name = "LinkSearchForms";
            this.LinkSearchForms.Size = new System.Drawing.Size(93, 38);
            this.LinkSearchForms.TabIndex = 8;
            this.LinkSearchForms.TabStop = true;
            this.LinkSearchForms.Text = "Search";
            this.LinkSearchForms.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkSearchForms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSearchForms_LinkClicked);
            // 
            // labelForms
            // 
            this.labelForms.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelForms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForms.Location = new System.Drawing.Point(6, 6);
            this.labelForms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelForms.Name = "labelForms";
            this.labelForms.Size = new System.Drawing.Size(293, 38);
            this.labelForms.TabIndex = 6;
            this.labelForms.Text = "Forms";
            this.labelForms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntitiesDropdown
            // 
            this.EntitiesDropdown.AutoLoadData = false;
            this.EntitiesDropdown.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EntitiesDropdown.Dock = System.Windows.Forms.DockStyle.Top;
            this.EntitiesDropdown.LanguageCode = 1033;
            this.EntitiesDropdown.Location = new System.Drawing.Point(0, 140);
            this.EntitiesDropdown.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.EntitiesDropdown.Name = "EntitiesDropdown";
            this.EntitiesDropdown.Service = null;
            this.EntitiesDropdown.Size = new System.Drawing.Size(650, 46);
            this.EntitiesDropdown.SolutionFilter = null;
            this.EntitiesDropdown.TabIndex = 10;
            this.EntitiesDropdown.SelectedItemChanged += new System.EventHandler(this.entitiesDropdown_SelectedItemChanged);
            this.EntitiesDropdown.LoadDataComplete += new System.EventHandler(this.entitiesDropdown_LoadDataComplete);
            // 
            // panelEntities
            // 
            this.panelEntities.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelEntities.Controls.Add(this.LinkSearchEntitites);
            this.panelEntities.Controls.Add(this.labelEntities);
            this.panelEntities.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEntities.Location = new System.Drawing.Point(0, 90);
            this.panelEntities.Margin = new System.Windows.Forms.Padding(4);
            this.panelEntities.Name = "panelEntities";
            this.panelEntities.Padding = new System.Windows.Forms.Padding(6);
            this.panelEntities.Size = new System.Drawing.Size(650, 50);
            this.panelEntities.TabIndex = 20;
            // 
            // LinkSearchEntitites
            // 
            this.LinkSearchEntitites.Dock = System.Windows.Forms.DockStyle.Right;
            this.LinkSearchEntitites.Location = new System.Drawing.Point(551, 6);
            this.LinkSearchEntitites.Name = "LinkSearchEntitites";
            this.LinkSearchEntitites.Size = new System.Drawing.Size(93, 38);
            this.LinkSearchEntitites.TabIndex = 9;
            this.LinkSearchEntitites.TabStop = true;
            this.LinkSearchEntitites.Text = "Search";
            this.LinkSearchEntitites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkSearchEntitites.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSearchEntitites_LinkClicked);
            // 
            // labelEntities
            // 
            this.labelEntities.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntities.Location = new System.Drawing.Point(6, 6);
            this.labelEntities.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEntities.Name = "labelEntities";
            this.labelEntities.Size = new System.Drawing.Size(279, 38);
            this.labelEntities.TabIndex = 6;
            this.labelEntities.Text = "Entities";
            this.labelEntities.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SolutionsDropdown
            // 
            this.SolutionsDropdown.AutoLoadData = false;
            this.SolutionsDropdown.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SolutionsDropdown.Dock = System.Windows.Forms.DockStyle.Top;
            this.SolutionsDropdown.LanguageCode = 1033;
            this.SolutionsDropdown.Location = new System.Drawing.Point(0, 44);
            this.SolutionsDropdown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SolutionsDropdown.Name = "SolutionsDropdown";
            this.SolutionsDropdown.PublisherPrefixes = ((System.Collections.Generic.List<string>)(resources.GetObject("SolutionsDropdown.PublisherPrefixes")));
            this.SolutionsDropdown.Service = null;
            this.SolutionsDropdown.Size = new System.Drawing.Size(650, 46);
            this.SolutionsDropdown.TabIndex = 12;
            this.SolutionsDropdown.SelectedItemChanged += new System.EventHandler(this.solutionsDropdown_SelectedItemChanged);
            this.SolutionsDropdown.LoadDataComplete += new System.EventHandler(this.solutionsDropdown_LoadDataComplete);
            // 
            // labelSolutions
            // 
            this.labelSolutions.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSolutions.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSolutions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSolutions.Location = new System.Drawing.Point(0, 0);
            this.labelSolutions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSolutions.Name = "labelSolutions";
            this.labelSolutions.Size = new System.Drawing.Size(650, 44);
            this.labelSolutions.TabIndex = 2;
            this.labelSolutions.Text = "Solutions";
            this.labelSolutions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelDetails.Controls.Add(this.RichTextSummary);
            this.panelDetails.Controls.Add(this.panelSummaryInfo);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 667);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(4);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(6);
            this.panelDetails.Size = new System.Drawing.Size(1070, 312);
            this.panelDetails.TabIndex = 3;
            // 
            // RichTextSummary
            // 
            this.RichTextSummary.BackColor = System.Drawing.SystemColors.Window;
            this.RichTextSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextSummary.Location = new System.Drawing.Point(6, 109);
            this.RichTextSummary.Margin = new System.Windows.Forms.Padding(6);
            this.RichTextSummary.Name = "RichTextSummary";
            this.RichTextSummary.ReadOnly = true;
            this.RichTextSummary.Size = new System.Drawing.Size(1058, 197);
            this.RichTextSummary.TabIndex = 4;
            this.RichTextSummary.Text = "";
            // 
            // panelSummaryInfo
            // 
            this.panelSummaryInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummaryInfo.Controls.Add(this.tableSearchDetails);
            this.panelSummaryInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummaryInfo.Location = new System.Drawing.Point(6, 6);
            this.panelSummaryInfo.Margin = new System.Windows.Forms.Padding(6);
            this.panelSummaryInfo.Name = "panelSummaryInfo";
            this.panelSummaryInfo.Size = new System.Drawing.Size(1058, 103);
            this.panelSummaryInfo.TabIndex = 3;
            // 
            // tableSearchDetails
            // 
            this.tableSearchDetails.ColumnCount = 2;
            this.tableSearchDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableSearchDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableSearchDetails.Controls.Add(this.linkOpenRecord, 1, 0);
            this.tableSearchDetails.Controls.Add(this.labelSummary, 0, 0);
            this.tableSearchDetails.Controls.Add(this.textBoxEntitiesSearched, 0, 1);
            this.tableSearchDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSearchDetails.Location = new System.Drawing.Point(0, 0);
            this.tableSearchDetails.Name = "tableSearchDetails";
            this.tableSearchDetails.RowCount = 2;
            this.tableSearchDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableSearchDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableSearchDetails.Size = new System.Drawing.Size(1056, 101);
            this.tableSearchDetails.TabIndex = 5;
            // 
            // linkOpenRecord
            // 
            this.linkOpenRecord.Location = new System.Drawing.Point(892, 0);
            this.linkOpenRecord.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkOpenRecord.Name = "linkOpenRecord";
            this.linkOpenRecord.Size = new System.Drawing.Size(158, 47);
            this.linkOpenRecord.TabIndex = 2;
            this.linkOpenRecord.TabStop = true;
            this.linkOpenRecord.Text = "Open Record";
            this.linkOpenRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkOpenRecord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenRecord_LinkClicked);
            // 
            // labelSummary
            // 
            this.labelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSummary.Location = new System.Drawing.Point(4, 0);
            this.labelSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(878, 47);
            this.labelSummary.TabIndex = 1;
            this.labelSummary.Text = "The search results for the selected item are highlighted below.";
            this.labelSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxEntitiesSearched
            // 
            this.textBoxEntitiesSearched.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableSearchDetails.SetColumnSpan(this.textBoxEntitiesSearched, 2);
            this.textBoxEntitiesSearched.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEntitiesSearched.Location = new System.Drawing.Point(3, 50);
            this.textBoxEntitiesSearched.Multiline = true;
            this.textBoxEntitiesSearched.Name = "textBoxEntitiesSearched";
            this.textBoxEntitiesSearched.ReadOnly = true;
            this.textBoxEntitiesSearched.Size = new System.Drawing.Size(1050, 48);
            this.textBoxEntitiesSearched.TabIndex = 3;
            // 
            // splitterDependencySummary
            // 
            this.splitterDependencySummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterDependencySummary.Location = new System.Drawing.Point(0, 658);
            this.splitterDependencySummary.Margin = new System.Windows.Forms.Padding(4);
            this.splitterDependencySummary.Name = "splitterDependencySummary";
            this.splitterDependencySummary.Size = new System.Drawing.Size(1070, 9);
            this.splitterDependencySummary.TabIndex = 4;
            this.splitterDependencySummary.TabStop = false;
            // 
            // ListViewDependencies
            // 
            this.ListViewDependencies.AutoLoadData = false;
            this.ListViewDependencies.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.ListViewDependencies.ContextMenuStrip = this.contextMenuList;
            this.ListViewDependencies.DisplayCheckBoxes = false;
            this.ListViewDependencies.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListViewDependencies.FullRowSelect = true;
            this.ListViewDependencies.HideSelection = false;
            this.ListViewDependencies.LanguageCode = 1033;
            this.ListViewDependencies.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[0];
            this.ListViewDependencies.Location = new System.Drawing.Point(0, 149);
            this.ListViewDependencies.Margin = new System.Windows.Forms.Padding(4);
            this.ListViewDependencies.MultiSelect = false;
            this.ListViewDependencies.Name = "ListViewDependencies";
            this.ListViewDependencies.Service = null;
            this.ListViewDependencies.Size = new System.Drawing.Size(1070, 509);
            this.ListViewDependencies.TabIndex = 1;
            this.ListViewDependencies.UseCompatibleStateImageBehavior = false;
            this.ListViewDependencies.View = System.Windows.Forms.View.Details;
            this.ListViewDependencies.BeginLoadData += new System.EventHandler(this.listDependencyItems_BeginLoadData);
            this.ListViewDependencies.LoadDataComplete += new System.EventHandler(this.listDependencyItems_LoadDataComplete);
            this.ListViewDependencies.SelectedItemChanged += new System.EventHandler(this.listDependencyItems_SelectedItemChanged);
            this.ListViewDependencies.DoubleClick += new System.EventHandler(this.listDependencyItems_DoubleClick);
            // 
            // contextMenuList
            // 
            this.contextMenuList.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpenRecord,
            this.menuItemCopyLinktoRecord});
            this.contextMenuList.Name = "contextMenuList";
            this.contextMenuList.Size = new System.Drawing.Size(272, 76);
            // 
            // menuItemOpenRecord
            // 
            this.menuItemOpenRecord.Name = "menuItemOpenRecord";
            this.menuItemOpenRecord.Size = new System.Drawing.Size(271, 36);
            this.menuItemOpenRecord.Text = "Open Record";
            this.menuItemOpenRecord.Click += new System.EventHandler(this.listDependencyItems_DoubleClick);
            // 
            // menuItemCopyLinktoRecord
            // 
            this.menuItemCopyLinktoRecord.Name = "menuItemCopyLinktoRecord";
            this.menuItemCopyLinktoRecord.Size = new System.Drawing.Size(271, 36);
            this.menuItemCopyLinktoRecord.Text = "Copy Link to Record";
            this.menuItemCopyLinktoRecord.Click += new System.EventHandler(this.menuItemCopyLinktoRecord_Click);
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.panelWebsites);
            this.panelSummary.Controls.Add(this.labelDetails);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(0, 0);
            this.panelSummary.Margin = new System.Windows.Forms.Padding(4);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Padding = new System.Windows.Forms.Padding(18);
            this.panelSummary.Size = new System.Drawing.Size(1070, 149);
            this.panelSummary.TabIndex = 2;
            // 
            // panelWebsites
            // 
            this.panelWebsites.Controls.Add(this.activeSitesDropdown);
            this.panelWebsites.Controls.Add(this.checkWebsiteFilter);
            this.panelWebsites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWebsites.Location = new System.Drawing.Point(18, 86);
            this.panelWebsites.Margin = new System.Windows.Forms.Padding(4);
            this.panelWebsites.Name = "panelWebsites";
            this.panelWebsites.Size = new System.Drawing.Size(1032, 43);
            this.panelWebsites.TabIndex = 5;
            // 
            // activeSitesDropdown
            // 
            this.activeSitesDropdown.AutoLoadData = false;
            this.activeSitesDropdown.FormattingEnabled = true;
            this.activeSitesDropdown.LanguageCode = 1033;
            this.activeSitesDropdown.Location = new System.Drawing.Point(201, 0);
            this.activeSitesDropdown.Margin = new System.Windows.Forms.Padding(4);
            this.activeSitesDropdown.Name = "activeSitesDropdown";
            this.activeSitesDropdown.Service = null;
            this.activeSitesDropdown.Size = new System.Drawing.Size(779, 32);
            this.activeSitesDropdown.TabIndex = 1;
            // 
            // checkWebsiteFilter
            // 
            this.checkWebsiteFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkWebsiteFilter.Location = new System.Drawing.Point(0, 0);
            this.checkWebsiteFilter.Margin = new System.Windows.Forms.Padding(4);
            this.checkWebsiteFilter.Name = "checkWebsiteFilter";
            this.checkWebsiteFilter.Size = new System.Drawing.Size(201, 43);
            this.checkWebsiteFilter.TabIndex = 2;
            this.checkWebsiteFilter.Text = "Filter by Website:";
            this.checkWebsiteFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkWebsiteFilter.UseVisualStyleBackColor = true;
            // 
            // labelDetails
            // 
            this.labelDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDetails.Location = new System.Drawing.Point(18, 18);
            this.labelDetails.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(1032, 68);
            this.labelDetails.TabIndex = 0;
            this.labelDetails.Text = "View the list of dependencies found below. Select the record to see a summary of " +
    "where the selected value was found. Double click to open the record, or right cl" +
    "ick for more options.";
            // 
            // PortalDependenciesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PortalDependenciesControl";
            this.Size = new System.Drawing.Size(1729, 1023);
            this.OnCloseTool += new System.EventHandler(this.PortalDependenciesControl_OnCloseTool);
            this.Load += new System.EventHandler(this.PortalDependenciesControl_Load);
            this.Resize += new System.EventHandler(this.PortalDependenciesControl_Resize);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelAttributes.ResumeLayout(false);
            this.panelViews.ResumeLayout(false);
            this.panelForms.ResumeLayout(false);
            this.panelEntities.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelSummaryInfo.ResumeLayout(false);
            this.tableSearchDetails.ResumeLayout(false);
            this.tableSearchDetails.PerformLayout();
            this.contextMenuList.ResumeLayout(false);
            this.panelSummary.ResumeLayout(false);
            this.panelWebsites.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Label labelSolutions;
        private xrmtb.XrmToolBox.Controls.EntitiesDropdownControl EntitiesDropdown;
        private xrmtb.XrmToolBox.Controls.EntitiesCollectionListView ListViewForms;
        private xrmtb.XrmToolBox.Controls.SolutionsDropdownControl SolutionsDropdown;
        private xrmtb.XrmToolBox.Controls.AttributeListControl ListViewAttributes;
        private System.Windows.Forms.Splitter splitterAttribs;
        private xrmtb.XrmToolBox.Controls.EntitiesCollectionListView ListViewViews;
        private System.Windows.Forms.Splitter splitterForms;
        private System.Windows.Forms.Panel panelAttributes;
        private System.Windows.Forms.Label labelAttributes;
        private System.Windows.Forms.Panel panelViews;
        private System.Windows.Forms.Label labelViews;
        private System.Windows.Forms.Panel panelForms;
        private System.Windows.Forms.Label labelForms;
        private System.Windows.Forms.Panel panelEntities;
        private System.Windows.Forms.Label labelEntities;
        private xrmtb.XrmToolBox.Controls.BoundListViewControl ListViewDependencies;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.Splitter splitterDependencySummary;
        private System.Windows.Forms.Panel panelSummaryInfo;
        private System.Windows.Forms.LinkLabel linkOpenRecord;
        private System.Windows.Forms.ContextMenuStrip contextMenuList;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenRecord;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopyLinktoRecord;
        private System.Windows.Forms.RichTextBox RichTextSummary;
        private System.Windows.Forms.Panel panelWebsites;
        private xrmtb.XrmToolBox.Controls.BoundDropdownControl activeSitesDropdown;
        private System.Windows.Forms.CheckBox checkWebsiteFilter;
        private System.Windows.Forms.TableLayoutPanel tableSearchDetails;
        private System.Windows.Forms.TextBox textBoxEntitiesSearched;
        private System.Windows.Forms.LinkLabel LinkSearchForms;
        private System.Windows.Forms.ToolStripButton toolButtonOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.LinkLabel LinkSearchAttributes;
        private System.Windows.Forms.LinkLabel LinkSearchViews;
        private System.Windows.Forms.LinkLabel LinkSearchEntitites;
    }
}
