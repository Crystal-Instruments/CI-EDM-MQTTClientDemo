namespace sparkplugDemo
{
    partial class SparkplugForm
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
            this.tabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnect = new DevComponents.DotNetBar.ButtonX();
            this.btnDisconnect = new DevComponents.DotNetBar.ButtonX();
            this.btnRun = new DevComponents.DotNetBar.ButtonX();
            this.btnPause = new DevComponents.DotNetBar.ButtonX();
            this.btnStop = new DevComponents.DotNetBar.ButtonX();
            this.btnContinue = new DevComponents.DotNetBar.ButtonX();
            this.btnStartRecord = new DevComponents.DotNetBar.ButtonX();
            this.btnStopRecord = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveSignals = new DevComponents.DotNetBar.ButtonX();
            this.btnStartTestSequence = new DevComponents.DotNetBar.ButtonX();
            this.btnNextTestSequence = new DevComponents.DotNetBar.ButtonX();
            this.btnPauseTestSequence = new DevComponents.DotNetBar.ButtonX();
            this.btnResumeTestSequence = new DevComponents.DotNetBar.ButtonX();
            this.btnStopTestSequence = new DevComponents.DotNetBar.ButtonX();
            this.btnChangeEdgeNode = new DevComponents.DotNetBar.ButtonX();
            this.tbCommand = new DevComponents.DotNetBar.SuperTabItem();
            this.tbTest = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx7 = new DevComponents.DotNetBar.PanelEx();
            this.tlpClientSetting = new System.Windows.Forms.TableLayoutPanel();
            this.tbClientId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.ipAddressInput1 = new DevComponents.Editors.IpAddressInput();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.iiPort = new DevComponents.Editors.IntegerInput();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.tbUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX22 = new DevComponents.DotNetBar.LabelX();
            this.lblScadaId = new DevComponents.DotNetBar.LabelX();
            this.lblGroupId = new DevComponents.DotNetBar.LabelX();
            this.tbGroupId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbScadaId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbEdgeNodeId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblEdgeNodeId = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnConnectClient = new DevComponents.DotNetBar.ButtonX();
            this.btnDisconnectClient = new DevComponents.DotNetBar.ButtonX();
            this.tbClientSettings = new DevComponents.DotNetBar.SuperTabItem();
            this.tbParameters = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.panelEx7.SuspendLayout();
            this.tlpClientSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iiPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tabControl1.ControlBox.MenuBox.Name = "";
            this.tabControl1.ControlBox.Name = "";
            this.tabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabControl1.ControlBox.MenuBox,
            this.tabControl1.ControlBox.CloseBox});
            this.tabControl1.Controls.Add(this.superTabControlPanel2);
            this.tabControl1.Controls.Add(this.superTabControlPanel1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.ReorderTabsEnabled = true;
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1064, 837);
            this.tabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbClientSettings,
            this.tbTest});
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.superTabControl1);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1064, 812);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tbTest;
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel3);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(1064, 812);
            this.superTabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.TabIndex = 17;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbCommand});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.tableLayoutPanel1);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(1064, 787);
            this.superTabControlPanel3.TabIndex = 1;
            this.superTabControlPanel3.TabItem = this.tbCommand;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.Controls.Add(this.btnConnect, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDisconnect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRun, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPause, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnContinue, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStartRecord, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStopRecord, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveSignals, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStartTestSequence, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnNextTestSequence, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnPauseTestSequence, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnResumeTestSequence, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnStopTestSequence, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnChangeEdgeNode, 0, 19);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 20;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 787);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.Location = new System.Drawing.Point(3, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(171, 33);
            this.btnConnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDisconnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDisconnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisconnect.Location = new System.Drawing.Point(180, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(171, 33);
            this.btnDisconnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            // 
            // btnRun
            // 
            this.btnRun.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRun.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRun.Location = new System.Drawing.Point(3, 42);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(171, 33);
            this.btnRun.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            // 
            // btnPause
            // 
            this.btnPause.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPause.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPause.Location = new System.Drawing.Point(180, 42);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(171, 33);
            this.btnPause.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            // 
            // btnStop
            // 
            this.btnStop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(534, 42);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(171, 33);
            this.btnStop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            // 
            // btnContinue
            // 
            this.btnContinue.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnContinue.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnContinue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnContinue.Location = new System.Drawing.Point(357, 42);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(171, 33);
            this.btnContinue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnContinue.TabIndex = 8;
            this.btnContinue.Text = "Continue";
            // 
            // btnStartRecord
            // 
            this.btnStartRecord.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartRecord.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStartRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartRecord.Location = new System.Drawing.Point(3, 81);
            this.btnStartRecord.Name = "btnStartRecord";
            this.btnStartRecord.Size = new System.Drawing.Size(171, 33);
            this.btnStartRecord.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStartRecord.TabIndex = 9;
            this.btnStartRecord.Text = "Start Record";
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStopRecord.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStopRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopRecord.Location = new System.Drawing.Point(180, 81);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(171, 33);
            this.btnStopRecord.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStopRecord.TabIndex = 10;
            this.btnStopRecord.Text = "Stop Record";
            // 
            // btnSaveSignals
            // 
            this.btnSaveSignals.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveSignals.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveSignals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveSignals.Location = new System.Drawing.Point(357, 81);
            this.btnSaveSignals.Name = "btnSaveSignals";
            this.btnSaveSignals.Size = new System.Drawing.Size(171, 33);
            this.btnSaveSignals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSaveSignals.TabIndex = 11;
            this.btnSaveSignals.Text = "Save Signals";
            // 
            // btnStartTestSequence
            // 
            this.btnStartTestSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartTestSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStartTestSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartTestSequence.Location = new System.Drawing.Point(3, 120);
            this.btnStartTestSequence.Name = "btnStartTestSequence";
            this.btnStartTestSequence.Size = new System.Drawing.Size(171, 33);
            this.btnStartTestSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStartTestSequence.TabIndex = 13;
            this.btnStartTestSequence.Text = "Start Test Sequence";
            // 
            // btnNextTestSequence
            // 
            this.btnNextTestSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNextTestSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNextTestSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextTestSequence.Location = new System.Drawing.Point(180, 120);
            this.btnNextTestSequence.Name = "btnNextTestSequence";
            this.btnNextTestSequence.Size = new System.Drawing.Size(171, 33);
            this.btnNextTestSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNextTestSequence.TabIndex = 12;
            this.btnNextTestSequence.Text = "Next Test Sequence";
            // 
            // btnPauseTestSequence
            // 
            this.btnPauseTestSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPauseTestSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPauseTestSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPauseTestSequence.Location = new System.Drawing.Point(357, 120);
            this.btnPauseTestSequence.Name = "btnPauseTestSequence";
            this.btnPauseTestSequence.Size = new System.Drawing.Size(171, 33);
            this.btnPauseTestSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPauseTestSequence.TabIndex = 14;
            this.btnPauseTestSequence.Text = "Pause Test Sequence";
            // 
            // btnResumeTestSequence
            // 
            this.btnResumeTestSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnResumeTestSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnResumeTestSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResumeTestSequence.Location = new System.Drawing.Point(534, 120);
            this.btnResumeTestSequence.Name = "btnResumeTestSequence";
            this.btnResumeTestSequence.Size = new System.Drawing.Size(171, 33);
            this.btnResumeTestSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnResumeTestSequence.TabIndex = 15;
            this.btnResumeTestSequence.Text = "Resume Test Sequence";
            // 
            // btnStopTestSequence
            // 
            this.btnStopTestSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStopTestSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStopTestSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopTestSequence.Location = new System.Drawing.Point(711, 120);
            this.btnStopTestSequence.Name = "btnStopTestSequence";
            this.btnStopTestSequence.Size = new System.Drawing.Size(171, 33);
            this.btnStopTestSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStopTestSequence.TabIndex = 16;
            this.btnStopTestSequence.Text = "Stop Test Sequence";
            // 
            // btnChangeEdgeNode
            // 
            this.btnChangeEdgeNode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChangeEdgeNode.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChangeEdgeNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeEdgeNode.Location = new System.Drawing.Point(3, 744);
            this.btnChangeEdgeNode.Name = "btnChangeEdgeNode";
            this.btnChangeEdgeNode.Size = new System.Drawing.Size(171, 40);
            this.btnChangeEdgeNode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChangeEdgeNode.TabIndex = 17;
            this.btnChangeEdgeNode.Text = "Change Edge Node";
            // 
            // tbCommand
            // 
            this.tbCommand.AttachedControl = this.superTabControlPanel3;
            this.tbCommand.GlobalItem = false;
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Text = "Command";
            // 
            // tbTest
            // 
            this.tbTest.AttachedControl = this.superTabControlPanel2;
            this.tbTest.GlobalItem = false;
            this.tbTest.Name = "tbTest";
            this.tbTest.Text = "Test";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.panelEx7);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1064, 812);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.tbClientSettings;
            // 
            // panelEx7
            // 
            this.panelEx7.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx7.Controls.Add(this.tlpClientSetting);
            this.panelEx7.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx7.Location = new System.Drawing.Point(0, 0);
            this.panelEx7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelEx7.Name = "panelEx7";
            this.panelEx7.Size = new System.Drawing.Size(1064, 812);
            this.panelEx7.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx7.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx7.Style.GradientAngle = 90;
            this.panelEx7.TabIndex = 2;
            // 
            // tlpClientSetting
            // 
            this.tlpClientSetting.ColumnCount = 4;
            this.tlpClientSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpClientSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpClientSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpClientSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientSetting.Controls.Add(this.tbClientId, 1, 10);
            this.tlpClientSetting.Controls.Add(this.labelX16, 0, 2);
            this.tlpClientSetting.Controls.Add(this.ipAddressInput1, 1, 0);
            this.tlpClientSetting.Controls.Add(this.labelX18, 0, 4);
            this.tlpClientSetting.Controls.Add(this.iiPort, 1, 2);
            this.tlpClientSetting.Controls.Add(this.labelX19, 0, 5);
            this.tlpClientSetting.Controls.Add(this.tbUser, 1, 4);
            this.tlpClientSetting.Controls.Add(this.tbPassword, 1, 5);
            this.tlpClientSetting.Controls.Add(this.labelX22, 0, 10);
            this.tlpClientSetting.Controls.Add(this.lblScadaId, 0, 13);
            this.tlpClientSetting.Controls.Add(this.lblGroupId, 0, 14);
            this.tlpClientSetting.Controls.Add(this.tbGroupId, 1, 14);
            this.tlpClientSetting.Controls.Add(this.tbScadaId, 1, 13);
            this.tlpClientSetting.Controls.Add(this.tbEdgeNodeId, 1, 15);
            this.tlpClientSetting.Controls.Add(this.labelX1, 0, 0);
            this.tlpClientSetting.Controls.Add(this.lblEdgeNodeId, 0, 15);
            this.tlpClientSetting.Controls.Add(this.checkBoxX1, 0, 17);
            this.tlpClientSetting.Controls.Add(this.btnConnectClient, 0, 16);
            this.tlpClientSetting.Controls.Add(this.btnDisconnectClient, 1, 16);
            this.tlpClientSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpClientSetting.Location = new System.Drawing.Point(0, 0);
            this.tlpClientSetting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpClientSetting.Name = "tlpClientSetting";
            this.tlpClientSetting.RowCount = 18;
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpClientSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 503F));
            this.tlpClientSetting.Size = new System.Drawing.Size(1064, 812);
            this.tlpClientSetting.TabIndex = 1;
            // 
            // tbClientId
            // 
            // 
            // 
            // 
            this.tbClientId.Border.Class = "TextBoxBorder";
            this.tbClientId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tlpClientSetting.SetColumnSpan(this.tbClientId, 3);
            this.tbClientId.Location = new System.Drawing.Point(162, 124);
            this.tbClientId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbClientId.Name = "tbClientId";
            this.tbClientId.PreventEnterBeep = true;
            this.tbClientId.Size = new System.Drawing.Size(279, 20);
            this.tbClientId.TabIndex = 11;
            this.tbClientId.Text = "SparkplugDemo";
            this.tbClientId.Visible = false;
            // 
            // labelX16
            // 
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelX16.Location = new System.Drawing.Point(4, 36);
            this.labelX16.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(150, 27);
            this.labelX16.TabIndex = 2;
            this.labelX16.Text = "Broker port";
            // 
            // ipAddressInput1
            // 
            this.ipAddressInput1.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAddressInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAddressInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAddressInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAddressInput1.Location = new System.Drawing.Point(162, 3);
            this.ipAddressInput1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ipAddressInput1.Name = "ipAddressInput1";
            this.ipAddressInput1.Size = new System.Drawing.Size(157, 20);
            this.ipAddressInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInput1.TabIndex = 0;
            this.ipAddressInput1.Value = "192.168.1.19";
            // 
            // labelX18
            // 
            this.labelX18.AutoSize = true;
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelX18.Location = new System.Drawing.Point(4, 69);
            this.labelX18.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(62, 18);
            this.labelX18.TabIndex = 4;
            this.labelX18.Text = "User name";
            // 
            // iiPort
            // 
            // 
            // 
            // 
            this.iiPort.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiPort.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiPort.Location = new System.Drawing.Point(162, 36);
            this.iiPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.iiPort.MinValue = 1;
            this.iiPort.Name = "iiPort";
            this.iiPort.ShowUpDown = true;
            this.iiPort.Size = new System.Drawing.Size(156, 20);
            this.iiPort.TabIndex = 3;
            this.iiPort.Value = 1883;
            // 
            // labelX19
            // 
            this.labelX19.AutoSize = true;
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelX19.Location = new System.Drawing.Point(4, 95);
            this.labelX19.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(56, 18);
            this.labelX19.TabIndex = 5;
            this.labelX19.Text = "Password";
            // 
            // tbUser
            // 
            // 
            // 
            // 
            this.tbUser.Border.Class = "TextBoxBorder";
            this.tbUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbUser.Location = new System.Drawing.Point(162, 69);
            this.tbUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbUser.Name = "tbUser";
            this.tbUser.PreventEnterBeep = true;
            this.tbUser.Size = new System.Drawing.Size(156, 20);
            this.tbUser.TabIndex = 5;
            this.tbUser.Text = "Admin";
            // 
            // tbPassword
            // 
            // 
            // 
            // 
            this.tbPassword.Border.Class = "TextBoxBorder";
            this.tbPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPassword.Location = new System.Drawing.Point(162, 95);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.PreventEnterBeep = true;
            this.tbPassword.Size = new System.Drawing.Size(156, 23);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.Text = "123456";
            // 
            // labelX22
            // 
            this.labelX22.AutoSize = true;
            // 
            // 
            // 
            this.labelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelX22.Location = new System.Drawing.Point(4, 124);
            this.labelX22.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX22.Name = "labelX22";
            this.labelX22.Size = new System.Drawing.Size(51, 18);
            this.labelX22.TabIndex = 5;
            this.labelX22.Text = "Client ID";
            this.labelX22.Visible = false;
            // 
            // lblScadaId
            // 
            // 
            // 
            // 
            this.lblScadaId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblScadaId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblScadaId.Location = new System.Drawing.Point(4, 150);
            this.lblScadaId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblScadaId.Name = "lblScadaId";
            this.lblScadaId.Size = new System.Drawing.Size(88, 21);
            this.lblScadaId.TabIndex = 20;
            this.lblScadaId.Text = "Scada Host ID";
            // 
            // lblGroupId
            // 
            // 
            // 
            // 
            this.lblGroupId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGroupId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupId.Location = new System.Drawing.Point(4, 188);
            this.lblGroupId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblGroupId.Name = "lblGroupId";
            this.lblGroupId.Size = new System.Drawing.Size(150, 25);
            this.lblGroupId.TabIndex = 22;
            this.lblGroupId.Text = "Group Identifier";
            // 
            // tbGroupId
            // 
            // 
            // 
            // 
            this.tbGroupId.Border.Class = "TextBoxBorder";
            this.tbGroupId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbGroupId.Location = new System.Drawing.Point(162, 188);
            this.tbGroupId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbGroupId.Name = "tbGroupId";
            this.tbGroupId.PreventEnterBeep = true;
            this.tbGroupId.Size = new System.Drawing.Size(156, 20);
            this.tbGroupId.TabIndex = 23;
            this.tbGroupId.Text = "EDM";
            // 
            // tbScadaId
            // 
            // 
            // 
            // 
            this.tbScadaId.Border.Class = "TextBoxBorder";
            this.tbScadaId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbScadaId.Location = new System.Drawing.Point(162, 150);
            this.tbScadaId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbScadaId.Name = "tbScadaId";
            this.tbScadaId.PreventEnterBeep = true;
            this.tbScadaId.Size = new System.Drawing.Size(156, 20);
            this.tbScadaId.TabIndex = 24;
            this.tbScadaId.Text = "Scada2";
            // 
            // tbEdgeNodeId
            // 
            // 
            // 
            // 
            this.tbEdgeNodeId.Border.Class = "TextBoxBorder";
            this.tbEdgeNodeId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEdgeNodeId.Location = new System.Drawing.Point(162, 227);
            this.tbEdgeNodeId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbEdgeNodeId.Name = "tbEdgeNodeId";
            this.tbEdgeNodeId.PreventEnterBeep = true;
            this.tbEdgeNodeId.Size = new System.Drawing.Size(156, 20);
            this.tbEdgeNodeId.TabIndex = 26;
            this.tbEdgeNodeId.Text = "EdgeNode2";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelX1.Location = new System.Drawing.Point(4, 3);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(150, 27);
            this.labelX1.TabIndex = 27;
            this.labelX1.Text = "Broker IP";
            // 
            // lblEdgeNodeId
            // 
            // 
            // 
            // 
            this.lblEdgeNodeId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEdgeNodeId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEdgeNodeId.Location = new System.Drawing.Point(4, 227);
            this.lblEdgeNodeId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblEdgeNodeId.Name = "lblEdgeNodeId";
            this.lblEdgeNodeId.Size = new System.Drawing.Size(150, 19);
            this.lblEdgeNodeId.TabIndex = 25;
            this.lblEdgeNodeId.Text = "Edge Node ID";
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.checkBoxX1.Location = new System.Drawing.Point(4, 312);
            this.checkBoxX1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(0, 0);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 14;
            // 
            // btnConnectClient
            // 
            this.btnConnectClient.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConnectClient.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConnectClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectClient.Location = new System.Drawing.Point(3, 269);
            this.btnConnectClient.Name = "btnConnectClient";
            this.btnConnectClient.Size = new System.Drawing.Size(152, 37);
            this.btnConnectClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConnectClient.TabIndex = 28;
            this.btnConnectClient.Text = "Connect";
            this.btnConnectClient.Click += new System.EventHandler(this.btnConnectClient_Click);
            // 
            // btnDisconnectClient
            // 
            this.btnDisconnectClient.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDisconnectClient.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDisconnectClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisconnectClient.Location = new System.Drawing.Point(161, 269);
            this.btnDisconnectClient.Name = "btnDisconnectClient";
            this.btnDisconnectClient.Size = new System.Drawing.Size(159, 37);
            this.btnDisconnectClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDisconnectClient.TabIndex = 29;
            this.btnDisconnectClient.Text = "Disconnect";
            this.btnDisconnectClient.Click += new System.EventHandler(this.btnDisonnectClient_Click);
            // 
            // tbClientSettings
            // 
            this.tbClientSettings.AttachedControl = this.superTabControlPanel1;
            this.tbClientSettings.GlobalItem = false;
            this.tbClientSettings.Name = "tbClientSettings";
            this.tbClientSettings.Text = "Sparkplug";
            // 
            // tbParameters
            // 
            this.tbParameters.GlobalItem = false;
            this.tbParameters.Name = "tbParameters";
            this.tbParameters.Text = "Global Parameters";
            // 
            // SparkplugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 837);
            this.Controls.Add(this.tabControl1);
            this.Name = "SparkplugForm";
            this.Text = "MQTT Sparkplug Demo";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.panelEx7.ResumeLayout(false);
            this.tlpClientSetting.ResumeLayout(false);
            this.tlpClientSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iiPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl tabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tbClientSettings;
        private DevComponents.DotNetBar.PanelEx panelEx7;
        private System.Windows.Forms.TableLayoutPanel tlpClientSetting;
        private DevComponents.DotNetBar.Controls.TextBoxX tbClientId;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.Editors.IpAddressInput ipAddressInput1;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.Editors.IntegerInput iiPort;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.Controls.TextBoxX tbUser;
        private DevComponents.DotNetBar.Controls.TextBoxX tbPassword;
        private DevComponents.DotNetBar.LabelX labelX22;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.LabelX lblScadaId;
        private DevComponents.DotNetBar.LabelX lblGroupId;
        private DevComponents.DotNetBar.Controls.TextBoxX tbGroupId;
        private DevComponents.DotNetBar.Controls.TextBoxX tbScadaId;
        private DevComponents.DotNetBar.LabelX lblEdgeNodeId;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEdgeNodeId;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.ButtonX btnConnect;
        private DevComponents.DotNetBar.SuperTabItem tbTest;
        private DevComponents.DotNetBar.ButtonX btnPause;
        private DevComponents.DotNetBar.ButtonX btnRun;
        private DevComponents.DotNetBar.ButtonX btnDisconnect;
        private DevComponents.DotNetBar.ButtonX btnStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX btnConnectClient;
        private DevComponents.DotNetBar.ButtonX btnDisconnectClient;
        private DevComponents.DotNetBar.ButtonX btnContinue;
        private DevComponents.DotNetBar.ButtonX btnStartRecord;
        private DevComponents.DotNetBar.ButtonX btnStopRecord;
        private DevComponents.DotNetBar.ButtonX btnSaveSignals;
        private DevComponents.DotNetBar.ButtonX btnNextTestSequence;
        private DevComponents.DotNetBar.ButtonX btnPauseTestSequence;
        private DevComponents.DotNetBar.ButtonX btnStartTestSequence;
        private DevComponents.DotNetBar.ButtonX btnResumeTestSequence;
        private DevComponents.DotNetBar.ButtonX btnStopTestSequence;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem tbCommand;
        private DevComponents.DotNetBar.SuperTabItem tbParameters;
        private DevComponents.DotNetBar.ButtonX btnChangeEdgeNode;
    }
}