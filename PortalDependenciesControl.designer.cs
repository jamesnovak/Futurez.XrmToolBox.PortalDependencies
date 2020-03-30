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
            this.attributeList = new xrmtb.XrmToolBox.Controls.AttributeListControl();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonFindForms = new System.Windows.Forms.Button();
            this.labelForms = new System.Windows.Forms.Label();
            this.entitiesDropdown = new xrmtb.XrmToolBox.Controls.EntitiesDropdownControl();
            this.panelEntities = new System.Windows.Forms.Panel();
            this.buttonEntities = new System.Windows.Forms.Button();
            this.labelEntities = new System.Windows.Forms.Label();
            this.solutionsDropdown = new xrmtb.XrmToolBox.Controls.SolutionsDropdownControl();
            this.labelSolutions = new System.Windows.Forms.Label();
            this.listDependencyItems = new xrmtb.XrmToolBox.Controls.BoundListViewControl();
            this.contextMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemOpenRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopyLinktoRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.labelDetails = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.richTextSummary = new System.Windows.Forms.RichTextBox();
            this.panelSummaryInfo = new System.Windows.Forms.Panel();
            this.linkOpenRecord = new System.Windows.Forms.LinkLabel();
            this.labelSummary = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelAttributes.SuspendLayout();
            this.panelViews.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelEntities.SuspendLayout();
            this.contextMenuList.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.panelSummaryInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(899, 35);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(68, 32);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 35);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.attributeList);
            this.splitContainerMain.Panel1.Controls.Add(this.panelAttributes);
            this.splitContainerMain.Panel1.Controls.Add(this.splitterAttribs);
            this.splitContainerMain.Panel1.Controls.Add(this.listViewViews);
            this.splitContainerMain.Panel1.Controls.Add(this.panelViews);
            this.splitContainerMain.Panel1.Controls.Add(this.splitterForms);
            this.splitContainerMain.Panel1.Controls.Add(this.listViewForms);
            this.splitContainerMain.Panel1.Controls.Add(this.panel2);
            this.splitContainerMain.Panel1.Controls.Add(this.entitiesDropdown);
            this.splitContainerMain.Panel1.Controls.Add(this.panelEntities);
            this.splitContainerMain.Panel1.Controls.Add(this.solutionsDropdown);
            this.splitContainerMain.Panel1.Controls.Add(this.labelSolutions);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.listDependencyItems);
            this.splitContainerMain.Panel2.Controls.Add(this.panelSummary);
            this.splitContainerMain.Panel2.Controls.Add(this.splitter1);
            this.splitContainerMain.Panel2.Controls.Add(this.panelDetails);
            this.splitContainerMain.Size = new System.Drawing.Size(899, 582);
            this.splitContainerMain.SplitterDistance = 411;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 5;
            // 
            // attributeList
            // 
            this.attributeList.AutoLoadData = false;
            this.attributeList.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.attributeList.Checkboxes = true;
            this.attributeList.DisplayToolbar = false;
            this.attributeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeList.LanguageCode = 1033;
            this.attributeList.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[] {
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("attributeList.ListViewColDefs"))),
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("attributeList.ListViewColDefs1"))),
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("attributeList.ListViewColDefs2"))),
        ((xrmtb.XrmToolBox.Controls.ListViewColumnDef)(resources.GetObject("attributeList.ListViewColDefs3")))};
            this.attributeList.Location = new System.Drawing.Point(0, 449);
            this.attributeList.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.attributeList.Name = "attributeList";
            this.attributeList.ParentEntity = null;
            this.attributeList.ParentEntityLogicalName = null;
            this.attributeList.Service = null;
            this.attributeList.Size = new System.Drawing.Size(411, 133);
            this.attributeList.TabIndex = 13;
            this.attributeList.LoadDataComplete += new System.EventHandler(this.attributeList_LoadDataComplete);
            // 
            // panelAttributes
            // 
            this.panelAttributes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelAttributes.Controls.Add(this.buttonFindAttribs);
            this.panelAttributes.Controls.Add(this.labelAttributes);
            this.panelAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttributes.Location = new System.Drawing.Point(0, 417);
            this.panelAttributes.Margin = new System.Windows.Forms.Padding(2);
            this.panelAttributes.Name = "panelAttributes";
            this.panelAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.panelAttributes.Size = new System.Drawing.Size(411, 32);
            this.panelAttributes.TabIndex = 17;
            // 
            // buttonFindAttribs
            // 
            this.buttonFindAttribs.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFindAttribs.Location = new System.Drawing.Point(348, 3);
            this.buttonFindAttribs.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.buttonFindAttribs.Name = "buttonFindAttribs";
            this.buttonFindAttribs.Size = new System.Drawing.Size(60, 26);
            this.buttonFindAttribs.TabIndex = 7;
            this.buttonFindAttribs.Text = "Search";
            this.buttonFindAttribs.UseVisualStyleBackColor = true;
            this.buttonFindAttribs.Click += new System.EventHandler(this.buttonFindAttribs_Click);
            // 
            // labelAttributes
            // 
            this.labelAttributes.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttributes.Location = new System.Drawing.Point(3, 3);
            this.labelAttributes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAttributes.Name = "labelAttributes";
            this.labelAttributes.Size = new System.Drawing.Size(160, 26);
            this.labelAttributes.TabIndex = 6;
            this.labelAttributes.Text = "Attributes";
            this.labelAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitterAttribs
            // 
            this.splitterAttribs.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitterAttribs.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterAttribs.Location = new System.Drawing.Point(0, 412);
            this.splitterAttribs.Margin = new System.Windows.Forms.Padding(2);
            this.splitterAttribs.Name = "splitterAttribs";
            this.splitterAttribs.Size = new System.Drawing.Size(411, 5);
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
            this.listViewViews.Location = new System.Drawing.Point(0, 291);
            this.listViewViews.Margin = new System.Windows.Forms.Padding(2);
            this.listViewViews.Name = "listViewViews";
            this.listViewViews.Service = null;
            this.listViewViews.ShowFriendlyNames = true;
            this.listViewViews.ShowLocalTimes = true;
            this.listViewViews.Size = new System.Drawing.Size(411, 121);
            this.listViewViews.TabIndex = 14;
            this.listViewViews.UseCompatibleStateImageBehavior = false;
            this.listViewViews.View = System.Windows.Forms.View.Details;
            this.listViewViews.LoadDataComplete += new System.EventHandler(this.listViewViews_LoadDataComplete);
            // 
            // panelViews
            // 
            this.panelViews.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelViews.Controls.Add(this.buttonFindViews);
            this.panelViews.Controls.Add(this.labelViews);
            this.panelViews.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelViews.Location = new System.Drawing.Point(0, 259);
            this.panelViews.Margin = new System.Windows.Forms.Padding(2);
            this.panelViews.Name = "panelViews";
            this.panelViews.Padding = new System.Windows.Forms.Padding(3);
            this.panelViews.Size = new System.Drawing.Size(411, 32);
            this.panelViews.TabIndex = 19;
            // 
            // buttonFindViews
            // 
            this.buttonFindViews.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFindViews.Location = new System.Drawing.Point(348, 3);
            this.buttonFindViews.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.buttonFindViews.Name = "buttonFindViews";
            this.buttonFindViews.Size = new System.Drawing.Size(60, 26);
            this.buttonFindViews.TabIndex = 7;
            this.buttonFindViews.Text = "Search";
            this.buttonFindViews.UseVisualStyleBackColor = true;
            // 
            // labelViews
            // 
            this.labelViews.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelViews.Location = new System.Drawing.Point(3, 3);
            this.labelViews.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelViews.Name = "labelViews";
            this.labelViews.Size = new System.Drawing.Size(160, 26);
            this.labelViews.TabIndex = 6;
            this.labelViews.Text = "Views";
            this.labelViews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitterForms
            // 
            this.splitterForms.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitterForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterForms.Location = new System.Drawing.Point(0, 254);
            this.splitterForms.Margin = new System.Windows.Forms.Padding(2);
            this.splitterForms.Name = "splitterForms";
            this.splitterForms.Size = new System.Drawing.Size(411, 5);
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
            this.listViewForms.Location = new System.Drawing.Point(0, 138);
            this.listViewForms.Margin = new System.Windows.Forms.Padding(2);
            this.listViewForms.Name = "listViewForms";
            this.listViewForms.Service = null;
            this.listViewForms.ShowFriendlyNames = true;
            this.listViewForms.ShowLocalTimes = true;
            this.listViewForms.Size = new System.Drawing.Size(411, 116);
            this.listViewForms.TabIndex = 11;
            this.listViewForms.UseCompatibleStateImageBehavior = false;
            this.listViewForms.View = System.Windows.Forms.View.Details;
            this.listViewForms.LoadDataComplete += new System.EventHandler(this.listViewForms_LoadDataComplete);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.buttonFindForms);
            this.panel2.Controls.Add(this.labelForms);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(411, 32);
            this.panel2.TabIndex = 18;
            // 
            // buttonFindForms
            // 
            this.buttonFindForms.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFindForms.Location = new System.Drawing.Point(348, 3);
            this.buttonFindForms.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.buttonFindForms.Name = "buttonFindForms";
            this.buttonFindForms.Size = new System.Drawing.Size(60, 26);
            this.buttonFindForms.TabIndex = 7;
            this.buttonFindForms.Text = "Search";
            this.buttonFindForms.UseVisualStyleBackColor = true;
            this.buttonFindForms.Click += new System.EventHandler(this.buttonFindForms_Click);
            // 
            // labelForms
            // 
            this.labelForms.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelForms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForms.Location = new System.Drawing.Point(3, 3);
            this.labelForms.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelForms.Name = "labelForms";
            this.labelForms.Size = new System.Drawing.Size(160, 26);
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
            this.entitiesDropdown.Location = new System.Drawing.Point(0, 81);
            this.entitiesDropdown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.entitiesDropdown.Name = "entitiesDropdown";
            this.entitiesDropdown.Service = null;
            this.entitiesDropdown.Size = new System.Drawing.Size(411, 25);
            this.entitiesDropdown.SolutionFilter = null;
            this.entitiesDropdown.TabIndex = 10;
            this.entitiesDropdown.SelectedItemChanged += new System.EventHandler(this.entitiesDropdown_SelectedItemChanged);
            this.entitiesDropdown.LoadDataComplete += new System.EventHandler(this.entitiesDropdown_LoadDataComplete);
            // 
            // panelEntities
            // 
            this.panelEntities.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelEntities.Controls.Add(this.buttonEntities);
            this.panelEntities.Controls.Add(this.labelEntities);
            this.panelEntities.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEntities.Location = new System.Drawing.Point(0, 49);
            this.panelEntities.Margin = new System.Windows.Forms.Padding(2);
            this.panelEntities.Name = "panelEntities";
            this.panelEntities.Padding = new System.Windows.Forms.Padding(3);
            this.panelEntities.Size = new System.Drawing.Size(411, 32);
            this.panelEntities.TabIndex = 20;
            // 
            // buttonEntities
            // 
            this.buttonEntities.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonEntities.Location = new System.Drawing.Point(348, 3);
            this.buttonEntities.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.buttonEntities.Name = "buttonEntities";
            this.buttonEntities.Size = new System.Drawing.Size(60, 26);
            this.buttonEntities.TabIndex = 7;
            this.buttonEntities.Text = "Search";
            this.buttonEntities.UseVisualStyleBackColor = true;
            this.buttonEntities.Click += new System.EventHandler(this.buttonEntities_Click);
            // 
            // labelEntities
            // 
            this.labelEntities.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntities.Location = new System.Drawing.Point(3, 3);
            this.labelEntities.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEntities.Name = "labelEntities";
            this.labelEntities.Size = new System.Drawing.Size(160, 26);
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
            this.solutionsDropdown.Location = new System.Drawing.Point(0, 24);
            this.solutionsDropdown.Margin = new System.Windows.Forms.Padding(1);
            this.solutionsDropdown.Name = "solutionsDropdown";
            this.solutionsDropdown.PublisherPrefixes = ((System.Collections.Generic.List<string>)(resources.GetObject("solutionsDropdown.PublisherPrefixes")));
            this.solutionsDropdown.Service = null;
            this.solutionsDropdown.Size = new System.Drawing.Size(411, 25);
            this.solutionsDropdown.TabIndex = 12;
            this.solutionsDropdown.SelectedItemChanged += new System.EventHandler(this.solutionsDropdown_SelectedItemChanged);
            this.solutionsDropdown.LoadDataComplete += new System.EventHandler(this.solutionsDropdown_LoadDataComplete);
            // 
            // labelSolutions
            // 
            this.labelSolutions.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSolutions.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSolutions.Location = new System.Drawing.Point(0, 0);
            this.labelSolutions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSolutions.Name = "labelSolutions";
            this.labelSolutions.Size = new System.Drawing.Size(411, 24);
            this.labelSolutions.TabIndex = 2;
            this.labelSolutions.Text = "Solutions:";
            this.labelSolutions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listDependencyItems
            // 
            this.listDependencyItems.AutoLoadData = false;
            this.listDependencyItems.AutosizeColumns = System.Windows.Forms.ColumnHeaderAutoResizeStyle.None;
            this.listDependencyItems.ContextMenuStrip = this.contextMenuList;
            this.listDependencyItems.DisplayCheckBoxes = false;
            this.listDependencyItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDependencyItems.FullRowSelect = true;
            this.listDependencyItems.HideSelection = false;
            this.listDependencyItems.LanguageCode = 1033;
            this.listDependencyItems.ListViewColDefs = new xrmtb.XrmToolBox.Controls.ListViewColumnDef[0];
            this.listDependencyItems.Location = new System.Drawing.Point(0, 49);
            this.listDependencyItems.Margin = new System.Windows.Forms.Padding(2);
            this.listDependencyItems.MultiSelect = false;
            this.listDependencyItems.Name = "listDependencyItems";
            this.listDependencyItems.Service = null;
            this.listDependencyItems.Size = new System.Drawing.Size(483, 309);
            this.listDependencyItems.TabIndex = 1;
            this.listDependencyItems.UseCompatibleStateImageBehavior = false;
            this.listDependencyItems.View = System.Windows.Forms.View.Details;
            this.listDependencyItems.SelectedItemChanged += new System.EventHandler(this.listDependencyItems_SelectedItemChanged);
            this.listDependencyItems.DoubleClick += new System.EventHandler(this.listDependencyItems_DoubleClick);
            // 
            // contextMenuList
            // 
            this.contextMenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpenRecord,
            this.menuItemCopyLinktoRecord});
            this.contextMenuList.Name = "contextMenuList";
            this.contextMenuList.Size = new System.Drawing.Size(182, 48);
            // 
            // menuItemOpenRecord
            // 
            this.menuItemOpenRecord.Name = "menuItemOpenRecord";
            this.menuItemOpenRecord.Size = new System.Drawing.Size(181, 22);
            this.menuItemOpenRecord.Text = "Open Record";
            this.menuItemOpenRecord.Click += new System.EventHandler(this.listDependencyItems_DoubleClick);
            // 
            // menuItemCopyLinktoRecord
            // 
            this.menuItemCopyLinktoRecord.Name = "menuItemCopyLinktoRecord";
            this.menuItemCopyLinktoRecord.Size = new System.Drawing.Size(181, 22);
            this.menuItemCopyLinktoRecord.Text = "Copy Link to Record";
            this.menuItemCopyLinktoRecord.Click += new System.EventHandler(this.menuItemCopyLinktoRecord_Click);
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelSummary.Controls.Add(this.labelDetails);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(0, 0);
            this.panelSummary.Margin = new System.Windows.Forms.Padding(2);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Padding = new System.Windows.Forms.Padding(10);
            this.panelSummary.Size = new System.Drawing.Size(483, 49);
            this.panelSummary.TabIndex = 2;
            // 
            // labelDetails
            // 
            this.labelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDetails.Location = new System.Drawing.Point(10, 10);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(463, 29);
            this.labelDetails.TabIndex = 0;
            this.labelDetails.Text = "View the list of dependencies found below. Select the record to see a summary of " +
    "where the selected value was found. Double click to open the record, or right cl" +
    "ick for more options.";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 358);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(483, 5);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelDetails.Controls.Add(this.richTextSummary);
            this.panelDetails.Controls.Add(this.panelSummaryInfo);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDetails.Location = new System.Drawing.Point(0, 363);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(2);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(3);
            this.panelDetails.Size = new System.Drawing.Size(483, 219);
            this.panelDetails.TabIndex = 3;
            // 
            // richTextSummary
            // 
            this.richTextSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextSummary.Location = new System.Drawing.Point(3, 27);
            this.richTextSummary.Name = "richTextSummary";
            this.richTextSummary.ReadOnly = true;
            this.richTextSummary.Size = new System.Drawing.Size(477, 189);
            this.richTextSummary.TabIndex = 4;
            this.richTextSummary.Text = "";
            // 
            // panelSummaryInfo
            // 
            this.panelSummaryInfo.Controls.Add(this.linkOpenRecord);
            this.panelSummaryInfo.Controls.Add(this.labelSummary);
            this.panelSummaryInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummaryInfo.Location = new System.Drawing.Point(3, 3);
            this.panelSummaryInfo.Name = "panelSummaryInfo";
            this.panelSummaryInfo.Size = new System.Drawing.Size(477, 24);
            this.panelSummaryInfo.TabIndex = 3;
            // 
            // linkOpenRecord
            // 
            this.linkOpenRecord.Dock = System.Windows.Forms.DockStyle.Right;
            this.linkOpenRecord.Location = new System.Drawing.Point(391, 0);
            this.linkOpenRecord.Name = "linkOpenRecord";
            this.linkOpenRecord.Size = new System.Drawing.Size(86, 24);
            this.linkOpenRecord.TabIndex = 2;
            this.linkOpenRecord.TabStop = true;
            this.linkOpenRecord.Text = "Open Record";
            this.linkOpenRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkOpenRecord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenRecord_LinkClicked);
            // 
            // labelSummary
            // 
            this.labelSummary.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSummary.Location = new System.Drawing.Point(7, -1);
            this.labelSummary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(245, 24);
            this.labelSummary.TabIndex = 1;
            this.labelSummary.Text = "Summary: Scroll to see the found value highlighted";
            this.labelSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortalDependenciesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "PortalDependenciesControl";
            this.Size = new System.Drawing.Size(899, 617);
            this.Load += new System.EventHandler(this.PortalDependenciesControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelAttributes.ResumeLayout(false);
            this.panelViews.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelEntities.ResumeLayout(false);
            this.contextMenuList.ResumeLayout(false);
            this.panelSummary.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelSummaryInfo.ResumeLayout(false);
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
        private xrmtb.XrmToolBox.Controls.AttributeListControl attributeList;
        private System.Windows.Forms.Splitter splitterAttribs;
        private xrmtb.XrmToolBox.Controls.EntitiesCollectionListView listViewViews;
        private System.Windows.Forms.Splitter splitterForms;
        private System.Windows.Forms.Panel panelAttributes;
        private System.Windows.Forms.Button buttonFindAttribs;
        private System.Windows.Forms.Label labelAttributes;
        private System.Windows.Forms.Panel panelViews;
        private System.Windows.Forms.Button buttonFindViews;
        private System.Windows.Forms.Label labelViews;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonFindForms;
        private System.Windows.Forms.Label labelForms;
        private System.Windows.Forms.Panel panelEntities;
        private System.Windows.Forms.Button buttonEntities;
        private System.Windows.Forms.Label labelEntities;
        private xrmtb.XrmToolBox.Controls.BoundListViewControl listDependencyItems;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelSummaryInfo;
        private System.Windows.Forms.LinkLabel linkOpenRecord;
        private System.Windows.Forms.ContextMenuStrip contextMenuList;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenRecord;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopyLinktoRecord;
        private System.Windows.Forms.RichTextBox richTextSummary;
    }
}
