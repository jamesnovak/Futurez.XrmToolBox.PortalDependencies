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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.listViewAttributes = new xrmtb.XrmToolBox.Controls.AttributeListControl();
            this.panelAttributes = new System.Windows.Forms.Panel();
            this.buttonFindAttribs = new System.Windows.Forms.Button();
            this.labelAttributes = new System.Windows.Forms.Label();
            this.splitterAttribs = new System.Windows.Forms.Splitter();
            this.listViewViews = new xrmtb.XrmToolBox.Controls.EntitiesCollectionListView();
            this.panelViews = new System.Windows.Forms.Panel();
            this.buttonFindViews = new System.Windows.Forms.Button();
            this.labelViews = new System.Windows.Forms.Label();
            this.splitterForms = new System.Windows.Forms.Splitter();
            this.listViewForms = new xrmtb.XrmToolBox.Controls.EntitiesCollectionListView();
            this.panelForms = new System.Windows.Forms.Panel();
            this.buttonFindForms = new System.Windows.Forms.Button();
            this.labelForms = new System.Windows.Forms.Label();
            this.entitiesDropdown = new xrmtb.XrmToolBox.Controls.EntitiesDropdownControl();
            this.panelEntities = new System.Windows.Forms.Panel();
            this.buttonFindEntities = new System.Windows.Forms.Button();
            this.labelEntities = new System.Windows.Forms.Label();
            this.solutionsDropdown = new xrmtb.XrmToolBox.Controls.SolutionsDropdownControl();
            this.labelSolutions = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.richTextSummary = new System.Windows.Forms.RichTextBox();
            this.panelSummaryInfo = new System.Windows.Forms.Panel();
            this.linkOpenRecord = new System.Windows.Forms.LinkLabel();
            this.labelSummary = new System.Windows.Forms.Label();
            this.splitterDependencySummary = new System.Windows.Forms.Splitter();
            this.listViewDependencies = new xrmtb.XrmToolBox.Controls.BoundListViewControl();
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
            this.contextMenuList.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.panelWebsites.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1648, 44);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
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
            this.splitContainerMain.Panel1.Controls.Add(this.listViewAttributes);
            this.splitContainerMain.Panel1.Controls.Add(this.panelAttributes);
            this.splitContainerMain.Panel1.Controls.Add(this.splitterAttribs);
            this.splitContainerMain.Panel1.Controls.Add(this.listViewViews);
            this.splitContainerMain.Panel1.Controls.Add(this.panelViews);
            this.splitContainerMain.Panel1.Controls.Add(this.splitterForms);
            this.splitContainerMain.Panel1.Controls.Add(this.listViewForms);
            this.splitContainerMain.Panel1.Controls.Add(this.panelForms);
            this.splitContainerMain.Panel1.Controls.Add(this.entitiesDropdown);
            this.splitContainerMain.Panel1.Controls.Add(this.panelEntities);
            this.splitContainerMain.Panel1.Controls.Add(this.solutionsDropdown);
            this.splitContainerMain.Panel1.Controls.Add(this.labelSolutions);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelDetails);
            this.splitContainerMain.Panel2.Controls.Add(this.splitterDependencySummary);
            this.splitContainerMain.Panel2.Controls.Add(this.listViewDependencies);
            this.splitContainerMain.Panel2.Controls.Add(this.panelSummary);
            this.splitContainerMain.Size = new System.Drawing.Size(1648, 1229);
            this.splitContainerMain.SplitterDistance = 623;
            this.splitContainerMain.SplitterWidth = 9;
            this.splitContainerMain.TabIndex = 5;
            // 
            // listViewAttributes
            // 
            this.listViewAttributes.AutoLoadData = false;
            this.listViewAttributes.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.listViewAttributes.Checkboxes = true;
            this.listViewAttributes.DisplayToolbar = false;
            this.listViewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAttributes.LanguageCode = 1033;
            this.listViewAttributes.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[] {
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("listViewAttributes.ListViewColDefs"))),
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("listViewAttributes.ListViewColDefs1"))),
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("listViewAttributes.ListViewColDefs2"))),
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("listViewAttributes.ListViewColDefs3")))};
            this.listViewAttributes.Location = new System.Drawing.Point(0, 1113);
            this.listViewAttributes.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.listViewAttributes.Name = "listViewAttributes";
            this.listViewAttributes.ParentEntity = null;
            this.listViewAttributes.ParentEntityLogicalName = null;
            this.listViewAttributes.Service = null;
            this.listViewAttributes.Size = new System.Drawing.Size(623, 116);
            this.listViewAttributes.TabIndex = 13;
            this.listViewAttributes.SelectedItemChanged += new System.EventHandler(this.attributeList_ItemsChanged);
            this.listViewAttributes.CheckedItemsChanged += new System.EventHandler(this.attributeList_ItemsChanged);
            this.listViewAttributes.LoadDataComplete += new System.EventHandler(this.attributeList_LoadDataComplete);
            // 
            // panelAttributes
            // 
            this.panelAttributes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelAttributes.Controls.Add(this.buttonFindAttribs);
            this.panelAttributes.Controls.Add(this.labelAttributes);
            this.panelAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttributes.Location = new System.Drawing.Point(0, 1058);
            this.panelAttributes.Margin = new System.Windows.Forms.Padding(4);
            this.panelAttributes.Name = "panelAttributes";
            this.panelAttributes.Padding = new System.Windows.Forms.Padding(6);
            this.panelAttributes.Size = new System.Drawing.Size(623, 55);
            this.panelAttributes.TabIndex = 17;
            // 
            // buttonFindAttribs
            // 
            this.buttonFindAttribs.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFindAttribs.Location = new System.Drawing.Point(507, 6);
            this.buttonFindAttribs.Margin = new System.Windows.Forms.Padding(4, 4, 9, 4);
            this.buttonFindAttribs.Name = "buttonFindAttribs";
            this.buttonFindAttribs.Size = new System.Drawing.Size(110, 43);
            this.buttonFindAttribs.TabIndex = 7;
            this.buttonFindAttribs.Text = "Search";
            this.buttonFindAttribs.UseVisualStyleBackColor = true;
            this.buttonFindAttribs.Click += new System.EventHandler(this.buttonFindAttribs_Click);
            // 
            // labelAttributes
            // 
            this.labelAttributes.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttributes.Location = new System.Drawing.Point(6, 6);
            this.labelAttributes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAttributes.Name = "labelAttributes";
            this.labelAttributes.Size = new System.Drawing.Size(293, 43);
            this.labelAttributes.TabIndex = 6;
            this.labelAttributes.Text = "Attributes";
            this.labelAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitterAttribs
            // 
            this.splitterAttribs.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitterAttribs.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterAttribs.Location = new System.Drawing.Point(0, 1049);
            this.splitterAttribs.Margin = new System.Windows.Forms.Padding(4);
            this.splitterAttribs.Name = "splitterAttribs";
            this.splitterAttribs.Size = new System.Drawing.Size(623, 9);
            this.splitterAttribs.TabIndex = 15;
            this.splitterAttribs.TabStop = false;
            // 
            // listViewViews
            // 
            this.listViewViews.AutoLoadData = false;
            this.listViewViews.AutoRefresh = false;
            this.listViewViews.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.listViewViews.CheckBoxes = true;
            this.listViewViews.DisplayCheckBoxes = true;
            this.listViewViews.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewViews.FullRowSelect = true;
            this.listViewViews.HideSelection = false;
            this.listViewViews.LanguageCode = 1033;
            this.listViewViews.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[0];
            this.listViewViews.Location = new System.Drawing.Point(0, 704);
            this.listViewViews.Margin = new System.Windows.Forms.Padding(4);
            this.listViewViews.Name = "listViewViews";
            this.listViewViews.Service = null;
            this.listViewViews.ShowFriendlyNames = true;
            this.listViewViews.ShowLocalTimes = true;
            this.listViewViews.Size = new System.Drawing.Size(623, 345);
            this.listViewViews.TabIndex = 14;
            this.listViewViews.UseCompatibleStateImageBehavior = false;
            this.listViewViews.View = System.Windows.Forms.View.Details;
            this.listViewViews.LoadDataComplete += new System.EventHandler(this.listViewViews_LoadDataComplete);
            this.listViewViews.SelectedItemChanged += new System.EventHandler(this.listViewViews_ItemsChanged);
            this.listViewViews.CheckedItemsChanged += new System.EventHandler(this.listViewViews_ItemsChanged);
            // 
            // panelViews
            // 
            this.panelViews.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelViews.Controls.Add(this.buttonFindViews);
            this.panelViews.Controls.Add(this.labelViews);
            this.panelViews.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelViews.Location = new System.Drawing.Point(0, 649);
            this.panelViews.Margin = new System.Windows.Forms.Padding(4);
            this.panelViews.Name = "panelViews";
            this.panelViews.Padding = new System.Windows.Forms.Padding(6);
            this.panelViews.Size = new System.Drawing.Size(623, 55);
            this.panelViews.TabIndex = 19;
            // 
            // buttonFindViews
            // 
            this.buttonFindViews.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFindViews.Location = new System.Drawing.Point(507, 6);
            this.buttonFindViews.Margin = new System.Windows.Forms.Padding(4, 4, 9, 4);
            this.buttonFindViews.Name = "buttonFindViews";
            this.buttonFindViews.Size = new System.Drawing.Size(110, 43);
            this.buttonFindViews.TabIndex = 7;
            this.buttonFindViews.Text = "Search";
            this.buttonFindViews.UseVisualStyleBackColor = true;
            this.buttonFindViews.Click += new System.EventHandler(this.buttonFindViews_Click);
            // 
            // labelViews
            // 
            this.labelViews.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelViews.Location = new System.Drawing.Point(6, 6);
            this.labelViews.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelViews.Name = "labelViews";
            this.labelViews.Size = new System.Drawing.Size(293, 43);
            this.labelViews.TabIndex = 6;
            this.labelViews.Text = "Views";
            this.labelViews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitterForms
            // 
            this.splitterForms.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitterForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterForms.Location = new System.Drawing.Point(0, 640);
            this.splitterForms.Margin = new System.Windows.Forms.Padding(4);
            this.splitterForms.Name = "splitterForms";
            this.splitterForms.Size = new System.Drawing.Size(623, 9);
            this.splitterForms.TabIndex = 16;
            this.splitterForms.TabStop = false;
            // 
            // listViewForms
            // 
            this.listViewForms.AutoLoadData = false;
            this.listViewForms.AutoRefresh = false;
            this.listViewForms.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.listViewForms.CheckBoxes = true;
            this.listViewForms.DisplayCheckBoxes = true;
            this.listViewForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewForms.FullRowSelect = true;
            this.listViewForms.HideSelection = false;
            this.listViewForms.LanguageCode = 1033;
            this.listViewForms.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[0];
            this.listViewForms.Location = new System.Drawing.Point(0, 246);
            this.listViewForms.Margin = new System.Windows.Forms.Padding(4);
            this.listViewForms.Name = "listViewForms";
            this.listViewForms.Service = null;
            this.listViewForms.ShowFriendlyNames = true;
            this.listViewForms.ShowLocalTimes = true;
            this.listViewForms.Size = new System.Drawing.Size(623, 394);
            this.listViewForms.TabIndex = 11;
            this.listViewForms.UseCompatibleStateImageBehavior = false;
            this.listViewForms.View = System.Windows.Forms.View.Details;
            this.listViewForms.LoadDataComplete += new System.EventHandler(this.listViewForms_LoadDataComplete);
            this.listViewForms.SelectedItemChanged += new System.EventHandler(this.listViewForms_ItemsChanged);
            this.listViewForms.CheckedItemsChanged += new System.EventHandler(this.listViewForms_ItemsChanged);
            // 
            // panelForms
            // 
            this.panelForms.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelForms.Controls.Add(this.buttonFindForms);
            this.panelForms.Controls.Add(this.labelForms);
            this.panelForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForms.Location = new System.Drawing.Point(0, 191);
            this.panelForms.Margin = new System.Windows.Forms.Padding(4);
            this.panelForms.Name = "panelForms";
            this.panelForms.Padding = new System.Windows.Forms.Padding(6);
            this.panelForms.Size = new System.Drawing.Size(623, 55);
            this.panelForms.TabIndex = 18;
            // 
            // buttonFindForms
            // 
            this.buttonFindForms.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFindForms.Location = new System.Drawing.Point(507, 6);
            this.buttonFindForms.Margin = new System.Windows.Forms.Padding(4, 4, 9, 4);
            this.buttonFindForms.Name = "buttonFindForms";
            this.buttonFindForms.Size = new System.Drawing.Size(110, 43);
            this.buttonFindForms.TabIndex = 7;
            this.buttonFindForms.Text = "Search";
            this.buttonFindForms.UseVisualStyleBackColor = true;
            this.buttonFindForms.Click += new System.EventHandler(this.buttonFindForms_Click);
            // 
            // labelForms
            // 
            this.labelForms.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelForms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForms.Location = new System.Drawing.Point(6, 6);
            this.labelForms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelForms.Name = "labelForms";
            this.labelForms.Size = new System.Drawing.Size(293, 43);
            this.labelForms.TabIndex = 6;
            this.labelForms.Text = "Forms";
            this.labelForms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // entitiesDropdown
            // 
            this.entitiesDropdown.AutoLoadData = false;
            this.entitiesDropdown.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.entitiesDropdown.Dock = System.Windows.Forms.DockStyle.Top;
            this.entitiesDropdown.LanguageCode = 1033;
            this.entitiesDropdown.Location = new System.Drawing.Point(0, 145);
            this.entitiesDropdown.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.entitiesDropdown.Name = "entitiesDropdown";
            this.entitiesDropdown.Service = null;
            this.entitiesDropdown.Size = new System.Drawing.Size(623, 46);
            this.entitiesDropdown.SolutionFilter = null;
            this.entitiesDropdown.TabIndex = 10;
            this.entitiesDropdown.SelectedItemChanged += new System.EventHandler(this.entitiesDropdown_SelectedItemChanged);
            this.entitiesDropdown.LoadDataComplete += new System.EventHandler(this.entitiesDropdown_LoadDataComplete);
            // 
            // panelEntities
            // 
            this.panelEntities.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelEntities.Controls.Add(this.buttonFindEntities);
            this.panelEntities.Controls.Add(this.labelEntities);
            this.panelEntities.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEntities.Location = new System.Drawing.Point(0, 90);
            this.panelEntities.Margin = new System.Windows.Forms.Padding(4);
            this.panelEntities.Name = "panelEntities";
            this.panelEntities.Padding = new System.Windows.Forms.Padding(6);
            this.panelEntities.Size = new System.Drawing.Size(623, 55);
            this.panelEntities.TabIndex = 20;
            // 
            // buttonFindEntities
            // 
            this.buttonFindEntities.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFindEntities.Location = new System.Drawing.Point(507, 6);
            this.buttonFindEntities.Margin = new System.Windows.Forms.Padding(4, 4, 9, 4);
            this.buttonFindEntities.Name = "buttonFindEntities";
            this.buttonFindEntities.Size = new System.Drawing.Size(110, 43);
            this.buttonFindEntities.TabIndex = 7;
            this.buttonFindEntities.Text = "Search";
            this.buttonFindEntities.UseVisualStyleBackColor = true;
            this.buttonFindEntities.Click += new System.EventHandler(this.buttonFindEntities_Click);
            // 
            // labelEntities
            // 
            this.labelEntities.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntities.Location = new System.Drawing.Point(6, 6);
            this.labelEntities.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEntities.Name = "labelEntities";
            this.labelEntities.Size = new System.Drawing.Size(279, 43);
            this.labelEntities.TabIndex = 6;
            this.labelEntities.Text = "Entities";
            this.labelEntities.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // solutionsDropdown
            // 
            this.solutionsDropdown.AutoLoadData = false;
            this.solutionsDropdown.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.solutionsDropdown.Dock = System.Windows.Forms.DockStyle.Top;
            this.solutionsDropdown.LanguageCode = 1033;
            this.solutionsDropdown.Location = new System.Drawing.Point(0, 44);
            this.solutionsDropdown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.solutionsDropdown.Name = "solutionsDropdown";
            this.solutionsDropdown.PublisherPrefixes = ((System.Collections.Generic.List<string>)(resources.GetObject("solutionsDropdown.PublisherPrefixes")));
            this.solutionsDropdown.Service = null;
            this.solutionsDropdown.Size = new System.Drawing.Size(623, 46);
            this.solutionsDropdown.TabIndex = 12;
            this.solutionsDropdown.SelectedItemChanged += new System.EventHandler(this.solutionsDropdown_SelectedItemChanged);
            this.solutionsDropdown.LoadDataComplete += new System.EventHandler(this.solutionsDropdown_LoadDataComplete);
            // 
            // labelSolutions
            // 
            this.labelSolutions.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSolutions.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSolutions.Location = new System.Drawing.Point(0, 0);
            this.labelSolutions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSolutions.Name = "labelSolutions";
            this.labelSolutions.Size = new System.Drawing.Size(623, 44);
            this.labelSolutions.TabIndex = 2;
            this.labelSolutions.Text = "Solutions:";
            this.labelSolutions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelDetails.Controls.Add(this.richTextSummary);
            this.panelDetails.Controls.Add(this.panelSummaryInfo);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 667);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(4);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(6);
            this.panelDetails.Size = new System.Drawing.Size(1016, 562);
            this.panelDetails.TabIndex = 3;
            // 
            // richTextSummary
            // 
            this.richTextSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextSummary.Location = new System.Drawing.Point(6, 57);
            this.richTextSummary.Margin = new System.Windows.Forms.Padding(6);
            this.richTextSummary.Name = "richTextSummary";
            this.richTextSummary.ReadOnly = true;
            this.richTextSummary.Size = new System.Drawing.Size(1004, 499);
            this.richTextSummary.TabIndex = 4;
            this.richTextSummary.Text = "";
            // 
            // panelSummaryInfo
            // 
            this.panelSummaryInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummaryInfo.Controls.Add(this.linkOpenRecord);
            this.panelSummaryInfo.Controls.Add(this.labelSummary);
            this.panelSummaryInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummaryInfo.Location = new System.Drawing.Point(6, 6);
            this.panelSummaryInfo.Margin = new System.Windows.Forms.Padding(6);
            this.panelSummaryInfo.Name = "panelSummaryInfo";
            this.panelSummaryInfo.Size = new System.Drawing.Size(1004, 51);
            this.panelSummaryInfo.TabIndex = 3;
            // 
            // linkOpenRecord
            // 
            this.linkOpenRecord.Dock = System.Windows.Forms.DockStyle.Right;
            this.linkOpenRecord.Location = new System.Drawing.Point(844, 0);
            this.linkOpenRecord.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkOpenRecord.Name = "linkOpenRecord";
            this.linkOpenRecord.Size = new System.Drawing.Size(158, 49);
            this.linkOpenRecord.TabIndex = 2;
            this.linkOpenRecord.TabStop = true;
            this.linkOpenRecord.Text = "Open Record";
            this.linkOpenRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkOpenRecord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenRecord_LinkClicked);
            // 
            // labelSummary
            // 
            this.labelSummary.Location = new System.Drawing.Point(13, 15);
            this.labelSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(486, 31);
            this.labelSummary.TabIndex = 1;
            this.labelSummary.Text = "The search results are highlighted below.";
            // 
            // splitterDependencySummary
            // 
            this.splitterDependencySummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterDependencySummary.Location = new System.Drawing.Point(0, 658);
            this.splitterDependencySummary.Margin = new System.Windows.Forms.Padding(4);
            this.splitterDependencySummary.Name = "splitterDependencySummary";
            this.splitterDependencySummary.Size = new System.Drawing.Size(1016, 9);
            this.splitterDependencySummary.TabIndex = 4;
            this.splitterDependencySummary.TabStop = false;
            // 
            // listViewDependencies
            // 
            this.listViewDependencies.AutoLoadData = false;
            this.listViewDependencies.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.listViewDependencies.ContextMenuStrip = this.contextMenuList;
            this.listViewDependencies.DisplayCheckBoxes = false;
            this.listViewDependencies.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewDependencies.FullRowSelect = true;
            this.listViewDependencies.HideSelection = false;
            this.listViewDependencies.LanguageCode = 1033;
            this.listViewDependencies.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[0];
            this.listViewDependencies.Location = new System.Drawing.Point(0, 149);
            this.listViewDependencies.Margin = new System.Windows.Forms.Padding(4);
            this.listViewDependencies.MultiSelect = false;
            this.listViewDependencies.Name = "listViewDependencies";
            this.listViewDependencies.Service = null;
            this.listViewDependencies.Size = new System.Drawing.Size(1016, 509);
            this.listViewDependencies.TabIndex = 1;
            this.listViewDependencies.UseCompatibleStateImageBehavior = false;
            this.listViewDependencies.View = System.Windows.Forms.View.Details;
            this.listViewDependencies.BeginLoadData += new System.EventHandler(this.listDependencyItems_BeginLoadData);
            this.listViewDependencies.LoadDataComplete += new System.EventHandler(this.listDependencyItems_LoadDataComplete);
            this.listViewDependencies.SelectedItemChanged += new System.EventHandler(this.listDependencyItems_SelectedItemChanged);
            this.listViewDependencies.DoubleClick += new System.EventHandler(this.listDependencyItems_DoubleClick);
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
            this.panelSummary.Size = new System.Drawing.Size(1016, 149);
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
            this.panelWebsites.Size = new System.Drawing.Size(978, 43);
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
            this.labelDetails.Size = new System.Drawing.Size(978, 68);
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
            this.Size = new System.Drawing.Size(1648, 1273);
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
        private xrmtb.XrmToolBox.Controls.EntitiesDropdownControl entitiesDropdown;
        private xrmtb.XrmToolBox.Controls.EntitiesCollectionListView listViewForms;
        private xrmtb.XrmToolBox.Controls.SolutionsDropdownControl solutionsDropdown;
        private xrmtb.XrmToolBox.Controls.AttributeListControl listViewAttributes;
        private System.Windows.Forms.Splitter splitterAttribs;
        private xrmtb.XrmToolBox.Controls.EntitiesCollectionListView listViewViews;
        private System.Windows.Forms.Splitter splitterForms;
        private System.Windows.Forms.Panel panelAttributes;
        private System.Windows.Forms.Button buttonFindAttribs;
        private System.Windows.Forms.Label labelAttributes;
        private System.Windows.Forms.Panel panelViews;
        private System.Windows.Forms.Button buttonFindViews;
        private System.Windows.Forms.Label labelViews;
        private System.Windows.Forms.Panel panelForms;
        private System.Windows.Forms.Button buttonFindForms;
        private System.Windows.Forms.Label labelForms;
        private System.Windows.Forms.Panel panelEntities;
        private System.Windows.Forms.Button buttonFindEntities;
        private System.Windows.Forms.Label labelEntities;
        private xrmtb.XrmToolBox.Controls.BoundListViewControl listViewDependencies;
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
        private System.Windows.Forms.RichTextBox richTextSummary;
        private System.Windows.Forms.Panel panelWebsites;
        private xrmtb.XrmToolBox.Controls.BoundDropdownControl activeSitesDropdown;
        private System.Windows.Forms.CheckBox checkWebsiteFilter;
    }
}
