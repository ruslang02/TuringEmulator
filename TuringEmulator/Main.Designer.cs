namespace TuringEmulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HeaderMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadStateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveStateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ExportToJSONMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAppMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Table = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.RunAlgorithmButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ExecTimerSelector = new System.Windows.Forms.ComboBox();
            this.ExecTimerGlyph = new System.Windows.Forms.Button();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.CurrentStateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentStepLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.InputDataTable = new System.Windows.Forms.TableLayoutPanel();
            this.ExecTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.HelperTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.AlgorithmPreviewDock = new System.Windows.Forms.Panel();
            this.AlgorithmPreviewPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AlgorithmPreviewHeader = new System.Windows.Forms.Label();
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.NewButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.NewInstructionButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSymbolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.DeleteInstructionButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSymbolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchStateSelector = new System.Windows.Forms.ToolStripComboBox();
            this.LaunchStateLabel = new System.Windows.Forms.ToolStripLabel();
            this.LoadStateDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveStateDialog = new System.Windows.Forms.SaveFileDialog();
            this.JSONSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.HeaderMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.AlgorithmPreviewDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderMenu
            // 
            this.HeaderMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.HeaderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.HelpMenuItem});
            this.HeaderMenu.Location = new System.Drawing.Point(0, 0);
            this.HeaderMenu.Name = "HeaderMenu";
            this.HeaderMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.HeaderMenu.Size = new System.Drawing.Size(734, 24);
            this.HeaderMenu.TabIndex = 0;
            this.HeaderMenu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadStateMenuItem,
            this.SaveStateMenuItem,
            this.FileMenuSeparator,
            this.ExportToJSONMenuItem,
            this.toolStripSeparator2,
            this.ExitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileMenuItem.Text = "&Файл";
            // 
            // LoadStateMenuItem
            // 
            this.LoadStateMenuItem.Name = "LoadStateMenuItem";
            this.LoadStateMenuItem.Size = new System.Drawing.Size(168, 22);
            this.LoadStateMenuItem.Text = "Открыть...";
            this.LoadStateMenuItem.Click += new System.EventHandler(this.LoadStateButton_Click);
            // 
            // SaveStateMenuItem
            // 
            this.SaveStateMenuItem.Name = "SaveStateMenuItem";
            this.SaveStateMenuItem.Size = new System.Drawing.Size(168, 22);
            this.SaveStateMenuItem.Text = "Сохранить...";
            this.SaveStateMenuItem.Click += new System.EventHandler(this.SaveStateButton_Click);
            // 
            // FileMenuSeparator
            // 
            this.FileMenuSeparator.Name = "FileMenuSeparator";
            this.FileMenuSeparator.Size = new System.Drawing.Size(165, 6);
            // 
            // ExportToJSONMenuItem
            // 
            this.ExportToJSONMenuItem.Name = "ExportToJSONMenuItem";
            this.ExportToJSONMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ExportToJSONMenuItem.Text = "Экспорт в JSON...";
            this.ExportToJSONMenuItem.Click += new System.EventHandler(this.ExportToJSONButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ExitMenuItem.Text = "Выход";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutAppMenuItem});
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(65, 20);
            this.HelpMenuItem.Text = "&Справка";
            // 
            // AboutAppMenuItem
            // 
            this.AboutAppMenuItem.Name = "AboutAppMenuItem";
            this.AboutAppMenuItem.Size = new System.Drawing.Size(158, 22);
            this.AboutAppMenuItem.Text = "О программе...";
            this.AboutAppMenuItem.Click += new System.EventHandler(this.AboutApp_Click);
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.AllowUserToResizeColumns = false;
            this.Table.AllowUserToResizeRows = false;
            this.Table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Table.DefaultCellStyle = dataGridViewCellStyle2;
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point(0, 0);
            this.Table.MultiSelect = false;
            this.Table.Name = "Table";
            this.Table.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Table.Size = new System.Drawing.Size(499, 255);
            this.Table.TabIndex = 1;
            this.Table.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Table_CellValidating);
            this.Table.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellValueChanged);
            this.Table.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Table_ColumnHeaderClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 353);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 75);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.RunAlgorithmButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(247, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 69);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::TuringEmulator.Properties.Resources.step_backward;
            this.button3.Location = new System.Drawing.Point(49, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.PreviousStepButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::TuringEmulator.Properties.Resources.step_forward;
            this.button2.Location = new System.Drawing.Point(151, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.NextStepButton_Click);
            // 
            // RunAlgorithmButton
            // 
            this.RunAlgorithmButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RunAlgorithmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunAlgorithmButton.Image = global::TuringEmulator.Properties.Resources.play;
            this.RunAlgorithmButton.Location = new System.Drawing.Point(95, 10);
            this.RunAlgorithmButton.Name = "RunAlgorithmButton";
            this.RunAlgorithmButton.Size = new System.Drawing.Size(50, 50);
            this.RunAlgorithmButton.TabIndex = 0;
            this.RunAlgorithmButton.Tag = "play";
            this.RunAlgorithmButton.UseVisualStyleBackColor = true;
            this.RunAlgorithmButton.Click += new System.EventHandler(this.RunAlgorithmButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 69);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Изменить входное слово";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button4
            // 
            this.button4.Image = global::TuringEmulator.Properties.Resources.textbox_password;
            this.button4.Location = new System.Drawing.Point(9, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 0;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ChangeInputDataButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ExecTimerSelector);
            this.panel4.Controls.Add(this.ExecTimerGlyph);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(491, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 69);
            this.panel4.TabIndex = 2;
            // 
            // ExecTimerSelector
            // 
            this.ExecTimerSelector.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ExecTimerSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExecTimerSelector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExecTimerSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecTimerSelector.FormattingEnabled = true;
            this.ExecTimerSelector.Items.AddRange(new object[] {
            "0.5 секунд",
            "1 секунда",
            "2 секунды",
            "5 секунд",
            "10 секунд"});
            this.ExecTimerSelector.Location = new System.Drawing.Point(64, 26);
            this.ExecTimerSelector.Name = "ExecTimerSelector";
            this.ExecTimerSelector.Size = new System.Drawing.Size(121, 21);
            this.ExecTimerSelector.TabIndex = 1;
            this.ExecTimerSelector.SelectedIndexChanged += new System.EventHandler(this.ExecTimerSelector_SelectedIndexChanged);
            // 
            // ExecTimerGlyph
            // 
            this.ExecTimerGlyph.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ExecTimerGlyph.Enabled = false;
            this.ExecTimerGlyph.Image = global::TuringEmulator.Properties.Resources.timer_outline;
            this.ExecTimerGlyph.Location = new System.Drawing.Point(191, 15);
            this.ExecTimerGlyph.Name = "ExecTimerGlyph";
            this.ExecTimerGlyph.Size = new System.Drawing.Size(40, 40);
            this.ExecTimerGlyph.TabIndex = 0;
            this.ExecTimerGlyph.UseVisualStyleBackColor = true;
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentStateLabel,
            this.CurrentStepLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 428);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(734, 22);
            this.StatusBar.TabIndex = 4;
            // 
            // CurrentStateLabel
            // 
            this.CurrentStateLabel.Name = "CurrentStateLabel";
            this.CurrentStateLabel.Size = new System.Drawing.Size(667, 17);
            this.CurrentStateLabel.Spring = true;
            this.CurrentStateLabel.Text = "Готово.";
            this.CurrentStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentStepLabel
            // 
            this.CurrentStepLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.CurrentStepLabel.Name = "CurrentStepLabel";
            this.CurrentStepLabel.Size = new System.Drawing.Size(52, 17);
            this.CurrentStepLabel.Text = "Шаг: 0/0";
            this.CurrentStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InputDataTable
            // 
            this.InputDataTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InputDataTable.AutoSize = true;
            this.InputDataTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InputDataTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.InputDataTable.ColumnCount = 1;
            this.InputDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.InputDataTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.InputDataTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.InputDataTable.Location = new System.Drawing.Point(363, -1);
            this.InputDataTable.Margin = new System.Windows.Forms.Padding(0);
            this.InputDataTable.Name = "InputDataTable";
            this.InputDataTable.RowCount = 1;
            this.InputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.InputDataTable.Size = new System.Drawing.Size(2, 2);
            this.InputDataTable.TabIndex = 5;
            this.InputDataTable.SizeChanged += new System.EventHandler(this.InputDataTable_SizeChanged);
            // 
            // ExecTimer
            // 
            this.ExecTimer.Interval = 1000;
            this.ExecTimer.Tick += new System.EventHandler(this.ExecTimer_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.InputDataTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 310);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 43);
            this.panel2.TabIndex = 7;
            // 
            // AlgorithmPreviewDock
            // 
            this.AlgorithmPreviewDock.BackColor = System.Drawing.Color.White;
            this.AlgorithmPreviewDock.Controls.Add(this.AlgorithmPreviewPanel);
            this.AlgorithmPreviewDock.Controls.Add(this.AlgorithmPreviewHeader);
            this.AlgorithmPreviewDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlgorithmPreviewDock.Location = new System.Drawing.Point(0, 0);
            this.AlgorithmPreviewDock.Name = "AlgorithmPreviewDock";
            this.AlgorithmPreviewDock.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.AlgorithmPreviewDock.Size = new System.Drawing.Size(232, 255);
            this.AlgorithmPreviewDock.TabIndex = 8;
            // 
            // AlgorithmPreviewPanel
            // 
            this.AlgorithmPreviewPanel.AutoScroll = true;
            this.AlgorithmPreviewPanel.AutoScrollMargin = new System.Drawing.Size(100, 0);
            this.AlgorithmPreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlgorithmPreviewPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.AlgorithmPreviewPanel.Location = new System.Drawing.Point(5, 30);
            this.AlgorithmPreviewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AlgorithmPreviewPanel.Name = "AlgorithmPreviewPanel";
            this.AlgorithmPreviewPanel.Size = new System.Drawing.Size(227, 225);
            this.AlgorithmPreviewPanel.TabIndex = 1;
            this.AlgorithmPreviewPanel.WrapContents = false;
            // 
            // AlgorithmPreviewHeader
            // 
            this.AlgorithmPreviewHeader.BackColor = System.Drawing.Color.Transparent;
            this.AlgorithmPreviewHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlgorithmPreviewHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmPreviewHeader.Location = new System.Drawing.Point(5, 0);
            this.AlgorithmPreviewHeader.Margin = new System.Windows.Forms.Padding(0);
            this.AlgorithmPreviewHeader.Name = "AlgorithmPreviewHeader";
            this.AlgorithmPreviewHeader.Size = new System.Drawing.Size(227, 30);
            this.AlgorithmPreviewHeader.TabIndex = 0;
            this.AlgorithmPreviewHeader.Text = "Алгоритм";
            this.AlgorithmPreviewHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainContainer
            // 
            this.MainContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(0, 55);
            this.MainContainer.Name = "MainContainer";
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.Table);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.AlgorithmPreviewDock);
            this.MainContainer.Panel2MinSize = 200;
            this.MainContainer.Size = new System.Drawing.Size(734, 255);
            this.MainContainer.SplitterDistance = 499;
            this.MainContainer.SplitterWidth = 3;
            this.MainContainer.TabIndex = 9;
            // 
            // ToolBar
            // 
            this.ToolBar.AutoSize = false;
            this.ToolBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewButton,
            this.DeleteButton,
            this.LaunchStateSelector,
            this.LaunchStateLabel});
            this.ToolBar.Location = new System.Drawing.Point(0, 24);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolBar.Size = new System.Drawing.Size(734, 31);
            this.ToolBar.TabIndex = 10;
            this.ToolBar.Text = "toolStrip1";
            // 
            // NewButton
            // 
            this.NewButton.AutoSize = false;
            this.NewButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewInstructionButton,
            this.NewSymbolButton});
            this.NewButton.Image = global::TuringEmulator.Properties.Resources.plus_circle;
            this.NewButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewButton.Margin = new System.Windows.Forms.Padding(0);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(105, 28);
            this.NewButton.Text = "Добавить...";
            // 
            // NewInstructionButton
            // 
            this.NewInstructionButton.BackColor = System.Drawing.Color.White;
            this.NewInstructionButton.Image = global::TuringEmulator.Properties.Resources.table_row_plus_after;
            this.NewInstructionButton.Name = "NewInstructionButton";
            this.NewInstructionButton.Size = new System.Drawing.Size(168, 22);
            this.NewInstructionButton.Text = "Новая состояние";
            this.NewInstructionButton.Click += new System.EventHandler(this.NewInstructionButton_Click);
            // 
            // NewSymbolButton
            // 
            this.NewSymbolButton.BackColor = System.Drawing.Color.White;
            this.NewSymbolButton.Image = global::TuringEmulator.Properties.Resources.table_column_plus_after;
            this.NewSymbolButton.Name = "NewSymbolButton";
            this.NewSymbolButton.Size = new System.Drawing.Size(168, 22);
            this.NewSymbolButton.Text = "Новый символ";
            this.NewSymbolButton.Click += new System.EventHandler(this.NewSymbolButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteInstructionButton,
            this.DeleteSymbolButton});
            this.DeleteButton.Image = global::TuringEmulator.Properties.Resources.minus_circle_outline;
            this.DeleteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(97, 28);
            this.DeleteButton.Text = "Удалить...";
            // 
            // DeleteInstructionButton
            // 
            this.DeleteInstructionButton.Image = global::TuringEmulator.Properties.Resources.table_row_remove;
            this.DeleteInstructionButton.Name = "DeleteInstructionButton";
            this.DeleteInstructionButton.Size = new System.Drawing.Size(178, 22);
            this.DeleteInstructionButton.Text = "Удалить состояние";
            this.DeleteInstructionButton.Click += new System.EventHandler(this.DeleteInstructionButton_Click);
            // 
            // DeleteSymbolButton
            // 
            this.DeleteSymbolButton.Image = global::TuringEmulator.Properties.Resources.table_column_remove;
            this.DeleteSymbolButton.Name = "DeleteSymbolButton";
            this.DeleteSymbolButton.Size = new System.Drawing.Size(178, 22);
            this.DeleteSymbolButton.Text = "Удалить символ";
            this.DeleteSymbolButton.Click += new System.EventHandler(this.DeleteSymbolButton_Click);
            // 
            // LaunchStateSelector
            // 
            this.LaunchStateSelector.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LaunchStateSelector.AutoSize = false;
            this.LaunchStateSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LaunchStateSelector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LaunchStateSelector.Name = "LaunchStateSelector";
            this.LaunchStateSelector.Size = new System.Drawing.Size(80, 23);
            this.LaunchStateSelector.SelectedIndexChanged += new System.EventHandler(this.LaunchStateSelector_Change);
            // 
            // LaunchStateLabel
            // 
            this.LaunchStateLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LaunchStateLabel.Name = "LaunchStateLabel";
            this.LaunchStateLabel.Size = new System.Drawing.Size(51, 28);
            this.LaunchStateLabel.Text = "Запуск: ";
            // 
            // LoadStateDialog
            // 
            this.LoadStateDialog.FileName = "state.emt";
            this.LoadStateDialog.Filter = "Документ Эмулятора Машины Тьюринга|*.emt";
            this.LoadStateDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadStateDialog_Select);
            // 
            // SaveStateDialog
            // 
            this.SaveStateDialog.FileName = "state.emt";
            this.SaveStateDialog.Filter = "Документ Эмулятора Машины Тьюринга|*.emt";
            this.SaveStateDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveStateDialog_Select);
            // 
            // JSONSaveDialog
            // 
            this.JSONSaveDialog.FileName = "states.json";
            this.JSONSaveDialog.Filter = "JSON файл|*.json";
            this.JSONSaveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.JSONSaveDialog_Select);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 450);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.HeaderMenu);
            this.MainMenuStrip = this.HeaderMenu;
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Эмулятор Машины Тьюринга";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.HeaderMenu.ResumeLayout(false);
            this.HeaderMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.AlgorithmPreviewDock.ResumeLayout(false);
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip HeaderMenu;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel CurrentStateLabel;
        private System.Windows.Forms.ToolStripMenuItem LoadStateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveStateMenuItem;
        private System.Windows.Forms.ToolStripSeparator FileMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutAppMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button RunAlgorithmButton;
        private System.Windows.Forms.TableLayoutPanel InputDataTable;
        private System.Windows.Forms.Timer ExecTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip HelperTooltip;
        private System.Windows.Forms.ToolStripStatusLabel CurrentStepLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ExecTimerGlyph;
        private System.Windows.Forms.ComboBox ExecTimerSelector;
        private System.Windows.Forms.Panel AlgorithmPreviewDock;
        private System.Windows.Forms.FlowLayoutPanel AlgorithmPreviewPanel;
        private System.Windows.Forms.Label AlgorithmPreviewHeader;
        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripDropDownButton NewButton;
        private System.Windows.Forms.ToolStripMenuItem NewInstructionButton;
        private System.Windows.Forms.ToolStripMenuItem NewSymbolButton;
        private System.Windows.Forms.ToolStripComboBox LaunchStateSelector;
        private System.Windows.Forms.ToolStripLabel LaunchStateLabel;
        private System.Windows.Forms.ToolStripDropDownButton DeleteButton;
        private System.Windows.Forms.ToolStripMenuItem DeleteInstructionButton;
        private System.Windows.Forms.ToolStripMenuItem DeleteSymbolButton;
        private System.Windows.Forms.ToolStripMenuItem ExportToJSONMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog LoadStateDialog;
        private System.Windows.Forms.SaveFileDialog SaveStateDialog;
        private System.Windows.Forms.SaveFileDialog JSONSaveDialog;
    }
}

