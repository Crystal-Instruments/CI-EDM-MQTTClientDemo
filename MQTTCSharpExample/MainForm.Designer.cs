namespace MQTTCSharpExample
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
            this.tabControlDemo = new System.Windows.Forms.TabControl();
            this.tabPageMQTT = new System.Windows.Forms.TabPage();
            this.flpConnection = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.tlpConnection = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBrokerPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBrokerIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCommunicationTimeout = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbxProtocol = new System.Windows.Forms.ComboBox();
            this.nudKeepAliveInterval = new System.Windows.Forms.NumericUpDown();
            this.cbClearSession = new System.Windows.Forms.CheckBox();
            this.tbClientID = new System.Windows.Forms.TextBox();
            this.tbTopicPrefix = new System.Windows.Forms.TextBox();
            this.cbxTLS = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.selectIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.tbCACertificateFile = new System.Windows.Forms.TextBox();
            this.tbClientCertificateFile = new System.Windows.Forms.TextBox();
            this.tbClientPrivateKeyFile = new System.Windows.Forms.TextBox();
            this.btnBrowseCACertificateFile = new System.Windows.Forms.Button();
            this.btnBrowseClientCertificateFile = new System.Windows.Forms.Button();
            this.btnBrowseClientPrivateKeyFile = new System.Windows.Forms.Button();
            this.tabPageSystem = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.lvSystem = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.tabPageTest = new System.Windows.Forms.TabPage();
            this.tabControlTest = new System.Windows.Forms.TabControl();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblLimitStatus = new System.Windows.Forms.Label();
            this.lblLimitTest = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblRecordStatus = new System.Windows.Forms.Label();
            this.lblRecordName = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblControlFlagTest = new System.Windows.Forms.Label();
            this.lblControlFlag = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblStageTest = new System.Windows.Forms.Label();
            this.lblStage = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTestName = new System.Windows.Forms.Label();
            this.lblTestType = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblRunFolder = new System.Windows.Forms.Label();
            this.lblMeasureStartAt = new System.Windows.Forms.Label();
            this.tabPageTestCommand = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.btnSetLevel = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.nudFrequency = new System.Windows.Forms.NumericUpDown();
            this.btnSetFrequency = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.button44 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.rbVCSCommand = new System.Windows.Forms.RadioButton();
            this.rbDSACommand = new System.Windows.Forms.RadioButton();
            this.button38 = new System.Windows.Forms.Button();
            this.nudPhase = new System.Windows.Forms.NumericUpDown();
            this.btnSetPhase = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.btnSORTonesHold = new System.Windows.Forms.Button();
            this.btnSORTonesRelease = new System.Windows.Forms.Button();
            this.btnSORTonesSweepUp = new System.Windows.Forms.Button();
            this.btnSORTonesSweepDown = new System.Windows.Forms.Button();
            this.tbRoRBands = new System.Windows.Forms.TextBox();
            this.rorBandFlag = new System.Windows.Forms.CheckBox();
            this.btnRoRBandsOn = new System.Windows.Forms.Button();
            this.btnRoRBandsOff = new System.Windows.Forms.Button();
            this.tbSoRTones = new System.Windows.Forms.TextBox();
            this.sorBandFlag = new System.Windows.Forms.CheckBox();
            this.btnSORTonesOn = new System.Windows.Forms.Button();
            this.btnSORTonesOff = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button47 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.button46 = new System.Windows.Forms.Button();
            this.button52 = new System.Windows.Forms.Button();
            this.btnShutdownPC = new System.Windows.Forms.Button();
            this.nudShutdownPCDelay = new System.Windows.Forms.NumericUpDown();
            this.label78 = new System.Windows.Forms.Label();
            this.tabPageAdvTestCommand = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.tbRandomProfilePath = new System.Windows.Forms.TextBox();
            this.tbSineProfilePath = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.tbShockProfilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseRandomProfile = new System.Windows.Forms.Button();
            this.btnBrowseSineProfile = new System.Windows.Forms.Button();
            this.btnBrowseShockProfile = new System.Windows.Forms.Button();
            this.btnSetRandomProfile = new System.Windows.Forms.Button();
            this.btnSetSineProfile = new System.Windows.Forms.Button();
            this.btnSetShockProfile = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.tbChannelTablePath = new System.Windows.Forms.TextBox();
            this.btnBrowseChannelTable = new System.Windows.Forms.Button();
            this.btnSetChannelTable = new System.Windows.Forms.Button();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.tbSchedulePath = new System.Windows.Forms.TextBox();
            this.btnBrowseSchedule = new System.Windows.Forms.Button();
            this.btnSetSchedule = new System.Windows.Forms.Button();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbNTPServer = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.nudNTPPort = new System.Windows.Forms.NumericUpDown();
            this.label84 = new System.Windows.Forms.Label();
            this.nudNTPSynchInterval = new System.Windows.Forms.NumericUpDown();
            this.label85 = new System.Windows.Forms.Label();
            this.btnSetNTP = new System.Windows.Forms.Button();
            this.tabPageDetailStatus = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.button18 = new System.Windows.Forms.Button();
            this.lvDetailStatus = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageChannels = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.lvChannelTable = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
            this.label79 = new System.Windows.Forms.Label();
            this.cbxInputRange = new System.Windows.Forms.ComboBox();
            this.label82 = new System.Windows.Forms.Label();
            this.nudChannelIndex = new System.Windows.Forms.NumericUpDown();
            this.btnSetInputRange = new System.Windows.Forms.Button();
            this.tabPageChannelStatus = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.lvChannelStatus = new System.Windows.Forms.ListView();
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader57 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader58 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader59 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button49 = new System.Windows.Forms.Button();
            this.tabPageParameters = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tbParameterValue = new System.Windows.Forms.TextBox();
            this.lvParameters = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblParameterName = new System.Windows.Forms.Label();
            this.btnSetParameter = new System.Windows.Forms.Button();
            this.btnListParameter = new System.Windows.Forms.Button();
            this.tabShaker = new System.Windows.Forms.TabPage();
            this.lvShaker = new System.Windows.Forms.ListView();
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageTestManager = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lvTests = new System.Windows.Forms.ListView();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button29 = new System.Windows.Forms.Button();
            this.btnLoadTest = new System.Windows.Forms.Button();
            this.btnDeleteTest = new System.Windows.Forms.Button();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tbCreateTestName = new System.Windows.Forms.TextBox();
            this.btnCreatTest = new System.Windows.Forms.Button();
            this.cbxCreateTestType = new System.Windows.Forms.ComboBox();
            this.tabPageTHStatus = new System.Windows.Forms.TabPage();
            this.lvTHStatus = new System.Windows.Forms.ListView();
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageOutput = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbOutputSine = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.nudSineAmp = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.nudSineFreq = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.nudSineOffset = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbOutputTriangle = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.nudTriangleAmp = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.nudTriangleFreq = new System.Windows.Forms.NumericUpDown();
            this.nudOutputIndex = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbOutputSquare = new System.Windows.Forms.CheckBox();
            this.label38 = new System.Windows.Forms.Label();
            this.nudSquareAmp = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.nudSquareFreq = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbOutputWhiteNoise = new System.Windows.Forms.CheckBox();
            this.label40 = new System.Windows.Forms.Label();
            this.nudWhiteNoiseRMS = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbOutputPinkNoise = new System.Windows.Forms.CheckBox();
            this.label41 = new System.Windows.Forms.Label();
            this.nudPinkNoiseRMS = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbOutputDC = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.nudDCAmp = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbOutputChirp = new System.Windows.Forms.CheckBox();
            this.label43 = new System.Windows.Forms.Label();
            this.nudChirpAmp = new System.Windows.Forms.NumericUpDown();
            this.label44 = new System.Windows.Forms.Label();
            this.nudChirpLowFreq = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.nudChirpHighFreq = new System.Windows.Forms.NumericUpDown();
            this.label46 = new System.Windows.Forms.Label();
            this.nudChirpPercent = new System.Windows.Forms.NumericUpDown();
            this.label47 = new System.Windows.Forms.Label();
            this.nudChirpPeriod = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbOutputSweptSine = new System.Windows.Forms.CheckBox();
            this.label48 = new System.Windows.Forms.Label();
            this.nudSweptSineAmp = new System.Windows.Forms.NumericUpDown();
            this.label49 = new System.Windows.Forms.Label();
            this.nudSweptSineLowFreq = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.nudSweptSineHighFreq = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.nudSweptSinePeriod = new System.Windows.Forms.NumericUpDown();
            this.btnSetOutputParameters = new System.Windows.Forms.Button();
            this.button50 = new System.Windows.Forms.Button();
            this.button51 = new System.Windows.Forms.Button();
            this.btnSetOutputIndex = new System.Windows.Forms.Button();
            this.label52 = new System.Windows.Forms.Label();
            this.tabPageGlobalParameters = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.btnListGlobalParameters = new System.Windows.Forms.Button();
            this.btnGetGlobalParameter = new System.Windows.Forms.Button();
            this.listViewGlobalParameters = new System.Windows.Forms.ListView();
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtbGlobalParameter = new System.Windows.Forms.RichTextBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnCopyGlobalParameter = new System.Windows.Forms.Button();
            this.tabPageSignal = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.lvSignals = new System.Windows.Forms.ListView();
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart = new ZedGraph.ZedGraphControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbRMS = new System.Windows.Forms.CheckBox();
            this.cbPeak = new System.Windows.Forms.CheckBox();
            this.cbPkPk = new System.Windows.Forms.CheckBox();
            this.cbMin = new System.Windows.Forms.CheckBox();
            this.cbMax = new System.Windows.Forms.CheckBox();
            this.cbMean = new System.Windows.Forms.CheckBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectInverse = new System.Windows.Forms.Button();
            this.lvSignalProperty = new System.Windows.Forms.ListView();
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGetSignalProperty = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportFreqVsPeak = new System.Windows.Forms.Button();
            this.ckbAutoRefresh = new System.Windows.Forms.CheckBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.ckbPFFV = new System.Windows.Forms.CheckBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.tbPeakFreqSource = new System.Windows.Forms.TextBox();
            this.tbPeakValueSource = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.tbPeakFreqValue = new System.Windows.Forms.TextBox();
            this.tbPeakValue = new System.Windows.Forms.TextBox();
            this.lblPeakFreqUnit = new System.Windows.Forms.Label();
            this.lblPeakValueUnit = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.nudTimestampMatchOffset = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewFreqVsPeak = new System.Windows.Forms.DataGridView();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.btnRefreshFreqVsPeak = new System.Windows.Forms.Button();
            this.btnResetFreqVsPeak = new System.Windows.Forms.Button();
            this.ckbExcludedB = new System.Windows.Forms.CheckBox();
            this.tabPageReport = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.lvReportNotes = new System.Windows.Forms.ListView();
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvReportFile = new System.Windows.Forms.ListView();
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbReportDir = new System.Windows.Forms.TextBox();
            this.btnBrowseReportDir = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.cbxReportTemplates = new System.Windows.Forms.ComboBox();
            this.label70 = new System.Windows.Forms.Label();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.button53 = new System.Windows.Forms.Button();
            this.btnSetReportNotes = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.label72 = new System.Windows.Forms.Label();
            this.tbReportNoteName = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.tbReportNoteContent = new System.Windows.Forms.TextBox();
            this.btnUpdateReportNote = new System.Windows.Forms.Button();
            this.btnAddReportNote = new System.Windows.Forms.Button();
            this.btnDeleteReportNote = new System.Windows.Forms.Button();
            this.label74 = new System.Windows.Forms.Label();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button30 = new System.Windows.Forms.Button();
            this.btnGetRecordFile = new System.Windows.Forms.Button();
            this.lblRunFolderInfo = new System.Windows.Forms.Label();
            this.tbFileDir = new System.Windows.Forms.TextBox();
            this.btnBrowseFileDir = new System.Windows.Forms.Button();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btnPublishMessage = new System.Windows.Forms.Button();
            this.tbMessages = new System.Windows.Forms.Label();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblNTPTime = new System.Windows.Forms.Label();
            this.tabControlDemo.SuspendLayout();
            this.tabPageMQTT.SuspendLayout();
            this.flpConnection.SuspendLayout();
            this.tlpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrokerPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCommunicationTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepAliveInterval)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabPageSystem.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageTest.SuspendLayout();
            this.tabControlTest.SuspendLayout();
            this.tabPageStatus.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPageTestCommand.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhase)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShutdownPCDelay)).BeginInit();
            this.tabPageAdvTestCommand.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.flowLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNTPPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNTPSynchInterval)).BeginInit();
            this.tabPageDetailStatus.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tabPageChannels.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.flowLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChannelIndex)).BeginInit();
            this.tabPageChannelStatus.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.tabPageParameters.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tabShaker.SuspendLayout();
            this.tabPageTestManager.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tabPageTHStatus.SuspendLayout();
            this.tabPageOutput.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSineAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSineFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSineOffset)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTriangleAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTriangleFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputIndex)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSquareAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSquareFreq)).BeginInit();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWhiteNoiseRMS)).BeginInit();
            this.flowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinkNoiseRMS)).BeginInit();
            this.flowLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDCAmp)).BeginInit();
            this.flowLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpLowFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpHighFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpPeriod)).BeginInit();
            this.flowLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweptSineAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweptSineLowFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweptSineHighFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweptSinePeriod)).BeginInit();
            this.tabPageGlobalParameters.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPageSignal.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimestampMatchOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreqVsPeak)).BeginInit();
            this.tabPageReport.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.flowLayoutPanel11.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlDemo
            // 
            this.tabControlDemo.Controls.Add(this.tabPageMQTT);
            this.tabControlDemo.Controls.Add(this.tabPageSystem);
            this.tabControlDemo.Controls.Add(this.tabPageTest);
            this.tabControlDemo.Controls.Add(this.tabPageSignal);
            this.tabControlDemo.Controls.Add(this.tabPageReport);
            this.tabControlDemo.Controls.Add(this.tabPageFile);
            this.tabControlDemo.Controls.Add(this.tabPageLog);
            this.tabControlDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDemo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlDemo.Location = new System.Drawing.Point(0, 0);
            this.tabControlDemo.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlDemo.Multiline = true;
            this.tabControlDemo.Name = "tabControlDemo";
            this.tabControlDemo.SelectedIndex = 0;
            this.tabControlDemo.Size = new System.Drawing.Size(1186, 805);
            this.tabControlDemo.TabIndex = 0;
            // 
            // tabPageMQTT
            // 
            this.tabPageMQTT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageMQTT.Controls.Add(this.flpConnection);
            this.tabPageMQTT.Controls.Add(this.tlpConnection);
            this.tabPageMQTT.Location = new System.Drawing.Point(4, 24);
            this.tabPageMQTT.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMQTT.Name = "tabPageMQTT";
            this.tabPageMQTT.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMQTT.Size = new System.Drawing.Size(1178, 777);
            this.tabPageMQTT.TabIndex = 0;
            this.tabPageMQTT.Text = "MQTT";
            this.tabPageMQTT.UseVisualStyleBackColor = true;
            // 
            // flpConnection
            // 
            this.flpConnection.BackColor = System.Drawing.SystemColors.Window;
            this.flpConnection.Controls.Add(this.btnConnect);
            this.flpConnection.Controls.Add(this.btnDisconnect);
            this.flpConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpConnection.Location = new System.Drawing.Point(4, 464);
            this.flpConnection.Margin = new System.Windows.Forms.Padding(0);
            this.flpConnection.Name = "flpConnection";
            this.flpConnection.Size = new System.Drawing.Size(1168, 307);
            this.flpConnection.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.Green;
            this.btnConnect.Location = new System.Drawing.Point(4, 4);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(169, 50);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.OnConnectClick);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.ForeColor = System.Drawing.Color.Red;
            this.btnDisconnect.Location = new System.Drawing.Point(181, 4);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(183, 50);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.OnDisconnectClick);
            // 
            // tlpConnection
            // 
            this.tlpConnection.AutoSize = true;
            this.tlpConnection.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpConnection.ColumnCount = 4;
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 398F));
            this.tlpConnection.Controls.Add(this.label1, 0, 0);
            this.tlpConnection.Controls.Add(this.tbBrokerPort, 1, 1);
            this.tlpConnection.Controls.Add(this.label2, 0, 1);
            this.tlpConnection.Controls.Add(this.tbBrokerIP, 1, 0);
            this.tlpConnection.Controls.Add(this.label3, 0, 2);
            this.tlpConnection.Controls.Add(this.tbCommunicationTimeout, 1, 2);
            this.tlpConnection.Controls.Add(this.label4, 2, 2);
            this.tlpConnection.Controls.Add(this.label5, 0, 3);
            this.tlpConnection.Controls.Add(this.label6, 0, 4);
            this.tlpConnection.Controls.Add(this.label7, 0, 5);
            this.tlpConnection.Controls.Add(this.label8, 0, 9);
            this.tlpConnection.Controls.Add(this.label9, 0, 10);
            this.tlpConnection.Controls.Add(this.label10, 0, 11);
            this.tlpConnection.Controls.Add(this.label11, 0, 12);
            this.tlpConnection.Controls.Add(this.label12, 0, 13);
            this.tlpConnection.Controls.Add(this.tbUser, 1, 3);
            this.tlpConnection.Controls.Add(this.tbPassword, 1, 4);
            this.tlpConnection.Controls.Add(this.cbxProtocol, 1, 9);
            this.tlpConnection.Controls.Add(this.nudKeepAliveInterval, 1, 10);
            this.tlpConnection.Controls.Add(this.cbClearSession, 1, 11);
            this.tlpConnection.Controls.Add(this.tbClientID, 1, 12);
            this.tlpConnection.Controls.Add(this.tbTopicPrefix, 1, 13);
            this.tlpConnection.Controls.Add(this.cbxTLS, 1, 5);
            this.tlpConnection.Controls.Add(this.menuStrip1, 2, 0);
            this.tlpConnection.Controls.Add(this.label75, 0, 6);
            this.tlpConnection.Controls.Add(this.label76, 0, 7);
            this.tlpConnection.Controls.Add(this.label77, 0, 8);
            this.tlpConnection.Controls.Add(this.tbCACertificateFile, 1, 6);
            this.tlpConnection.Controls.Add(this.tbClientCertificateFile, 1, 7);
            this.tlpConnection.Controls.Add(this.tbClientPrivateKeyFile, 1, 8);
            this.tlpConnection.Controls.Add(this.btnBrowseCACertificateFile, 3, 6);
            this.tlpConnection.Controls.Add(this.btnBrowseClientCertificateFile, 3, 7);
            this.tlpConnection.Controls.Add(this.btnBrowseClientPrivateKeyFile, 3, 8);
            this.tlpConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpConnection.Location = new System.Drawing.Point(4, 4);
            this.tlpConnection.Margin = new System.Windows.Forms.Padding(6);
            this.tlpConnection.Name = "tlpConnection";
            this.tlpConnection.RowCount = 14;
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpConnection.Size = new System.Drawing.Size(1168, 460);
            this.tlpConnection.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broker IP";
            // 
            // tbBrokerPort
            // 
            this.tbBrokerPort.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MQTTExample.Properties.Settings.Default, "BrokerPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbBrokerPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBrokerPort.Location = new System.Drawing.Point(161, 39);
            this.tbBrokerPort.Margin = new System.Windows.Forms.Padding(4);
            this.tbBrokerPort.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.tbBrokerPort.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tbBrokerPort.Name = "tbBrokerPort";
            this.tbBrokerPort.Size = new System.Drawing.Size(206, 23);
            this.tbBrokerPort.TabIndex = 3;
            this.tbBrokerPort.Value = global::MQTTExample.Properties.Settings.Default.BrokerPort;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Broker Port";
            // 
            // tbBrokerIP
            // 
            this.tbBrokerIP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MQTTExample.Properties.Settings.Default, "BrokerIP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbBrokerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBrokerIP.Location = new System.Drawing.Point(161, 6);
            this.tbBrokerIP.Margin = new System.Windows.Forms.Padding(4);
            this.tbBrokerIP.Name = "tbBrokerIP";
            this.tbBrokerIP.Size = new System.Drawing.Size(206, 23);
            this.tbBrokerIP.TabIndex = 1;
            this.tbBrokerIP.Text = global::MQTTExample.Properties.Settings.Default.BrokerIP;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Communication Timeout";
            // 
            // tbCommunicationTimeout
            // 
            this.tbCommunicationTimeout.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MQTTExample.Properties.Settings.Default, "CommunicationTimeout", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbCommunicationTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCommunicationTimeout.Location = new System.Drawing.Point(161, 72);
            this.tbCommunicationTimeout.Margin = new System.Windows.Forms.Padding(4);
            this.tbCommunicationTimeout.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.tbCommunicationTimeout.Name = "tbCommunicationTimeout";
            this.tbCommunicationTimeout.Size = new System.Drawing.Size(206, 23);
            this.tbCommunicationTimeout.TabIndex = 3;
            this.tbCommunicationTimeout.Value = global::MQTTExample.Properties.Settings.Default.CommunicationTimeout;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "(ms)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "User Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 173);
            this.label7.Margin = new System.Windows.Forms.Padding(6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "TLS Version";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 305);
            this.label8.Margin = new System.Windows.Forms.Padding(6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Protocol Version";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 338);
            this.label9.Margin = new System.Windows.Forms.Padding(6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Keep alive interval";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 371);
            this.label10.Margin = new System.Windows.Forms.Padding(6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Clear Session";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 400);
            this.label11.Margin = new System.Windows.Forms.Padding(6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Client ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 433);
            this.label12.Margin = new System.Windows.Forms.Padding(6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Topic Prefix";
            // 
            // tbUser
            // 
            this.tbUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MQTTExample.Properties.Settings.Default, "UserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUser.Location = new System.Drawing.Point(161, 105);
            this.tbUser.Margin = new System.Windows.Forms.Padding(4);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(206, 23);
            this.tbUser.TabIndex = 1;
            this.tbUser.Text = global::MQTTExample.Properties.Settings.Default.UserName;
            // 
            // tbPassword
            // 
            this.tbPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MQTTExample.Properties.Settings.Default, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword.Location = new System.Drawing.Point(161, 138);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(206, 23);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.Text = global::MQTTExample.Properties.Settings.Default.Password;
            // 
            // cbxProtocol
            // 
            this.cbxProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProtocol.FormattingEnabled = true;
            this.cbxProtocol.Location = new System.Drawing.Point(161, 303);
            this.cbxProtocol.Margin = new System.Windows.Forms.Padding(4);
            this.cbxProtocol.Name = "cbxProtocol";
            this.cbxProtocol.Size = new System.Drawing.Size(206, 23);
            this.cbxProtocol.TabIndex = 2;
            // 
            // nudKeepAliveInterval
            // 
            this.nudKeepAliveInterval.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MQTTExample.Properties.Settings.Default, "KeepAliveTimeout", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudKeepAliveInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudKeepAliveInterval.Location = new System.Drawing.Point(161, 336);
            this.nudKeepAliveInterval.Margin = new System.Windows.Forms.Padding(4);
            this.nudKeepAliveInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudKeepAliveInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudKeepAliveInterval.Name = "nudKeepAliveInterval";
            this.nudKeepAliveInterval.Size = new System.Drawing.Size(206, 23);
            this.nudKeepAliveInterval.TabIndex = 3;
            this.nudKeepAliveInterval.Value = global::MQTTExample.Properties.Settings.Default.KeepAliveTimeout;
            // 
            // cbClearSession
            // 
            this.cbClearSession.AutoSize = true;
            this.cbClearSession.Checked = global::MQTTExample.Properties.Settings.Default.IsClearSession;
            this.cbClearSession.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MQTTExample.Properties.Settings.Default, "IsClearSession", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbClearSession.Location = new System.Drawing.Point(161, 369);
            this.cbClearSession.Margin = new System.Windows.Forms.Padding(4);
            this.cbClearSession.Name = "cbClearSession";
            this.cbClearSession.Size = new System.Drawing.Size(15, 14);
            this.cbClearSession.TabIndex = 4;
            this.cbClearSession.UseVisualStyleBackColor = true;
            // 
            // tbClientID
            // 
            this.tlpConnection.SetColumnSpan(this.tbClientID, 2);
            this.tbClientID.Location = new System.Drawing.Point(161, 398);
            this.tbClientID.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.tbClientID.Name = "tbClientID";
            this.tbClientID.Size = new System.Drawing.Size(605, 23);
            this.tbClientID.TabIndex = 1;
            this.tbClientID.Text = "EDM-MQTT-Example-Client";
            // 
            // tbTopicPrefix
            // 
            this.tbTopicPrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MQTTExample.Properties.Settings.Default, "TopicPrefix", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbTopicPrefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTopicPrefix.Location = new System.Drawing.Point(161, 431);
            this.tbTopicPrefix.Margin = new System.Windows.Forms.Padding(4);
            this.tbTopicPrefix.Name = "tbTopicPrefix";
            this.tbTopicPrefix.Size = new System.Drawing.Size(206, 23);
            this.tbTopicPrefix.TabIndex = 1;
            this.tbTopicPrefix.Text = global::MQTTExample.Properties.Settings.Default.TopicPrefix;
            // 
            // cbxTLS
            // 
            this.cbxTLS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTLS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTLS.FormattingEnabled = true;
            this.cbxTLS.Location = new System.Drawing.Point(161, 171);
            this.cbxTLS.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTLS.Name = "cbxTLS";
            this.cbxTLS.Size = new System.Drawing.Size(206, 23);
            this.cbxTLS.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectIPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(373, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(393, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectIPToolStripMenuItem
            // 
            this.selectIPToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Underline);
            this.selectIPToolStripMenuItem.Name = "selectIPToolStripMenuItem";
            this.selectIPToolStripMenuItem.Size = new System.Drawing.Size(110, 21);
            this.selectIPToolStripMenuItem.Text = "Select local IP ↓";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Dock = System.Windows.Forms.DockStyle.Right;
            this.label75.Location = new System.Drawing.Point(52, 206);
            this.label75.Margin = new System.Windows.Forms.Padding(6);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(97, 19);
            this.label75.TabIndex = 0;
            this.label75.Text = "CA certificate file";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Dock = System.Windows.Forms.DockStyle.Right;
            this.label76.Location = new System.Drawing.Point(37, 239);
            this.label76.Margin = new System.Windows.Forms.Padding(6);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(112, 19);
            this.label76.TabIndex = 0;
            this.label76.Text = "Client certificate file";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Dock = System.Windows.Forms.DockStyle.Right;
            this.label77.Location = new System.Drawing.Point(32, 272);
            this.label77.Margin = new System.Windows.Forms.Padding(6);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(117, 19);
            this.label77.TabIndex = 0;
            this.label77.Text = "Client private key file";
            // 
            // tbCACertificateFile
            // 
            this.tlpConnection.SetColumnSpan(this.tbCACertificateFile, 2);
            this.tbCACertificateFile.Location = new System.Drawing.Point(161, 204);
            this.tbCACertificateFile.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.tbCACertificateFile.Name = "tbCACertificateFile";
            this.tbCACertificateFile.Size = new System.Drawing.Size(605, 23);
            this.tbCACertificateFile.TabIndex = 1;
            // 
            // tbClientCertificateFile
            // 
            this.tlpConnection.SetColumnSpan(this.tbClientCertificateFile, 2);
            this.tbClientCertificateFile.Location = new System.Drawing.Point(161, 237);
            this.tbClientCertificateFile.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.tbClientCertificateFile.Name = "tbClientCertificateFile";
            this.tbClientCertificateFile.Size = new System.Drawing.Size(605, 23);
            this.tbClientCertificateFile.TabIndex = 1;
            // 
            // tbClientPrivateKeyFile
            // 
            this.tlpConnection.SetColumnSpan(this.tbClientPrivateKeyFile, 2);
            this.tbClientPrivateKeyFile.Location = new System.Drawing.Point(161, 270);
            this.tbClientPrivateKeyFile.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.tbClientPrivateKeyFile.Name = "tbClientPrivateKeyFile";
            this.tbClientPrivateKeyFile.Size = new System.Drawing.Size(605, 23);
            this.tbClientPrivateKeyFile.TabIndex = 1;
            // 
            // btnBrowseCACertificateFile
            // 
            this.btnBrowseCACertificateFile.Location = new System.Drawing.Point(771, 203);
            this.btnBrowseCACertificateFile.Name = "btnBrowseCACertificateFile";
            this.btnBrowseCACertificateFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseCACertificateFile.TabIndex = 6;
            this.btnBrowseCACertificateFile.Text = "Browse";
            this.btnBrowseCACertificateFile.UseVisualStyleBackColor = true;
            this.btnBrowseCACertificateFile.Click += new System.EventHandler(this.btnBrowseCACertificateFile_Click);
            // 
            // btnBrowseClientCertificateFile
            // 
            this.btnBrowseClientCertificateFile.Location = new System.Drawing.Point(771, 236);
            this.btnBrowseClientCertificateFile.Name = "btnBrowseClientCertificateFile";
            this.btnBrowseClientCertificateFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseClientCertificateFile.TabIndex = 6;
            this.btnBrowseClientCertificateFile.Text = "Browse";
            this.btnBrowseClientCertificateFile.UseVisualStyleBackColor = true;
            this.btnBrowseClientCertificateFile.Click += new System.EventHandler(this.btnBrowseClientCertificateFile_Click);
            // 
            // btnBrowseClientPrivateKeyFile
            // 
            this.btnBrowseClientPrivateKeyFile.Location = new System.Drawing.Point(771, 269);
            this.btnBrowseClientPrivateKeyFile.Name = "btnBrowseClientPrivateKeyFile";
            this.btnBrowseClientPrivateKeyFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseClientPrivateKeyFile.TabIndex = 6;
            this.btnBrowseClientPrivateKeyFile.Text = "Browse";
            this.btnBrowseClientPrivateKeyFile.UseVisualStyleBackColor = true;
            this.btnBrowseClientPrivateKeyFile.Click += new System.EventHandler(this.btnBrowseClientPrivateKeyFile_Click);
            // 
            // tabPageSystem
            // 
            this.tabPageSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageSystem.Controls.Add(this.groupBox2);
            this.tabPageSystem.Controls.Add(this.groupBox1);
            this.tabPageSystem.Location = new System.Drawing.Point(4, 24);
            this.tabPageSystem.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSystem.Name = "tabPageSystem";
            this.tabPageSystem.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSystem.Size = new System.Drawing.Size(1178, 777);
            this.tabPageSystem.TabIndex = 1;
            this.tabPageSystem.Text = "System";
            this.tabPageSystem.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(9, 118);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(583, 390);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Information";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSystemName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSystemStatus, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lvSystem, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(575, 366);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 7);
            this.label15.Margin = new System.Windows.Forms.Padding(6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 35);
            this.label16.Margin = new System.Windows.Forms.Padding(6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Status";
            // 
            // lblSystemName
            // 
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.Location = new System.Drawing.Point(59, 7);
            this.lblSystemName.Margin = new System.Windows.Forms.Padding(6);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(54, 15);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "<Mode>";
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.Location = new System.Drawing.Point(59, 35);
            this.lblSystemStatus.Margin = new System.Windows.Forms.Padding(6);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(55, 15);
            this.lblSystemStatus.TabIndex = 1;
            this.lblSystemStatus.Text = "<Status>";
            // 
            // lvSystem
            // 
            this.lvSystem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.tableLayoutPanel2.SetColumnSpan(this.lvSystem, 2);
            this.lvSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSystem.HideSelection = false;
            this.lvSystem.Location = new System.Drawing.Point(5, 61);
            this.lvSystem.Margin = new System.Windows.Forms.Padding(4);
            this.lvSystem.Name = "lvSystem";
            this.lvSystem.Size = new System.Drawing.Size(565, 300);
            this.lvSystem.TabIndex = 2;
            this.lvSystem.UseCompatibleStateImageBehavior = false;
            this.lvSystem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Device type";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Serial number";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IP address";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hardware version";
            this.columnHeader4.Width = 140;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(266, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "App information";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblVersion, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 7);
            this.label13.Margin = new System.Windows.Forms.Padding(6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Software Mode";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 35);
            this.label14.Margin = new System.Windows.Forms.Padding(6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Version";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(135, 7);
            this.lblName.Margin = new System.Windows.Forms.Padding(6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "<Mode>";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(135, 35);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(6);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(39, 15);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "<Ver>";
            // 
            // tabPageTest
            // 
            this.tabPageTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageTest.Controls.Add(this.tabControlTest);
            this.tabPageTest.Location = new System.Drawing.Point(4, 24);
            this.tabPageTest.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageTest.Name = "tabPageTest";
            this.tabPageTest.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageTest.Size = new System.Drawing.Size(1178, 777);
            this.tabPageTest.TabIndex = 2;
            this.tabPageTest.Text = "Test";
            this.tabPageTest.UseVisualStyleBackColor = true;
            // 
            // tabControlTest
            // 
            this.tabControlTest.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlTest.Controls.Add(this.tabPageStatus);
            this.tabControlTest.Controls.Add(this.tabPageTestCommand);
            this.tabControlTest.Controls.Add(this.tabPageAdvTestCommand);
            this.tabControlTest.Controls.Add(this.tabPageDetailStatus);
            this.tabControlTest.Controls.Add(this.tabPageChannels);
            this.tabControlTest.Controls.Add(this.tabPageChannelStatus);
            this.tabControlTest.Controls.Add(this.tabPageParameters);
            this.tabControlTest.Controls.Add(this.tabShaker);
            this.tabControlTest.Controls.Add(this.tabPageTestManager);
            this.tabControlTest.Controls.Add(this.tabPageTHStatus);
            this.tabControlTest.Controls.Add(this.tabPageOutput);
            this.tabControlTest.Controls.Add(this.tabPageGlobalParameters);
            this.tabControlTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTest.HotTrack = true;
            this.tabControlTest.Location = new System.Drawing.Point(6, 6);
            this.tabControlTest.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlTest.Multiline = true;
            this.tabControlTest.Name = "tabControlTest";
            this.tabControlTest.Padding = new System.Drawing.Point(10, 10);
            this.tabControlTest.SelectedIndex = 0;
            this.tabControlTest.Size = new System.Drawing.Size(1164, 763);
            this.tabControlTest.TabIndex = 0;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.groupBox6);
            this.tabPageStatus.Controls.Add(this.groupBox5);
            this.tabPageStatus.Controls.Add(this.groupBox7);
            this.tabPageStatus.Controls.Add(this.groupBox4);
            this.tabPageStatus.Controls.Add(this.groupBox3);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 41);
            this.tabPageStatus.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageStatus.Size = new System.Drawing.Size(1156, 718);
            this.tabPageStatus.TabIndex = 0;
            this.tabPageStatus.Text = "Status";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel14);
            this.groupBox6.Location = new System.Drawing.Point(387, 12);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(448, 215);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Limit Status";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Controls.Add(this.label31, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.label32, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.lblLimitStatus, 1, 1);
            this.tableLayoutPanel14.Controls.Add(this.lblLimitTest, 1, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 2;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(440, 191);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(7, 35);
            this.label31.Margin = new System.Windows.Forms.Padding(6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(39, 15);
            this.label31.TabIndex = 0;
            this.label31.Text = "Status";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(7, 7);
            this.label32.Margin = new System.Windows.Forms.Padding(6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(39, 15);
            this.label32.TabIndex = 0;
            this.label32.Text = "Name";
            // 
            // lblLimitStatus
            // 
            this.lblLimitStatus.AutoSize = true;
            this.lblLimitStatus.Location = new System.Drawing.Point(226, 35);
            this.lblLimitStatus.Margin = new System.Windows.Forms.Padding(6);
            this.lblLimitStatus.Name = "lblLimitStatus";
            this.lblLimitStatus.Size = new System.Drawing.Size(55, 15);
            this.lblLimitStatus.TabIndex = 1;
            this.lblLimitStatus.Text = "<Status>";
            // 
            // lblLimitTest
            // 
            this.lblLimitTest.AutoSize = true;
            this.lblLimitTest.Location = new System.Drawing.Point(226, 7);
            this.lblLimitTest.Margin = new System.Windows.Forms.Padding(6);
            this.lblLimitTest.Name = "lblLimitTest";
            this.lblLimitTest.Size = new System.Drawing.Size(55, 15);
            this.lblLimitTest.TabIndex = 1;
            this.lblLimitTest.Text = "<Name>";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel6);
            this.groupBox5.Location = new System.Drawing.Point(9, 418);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(341, 92);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Record Status";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label23, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label26, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblRecordStatus, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.lblRecordName, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(333, 68);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 35);
            this.label23.Margin = new System.Windows.Forms.Padding(6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(39, 15);
            this.label23.TabIndex = 0;
            this.label23.Text = "Status";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(7, 7);
            this.label26.Margin = new System.Windows.Forms.Padding(6);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(39, 15);
            this.label26.TabIndex = 0;
            this.label26.Text = "Name";
            // 
            // lblRecordStatus
            // 
            this.lblRecordStatus.AutoSize = true;
            this.lblRecordStatus.Location = new System.Drawing.Point(173, 35);
            this.lblRecordStatus.Margin = new System.Windows.Forms.Padding(6);
            this.lblRecordStatus.Name = "lblRecordStatus";
            this.lblRecordStatus.Size = new System.Drawing.Size(55, 15);
            this.lblRecordStatus.TabIndex = 1;
            this.lblRecordStatus.Text = "<Status>";
            // 
            // lblRecordName
            // 
            this.lblRecordName.AutoSize = true;
            this.lblRecordName.Location = new System.Drawing.Point(173, 7);
            this.lblRecordName.Margin = new System.Windows.Forms.Padding(6);
            this.lblRecordName.Name = "lblRecordName";
            this.lblRecordName.Size = new System.Drawing.Size(55, 15);
            this.lblRecordName.TabIndex = 1;
            this.lblRecordName.Text = "<Name>";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tableLayoutPanel15);
            this.groupBox7.Location = new System.Drawing.Point(387, 266);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(444, 108);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "VCS Control Flag";
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.Controls.Add(this.label35, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.label36, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.lblControlFlagTest, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.lblControlFlag, 1, 1);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 2;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(436, 84);
            this.tableLayoutPanel15.TabIndex = 0;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(7, 35);
            this.label35.Margin = new System.Windows.Forms.Padding(6);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(29, 15);
            this.label35.TabIndex = 0;
            this.label35.Text = "Flag";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(7, 7);
            this.label36.Margin = new System.Windows.Forms.Padding(6);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(39, 15);
            this.label36.TabIndex = 0;
            this.label36.Text = "Name";
            // 
            // lblControlFlagTest
            // 
            this.lblControlFlagTest.AutoSize = true;
            this.lblControlFlagTest.Location = new System.Drawing.Point(224, 7);
            this.lblControlFlagTest.Margin = new System.Windows.Forms.Padding(6);
            this.lblControlFlagTest.Name = "lblControlFlagTest";
            this.lblControlFlagTest.Size = new System.Drawing.Size(55, 15);
            this.lblControlFlagTest.TabIndex = 1;
            this.lblControlFlagTest.Text = "<Name>";
            // 
            // lblControlFlag
            // 
            this.lblControlFlag.AutoSize = true;
            this.lblControlFlag.Location = new System.Drawing.Point(224, 35);
            this.lblControlFlag.Margin = new System.Windows.Forms.Padding(6);
            this.lblControlFlag.Name = "lblControlFlag";
            this.lblControlFlag.Size = new System.Drawing.Size(52, 15);
            this.lblControlFlag.TabIndex = 1;
            this.lblControlFlag.Text = "<Stage>";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Location = new System.Drawing.Point(9, 266);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(341, 108);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "VCS Test Stage";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label22, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label29, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblStageTest, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblStage, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(333, 84);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 35);
            this.label22.Margin = new System.Windows.Forms.Padding(6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(36, 15);
            this.label22.TabIndex = 0;
            this.label22.Text = "Stage";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(7, 7);
            this.label29.Margin = new System.Windows.Forms.Padding(6);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(39, 15);
            this.label29.TabIndex = 0;
            this.label29.Text = "Name";
            // 
            // lblStageTest
            // 
            this.lblStageTest.AutoSize = true;
            this.lblStageTest.Location = new System.Drawing.Point(173, 7);
            this.lblStageTest.Margin = new System.Windows.Forms.Padding(6);
            this.lblStageTest.Name = "lblStageTest";
            this.lblStageTest.Size = new System.Drawing.Size(55, 15);
            this.lblStageTest.TabIndex = 1;
            this.lblStageTest.Text = "<Name>";
            // 
            // lblStage
            // 
            this.lblStage.AutoSize = true;
            this.lblStage.Location = new System.Drawing.Point(173, 35);
            this.lblStage.Margin = new System.Windows.Forms.Padding(6);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(52, 15);
            this.lblStage.TabIndex = 1;
            this.lblStage.Text = "<Stage>";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(355, 221);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test Information";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblTestName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTestType, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label21, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblTestStatus, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label19, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label20, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.lblRunFolder, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblMeasureStartAt, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(347, 197);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 7);
            this.label17.Margin = new System.Windows.Forms.Padding(6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "Name";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 35);
            this.label18.Margin = new System.Windows.Forms.Padding(6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "Type";
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Location = new System.Drawing.Point(180, 7);
            this.lblTestName.Margin = new System.Windows.Forms.Padding(6);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(55, 15);
            this.lblTestName.TabIndex = 1;
            this.lblTestName.Text = "<Name>";
            // 
            // lblTestType
            // 
            this.lblTestType.AutoSize = true;
            this.lblTestType.Location = new System.Drawing.Point(180, 35);
            this.lblTestType.Margin = new System.Windows.Forms.Padding(6);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(47, 15);
            this.lblTestType.TabIndex = 1;
            this.lblTestType.Text = "<Type>";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 63);
            this.label21.Margin = new System.Windows.Forms.Padding(6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "Status";
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Location = new System.Drawing.Point(180, 63);
            this.lblTestStatus.Margin = new System.Windows.Forms.Padding(6);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(55, 15);
            this.lblTestStatus.TabIndex = 1;
            this.lblTestStatus.Text = "<Status>";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 91);
            this.label19.Margin = new System.Windows.Forms.Padding(6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "Run Folder";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 119);
            this.label20.Margin = new System.Windows.Forms.Padding(6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 15);
            this.label20.TabIndex = 0;
            this.label20.Text = "Measure Start At";
            // 
            // lblRunFolder
            // 
            this.lblRunFolder.AutoSize = true;
            this.lblRunFolder.Location = new System.Drawing.Point(180, 91);
            this.lblRunFolder.Margin = new System.Windows.Forms.Padding(6);
            this.lblRunFolder.Name = "lblRunFolder";
            this.lblRunFolder.Size = new System.Drawing.Size(80, 15);
            this.lblRunFolder.TabIndex = 0;
            this.lblRunFolder.Text = "<Run Folder>";
            // 
            // lblMeasureStartAt
            // 
            this.lblMeasureStartAt.AutoSize = true;
            this.lblMeasureStartAt.Location = new System.Drawing.Point(180, 119);
            this.lblMeasureStartAt.Margin = new System.Windows.Forms.Padding(6);
            this.lblMeasureStartAt.Name = "lblMeasureStartAt";
            this.lblMeasureStartAt.Size = new System.Drawing.Size(110, 15);
            this.lblMeasureStartAt.TabIndex = 0;
            this.lblMeasureStartAt.Text = "<Measure Start At>";
            // 
            // tabPageTestCommand
            // 
            this.tabPageTestCommand.Controls.Add(this.tableLayoutPanel7);
            this.tabPageTestCommand.Controls.Add(this.tableLayoutPanel5);
            this.tabPageTestCommand.Location = new System.Drawing.Point(4, 41);
            this.tabPageTestCommand.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageTestCommand.Name = "tabPageTestCommand";
            this.tabPageTestCommand.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageTestCommand.Size = new System.Drawing.Size(1156, 718);
            this.tabPageTestCommand.TabIndex = 1;
            this.tabPageTestCommand.Text = "Command";
            this.tabPageTestCommand.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 6;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66668F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.Controls.Add(this.button19, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.button20, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.button10, 0, 12);
            this.tableLayoutPanel7.Controls.Add(this.button11, 1, 12);
            this.tableLayoutPanel7.Controls.Add(this.button12, 2, 12);
            this.tableLayoutPanel7.Controls.Add(this.button13, 3, 12);
            this.tableLayoutPanel7.Controls.Add(this.button22, 2, 1);
            this.tableLayoutPanel7.Controls.Add(this.button16, 0, 13);
            this.tableLayoutPanel7.Controls.Add(this.button17, 1, 13);
            this.tableLayoutPanel7.Controls.Add(this.button21, 3, 1);
            this.tableLayoutPanel7.Controls.Add(this.button14, 4, 1);
            this.tableLayoutPanel7.Controls.Add(this.button23, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.button15, 5, 1);
            this.tableLayoutPanel7.Controls.Add(this.button24, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.button25, 2, 2);
            this.tableLayoutPanel7.Controls.Add(this.button26, 3, 2);
            this.tableLayoutPanel7.Controls.Add(this.button28, 5, 2);
            this.tableLayoutPanel7.Controls.Add(this.button27, 4, 2);
            this.tableLayoutPanel7.Controls.Add(this.button35, 0, 8);
            this.tableLayoutPanel7.Controls.Add(this.button31, 0, 7);
            this.tableLayoutPanel7.Controls.Add(this.button37, 1, 7);
            this.tableLayoutPanel7.Controls.Add(this.nudLevel, 2, 7);
            this.tableLayoutPanel7.Controls.Add(this.btnSetLevel, 3, 7);
            this.tableLayoutPanel7.Controls.Add(this.button39, 3, 9);
            this.tableLayoutPanel7.Controls.Add(this.button36, 1, 8);
            this.tableLayoutPanel7.Controls.Add(this.nudFrequency, 2, 8);
            this.tableLayoutPanel7.Controls.Add(this.btnSetFrequency, 3, 8);
            this.tableLayoutPanel7.Controls.Add(this.button42, 0, 9);
            this.tableLayoutPanel7.Controls.Add(this.button41, 1, 9);
            this.tableLayoutPanel7.Controls.Add(this.button40, 2, 9);
            this.tableLayoutPanel7.Controls.Add(this.button43, 4, 9);
            this.tableLayoutPanel7.Controls.Add(this.button44, 2, 13);
            this.tableLayoutPanel7.Controls.Add(this.button33, 0, 6);
            this.tableLayoutPanel7.Controls.Add(this.button32, 1, 6);
            this.tableLayoutPanel7.Controls.Add(this.button34, 2, 6);
            this.tableLayoutPanel7.Controls.Add(this.rbVCSCommand, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.rbDSACommand, 0, 10);
            this.tableLayoutPanel7.Controls.Add(this.button38, 3, 6);
            this.tableLayoutPanel7.Controls.Add(this.nudPhase, 4, 8);
            this.tableLayoutPanel7.Controls.Add(this.btnSetPhase, 5, 8);
            this.tableLayoutPanel7.Controls.Add(this.button45, 4, 7);
            this.tableLayoutPanel7.Controls.Add(this.btnSORTonesHold, 0, 5);
            this.tableLayoutPanel7.Controls.Add(this.btnSORTonesRelease, 1, 5);
            this.tableLayoutPanel7.Controls.Add(this.btnSORTonesSweepUp, 2, 5);
            this.tableLayoutPanel7.Controls.Add(this.btnSORTonesSweepDown, 3, 5);
            this.tableLayoutPanel7.Controls.Add(this.tbRoRBands, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.rorBandFlag, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.btnRoRBandsOn, 2, 3);
            this.tableLayoutPanel7.Controls.Add(this.btnRoRBandsOff, 3, 3);
            this.tableLayoutPanel7.Controls.Add(this.tbSoRTones, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.sorBandFlag, 1, 4);
            this.tableLayoutPanel7.Controls.Add(this.btnSORTonesOn, 2, 4);
            this.tableLayoutPanel7.Controls.Add(this.btnSORTonesOff, 3, 4);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(2, 154);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 16;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1152, 562);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // button19
            // 
            this.button19.Dock = System.Windows.Forms.DockStyle.Top;
            this.button19.Location = new System.Drawing.Point(4, 37);
            this.button19.Margin = new System.Windows.Forms.Padding(4);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(184, 35);
            this.button19.TabIndex = 1;
            this.button19.Tag = "CheckOnly";
            this.button19.Text = "Check Only";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button20
            // 
            this.button20.Dock = System.Windows.Forms.DockStyle.Top;
            this.button20.Location = new System.Drawing.Point(196, 37);
            this.button20.Margin = new System.Windows.Forms.Padding(4);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(183, 35);
            this.button20.TabIndex = 2;
            this.button20.Tag = "Proceed";
            this.button20.Text = "Proceed";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.Location = new System.Drawing.Point(4, 457);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(184, 35);
            this.button10.TabIndex = 4;
            this.button10.Tag = "TriggerOn";
            this.button10.Text = "Trigger On";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Top;
            this.button11.Location = new System.Drawing.Point(196, 457);
            this.button11.Margin = new System.Windows.Forms.Padding(4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(183, 35);
            this.button11.TabIndex = 4;
            this.button11.Tag = "TriggerOff";
            this.button11.Text = "Trigger Off";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button12
            // 
            this.button12.Dock = System.Windows.Forms.DockStyle.Top;
            this.button12.Location = new System.Drawing.Point(387, 457);
            this.button12.Margin = new System.Windows.Forms.Padding(4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(183, 35);
            this.button12.TabIndex = 4;
            this.button12.Tag = "OutputOn";
            this.button12.Text = "Output On";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button13
            // 
            this.button13.Dock = System.Windows.Forms.DockStyle.Top;
            this.button13.Location = new System.Drawing.Point(578, 457);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(183, 35);
            this.button13.TabIndex = 4;
            this.button13.Tag = "OutputOff";
            this.button13.Text = "Output Off";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button22
            // 
            this.button22.Dock = System.Windows.Forms.DockStyle.Top;
            this.button22.Location = new System.Drawing.Point(387, 37);
            this.button22.Margin = new System.Windows.Forms.Padding(4);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(183, 35);
            this.button22.TabIndex = 2;
            this.button22.Tag = "ShowPretest";
            this.button22.Text = "Show Pretest";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button16
            // 
            this.button16.Dock = System.Windows.Forms.DockStyle.Top;
            this.button16.Location = new System.Drawing.Point(4, 500);
            this.button16.Margin = new System.Windows.Forms.Padding(4);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(184, 35);
            this.button16.TabIndex = 4;
            this.button16.Tag = "LimitOn";
            this.button16.Text = "Limit On";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button17
            // 
            this.button17.Dock = System.Windows.Forms.DockStyle.Top;
            this.button17.Location = new System.Drawing.Point(196, 500);
            this.button17.Margin = new System.Windows.Forms.Padding(4);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(183, 35);
            this.button17.TabIndex = 4;
            this.button17.Tag = "LimitOff";
            this.button17.Text = "Limit Off";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button21
            // 
            this.button21.Dock = System.Windows.Forms.DockStyle.Top;
            this.button21.Location = new System.Drawing.Point(578, 37);
            this.button21.Margin = new System.Windows.Forms.Padding(4);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(183, 35);
            this.button21.TabIndex = 2;
            this.button21.Tag = "SaveHSignal";
            this.button21.Text = "Save H Signal";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button14
            // 
            this.button14.Dock = System.Windows.Forms.DockStyle.Top;
            this.button14.Location = new System.Drawing.Point(769, 37);
            this.button14.Margin = new System.Windows.Forms.Padding(4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(183, 35);
            this.button14.TabIndex = 5;
            this.button14.Tag = "ResetAverage";
            this.button14.Text = "Reset Average";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button23
            // 
            this.button23.Dock = System.Windows.Forms.DockStyle.Top;
            this.button23.Location = new System.Drawing.Point(4, 80);
            this.button23.Margin = new System.Windows.Forms.Padding(4);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(184, 35);
            this.button23.TabIndex = 3;
            this.button23.Tag = "AbortChecksOn";
            this.button23.Text = "Abort Check On";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button15
            // 
            this.button15.Dock = System.Windows.Forms.DockStyle.Top;
            this.button15.Location = new System.Drawing.Point(960, 37);
            this.button15.Margin = new System.Windows.Forms.Padding(4);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(188, 35);
            this.button15.TabIndex = 2;
            this.button15.Tag = "NextEntry";
            this.button15.Text = "Next Entry";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button24
            // 
            this.button24.Dock = System.Windows.Forms.DockStyle.Top;
            this.button24.Location = new System.Drawing.Point(196, 80);
            this.button24.Margin = new System.Windows.Forms.Padding(4);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(183, 35);
            this.button24.TabIndex = 3;
            this.button24.Tag = "AbortChecksOff";
            this.button24.Text = "Abort Check Off";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button25
            // 
            this.button25.Dock = System.Windows.Forms.DockStyle.Top;
            this.button25.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.button25.Location = new System.Drawing.Point(387, 80);
            this.button25.Margin = new System.Windows.Forms.Padding(4);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(183, 35);
            this.button25.TabIndex = 3;
            this.button25.Tag = "ClosedLoopControlOn";
            this.button25.Text = "Closed Loop Ctrl On";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button26
            // 
            this.button26.Dock = System.Windows.Forms.DockStyle.Top;
            this.button26.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.button26.Location = new System.Drawing.Point(578, 80);
            this.button26.Margin = new System.Windows.Forms.Padding(4);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(183, 35);
            this.button26.TabIndex = 3;
            this.button26.Tag = "ClosedLoopControlOff";
            this.button26.Text = "Closed Loop Ctrl Off";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button28
            // 
            this.button28.Dock = System.Windows.Forms.DockStyle.Top;
            this.button28.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.button28.Location = new System.Drawing.Point(960, 80);
            this.button28.Margin = new System.Windows.Forms.Padding(4);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(188, 35);
            this.button28.TabIndex = 4;
            this.button28.Tag = "ScheduleClockTimerOff";
            this.button28.Text = "Schedule Clock Timer Off";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button27
            // 
            this.button27.Dock = System.Windows.Forms.DockStyle.Top;
            this.button27.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.button27.Location = new System.Drawing.Point(769, 80);
            this.button27.Margin = new System.Windows.Forms.Padding(4);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(183, 35);
            this.button27.TabIndex = 4;
            this.button27.Tag = "ScheduleClockTimerOn";
            this.button27.Text = "Schedule Clock Timer On";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button35
            // 
            this.button35.Dock = System.Windows.Forms.DockStyle.Top;
            this.button35.Location = new System.Drawing.Point(4, 338);
            this.button35.Margin = new System.Windows.Forms.Padding(4);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(184, 35);
            this.button35.TabIndex = 4;
            this.button35.Tag = "IncreaseSpeed";
            this.button35.Text = "Increase Speed";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button31
            // 
            this.button31.Dock = System.Windows.Forms.DockStyle.Top;
            this.button31.Location = new System.Drawing.Point(4, 295);
            this.button31.Margin = new System.Windows.Forms.Padding(4);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(184, 35);
            this.button31.TabIndex = 4;
            this.button31.Tag = "LevelUp";
            this.button31.Text = "Level Up";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button37
            // 
            this.button37.Dock = System.Windows.Forms.DockStyle.Top;
            this.button37.Location = new System.Drawing.Point(196, 295);
            this.button37.Margin = new System.Windows.Forms.Padding(4);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(183, 35);
            this.button37.TabIndex = 4;
            this.button37.Tag = "LevelDown";
            this.button37.Text = "Level Down";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // nudLevel
            // 
            this.nudLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudLevel.Location = new System.Drawing.Point(387, 296);
            this.nudLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 4);
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(183, 23);
            this.nudLevel.TabIndex = 6;
            // 
            // btnSetLevel
            // 
            this.btnSetLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetLevel.Location = new System.Drawing.Point(578, 295);
            this.btnSetLevel.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetLevel.Name = "btnSetLevel";
            this.btnSetLevel.Size = new System.Drawing.Size(183, 35);
            this.btnSetLevel.TabIndex = 7;
            this.btnSetLevel.Tag = "SetLevel";
            this.btnSetLevel.Text = "Set Level";
            this.btnSetLevel.UseVisualStyleBackColor = true;
            this.btnSetLevel.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button39
            // 
            this.button39.Dock = System.Windows.Forms.DockStyle.Top;
            this.button39.Location = new System.Drawing.Point(578, 381);
            this.button39.Margin = new System.Windows.Forms.Padding(4);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(183, 35);
            this.button39.TabIndex = 4;
            this.button39.Tag = "SinglePulseOff";
            this.button39.Text = "Single Pulse Off";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button36
            // 
            this.button36.Dock = System.Windows.Forms.DockStyle.Top;
            this.button36.Location = new System.Drawing.Point(196, 338);
            this.button36.Margin = new System.Windows.Forms.Padding(4);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(183, 35);
            this.button36.TabIndex = 4;
            this.button36.Tag = "DecreaseSpeed";
            this.button36.Text = "Decrease Speed";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // nudFrequency
            // 
            this.nudFrequency.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudFrequency.Location = new System.Drawing.Point(387, 340);
            this.nudFrequency.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.nudFrequency.Name = "nudFrequency";
            this.nudFrequency.Size = new System.Drawing.Size(183, 23);
            this.nudFrequency.TabIndex = 6;
            // 
            // btnSetFrequency
            // 
            this.btnSetFrequency.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetFrequency.Location = new System.Drawing.Point(578, 338);
            this.btnSetFrequency.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetFrequency.Name = "btnSetFrequency";
            this.btnSetFrequency.Size = new System.Drawing.Size(183, 35);
            this.btnSetFrequency.TabIndex = 7;
            this.btnSetFrequency.Tag = "SetFrequency";
            this.btnSetFrequency.Text = "Set Frequency";
            this.btnSetFrequency.UseVisualStyleBackColor = true;
            this.btnSetFrequency.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button42
            // 
            this.button42.Dock = System.Windows.Forms.DockStyle.Top;
            this.button42.Location = new System.Drawing.Point(4, 381);
            this.button42.Margin = new System.Windows.Forms.Padding(4);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(184, 35);
            this.button42.TabIndex = 4;
            this.button42.Tag = "InversePulseOn";
            this.button42.Text = "Inverse Pulse On";
            this.button42.UseVisualStyleBackColor = true;
            this.button42.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button41
            // 
            this.button41.Dock = System.Windows.Forms.DockStyle.Top;
            this.button41.Location = new System.Drawing.Point(196, 381);
            this.button41.Margin = new System.Windows.Forms.Padding(4);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(183, 35);
            this.button41.TabIndex = 4;
            this.button41.Tag = "InversePulseOff";
            this.button41.Text = "Inverse Pulse Off";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button40
            // 
            this.button40.Dock = System.Windows.Forms.DockStyle.Top;
            this.button40.Location = new System.Drawing.Point(387, 381);
            this.button40.Margin = new System.Windows.Forms.Padding(4);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(183, 35);
            this.button40.TabIndex = 4;
            this.button40.Tag = "SinglePulseOn";
            this.button40.Text = "Single Pulse On";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button43
            // 
            this.button43.Dock = System.Windows.Forms.DockStyle.Top;
            this.button43.Location = new System.Drawing.Point(769, 381);
            this.button43.Margin = new System.Windows.Forms.Padding(4);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(183, 35);
            this.button43.TabIndex = 4;
            this.button43.Tag = "OutputSinglePulse";
            this.button43.Text = "Output Single Pulse";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button44
            // 
            this.button44.Dock = System.Windows.Forms.DockStyle.Top;
            this.button44.Location = new System.Drawing.Point(387, 500);
            this.button44.Margin = new System.Windows.Forms.Padding(4);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(183, 35);
            this.button44.TabIndex = 5;
            this.button44.Tag = "ResetAverage";
            this.button44.Text = "Reset Average";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button33
            // 
            this.button33.Dock = System.Windows.Forms.DockStyle.Top;
            this.button33.Location = new System.Drawing.Point(4, 252);
            this.button33.Margin = new System.Windows.Forms.Padding(4);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(184, 35);
            this.button33.TabIndex = 4;
            this.button33.Tag = "SweepUp";
            this.button33.Text = "Sweep Up";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button32
            // 
            this.button32.Dock = System.Windows.Forms.DockStyle.Top;
            this.button32.Location = new System.Drawing.Point(196, 252);
            this.button32.Margin = new System.Windows.Forms.Padding(4);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(183, 35);
            this.button32.TabIndex = 4;
            this.button32.Tag = "SweepDown";
            this.button32.Text = "Sweep Down";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button34
            // 
            this.button34.Dock = System.Windows.Forms.DockStyle.Top;
            this.button34.Location = new System.Drawing.Point(387, 252);
            this.button34.Margin = new System.Windows.Forms.Padding(4);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(183, 35);
            this.button34.TabIndex = 4;
            this.button34.Tag = "HoldSweep";
            this.button34.Text = "Hold Sweep";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // rbVCSCommand
            // 
            this.rbVCSCommand.AutoSize = true;
            this.rbVCSCommand.Checked = true;
            this.tableLayoutPanel7.SetColumnSpan(this.rbVCSCommand, 2);
            this.rbVCSCommand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.rbVCSCommand.Location = new System.Drawing.Point(4, 4);
            this.rbVCSCommand.Margin = new System.Windows.Forms.Padding(4);
            this.rbVCSCommand.Name = "rbVCSCommand";
            this.rbVCSCommand.Size = new System.Drawing.Size(205, 25);
            this.rbVCSCommand.TabIndex = 9;
            this.rbVCSCommand.TabStop = true;
            this.rbVCSCommand.Text = "Execute VCS Command";
            this.rbVCSCommand.UseVisualStyleBackColor = true;
            // 
            // rbDSACommand
            // 
            this.rbDSACommand.AutoSize = true;
            this.tableLayoutPanel7.SetColumnSpan(this.rbDSACommand, 2);
            this.rbDSACommand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.rbDSACommand.Location = new System.Drawing.Point(4, 424);
            this.rbDSACommand.Margin = new System.Windows.Forms.Padding(4);
            this.rbDSACommand.Name = "rbDSACommand";
            this.rbDSACommand.Size = new System.Drawing.Size(207, 25);
            this.rbDSACommand.TabIndex = 9;
            this.rbDSACommand.Text = "Execute DSA Command";
            this.rbDSACommand.UseVisualStyleBackColor = true;
            // 
            // button38
            // 
            this.button38.Dock = System.Windows.Forms.DockStyle.Top;
            this.button38.Location = new System.Drawing.Point(578, 252);
            this.button38.Margin = new System.Windows.Forms.Padding(4);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(183, 35);
            this.button38.TabIndex = 4;
            this.button38.Tag = "ReleaseSweep";
            this.button38.Text = "Release Sweep";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // nudPhase
            // 
            this.nudPhase.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudPhase.Location = new System.Drawing.Point(769, 340);
            this.nudPhase.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.nudPhase.Name = "nudPhase";
            this.nudPhase.Size = new System.Drawing.Size(183, 23);
            this.nudPhase.TabIndex = 6;
            // 
            // btnSetPhase
            // 
            this.btnSetPhase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetPhase.Location = new System.Drawing.Point(960, 338);
            this.btnSetPhase.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetPhase.Name = "btnSetPhase";
            this.btnSetPhase.Size = new System.Drawing.Size(188, 35);
            this.btnSetPhase.TabIndex = 7;
            this.btnSetPhase.Tag = "SetPhase";
            this.btnSetPhase.Text = "Set Phase";
            this.btnSetPhase.UseVisualStyleBackColor = true;
            this.btnSetPhase.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button45
            // 
            this.button45.Dock = System.Windows.Forms.DockStyle.Top;
            this.button45.Location = new System.Drawing.Point(769, 295);
            this.button45.Margin = new System.Windows.Forms.Padding(4);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(183, 35);
            this.button45.TabIndex = 7;
            this.button45.Tag = "RestoreLevel";
            this.button45.Text = "Restore Level";
            this.button45.UseVisualStyleBackColor = true;
            this.button45.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnSORTonesHold
            // 
            this.btnSORTonesHold.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSORTonesHold.Location = new System.Drawing.Point(4, 209);
            this.btnSORTonesHold.Margin = new System.Windows.Forms.Padding(4);
            this.btnSORTonesHold.Name = "btnSORTonesHold";
            this.btnSORTonesHold.Size = new System.Drawing.Size(184, 35);
            this.btnSORTonesHold.TabIndex = 3;
            this.btnSORTonesHold.Tag = "SoRTonesHoldSweep";
            this.btnSORTonesHold.Text = "Tones Hold Sweep";
            this.btnSORTonesHold.UseVisualStyleBackColor = true;
            this.btnSORTonesHold.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnSORTonesRelease
            // 
            this.btnSORTonesRelease.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSORTonesRelease.Location = new System.Drawing.Point(196, 209);
            this.btnSORTonesRelease.Margin = new System.Windows.Forms.Padding(4);
            this.btnSORTonesRelease.Name = "btnSORTonesRelease";
            this.btnSORTonesRelease.Size = new System.Drawing.Size(183, 35);
            this.btnSORTonesRelease.TabIndex = 3;
            this.btnSORTonesRelease.Tag = "SoRTonesReleaseSweep";
            this.btnSORTonesRelease.Text = "Tones Release Sweep";
            this.btnSORTonesRelease.UseVisualStyleBackColor = true;
            this.btnSORTonesRelease.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnSORTonesSweepUp
            // 
            this.btnSORTonesSweepUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSORTonesSweepUp.Location = new System.Drawing.Point(387, 209);
            this.btnSORTonesSweepUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnSORTonesSweepUp.Name = "btnSORTonesSweepUp";
            this.btnSORTonesSweepUp.Size = new System.Drawing.Size(183, 35);
            this.btnSORTonesSweepUp.TabIndex = 3;
            this.btnSORTonesSweepUp.Tag = "SoRTonesSweepUp";
            this.btnSORTonesSweepUp.Text = "Tones Sweep Up";
            this.btnSORTonesSweepUp.UseVisualStyleBackColor = true;
            this.btnSORTonesSweepUp.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnSORTonesSweepDown
            // 
            this.btnSORTonesSweepDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSORTonesSweepDown.Location = new System.Drawing.Point(578, 209);
            this.btnSORTonesSweepDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnSORTonesSweepDown.Name = "btnSORTonesSweepDown";
            this.btnSORTonesSweepDown.Size = new System.Drawing.Size(183, 35);
            this.btnSORTonesSweepDown.TabIndex = 3;
            this.btnSORTonesSweepDown.Tag = "SoRTonesSweepDown";
            this.btnSORTonesSweepDown.Text = "Tones Sweep Down";
            this.btnSORTonesSweepDown.UseVisualStyleBackColor = true;
            this.btnSORTonesSweepDown.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // tbRoRBands
            // 
            this.tbRoRBands.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbRoRBands.Location = new System.Drawing.Point(4, 125);
            this.tbRoRBands.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.tbRoRBands.Name = "tbRoRBands";
            this.tbRoRBands.Size = new System.Drawing.Size(184, 23);
            this.tbRoRBands.TabIndex = 10;
            this.tbRoRBands.Text = "0;1;0;1";
            this.tbRoRBands.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rorBandFlag
            // 
            this.rorBandFlag.AutoSize = true;
            this.rorBandFlag.Checked = true;
            this.rorBandFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rorBandFlag.Dock = System.Windows.Forms.DockStyle.Top;
            this.rorBandFlag.Location = new System.Drawing.Point(198, 129);
            this.rorBandFlag.Margin = new System.Windows.Forms.Padding(6, 10, 4, 4);
            this.rorBandFlag.Name = "rorBandFlag";
            this.rorBandFlag.Size = new System.Drawing.Size(181, 19);
            this.rorBandFlag.TabIndex = 11;
            this.rorBandFlag.Text = "ROR Board Band On/Off";
            this.rorBandFlag.UseVisualStyleBackColor = true;
            // 
            // btnRoRBandsOn
            // 
            this.btnRoRBandsOn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoRBandsOn.Location = new System.Drawing.Point(387, 123);
            this.btnRoRBandsOn.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoRBandsOn.Name = "btnRoRBandsOn";
            this.btnRoRBandsOn.Size = new System.Drawing.Size(183, 35);
            this.btnRoRBandsOn.TabIndex = 3;
            this.btnRoRBandsOn.Tag = "RoRBandsOn";
            this.btnRoRBandsOn.Text = "RoR Bands On";
            this.btnRoRBandsOn.UseVisualStyleBackColor = true;
            this.btnRoRBandsOn.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnRoRBandsOff
            // 
            this.btnRoRBandsOff.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoRBandsOff.Location = new System.Drawing.Point(578, 123);
            this.btnRoRBandsOff.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoRBandsOff.Name = "btnRoRBandsOff";
            this.btnRoRBandsOff.Size = new System.Drawing.Size(183, 35);
            this.btnRoRBandsOff.TabIndex = 3;
            this.btnRoRBandsOff.Tag = "RoRBandsOff";
            this.btnRoRBandsOff.Text = "RoR Bands Off";
            this.btnRoRBandsOff.UseVisualStyleBackColor = true;
            this.btnRoRBandsOff.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // tbSoRTones
            // 
            this.tbSoRTones.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSoRTones.Location = new System.Drawing.Point(4, 168);
            this.tbSoRTones.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.tbSoRTones.Name = "tbSoRTones";
            this.tbSoRTones.Size = new System.Drawing.Size(184, 23);
            this.tbSoRTones.TabIndex = 10;
            this.tbSoRTones.Text = "0;1;0;1";
            this.tbSoRTones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sorBandFlag
            // 
            this.sorBandFlag.AutoSize = true;
            this.sorBandFlag.Checked = true;
            this.sorBandFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sorBandFlag.Dock = System.Windows.Forms.DockStyle.Top;
            this.sorBandFlag.Location = new System.Drawing.Point(198, 172);
            this.sorBandFlag.Margin = new System.Windows.Forms.Padding(6, 10, 4, 4);
            this.sorBandFlag.Name = "sorBandFlag";
            this.sorBandFlag.Size = new System.Drawing.Size(181, 19);
            this.sorBandFlag.TabIndex = 11;
            this.sorBandFlag.Text = "SOR Board Band On/Off";
            this.sorBandFlag.UseVisualStyleBackColor = true;
            // 
            // btnSORTonesOn
            // 
            this.btnSORTonesOn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSORTonesOn.Location = new System.Drawing.Point(387, 166);
            this.btnSORTonesOn.Margin = new System.Windows.Forms.Padding(4);
            this.btnSORTonesOn.Name = "btnSORTonesOn";
            this.btnSORTonesOn.Size = new System.Drawing.Size(183, 35);
            this.btnSORTonesOn.TabIndex = 3;
            this.btnSORTonesOn.Tag = "SoRTonesOn";
            this.btnSORTonesOn.Text = "SoR Tones On";
            this.btnSORTonesOn.UseVisualStyleBackColor = true;
            this.btnSORTonesOn.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnSORTonesOff
            // 
            this.btnSORTonesOff.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSORTonesOff.Location = new System.Drawing.Point(578, 166);
            this.btnSORTonesOff.Margin = new System.Windows.Forms.Padding(4);
            this.btnSORTonesOff.Name = "btnSORTonesOff";
            this.btnSORTonesOff.Size = new System.Drawing.Size(183, 35);
            this.btnSORTonesOff.TabIndex = 3;
            this.btnSORTonesOff.Tag = "SoRTonesOff";
            this.btnSORTonesOff.Text = "SoR Tones Off";
            this.btnSORTonesOff.UseVisualStyleBackColor = true;
            this.btnSORTonesOff.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.Controls.Add(this.button47, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.button4, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.button5, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.button6, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.button7, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.button8, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.button9, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.button48, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.button46, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.button52, 3, 3);
            this.tableLayoutPanel5.Controls.Add(this.btnShutdownPC, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.nudShutdownPCDelay, 4, 2);
            this.tableLayoutPanel5.Controls.Add(this.label78, 5, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1152, 152);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // button47
            // 
            this.button47.Dock = System.Windows.Forms.DockStyle.Top;
            this.button47.Location = new System.Drawing.Point(2, 116);
            this.button47.Margin = new System.Windows.Forms.Padding(2);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(188, 32);
            this.button47.TabIndex = 2;
            this.button47.Tag = "NextTestSequence";
            this.button47.Text = "Next Test Sequence";
            this.button47.UseVisualStyleBackColor = true;
            this.button47.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(2, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 32);
            this.button1.TabIndex = 0;
            this.button1.Tag = "Connect";
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(194, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 32);
            this.button2.TabIndex = 0;
            this.button2.Tag = "Disconnect";
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(2, 40);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 32);
            this.button3.TabIndex = 0;
            this.button3.Tag = "Run";
            this.button3.Text = "Run";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(194, 40);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 32);
            this.button4.TabIndex = 0;
            this.button4.Tag = "Pause";
            this.button4.Text = "Pause";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(386, 40);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(188, 32);
            this.button5.TabIndex = 0;
            this.button5.Tag = "Continue";
            this.button5.Text = "Continue";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.Location = new System.Drawing.Point(578, 40);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(188, 32);
            this.button6.TabIndex = 0;
            this.button6.Tag = "Stop";
            this.button6.Text = "Stop";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.Location = new System.Drawing.Point(2, 78);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(188, 32);
            this.button7.TabIndex = 0;
            this.button7.Tag = "StartRecord";
            this.button7.Text = "Start Record";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.Location = new System.Drawing.Point(194, 78);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(188, 32);
            this.button8.TabIndex = 0;
            this.button8.Tag = "StopRecord";
            this.button8.Text = "Stop Record";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.Location = new System.Drawing.Point(386, 78);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(188, 32);
            this.button9.TabIndex = 0;
            this.button9.Tag = "SaveSignals";
            this.button9.Text = "Save Signals";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button48
            // 
            this.button48.Dock = System.Windows.Forms.DockStyle.Top;
            this.button48.Location = new System.Drawing.Point(194, 116);
            this.button48.Margin = new System.Windows.Forms.Padding(2);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(188, 32);
            this.button48.TabIndex = 3;
            this.button48.Tag = "StartTestSequence";
            this.button48.Text = "Start Test Sequence";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button46
            // 
            this.button46.Dock = System.Windows.Forms.DockStyle.Top;
            this.button46.Location = new System.Drawing.Point(386, 116);
            this.button46.Margin = new System.Windows.Forms.Padding(2);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(188, 32);
            this.button46.TabIndex = 1;
            this.button46.Tag = "PauseTestSequence";
            this.button46.Text = "Pause Test Sequence";
            this.button46.UseVisualStyleBackColor = true;
            this.button46.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button52
            // 
            this.button52.Dock = System.Windows.Forms.DockStyle.Top;
            this.button52.Location = new System.Drawing.Point(578, 116);
            this.button52.Margin = new System.Windows.Forms.Padding(2);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(188, 32);
            this.button52.TabIndex = 5;
            this.button52.Tag = "ResumeTestSequence";
            this.button52.Text = "Resume Test Sequence";
            this.button52.UseVisualStyleBackColor = true;
            this.button52.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnShutdownPC
            // 
            this.btnShutdownPC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShutdownPC.Location = new System.Drawing.Point(578, 78);
            this.btnShutdownPC.Margin = new System.Windows.Forms.Padding(2);
            this.btnShutdownPC.Name = "btnShutdownPC";
            this.btnShutdownPC.Size = new System.Drawing.Size(188, 32);
            this.btnShutdownPC.TabIndex = 4;
            this.btnShutdownPC.Tag = "ShutdownPC";
            this.btnShutdownPC.Text = "Shutdown PC";
            this.btnShutdownPC.UseVisualStyleBackColor = true;
            this.btnShutdownPC.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // nudShutdownPCDelay
            // 
            this.nudShutdownPCDelay.Location = new System.Drawing.Point(772, 82);
            this.nudShutdownPCDelay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.nudShutdownPCDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudShutdownPCDelay.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudShutdownPCDelay.Name = "nudShutdownPCDelay";
            this.nudShutdownPCDelay.Size = new System.Drawing.Size(183, 23);
            this.nudShutdownPCDelay.TabIndex = 7;
            this.nudShutdownPCDelay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(963, 84);
            this.label78.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(127, 15);
            this.label78.TabIndex = 8;
            this.label78.Text = "(Shutdown delay time)";
            // 
            // tabPageAdvTestCommand
            // 
            this.tabPageAdvTestCommand.Controls.Add(this.tableLayoutPanel19);
            this.tabPageAdvTestCommand.Location = new System.Drawing.Point(4, 41);
            this.tabPageAdvTestCommand.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAdvTestCommand.Name = "tabPageAdvTestCommand";
            this.tabPageAdvTestCommand.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAdvTestCommand.Size = new System.Drawing.Size(1156, 718);
            this.tabPageAdvTestCommand.TabIndex = 8;
            this.tabPageAdvTestCommand.Text = "Advanced Command";
            this.tabPageAdvTestCommand.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 4;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel19.Controls.Add(this.label53, 0, 5);
            this.tableLayoutPanel19.Controls.Add(this.label54, 0, 6);
            this.tableLayoutPanel19.Controls.Add(this.tbRandomProfilePath, 1, 5);
            this.tableLayoutPanel19.Controls.Add(this.tbSineProfilePath, 1, 6);
            this.tableLayoutPanel19.Controls.Add(this.label55, 0, 7);
            this.tableLayoutPanel19.Controls.Add(this.tbShockProfilePath, 1, 7);
            this.tableLayoutPanel19.Controls.Add(this.btnBrowseRandomProfile, 2, 5);
            this.tableLayoutPanel19.Controls.Add(this.btnBrowseSineProfile, 2, 6);
            this.tableLayoutPanel19.Controls.Add(this.btnBrowseShockProfile, 2, 7);
            this.tableLayoutPanel19.Controls.Add(this.btnSetRandomProfile, 3, 5);
            this.tableLayoutPanel19.Controls.Add(this.btnSetSineProfile, 3, 6);
            this.tableLayoutPanel19.Controls.Add(this.btnSetShockProfile, 3, 7);
            this.tableLayoutPanel19.Controls.Add(this.label56, 0, 1);
            this.tableLayoutPanel19.Controls.Add(this.tbChannelTablePath, 1, 1);
            this.tableLayoutPanel19.Controls.Add(this.btnBrowseChannelTable, 2, 1);
            this.tableLayoutPanel19.Controls.Add(this.btnSetChannelTable, 3, 1);
            this.tableLayoutPanel19.Controls.Add(this.label57, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.label58, 0, 4);
            this.tableLayoutPanel19.Controls.Add(this.label68, 0, 2);
            this.tableLayoutPanel19.Controls.Add(this.label69, 0, 3);
            this.tableLayoutPanel19.Controls.Add(this.tbSchedulePath, 1, 3);
            this.tableLayoutPanel19.Controls.Add(this.btnBrowseSchedule, 2, 3);
            this.tableLayoutPanel19.Controls.Add(this.btnSetSchedule, 3, 3);
            this.tableLayoutPanel19.Controls.Add(this.label80, 0, 8);
            this.tableLayoutPanel19.Controls.Add(this.label81, 0, 9);
            this.tableLayoutPanel19.Controls.Add(this.flowLayoutPanel13, 1, 9);
            this.tableLayoutPanel19.Controls.Add(this.btnSetNTP, 3, 9);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel19.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 10;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.Size = new System.Drawing.Size(1148, 710);
            this.tableLayoutPanel19.TabIndex = 0;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(4, 151);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(108, 15);
            this.label53.TabIndex = 0;
            this.label53.Text = "Set Random Profile";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(4, 188);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(85, 15);
            this.label54.TabIndex = 0;
            this.label54.Text = "Set Sine Profile";
            // 
            // tbRandomProfilePath
            // 
            this.tbRandomProfilePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbRandomProfilePath.Location = new System.Drawing.Point(120, 151);
            this.tbRandomProfilePath.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.tbRandomProfilePath.Name = "tbRandomProfilePath";
            this.tbRandomProfilePath.Size = new System.Drawing.Size(832, 23);
            this.tbRandomProfilePath.TabIndex = 1;
            // 
            // tbSineProfilePath
            // 
            this.tbSineProfilePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSineProfilePath.Location = new System.Drawing.Point(120, 188);
            this.tbSineProfilePath.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.tbSineProfilePath.Name = "tbSineProfilePath";
            this.tbSineProfilePath.Size = new System.Drawing.Size(832, 23);
            this.tbSineProfilePath.TabIndex = 1;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(4, 225);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(95, 15);
            this.label55.TabIndex = 0;
            this.label55.Text = "Set Shock Profile";
            // 
            // tbShockProfilePath
            // 
            this.tbShockProfilePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbShockProfilePath.Location = new System.Drawing.Point(120, 225);
            this.tbShockProfilePath.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.tbShockProfilePath.Name = "tbShockProfilePath";
            this.tbShockProfilePath.Size = new System.Drawing.Size(832, 23);
            this.tbShockProfilePath.TabIndex = 1;
            // 
            // btnBrowseRandomProfile
            // 
            this.btnBrowseRandomProfile.Location = new System.Drawing.Point(960, 147);
            this.btnBrowseRandomProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseRandomProfile.Name = "btnBrowseRandomProfile";
            this.btnBrowseRandomProfile.Size = new System.Drawing.Size(88, 29);
            this.btnBrowseRandomProfile.TabIndex = 2;
            this.btnBrowseRandomProfile.Text = "Browse";
            this.btnBrowseRandomProfile.UseVisualStyleBackColor = true;
            this.btnBrowseRandomProfile.Click += new System.EventHandler(this.OnBrowseProfile);
            // 
            // btnBrowseSineProfile
            // 
            this.btnBrowseSineProfile.Location = new System.Drawing.Point(960, 184);
            this.btnBrowseSineProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseSineProfile.Name = "btnBrowseSineProfile";
            this.btnBrowseSineProfile.Size = new System.Drawing.Size(88, 29);
            this.btnBrowseSineProfile.TabIndex = 2;
            this.btnBrowseSineProfile.Text = "Browse";
            this.btnBrowseSineProfile.UseVisualStyleBackColor = true;
            this.btnBrowseSineProfile.Click += new System.EventHandler(this.OnBrowseProfile);
            // 
            // btnBrowseShockProfile
            // 
            this.btnBrowseShockProfile.Location = new System.Drawing.Point(960, 221);
            this.btnBrowseShockProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseShockProfile.Name = "btnBrowseShockProfile";
            this.btnBrowseShockProfile.Size = new System.Drawing.Size(88, 29);
            this.btnBrowseShockProfile.TabIndex = 2;
            this.btnBrowseShockProfile.Text = "Browse";
            this.btnBrowseShockProfile.UseVisualStyleBackColor = true;
            this.btnBrowseShockProfile.Click += new System.EventHandler(this.OnBrowseProfile);
            // 
            // btnSetRandomProfile
            // 
            this.btnSetRandomProfile.Location = new System.Drawing.Point(1056, 147);
            this.btnSetRandomProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetRandomProfile.Name = "btnSetRandomProfile";
            this.btnSetRandomProfile.Size = new System.Drawing.Size(88, 29);
            this.btnSetRandomProfile.TabIndex = 2;
            this.btnSetRandomProfile.Text = "Set";
            this.btnSetRandomProfile.UseVisualStyleBackColor = true;
            this.btnSetRandomProfile.Click += new System.EventHandler(this.OnAdvancedCommand);
            // 
            // btnSetSineProfile
            // 
            this.btnSetSineProfile.Location = new System.Drawing.Point(1056, 184);
            this.btnSetSineProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetSineProfile.Name = "btnSetSineProfile";
            this.btnSetSineProfile.Size = new System.Drawing.Size(88, 29);
            this.btnSetSineProfile.TabIndex = 2;
            this.btnSetSineProfile.Text = "Set";
            this.btnSetSineProfile.UseVisualStyleBackColor = true;
            this.btnSetSineProfile.Click += new System.EventHandler(this.OnAdvancedCommand);
            // 
            // btnSetShockProfile
            // 
            this.btnSetShockProfile.Location = new System.Drawing.Point(1056, 221);
            this.btnSetShockProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetShockProfile.Name = "btnSetShockProfile";
            this.btnSetShockProfile.Size = new System.Drawing.Size(88, 29);
            this.btnSetShockProfile.TabIndex = 2;
            this.btnSetShockProfile.Text = "Set";
            this.btnSetShockProfile.UseVisualStyleBackColor = true;
            this.btnSetShockProfile.Click += new System.EventHandler(this.OnAdvancedCommand);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(4, 31);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(100, 15);
            this.label56.TabIndex = 0;
            this.label56.Text = "Set Channel Table";
            // 
            // tbChannelTablePath
            // 
            this.tbChannelTablePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbChannelTablePath.Location = new System.Drawing.Point(120, 31);
            this.tbChannelTablePath.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.tbChannelTablePath.Name = "tbChannelTablePath";
            this.tbChannelTablePath.Size = new System.Drawing.Size(832, 23);
            this.tbChannelTablePath.TabIndex = 3;
            // 
            // btnBrowseChannelTable
            // 
            this.btnBrowseChannelTable.Location = new System.Drawing.Point(960, 27);
            this.btnBrowseChannelTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseChannelTable.Name = "btnBrowseChannelTable";
            this.btnBrowseChannelTable.Size = new System.Drawing.Size(88, 29);
            this.btnBrowseChannelTable.TabIndex = 2;
            this.btnBrowseChannelTable.Text = "Browse";
            this.btnBrowseChannelTable.UseVisualStyleBackColor = true;
            this.btnBrowseChannelTable.Click += new System.EventHandler(this.OnBrowseProfile);
            // 
            // btnSetChannelTable
            // 
            this.btnSetChannelTable.Location = new System.Drawing.Point(1056, 27);
            this.btnSetChannelTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetChannelTable.Name = "btnSetChannelTable";
            this.btnSetChannelTable.Size = new System.Drawing.Size(88, 29);
            this.btnSetChannelTable.TabIndex = 2;
            this.btnSetChannelTable.Text = "Set";
            this.btnSetChannelTable.UseVisualStyleBackColor = true;
            this.btnSetChannelTable.Click += new System.EventHandler(this.OnAdvancedCommand);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.label57, 2);
            this.label57.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(4, 8);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(604, 15);
            this.label57.TabIndex = 0;
            this.label57.Text = "Set Channel Table Advanced Command(Select a CSV file which exported by EDM input " +
    "channel setup dialog)";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.label58, 2);
            this.label58.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(4, 128);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(453, 15);
            this.label58.TabIndex = 0;
            this.label58.Text = "VCS Advanced Command(Select a CSV file which exported by VCS profile editor)";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.label68, 2);
            this.label68.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(4, 68);
            this.label68.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(557, 15);
            this.label68.TabIndex = 0;
            this.label68.Text = "Set Schedule Advanced Command(Select a Json file which exported by EDM Schedule s" +
    "etup dialog)";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(4, 91);
            this.label69.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(74, 15);
            this.label69.TabIndex = 0;
            this.label69.Text = "Set Schedule";
            // 
            // tbSchedulePath
            // 
            this.tbSchedulePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSchedulePath.Location = new System.Drawing.Point(120, 91);
            this.tbSchedulePath.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.tbSchedulePath.Name = "tbSchedulePath";
            this.tbSchedulePath.Size = new System.Drawing.Size(832, 23);
            this.tbSchedulePath.TabIndex = 3;
            // 
            // btnBrowseSchedule
            // 
            this.btnBrowseSchedule.Location = new System.Drawing.Point(960, 87);
            this.btnBrowseSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseSchedule.Name = "btnBrowseSchedule";
            this.btnBrowseSchedule.Size = new System.Drawing.Size(88, 29);
            this.btnBrowseSchedule.TabIndex = 2;
            this.btnBrowseSchedule.Text = "Browse";
            this.btnBrowseSchedule.UseVisualStyleBackColor = true;
            this.btnBrowseSchedule.Click += new System.EventHandler(this.OnBrowseProfile);
            // 
            // btnSetSchedule
            // 
            this.btnSetSchedule.Location = new System.Drawing.Point(1056, 87);
            this.btnSetSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetSchedule.Name = "btnSetSchedule";
            this.btnSetSchedule.Size = new System.Drawing.Size(88, 29);
            this.btnSetSchedule.TabIndex = 2;
            this.btnSetSchedule.Text = "Set";
            this.btnSetSchedule.UseVisualStyleBackColor = true;
            this.btnSetSchedule.Click += new System.EventHandler(this.OnAdvancedCommand);
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.label80, 3);
            this.label80.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.Location = new System.Drawing.Point(4, 262);
            this.label80.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(201, 15);
            this.label80.TabIndex = 0;
            this.label80.Text = "Set NTP Server,Port,Synch interval";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(4, 285);
            this.label81.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(64, 15);
            this.label81.TabIndex = 0;
            this.label81.Text = "NPT Server";
            // 
            // flowLayoutPanel13
            // 
            this.flowLayoutPanel13.AutoSize = true;
            this.flowLayoutPanel13.Controls.Add(this.tbNTPServer);
            this.flowLayoutPanel13.Controls.Add(this.label83);
            this.flowLayoutPanel13.Controls.Add(this.nudNTPPort);
            this.flowLayoutPanel13.Controls.Add(this.label84);
            this.flowLayoutPanel13.Controls.Add(this.nudNTPSynchInterval);
            this.flowLayoutPanel13.Controls.Add(this.label85);
            this.flowLayoutPanel13.Controls.Add(this.lblNTPTime);
            this.flowLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel13.Location = new System.Drawing.Point(116, 277);
            this.flowLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel13.Name = "flowLayoutPanel13";
            this.flowLayoutPanel13.Size = new System.Drawing.Size(840, 29);
            this.flowLayoutPanel13.TabIndex = 4;
            // 
            // tbNTPServer
            // 
            this.tbNTPServer.Location = new System.Drawing.Point(3, 3);
            this.tbNTPServer.Name = "tbNTPServer";
            this.tbNTPServer.Size = new System.Drawing.Size(284, 23);
            this.tbNTPServer.TabIndex = 1;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(294, 8);
            this.label83.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(54, 15);
            this.label83.TabIndex = 0;
            this.label83.Text = "NPT Port";
            // 
            // nudNTPPort
            // 
            this.nudNTPPort.Location = new System.Drawing.Point(355, 3);
            this.nudNTPPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudNTPPort.Name = "nudNTPPort";
            this.nudNTPPort.Size = new System.Drawing.Size(78, 23);
            this.nudNTPPort.TabIndex = 2;
            this.nudNTPPort.Value = new decimal(new int[] {
            123,
            0,
            0,
            0});
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(440, 8);
            this.label84.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(81, 15);
            this.label84.TabIndex = 0;
            this.label84.Text = "Synch interval";
            // 
            // nudNTPSynchInterval
            // 
            this.nudNTPSynchInterval.Location = new System.Drawing.Point(528, 3);
            this.nudNTPSynchInterval.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudNTPSynchInterval.Name = "nudNTPSynchInterval";
            this.nudNTPSynchInterval.Size = new System.Drawing.Size(78, 23);
            this.nudNTPSynchInterval.TabIndex = 2;
            this.nudNTPSynchInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(613, 8);
            this.label85.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(20, 15);
            this.label85.TabIndex = 0;
            this.label85.Text = "(s)";
            // 
            // btnSetNTP
            // 
            this.btnSetNTP.Location = new System.Drawing.Point(1056, 281);
            this.btnSetNTP.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetNTP.Name = "btnSetNTP";
            this.btnSetNTP.Size = new System.Drawing.Size(88, 29);
            this.btnSetNTP.TabIndex = 2;
            this.btnSetNTP.Tag = "SetNTP";
            this.btnSetNTP.Text = "Set";
            this.btnSetNTP.UseVisualStyleBackColor = true;
            this.btnSetNTP.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // tabPageDetailStatus
            // 
            this.tabPageDetailStatus.Controls.Add(this.tableLayoutPanel8);
            this.tabPageDetailStatus.Location = new System.Drawing.Point(4, 41);
            this.tabPageDetailStatus.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageDetailStatus.Name = "tabPageDetailStatus";
            this.tabPageDetailStatus.Size = new System.Drawing.Size(1156, 718);
            this.tabPageDetailStatus.TabIndex = 5;
            this.tabPageDetailStatus.Text = "Detail Status";
            this.tabPageDetailStatus.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.button18, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.lvDetailStatus, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1156, 718);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(4, 4);
            this.button18.Margin = new System.Windows.Forms.Padding(4);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(212, 32);
            this.button18.TabIndex = 1;
            this.button18.Tag = "RequestDetailStatus";
            this.button18.Text = "Get Test Detail Status";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // lvDetailStatus
            // 
            this.lvDetailStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16});
            this.lvDetailStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetailStatus.FullRowSelect = true;
            this.lvDetailStatus.HideSelection = false;
            this.lvDetailStatus.Location = new System.Drawing.Point(2, 42);
            this.lvDetailStatus.Margin = new System.Windows.Forms.Padding(2);
            this.lvDetailStatus.Name = "lvDetailStatus";
            this.lvDetailStatus.Size = new System.Drawing.Size(1152, 674);
            this.lvDetailStatus.TabIndex = 0;
            this.lvDetailStatus.UseCompatibleStateImageBehavior = false;
            this.lvDetailStatus.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Name";
            this.columnHeader15.Width = 200;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Value";
            this.columnHeader16.Width = 200;
            // 
            // tabPageChannels
            // 
            this.tabPageChannels.Controls.Add(this.tableLayoutPanel23);
            this.tabPageChannels.Location = new System.Drawing.Point(4, 41);
            this.tabPageChannels.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageChannels.Name = "tabPageChannels";
            this.tabPageChannels.Size = new System.Drawing.Size(1156, 718);
            this.tabPageChannels.TabIndex = 4;
            this.tabPageChannels.Text = "Channels";
            this.tabPageChannels.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.ColumnCount = 1;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.Controls.Add(this.lvChannelTable, 0, 1);
            this.tableLayoutPanel23.Controls.Add(this.flowLayoutPanel12, 0, 0);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 2;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(1156, 718);
            this.tableLayoutPanel23.TabIndex = 1;
            // 
            // lvChannelTable
            // 
            this.lvChannelTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31});
            this.lvChannelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChannelTable.FullRowSelect = true;
            this.lvChannelTable.HideSelection = false;
            this.lvChannelTable.Location = new System.Drawing.Point(2, 31);
            this.lvChannelTable.Margin = new System.Windows.Forms.Padding(2);
            this.lvChannelTable.Name = "lvChannelTable";
            this.lvChannelTable.Size = new System.Drawing.Size(1152, 685);
            this.lvChannelTable.TabIndex = 0;
            this.lvChannelTable.UseCompatibleStateImageBehavior = false;
            this.lvChannelTable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Module";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Location ID";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Enable";
            this.columnHeader7.Width = 50;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Quantity";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Unit";
            this.columnHeader9.Width = 50;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Senstitivity";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Input Mode";
            this.columnHeader11.Width = 140;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Input Range";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "High Pass Frequency";
            this.columnHeader29.Width = 140;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Integration";
            this.columnHeader30.Width = 80;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Control Weighting";
            this.columnHeader31.Width = 120;
            // 
            // flowLayoutPanel12
            // 
            this.flowLayoutPanel12.AutoSize = true;
            this.flowLayoutPanel12.Controls.Add(this.label79);
            this.flowLayoutPanel12.Controls.Add(this.cbxInputRange);
            this.flowLayoutPanel12.Controls.Add(this.label82);
            this.flowLayoutPanel12.Controls.Add(this.nudChannelIndex);
            this.flowLayoutPanel12.Controls.Add(this.btnSetInputRange);
            this.flowLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel12.Name = "flowLayoutPanel12";
            this.flowLayoutPanel12.Size = new System.Drawing.Size(609, 29);
            this.flowLayoutPanel12.TabIndex = 1;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(3, 8);
            this.label79.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(71, 15);
            this.label79.TabIndex = 0;
            this.label79.Text = "Input Range";
            // 
            // cbxInputRange
            // 
            this.cbxInputRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInputRange.FormattingEnabled = true;
            this.cbxInputRange.Items.AddRange(new object[] {
            " AutoRange",
            " FullRange",
            " SmallRange",
            " Range_10mV",
            " Range_5mV",
            " Range_100mV",
            " Range_1V",
            " Range_10V",
            " Range_50mV"});
            this.cbxInputRange.Location = new System.Drawing.Point(80, 3);
            this.cbxInputRange.Name = "cbxInputRange";
            this.cbxInputRange.Size = new System.Drawing.Size(154, 23);
            this.cbxInputRange.TabIndex = 1;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(240, 8);
            this.label82.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(83, 15);
            this.label82.TabIndex = 0;
            this.label82.Text = "Channel Index";
            // 
            // nudChannelIndex
            // 
            this.nudChannelIndex.Location = new System.Drawing.Point(329, 3);
            this.nudChannelIndex.Name = "nudChannelIndex";
            this.nudChannelIndex.Size = new System.Drawing.Size(120, 23);
            this.nudChannelIndex.TabIndex = 3;
            // 
            // btnSetInputRange
            // 
            this.btnSetInputRange.Location = new System.Drawing.Point(455, 3);
            this.btnSetInputRange.Name = "btnSetInputRange";
            this.btnSetInputRange.Size = new System.Drawing.Size(151, 23);
            this.btnSetInputRange.TabIndex = 2;
            this.btnSetInputRange.Tag = "SetInputRange";
            this.btnSetInputRange.Text = "Set Input Range";
            this.btnSetInputRange.UseVisualStyleBackColor = true;
            this.btnSetInputRange.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // tabPageChannelStatus
            // 
            this.tabPageChannelStatus.Controls.Add(this.tableLayoutPanel22);
            this.tabPageChannelStatus.Location = new System.Drawing.Point(4, 41);
            this.tabPageChannelStatus.Name = "tabPageChannelStatus";
            this.tabPageChannelStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChannelStatus.Size = new System.Drawing.Size(1156, 718);
            this.tabPageChannelStatus.TabIndex = 11;
            this.tabPageChannelStatus.Text = "Channel Status";
            this.tabPageChannelStatus.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.ColumnCount = 1;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel22.Controls.Add(this.lvChannelStatus, 0, 1);
            this.tableLayoutPanel22.Controls.Add(this.button49, 0, 0);
            this.tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel22.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel22.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 2;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(1150, 712);
            this.tableLayoutPanel22.TabIndex = 3;
            // 
            // lvChannelStatus
            // 
            this.lvChannelStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader50,
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader54,
            this.columnHeader55,
            this.columnHeader56,
            this.columnHeader57,
            this.columnHeader58,
            this.columnHeader59});
            this.lvChannelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChannelStatus.FullRowSelect = true;
            this.lvChannelStatus.HideSelection = false;
            this.lvChannelStatus.Location = new System.Drawing.Point(2, 42);
            this.lvChannelStatus.Margin = new System.Windows.Forms.Padding(2);
            this.lvChannelStatus.Name = "lvChannelStatus";
            this.lvChannelStatus.Size = new System.Drawing.Size(1146, 668);
            this.lvChannelStatus.TabIndex = 2;
            this.lvChannelStatus.UseCompatibleStateImageBehavior = false;
            this.lvChannelStatus.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "Location ID";
            this.columnHeader50.Width = 140;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "Min";
            this.columnHeader52.Width = 80;
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "Max";
            this.columnHeader53.Width = 80;
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "Peak";
            this.columnHeader54.Width = 80;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "RMS";
            this.columnHeader55.Width = 80;
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "Average";
            this.columnHeader56.Width = 80;
            // 
            // columnHeader57
            // 
            this.columnHeader57.Text = "Is IEPE";
            this.columnHeader57.Width = 80;
            // 
            // columnHeader58
            // 
            this.columnHeader58.Text = "Is Overload";
            this.columnHeader58.Width = 100;
            // 
            // columnHeader59
            // 
            this.columnHeader59.Text = "Is SG Not Connected";
            this.columnHeader59.Width = 130;
            // 
            // button49
            // 
            this.button49.Location = new System.Drawing.Point(4, 4);
            this.button49.Margin = new System.Windows.Forms.Padding(4);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(212, 32);
            this.button49.TabIndex = 1;
            this.button49.Tag = "RequestChannelStatus";
            this.button49.Text = "Get Channel Status";
            this.button49.UseVisualStyleBackColor = true;
            this.button49.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // tabPageParameters
            // 
            this.tabPageParameters.Controls.Add(this.tableLayoutPanel9);
            this.tabPageParameters.Location = new System.Drawing.Point(4, 41);
            this.tabPageParameters.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageParameters.Name = "tabPageParameters";
            this.tabPageParameters.Size = new System.Drawing.Size(1156, 718);
            this.tabPageParameters.TabIndex = 3;
            this.tabPageParameters.Text = "Parameters";
            this.tabPageParameters.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 4;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.tbParameterValue, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.lvParameters, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblParameterName, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnSetParameter, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnListParameter, 3, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1156, 718);
            this.tableLayoutPanel9.TabIndex = 2;
            // 
            // tbParameterValue
            // 
            this.tbParameterValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbParameterValue.Location = new System.Drawing.Point(304, 8);
            this.tbParameterValue.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.tbParameterValue.Name = "tbParameterValue";
            this.tbParameterValue.Size = new System.Drawing.Size(132, 23);
            this.tbParameterValue.TabIndex = 3;
            this.tbParameterValue.Visible = false;
            // 
            // lvParameters
            // 
            this.lvParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader43});
            this.tableLayoutPanel9.SetColumnSpan(this.lvParameters, 4);
            this.lvParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvParameters.FullRowSelect = true;
            this.lvParameters.HideSelection = false;
            this.lvParameters.Location = new System.Drawing.Point(2, 39);
            this.lvParameters.Margin = new System.Windows.Forms.Padding(2);
            this.lvParameters.Name = "lvParameters";
            this.lvParameters.Size = new System.Drawing.Size(1152, 677);
            this.lvParameters.TabIndex = 1;
            this.lvParameters.UseCompatibleStateImageBehavior = false;
            this.lvParameters.View = System.Windows.Forms.View.Details;
            this.lvParameters.SelectedIndexChanged += new System.EventHandler(this.OnParametersSelectedIndexChanged);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Name";
            this.columnHeader13.Width = 200;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Value";
            this.columnHeader14.Width = 200;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "Description";
            this.columnHeader43.Width = 600;
            // 
            // lblParameterName
            // 
            this.lblParameterName.AutoSize = true;
            this.lblParameterName.Location = new System.Drawing.Point(3, 8);
            this.lblParameterName.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblParameterName.Name = "lblParameterName";
            this.lblParameterName.Size = new System.Drawing.Size(109, 15);
            this.lblParameterName.TabIndex = 2;
            this.lblParameterName.Text = "<ParameterName>";
            this.lblParameterName.Visible = false;
            // 
            // btnSetParameter
            // 
            this.btnSetParameter.Location = new System.Drawing.Point(444, 4);
            this.btnSetParameter.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetParameter.Name = "btnSetParameter";
            this.btnSetParameter.Size = new System.Drawing.Size(153, 29);
            this.btnSetParameter.TabIndex = 4;
            this.btnSetParameter.Tag = "SetParameter";
            this.btnSetParameter.Text = "Set Parameter";
            this.btnSetParameter.UseVisualStyleBackColor = true;
            this.btnSetParameter.Visible = false;
            this.btnSetParameter.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnListParameter
            // 
            this.btnListParameter.Location = new System.Drawing.Point(605, 4);
            this.btnListParameter.Margin = new System.Windows.Forms.Padding(4);
            this.btnListParameter.Name = "btnListParameter";
            this.btnListParameter.Size = new System.Drawing.Size(153, 29);
            this.btnListParameter.TabIndex = 4;
            this.btnListParameter.Tag = "ListParameters";
            this.btnListParameter.Text = "List Parameters";
            this.btnListParameter.UseVisualStyleBackColor = true;
            this.btnListParameter.Visible = false;
            this.btnListParameter.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // tabShaker
            // 
            this.tabShaker.Controls.Add(this.lvShaker);
            this.tabShaker.Location = new System.Drawing.Point(4, 41);
            this.tabShaker.Name = "tabShaker";
            this.tabShaker.Padding = new System.Windows.Forms.Padding(3);
            this.tabShaker.Size = new System.Drawing.Size(1156, 718);
            this.tabShaker.TabIndex = 10;
            this.tabShaker.Text = "Shaker";
            this.tabShaker.UseVisualStyleBackColor = true;
            // 
            // lvShaker
            // 
            this.lvShaker.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46});
            this.lvShaker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShaker.FullRowSelect = true;
            this.lvShaker.HideSelection = false;
            this.lvShaker.Location = new System.Drawing.Point(3, 3);
            this.lvShaker.Margin = new System.Windows.Forms.Padding(2);
            this.lvShaker.Name = "lvShaker";
            this.lvShaker.Size = new System.Drawing.Size(1150, 712);
            this.lvShaker.TabIndex = 2;
            this.lvShaker.UseCompatibleStateImageBehavior = false;
            this.lvShaker.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "Name";
            this.columnHeader44.Width = 200;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "Value";
            this.columnHeader45.Width = 200;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "Description";
            this.columnHeader46.Width = 600;
            // 
            // tabPageTestManager
            // 
            this.tabPageTestManager.Controls.Add(this.tableLayoutPanel10);
            this.tabPageTestManager.Location = new System.Drawing.Point(4, 41);
            this.tabPageTestManager.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageTestManager.Name = "tabPageTestManager";
            this.tabPageTestManager.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageTestManager.Size = new System.Drawing.Size(1156, 718);
            this.tabPageTestManager.TabIndex = 2;
            this.tabPageTestManager.Text = "List/Create/Load/Delete";
            this.tabPageTestManager.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 5;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.Controls.Add(this.lvTests, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.button29, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnLoadTest, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnDeleteTest, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 4, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(1152, 714);
            this.tableLayoutPanel10.TabIndex = 2;
            // 
            // lvTests
            // 
            this.lvTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18});
            this.tableLayoutPanel10.SetColumnSpan(this.lvTests, 4);
            this.lvTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTests.FullRowSelect = true;
            this.lvTests.HideSelection = false;
            this.lvTests.Location = new System.Drawing.Point(4, 41);
            this.lvTests.Margin = new System.Windows.Forms.Padding(4);
            this.lvTests.MultiSelect = false;
            this.lvTests.Name = "lvTests";
            this.lvTests.Size = new System.Drawing.Size(928, 669);
            this.lvTests.TabIndex = 1;
            this.lvTests.UseCompatibleStateImageBehavior = false;
            this.lvTests.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Name";
            this.columnHeader17.Width = 200;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Type";
            this.columnHeader18.Width = 200;
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(4, 4);
            this.button29.Margin = new System.Windows.Forms.Padding(4);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(88, 29);
            this.button29.TabIndex = 0;
            this.button29.Tag = "ListTest";
            this.button29.Text = "List Test";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnLoadTest
            // 
            this.btnLoadTest.Location = new System.Drawing.Point(100, 4);
            this.btnLoadTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadTest.Name = "btnLoadTest";
            this.btnLoadTest.Size = new System.Drawing.Size(88, 29);
            this.btnLoadTest.TabIndex = 0;
            this.btnLoadTest.Tag = "LoadTest";
            this.btnLoadTest.Text = "Load Test";
            this.btnLoadTest.UseVisualStyleBackColor = true;
            this.btnLoadTest.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnDeleteTest
            // 
            this.btnDeleteTest.Location = new System.Drawing.Point(196, 4);
            this.btnDeleteTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteTest.Name = "btnDeleteTest";
            this.btnDeleteTest.Size = new System.Drawing.Size(88, 29);
            this.btnDeleteTest.TabIndex = 0;
            this.btnDeleteTest.Tag = "DeleteTest";
            this.btnDeleteTest.Text = "Delete Test";
            this.btnDeleteTest.UseVisualStyleBackColor = true;
            this.btnDeleteTest.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.label24, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.label25, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.tbCreateTestName, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.btnCreatTest, 0, 4);
            this.tableLayoutPanel11.Controls.Add(this.cbxCreateTestType, 0, 3);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(940, 4);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 5;
            this.tableLayoutPanel10.SetRowSpan(this.tableLayoutPanel11, 2);
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.Size = new System.Drawing.Size(208, 706);
            this.tableLayoutPanel11.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 6);
            this.label24.Margin = new System.Windows.Forms.Padding(6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 15);
            this.label24.TabIndex = 0;
            this.label24.Text = "Test Name";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 62);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 15);
            this.label25.TabIndex = 0;
            this.label25.Text = "Test Type";
            // 
            // tbCreateTestName
            // 
            this.tbCreateTestName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCreateTestName.Location = new System.Drawing.Point(6, 33);
            this.tbCreateTestName.Margin = new System.Windows.Forms.Padding(6);
            this.tbCreateTestName.Name = "tbCreateTestName";
            this.tbCreateTestName.Size = new System.Drawing.Size(196, 23);
            this.tbCreateTestName.TabIndex = 1;
            // 
            // btnCreatTest
            // 
            this.btnCreatTest.Location = new System.Drawing.Point(6, 114);
            this.btnCreatTest.Margin = new System.Windows.Forms.Padding(6);
            this.btnCreatTest.Name = "btnCreatTest";
            this.btnCreatTest.Size = new System.Drawing.Size(88, 29);
            this.btnCreatTest.TabIndex = 2;
            this.btnCreatTest.Tag = "CreateTest";
            this.btnCreatTest.Text = "Create Test";
            this.btnCreatTest.UseVisualStyleBackColor = true;
            this.btnCreatTest.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // cbxCreateTestType
            // 
            this.cbxCreateTestType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxCreateTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCreateTestType.FormattingEnabled = true;
            this.cbxCreateTestType.Location = new System.Drawing.Point(4, 81);
            this.cbxCreateTestType.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCreateTestType.Name = "cbxCreateTestType";
            this.cbxCreateTestType.Size = new System.Drawing.Size(200, 23);
            this.cbxCreateTestType.TabIndex = 3;
            // 
            // tabPageTHStatus
            // 
            this.tabPageTHStatus.Controls.Add(this.lvTHStatus);
            this.tabPageTHStatus.Location = new System.Drawing.Point(4, 41);
            this.tabPageTHStatus.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageTHStatus.Name = "tabPageTHStatus";
            this.tabPageTHStatus.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageTHStatus.Size = new System.Drawing.Size(1156, 718);
            this.tabPageTHStatus.TabIndex = 6;
            this.tabPageTHStatus.Text = "TH Status";
            this.tabPageTHStatus.UseVisualStyleBackColor = true;
            // 
            // lvTHStatus
            // 
            this.lvTHStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader32,
            this.columnHeader33});
            this.lvTHStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTHStatus.FullRowSelect = true;
            this.lvTHStatus.HideSelection = false;
            this.lvTHStatus.Location = new System.Drawing.Point(4, 4);
            this.lvTHStatus.Margin = new System.Windows.Forms.Padding(2);
            this.lvTHStatus.Name = "lvTHStatus";
            this.lvTHStatus.Size = new System.Drawing.Size(1148, 710);
            this.lvTHStatus.TabIndex = 1;
            this.lvTHStatus.UseCompatibleStateImageBehavior = false;
            this.lvTHStatus.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Name";
            this.columnHeader32.Width = 200;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "Value";
            this.columnHeader33.Width = 200;
            // 
            // tabPageOutput
            // 
            this.tabPageOutput.Controls.Add(this.tableLayoutPanel18);
            this.tabPageOutput.Location = new System.Drawing.Point(4, 41);
            this.tabPageOutput.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageOutput.Name = "tabPageOutput";
            this.tabPageOutput.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageOutput.Size = new System.Drawing.Size(1156, 718);
            this.tabPageOutput.TabIndex = 7;
            this.tabPageOutput.Text = "Output";
            this.tabPageOutput.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 4;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel18.Controls.Add(this.flowLayoutPanel3, 1, 2);
            this.tableLayoutPanel18.Controls.Add(this.nudOutputIndex, 2, 1);
            this.tableLayoutPanel18.Controls.Add(this.flowLayoutPanel4, 2, 2);
            this.tableLayoutPanel18.Controls.Add(this.flowLayoutPanel5, 3, 2);
            this.tableLayoutPanel18.Controls.Add(this.flowLayoutPanel6, 0, 3);
            this.tableLayoutPanel18.Controls.Add(this.flowLayoutPanel7, 1, 3);
            this.tableLayoutPanel18.Controls.Add(this.flowLayoutPanel8, 2, 3);
            this.tableLayoutPanel18.Controls.Add(this.flowLayoutPanel9, 3, 3);
            this.tableLayoutPanel18.Controls.Add(this.btnSetOutputParameters, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.button50, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.button51, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.btnSetOutputIndex, 1, 1);
            this.tableLayoutPanel18.Controls.Add(this.label52, 2, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 4;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(1148, 710);
            this.tableLayoutPanel18.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.cbOutputSine);
            this.flowLayoutPanel2.Controls.Add(this.label28);
            this.flowLayoutPanel2.Controls.Add(this.nudSineAmp);
            this.flowLayoutPanel2.Controls.Add(this.label30);
            this.flowLayoutPanel2.Controls.Add(this.nudSineFreq);
            this.flowLayoutPanel2.Controls.Add(this.label33);
            this.flowLayoutPanel2.Controls.Add(this.nudSineOffset);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 90);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(279, 241);
            this.flowLayoutPanel2.TabIndex = 5;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // cbOutputSine
            // 
            this.cbOutputSine.AutoSize = true;
            this.cbOutputSine.Checked = true;
            this.cbOutputSine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOutputSine.Location = new System.Drawing.Point(4, 4);
            this.cbOutputSine.Margin = new System.Windows.Forms.Padding(4);
            this.cbOutputSine.Name = "cbOutputSine";
            this.cbOutputSine.Size = new System.Drawing.Size(48, 19);
            this.cbOutputSine.TabIndex = 0;
            this.cbOutputSine.Tag = "Sine";
            this.cbOutputSine.Text = "Sine";
            this.cbOutputSine.UseVisualStyleBackColor = true;
            this.cbOutputSine.CheckedChanged += new System.EventHandler(this.OnOutputTypeCheckedChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(4, 27);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 15);
            this.label28.TabIndex = 1;
            this.label28.Text = "Amplitude";
            // 
            // nudSineAmp
            // 
            this.nudSineAmp.DecimalPlaces = 3;
            this.nudSineAmp.Location = new System.Drawing.Point(4, 46);
            this.nudSineAmp.Margin = new System.Windows.Forms.Padding(4);
            this.nudSineAmp.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSineAmp.Name = "nudSineAmp";
            this.nudSineAmp.Size = new System.Drawing.Size(140, 23);
            this.nudSineAmp.TabIndex = 2;
            this.nudSineAmp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(4, 73);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(62, 15);
            this.label30.TabIndex = 1;
            this.label30.Text = "Frequency";
            // 
            // nudSineFreq
            // 
            this.nudSineFreq.DecimalPlaces = 3;
            this.nudSineFreq.Location = new System.Drawing.Point(4, 92);
            this.nudSineFreq.Margin = new System.Windows.Forms.Padding(4);
            this.nudSineFreq.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSineFreq.Name = "nudSineFreq";
            this.nudSineFreq.Size = new System.Drawing.Size(140, 23);
            this.nudSineFreq.TabIndex = 2;
            this.nudSineFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(4, 119);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(39, 15);
            this.label33.TabIndex = 1;
            this.label33.Text = "Offset";
            // 
            // nudSineOffset
            // 
            this.nudSineOffset.DecimalPlaces = 3;
            this.nudSineOffset.Location = new System.Drawing.Point(4, 138);
            this.nudSineOffset.Margin = new System.Windows.Forms.Padding(4);
            this.nudSineOffset.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSineOffset.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudSineOffset.Name = "nudSineOffset";
            this.nudSineOffset.Size = new System.Drawing.Size(140, 23);
            this.nudSineOffset.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel3.Controls.Add(this.cbOutputTriangle);
            this.flowLayoutPanel3.Controls.Add(this.label34);
            this.flowLayoutPanel3.Controls.Add(this.nudTriangleAmp);
            this.flowLayoutPanel3.Controls.Add(this.label37);
            this.flowLayoutPanel3.Controls.Add(this.nudTriangleFreq);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(291, 90);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(279, 241);
            this.flowLayoutPanel3.TabIndex = 5;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // cbOutputTriangle
            // 
            this.cbOutputTriangle.AutoSize = true;
            this.cbOutputTriangle.Location = new System.Drawing.Point(4, 4);
            this.cbOutputTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.cbOutputTriangle.Name = "cbOutputTriangle";
            this.cbOutputTriangle.Size = new System.Drawing.Size(67, 19);
            this.cbOutputTriangle.TabIndex = 0;
            this.cbOutputTriangle.Tag = "Triangle";
            this.cbOutputTriangle.Text = "Triangle";
            this.cbOutputTriangle.UseVisualStyleBackColor = true;
            this.cbOutputTriangle.CheckedChanged += new System.EventHandler(this.OnOutputTypeCheckedChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(4, 27);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(63, 15);
            this.label34.TabIndex = 1;
            this.label34.Text = "Amplitude";
            // 
            // nudTriangleAmp
            // 
            this.nudTriangleAmp.DecimalPlaces = 3;
            this.nudTriangleAmp.Location = new System.Drawing.Point(4, 46);
            this.nudTriangleAmp.Margin = new System.Windows.Forms.Padding(4);
            this.nudTriangleAmp.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudTriangleAmp.Name = "nudTriangleAmp";
            this.nudTriangleAmp.Size = new System.Drawing.Size(140, 23);
            this.nudTriangleAmp.TabIndex = 2;
            this.nudTriangleAmp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(4, 73);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(62, 15);
            this.label37.TabIndex = 1;
            this.label37.Text = "Frequency";
            // 
            // nudTriangleFreq
            // 
            this.nudTriangleFreq.DecimalPlaces = 3;
            this.nudTriangleFreq.Location = new System.Drawing.Point(4, 92);
            this.nudTriangleFreq.Margin = new System.Windows.Forms.Padding(4);
            this.nudTriangleFreq.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudTriangleFreq.Name = "nudTriangleFreq";
            this.nudTriangleFreq.Size = new System.Drawing.Size(140, 23);
            this.nudTriangleFreq.TabIndex = 2;
            this.nudTriangleFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // nudOutputIndex
            // 
            this.nudOutputIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudOutputIndex.Location = new System.Drawing.Point(578, 49);
            this.nudOutputIndex.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.nudOutputIndex.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudOutputIndex.Name = "nudOutputIndex";
            this.nudOutputIndex.Size = new System.Drawing.Size(279, 23);
            this.nudOutputIndex.TabIndex = 2;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel4.Controls.Add(this.cbOutputSquare);
            this.flowLayoutPanel4.Controls.Add(this.label38);
            this.flowLayoutPanel4.Controls.Add(this.nudSquareAmp);
            this.flowLayoutPanel4.Controls.Add(this.label39);
            this.flowLayoutPanel4.Controls.Add(this.nudSquareFreq);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(578, 90);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(279, 241);
            this.flowLayoutPanel4.TabIndex = 5;
            this.flowLayoutPanel4.WrapContents = false;
            // 
            // cbOutputSquare
            // 
            this.cbOutputSquare.AutoSize = true;
            this.cbOutputSquare.Location = new System.Drawing.Point(4, 4);
            this.cbOutputSquare.Margin = new System.Windows.Forms.Padding(4);
            this.cbOutputSquare.Name = "cbOutputSquare";
            this.cbOutputSquare.Size = new System.Drawing.Size(62, 19);
            this.cbOutputSquare.TabIndex = 0;
            this.cbOutputSquare.Tag = "Square";
            this.cbOutputSquare.Text = "Square";
            this.cbOutputSquare.UseVisualStyleBackColor = true;
            this.cbOutputSquare.CheckedChanged += new System.EventHandler(this.OnOutputTypeCheckedChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(4, 27);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 15);
            this.label38.TabIndex = 1;
            this.label38.Text = "Amplitude";
            // 
            // nudSquareAmp
            // 
            this.nudSquareAmp.DecimalPlaces = 3;
            this.nudSquareAmp.Location = new System.Drawing.Point(4, 46);
            this.nudSquareAmp.Margin = new System.Windows.Forms.Padding(4);
            this.nudSquareAmp.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSquareAmp.Name = "nudSquareAmp";
            this.nudSquareAmp.Size = new System.Drawing.Size(140, 23);
            this.nudSquareAmp.TabIndex = 2;
            this.nudSquareAmp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(4, 73);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(62, 15);
            this.label39.TabIndex = 1;
            this.label39.Text = "Frequency";
            // 
            // nudSquareFreq
            // 
            this.nudSquareFreq.DecimalPlaces = 3;
            this.nudSquareFreq.Location = new System.Drawing.Point(4, 92);
            this.nudSquareFreq.Margin = new System.Windows.Forms.Padding(4);
            this.nudSquareFreq.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSquareFreq.Name = "nudSquareFreq";
            this.nudSquareFreq.Size = new System.Drawing.Size(140, 23);
            this.nudSquareFreq.TabIndex = 2;
            this.nudSquareFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel5.Controls.Add(this.cbOutputWhiteNoise);
            this.flowLayoutPanel5.Controls.Add(this.label40);
            this.flowLayoutPanel5.Controls.Add(this.nudWhiteNoiseRMS);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(865, 90);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(279, 241);
            this.flowLayoutPanel5.TabIndex = 5;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // cbOutputWhiteNoise
            // 
            this.cbOutputWhiteNoise.AutoSize = true;
            this.cbOutputWhiteNoise.Location = new System.Drawing.Point(4, 4);
            this.cbOutputWhiteNoise.Margin = new System.Windows.Forms.Padding(4);
            this.cbOutputWhiteNoise.Name = "cbOutputWhiteNoise";
            this.cbOutputWhiteNoise.Size = new System.Drawing.Size(90, 19);
            this.cbOutputWhiteNoise.TabIndex = 0;
            this.cbOutputWhiteNoise.Tag = "WhiteNoise";
            this.cbOutputWhiteNoise.Text = "White Noise";
            this.cbOutputWhiteNoise.UseVisualStyleBackColor = true;
            this.cbOutputWhiteNoise.CheckedChanged += new System.EventHandler(this.OnOutputTypeCheckedChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(4, 27);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(31, 15);
            this.label40.TabIndex = 1;
            this.label40.Text = "RMS";
            // 
            // nudWhiteNoiseRMS
            // 
            this.nudWhiteNoiseRMS.DecimalPlaces = 3;
            this.nudWhiteNoiseRMS.Location = new System.Drawing.Point(4, 46);
            this.nudWhiteNoiseRMS.Margin = new System.Windows.Forms.Padding(4);
            this.nudWhiteNoiseRMS.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudWhiteNoiseRMS.Name = "nudWhiteNoiseRMS";
            this.nudWhiteNoiseRMS.Size = new System.Drawing.Size(140, 23);
            this.nudWhiteNoiseRMS.TabIndex = 2;
            this.nudWhiteNoiseRMS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel6.Controls.Add(this.cbOutputPinkNoise);
            this.flowLayoutPanel6.Controls.Add(this.label41);
            this.flowLayoutPanel6.Controls.Add(this.nudPinkNoiseRMS);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(4, 339);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(279, 367);
            this.flowLayoutPanel6.TabIndex = 5;
            this.flowLayoutPanel6.WrapContents = false;
            // 
            // cbOutputPinkNoise
            // 
            this.cbOutputPinkNoise.AutoSize = true;
            this.cbOutputPinkNoise.Location = new System.Drawing.Point(4, 4);
            this.cbOutputPinkNoise.Margin = new System.Windows.Forms.Padding(4);
            this.cbOutputPinkNoise.Name = "cbOutputPinkNoise";
            this.cbOutputPinkNoise.Size = new System.Drawing.Size(82, 19);
            this.cbOutputPinkNoise.TabIndex = 0;
            this.cbOutputPinkNoise.Tag = "PinkNoise";
            this.cbOutputPinkNoise.Text = "Pink Noise";
            this.cbOutputPinkNoise.UseVisualStyleBackColor = true;
            this.cbOutputPinkNoise.CheckedChanged += new System.EventHandler(this.OnOutputTypeCheckedChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(4, 27);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(31, 15);
            this.label41.TabIndex = 1;
            this.label41.Text = "RMS";
            // 
            // nudPinkNoiseRMS
            // 
            this.nudPinkNoiseRMS.DecimalPlaces = 3;
            this.nudPinkNoiseRMS.Location = new System.Drawing.Point(4, 46);
            this.nudPinkNoiseRMS.Margin = new System.Windows.Forms.Padding(4);
            this.nudPinkNoiseRMS.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudPinkNoiseRMS.Name = "nudPinkNoiseRMS";
            this.nudPinkNoiseRMS.Size = new System.Drawing.Size(140, 23);
            this.nudPinkNoiseRMS.TabIndex = 2;
            this.nudPinkNoiseRMS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel7.Controls.Add(this.cbOutputDC);
            this.flowLayoutPanel7.Controls.Add(this.label42);
            this.flowLayoutPanel7.Controls.Add(this.nudDCAmp);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(291, 339);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(279, 367);
            this.flowLayoutPanel7.TabIndex = 5;
            this.flowLayoutPanel7.WrapContents = false;
            // 
            // cbOutputDC
            // 
            this.cbOutputDC.AutoSize = true;
            this.cbOutputDC.Location = new System.Drawing.Point(4, 4);
            this.cbOutputDC.Margin = new System.Windows.Forms.Padding(4);
            this.cbOutputDC.Name = "cbOutputDC";
            this.cbOutputDC.Size = new System.Drawing.Size(42, 19);
            this.cbOutputDC.TabIndex = 0;
            this.cbOutputDC.Tag = "DC";
            this.cbOutputDC.Text = "DC";
            this.cbOutputDC.UseVisualStyleBackColor = true;
            this.cbOutputDC.CheckedChanged += new System.EventHandler(this.OnOutputTypeCheckedChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(4, 27);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(63, 15);
            this.label42.TabIndex = 1;
            this.label42.Text = "Amplitude";
            // 
            // nudDCAmp
            // 
            this.nudDCAmp.DecimalPlaces = 3;
            this.nudDCAmp.Location = new System.Drawing.Point(4, 46);
            this.nudDCAmp.Margin = new System.Windows.Forms.Padding(4);
            this.nudDCAmp.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudDCAmp.Name = "nudDCAmp";
            this.nudDCAmp.Size = new System.Drawing.Size(140, 23);
            this.nudDCAmp.TabIndex = 2;
            this.nudDCAmp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel8.Controls.Add(this.cbOutputChirp);
            this.flowLayoutPanel8.Controls.Add(this.label43);
            this.flowLayoutPanel8.Controls.Add(this.nudChirpAmp);
            this.flowLayoutPanel8.Controls.Add(this.label44);
            this.flowLayoutPanel8.Controls.Add(this.nudChirpLowFreq);
            this.flowLayoutPanel8.Controls.Add(this.label45);
            this.flowLayoutPanel8.Controls.Add(this.nudChirpHighFreq);
            this.flowLayoutPanel8.Controls.Add(this.label46);
            this.flowLayoutPanel8.Controls.Add(this.nudChirpPercent);
            this.flowLayoutPanel8.Controls.Add(this.label47);
            this.flowLayoutPanel8.Controls.Add(this.nudChirpPeriod);
            this.flowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel8.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(578, 339);
            this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(279, 367);
            this.flowLayoutPanel8.TabIndex = 5;
            this.flowLayoutPanel8.WrapContents = false;
            // 
            // cbOutputChirp
            // 
            this.cbOutputChirp.AutoSize = true;
            this.cbOutputChirp.Location = new System.Drawing.Point(4, 4);
            this.cbOutputChirp.Margin = new System.Windows.Forms.Padding(4);
            this.cbOutputChirp.Name = "cbOutputChirp";
            this.cbOutputChirp.Size = new System.Drawing.Size(55, 19);
            this.cbOutputChirp.TabIndex = 0;
            this.cbOutputChirp.Tag = "Chirp";
            this.cbOutputChirp.Text = "Chirp";
            this.cbOutputChirp.UseVisualStyleBackColor = true;
            this.cbOutputChirp.CheckedChanged += new System.EventHandler(this.OnOutputTypeCheckedChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(4, 27);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(63, 15);
            this.label43.TabIndex = 1;
            this.label43.Text = "Amplitude";
            // 
            // nudChirpAmp
            // 
            this.nudChirpAmp.DecimalPlaces = 3;
            this.nudChirpAmp.Location = new System.Drawing.Point(4, 46);
            this.nudChirpAmp.Margin = new System.Windows.Forms.Padding(4);
            this.nudChirpAmp.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudChirpAmp.Name = "nudChirpAmp";
            this.nudChirpAmp.Size = new System.Drawing.Size(140, 23);
            this.nudChirpAmp.TabIndex = 2;
            this.nudChirpAmp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(4, 73);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(87, 15);
            this.label44.TabIndex = 1;
            this.label44.Text = "Low Frequency";
            // 
            // nudChirpLowFreq
            // 
            this.nudChirpLowFreq.DecimalPlaces = 3;
            this.nudChirpLowFreq.Location = new System.Drawing.Point(4, 92);
            this.nudChirpLowFreq.Margin = new System.Windows.Forms.Padding(4);
            this.nudChirpLowFreq.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudChirpLowFreq.Name = "nudChirpLowFreq";
            this.nudChirpLowFreq.Size = new System.Drawing.Size(140, 23);
            this.nudChirpLowFreq.TabIndex = 2;
            this.nudChirpLowFreq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(4, 119);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(91, 15);
            this.label45.TabIndex = 1;
            this.label45.Text = "High Frequency";
            // 
            // nudChirpHighFreq
            // 
            this.nudChirpHighFreq.DecimalPlaces = 3;
            this.nudChirpHighFreq.Location = new System.Drawing.Point(4, 138);
            this.nudChirpHighFreq.Margin = new System.Windows.Forms.Padding(4);
            this.nudChirpHighFreq.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudChirpHighFreq.Name = "nudChirpHighFreq";
            this.nudChirpHighFreq.Size = new System.Drawing.Size(140, 23);
            this.nudChirpHighFreq.TabIndex = 2;
            this.nudChirpHighFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(4, 165);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(47, 15);
            this.label46.TabIndex = 1;
            this.label46.Text = "Percent";
            // 
            // nudChirpPercent
            // 
            this.nudChirpPercent.DecimalPlaces = 3;
            this.nudChirpPercent.Location = new System.Drawing.Point(4, 184);
            this.nudChirpPercent.Margin = new System.Windows.Forms.Padding(4);
            this.nudChirpPercent.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudChirpPercent.Name = "nudChirpPercent";
            this.nudChirpPercent.Size = new System.Drawing.Size(140, 23);
            this.nudChirpPercent.TabIndex = 2;
            this.nudChirpPercent.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(4, 211);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(41, 15);
            this.label47.TabIndex = 1;
            this.label47.Text = "Period";
            // 
            // nudChirpPeriod
            // 
            this.nudChirpPeriod.DecimalPlaces = 3;
            this.nudChirpPeriod.Location = new System.Drawing.Point(4, 230);
            this.nudChirpPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.nudChirpPeriod.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudChirpPeriod.Name = "nudChirpPeriod";
            this.nudChirpPeriod.Size = new System.Drawing.Size(140, 23);
            this.nudChirpPeriod.TabIndex = 2;
            this.nudChirpPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel9.Controls.Add(this.cbOutputSweptSine);
            this.flowLayoutPanel9.Controls.Add(this.label48);
            this.flowLayoutPanel9.Controls.Add(this.nudSweptSineAmp);
            this.flowLayoutPanel9.Controls.Add(this.label49);
            this.flowLayoutPanel9.Controls.Add(this.nudSweptSineLowFreq);
            this.flowLayoutPanel9.Controls.Add(this.label50);
            this.flowLayoutPanel9.Controls.Add(this.nudSweptSineHighFreq);
            this.flowLayoutPanel9.Controls.Add(this.label51);
            this.flowLayoutPanel9.Controls.Add(this.nudSweptSinePeriod);
            this.flowLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(865, 339);
            this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(279, 367);
            this.flowLayoutPanel9.TabIndex = 5;
            this.flowLayoutPanel9.WrapContents = false;
            // 
            // cbOutputSweptSine
            // 
            this.cbOutputSweptSine.AutoSize = true;
            this.cbOutputSweptSine.Location = new System.Drawing.Point(4, 4);
            this.cbOutputSweptSine.Margin = new System.Windows.Forms.Padding(4);
            this.cbOutputSweptSine.Name = "cbOutputSweptSine";
            this.cbOutputSweptSine.Size = new System.Drawing.Size(83, 19);
            this.cbOutputSweptSine.TabIndex = 0;
            this.cbOutputSweptSine.Tag = "SweptSine";
            this.cbOutputSweptSine.Text = "Swept Sine";
            this.cbOutputSweptSine.UseVisualStyleBackColor = true;
            this.cbOutputSweptSine.CheckedChanged += new System.EventHandler(this.OnOutputTypeCheckedChanged);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(4, 27);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(63, 15);
            this.label48.TabIndex = 1;
            this.label48.Text = "Amplitude";
            // 
            // nudSweptSineAmp
            // 
            this.nudSweptSineAmp.DecimalPlaces = 3;
            this.nudSweptSineAmp.Location = new System.Drawing.Point(4, 46);
            this.nudSweptSineAmp.Margin = new System.Windows.Forms.Padding(4);
            this.nudSweptSineAmp.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSweptSineAmp.Name = "nudSweptSineAmp";
            this.nudSweptSineAmp.Size = new System.Drawing.Size(140, 23);
            this.nudSweptSineAmp.TabIndex = 2;
            this.nudSweptSineAmp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(4, 73);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(87, 15);
            this.label49.TabIndex = 1;
            this.label49.Text = "Low Frequency";
            // 
            // nudSweptSineLowFreq
            // 
            this.nudSweptSineLowFreq.DecimalPlaces = 3;
            this.nudSweptSineLowFreq.Location = new System.Drawing.Point(4, 92);
            this.nudSweptSineLowFreq.Margin = new System.Windows.Forms.Padding(4);
            this.nudSweptSineLowFreq.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSweptSineLowFreq.Name = "nudSweptSineLowFreq";
            this.nudSweptSineLowFreq.Size = new System.Drawing.Size(140, 23);
            this.nudSweptSineLowFreq.TabIndex = 2;
            this.nudSweptSineLowFreq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(4, 119);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(91, 15);
            this.label50.TabIndex = 1;
            this.label50.Text = "High Frequency";
            // 
            // nudSweptSineHighFreq
            // 
            this.nudSweptSineHighFreq.DecimalPlaces = 3;
            this.nudSweptSineHighFreq.Location = new System.Drawing.Point(4, 138);
            this.nudSweptSineHighFreq.Margin = new System.Windows.Forms.Padding(4);
            this.nudSweptSineHighFreq.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSweptSineHighFreq.Name = "nudSweptSineHighFreq";
            this.nudSweptSineHighFreq.Size = new System.Drawing.Size(140, 23);
            this.nudSweptSineHighFreq.TabIndex = 2;
            this.nudSweptSineHighFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(4, 165);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(41, 15);
            this.label51.TabIndex = 1;
            this.label51.Text = "Period";
            // 
            // nudSweptSinePeriod
            // 
            this.nudSweptSinePeriod.DecimalPlaces = 3;
            this.nudSweptSinePeriod.Location = new System.Drawing.Point(4, 184);
            this.nudSweptSinePeriod.Margin = new System.Windows.Forms.Padding(4);
            this.nudSweptSinePeriod.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSweptSinePeriod.Name = "nudSweptSinePeriod";
            this.nudSweptSinePeriod.Size = new System.Drawing.Size(140, 23);
            this.nudSweptSinePeriod.TabIndex = 2;
            this.nudSweptSinePeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSetOutputParameters
            // 
            this.btnSetOutputParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetOutputParameters.Location = new System.Drawing.Point(4, 47);
            this.btnSetOutputParameters.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetOutputParameters.Name = "btnSetOutputParameters";
            this.btnSetOutputParameters.Size = new System.Drawing.Size(279, 35);
            this.btnSetOutputParameters.TabIndex = 4;
            this.btnSetOutputParameters.Tag = "SetOutputParameters";
            this.btnSetOutputParameters.Text = "Set Output Parameters";
            this.btnSetOutputParameters.UseVisualStyleBackColor = true;
            this.btnSetOutputParameters.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button50
            // 
            this.button50.Dock = System.Windows.Forms.DockStyle.Top;
            this.button50.Location = new System.Drawing.Point(4, 4);
            this.button50.Margin = new System.Windows.Forms.Padding(4);
            this.button50.Name = "button50";
            this.button50.Size = new System.Drawing.Size(279, 35);
            this.button50.TabIndex = 4;
            this.button50.Tag = "OutputOn";
            this.button50.Text = "Output On";
            this.button50.UseVisualStyleBackColor = true;
            this.button50.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // button51
            // 
            this.button51.Dock = System.Windows.Forms.DockStyle.Top;
            this.button51.Location = new System.Drawing.Point(291, 4);
            this.button51.Margin = new System.Windows.Forms.Padding(4);
            this.button51.Name = "button51";
            this.button51.Size = new System.Drawing.Size(279, 35);
            this.button51.TabIndex = 4;
            this.button51.Tag = "OutputOff";
            this.button51.Text = "Output Off";
            this.button51.UseVisualStyleBackColor = true;
            this.button51.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnSetOutputIndex
            // 
            this.btnSetOutputIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetOutputIndex.Location = new System.Drawing.Point(291, 47);
            this.btnSetOutputIndex.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetOutputIndex.Name = "btnSetOutputIndex";
            this.btnSetOutputIndex.Size = new System.Drawing.Size(279, 35);
            this.btnSetOutputIndex.TabIndex = 4;
            this.btnSetOutputIndex.Tag = "SetOutputIndex";
            this.btnSetOutputIndex.Text = "Set Output Index";
            this.btnSetOutputIndex.UseVisualStyleBackColor = true;
            this.btnSetOutputIndex.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // label52
            // 
            this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(578, 26);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 10, 4, 2);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(186, 15);
            this.label52.TabIndex = 1;
            this.label52.Text = "(Output index start from 0 to N-1)";
            // 
            // tabPageGlobalParameters
            // 
            this.tabPageGlobalParameters.Controls.Add(this.tableLayoutPanel20);
            this.tabPageGlobalParameters.Location = new System.Drawing.Point(4, 41);
            this.tabPageGlobalParameters.Name = "tabPageGlobalParameters";
            this.tabPageGlobalParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGlobalParameters.Size = new System.Drawing.Size(1156, 718);
            this.tabPageGlobalParameters.TabIndex = 9;
            this.tabPageGlobalParameters.Text = "Global Parameters";
            this.tabPageGlobalParameters.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 4;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 292F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Controls.Add(this.btnListGlobalParameters, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.btnGetGlobalParameter, 1, 0);
            this.tableLayoutPanel20.Controls.Add(this.listViewGlobalParameters, 0, 1);
            this.tableLayoutPanel20.Controls.Add(this.rtbGlobalParameter, 2, 1);
            this.tableLayoutPanel20.Controls.Add(this.propertyGrid, 2, 2);
            this.tableLayoutPanel20.Controls.Add(this.dataGridView, 3, 2);
            this.tableLayoutPanel20.Controls.Add(this.btnCopyGlobalParameter, 2, 0);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel20.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 3;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(1150, 712);
            this.tableLayoutPanel20.TabIndex = 3;
            // 
            // btnListGlobalParameters
            // 
            this.btnListGlobalParameters.AutoSize = true;
            this.btnListGlobalParameters.Location = new System.Drawing.Point(4, 4);
            this.btnListGlobalParameters.Margin = new System.Windows.Forms.Padding(4);
            this.btnListGlobalParameters.Name = "btnListGlobalParameters";
            this.btnListGlobalParameters.Size = new System.Drawing.Size(241, 31);
            this.btnListGlobalParameters.TabIndex = 0;
            this.btnListGlobalParameters.Tag = "ListTest";
            this.btnListGlobalParameters.Text = "List avaliable Global Parameters";
            this.btnListGlobalParameters.UseVisualStyleBackColor = true;
            this.btnListGlobalParameters.Click += new System.EventHandler(this.OnListGlobalParameters);
            // 
            // btnGetGlobalParameter
            // 
            this.btnGetGlobalParameter.AutoSize = true;
            this.btnGetGlobalParameter.Location = new System.Drawing.Point(253, 4);
            this.btnGetGlobalParameter.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetGlobalParameter.Name = "btnGetGlobalParameter";
            this.btnGetGlobalParameter.Size = new System.Drawing.Size(158, 31);
            this.btnGetGlobalParameter.TabIndex = 0;
            this.btnGetGlobalParameter.Tag = "LoadTest";
            this.btnGetGlobalParameter.Text = "Get Global Parameter";
            this.btnGetGlobalParameter.UseVisualStyleBackColor = true;
            this.btnGetGlobalParameter.Click += new System.EventHandler(this.OnGetGlobalParameter);
            // 
            // listViewGlobalParameters
            // 
            this.listViewGlobalParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader42});
            this.tableLayoutPanel20.SetColumnSpan(this.listViewGlobalParameters, 2);
            this.listViewGlobalParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGlobalParameters.FullRowSelect = true;
            this.listViewGlobalParameters.HideSelection = false;
            this.listViewGlobalParameters.Location = new System.Drawing.Point(4, 43);
            this.listViewGlobalParameters.Margin = new System.Windows.Forms.Padding(4);
            this.listViewGlobalParameters.MultiSelect = false;
            this.listViewGlobalParameters.Name = "listViewGlobalParameters";
            this.tableLayoutPanel20.SetRowSpan(this.listViewGlobalParameters, 2);
            this.listViewGlobalParameters.Size = new System.Drawing.Size(407, 665);
            this.listViewGlobalParameters.TabIndex = 1;
            this.listViewGlobalParameters.UseCompatibleStateImageBehavior = false;
            this.listViewGlobalParameters.View = System.Windows.Forms.View.Details;
            this.listViewGlobalParameters.SelectedIndexChanged += new System.EventHandler(this.OnGlobalParametersSelectedIndexChanged);
            this.listViewGlobalParameters.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "Name";
            this.columnHeader42.Width = 300;
            // 
            // rtbGlobalParameter
            // 
            this.tableLayoutPanel20.SetColumnSpan(this.rtbGlobalParameter, 2);
            this.rtbGlobalParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbGlobalParameter.Location = new System.Drawing.Point(419, 43);
            this.rtbGlobalParameter.Margin = new System.Windows.Forms.Padding(4);
            this.rtbGlobalParameter.Name = "rtbGlobalParameter";
            this.rtbGlobalParameter.ReadOnly = true;
            this.rtbGlobalParameter.Size = new System.Drawing.Size(727, 329);
            this.rtbGlobalParameter.TabIndex = 2;
            this.rtbGlobalParameter.Text = "";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(419, 380);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid.Size = new System.Drawing.Size(284, 328);
            this.propertyGrid.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(711, 380);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(435, 328);
            this.dataGridView.TabIndex = 4;
            // 
            // btnCopyGlobalParameter
            // 
            this.btnCopyGlobalParameter.AutoSize = true;
            this.btnCopyGlobalParameter.Location = new System.Drawing.Point(419, 4);
            this.btnCopyGlobalParameter.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyGlobalParameter.Name = "btnCopyGlobalParameter";
            this.btnCopyGlobalParameter.Size = new System.Drawing.Size(158, 31);
            this.btnCopyGlobalParameter.TabIndex = 0;
            this.btnCopyGlobalParameter.Tag = "LoadTest";
            this.btnCopyGlobalParameter.Text = "Copy Json content";
            this.btnCopyGlobalParameter.UseVisualStyleBackColor = true;
            this.btnCopyGlobalParameter.Click += new System.EventHandler(this.OnCopyJsonContent);
            // 
            // tabPageSignal
            // 
            this.tabPageSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageSignal.Controls.Add(this.tabControl1);
            this.tabPageSignal.Location = new System.Drawing.Point(4, 24);
            this.tabPageSignal.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSignal.Name = "tabPageSignal";
            this.tabPageSignal.Size = new System.Drawing.Size(1178, 777);
            this.tabPageSignal.TabIndex = 3;
            this.tabPageSignal.Text = "Signal";
            this.tabPageSignal.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1176, 775);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel12);
            this.tabPage1.Location = new System.Drawing.Point(4, 41);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1168, 730);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Signal View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 3;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.lvSignals, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.chart, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel12.Controls.Add(this.lvSignalProperty, 2, 2);
            this.tableLayoutPanel12.Controls.Add(this.btnGetSignalProperty, 0, 2);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 3;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(1162, 724);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // lvSignals
            // 
            this.lvSignals.CheckBoxes = true;
            this.lvSignals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.tableLayoutPanel12.SetColumnSpan(this.lvSignals, 3);
            this.lvSignals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSignals.FullRowSelect = true;
            this.lvSignals.HideSelection = false;
            this.lvSignals.Location = new System.Drawing.Point(4, 4);
            this.lvSignals.Margin = new System.Windows.Forms.Padding(4);
            this.lvSignals.Name = "lvSignals";
            this.lvSignals.Size = new System.Drawing.Size(1154, 209);
            this.lvSignals.TabIndex = 1;
            this.lvSignals.UseCompatibleStateImageBehavior = false;
            this.lvSignals.View = System.Windows.Forms.View.Details;
            this.lvSignals.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnSignalItemCheckChanged);
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Name";
            this.columnHeader19.Width = 120;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Type";
            this.columnHeader20.Width = 120;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Block Size";
            this.columnHeader21.Width = 120;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Sampling Rate";
            this.columnHeader22.Width = 120;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Unit X";
            this.columnHeader23.Width = 120;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Unit Y";
            this.columnHeader24.Width = 120;
            // 
            // chart
            // 
            this.tableLayoutPanel12.SetColumnSpan(this.chart, 3);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.IsAntiAlias = true;
            this.chart.Location = new System.Drawing.Point(5, 222);
            this.chart.Margin = new System.Windows.Forms.Padding(5);
            this.chart.Name = "chart";
            this.chart.ScrollGrace = 0D;
            this.chart.ScrollMaxX = 0D;
            this.chart.ScrollMaxY = 0D;
            this.chart.ScrollMaxY2 = 0D;
            this.chart.ScrollMinX = 0D;
            this.chart.ScrollMinY = 0D;
            this.chart.ScrollMinY2 = 0D;
            this.chart.Size = new System.Drawing.Size(1152, 352);
            this.chart.TabIndex = 3;
            this.chart.UseExtendedPrintDialog = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbRMS);
            this.flowLayoutPanel1.Controls.Add(this.cbPeak);
            this.flowLayoutPanel1.Controls.Add(this.cbPkPk);
            this.flowLayoutPanel1.Controls.Add(this.cbMin);
            this.flowLayoutPanel1.Controls.Add(this.cbMax);
            this.flowLayoutPanel1.Controls.Add(this.cbMean);
            this.flowLayoutPanel1.Controls.Add(this.btnSelectAll);
            this.flowLayoutPanel1.Controls.Add(this.btnSelectInverse);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(125, 583);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(136, 137);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // cbRMS
            // 
            this.cbRMS.AutoSize = true;
            this.cbRMS.Location = new System.Drawing.Point(1, 1);
            this.cbRMS.Margin = new System.Windows.Forms.Padding(1);
            this.cbRMS.Name = "cbRMS";
            this.cbRMS.Size = new System.Drawing.Size(50, 19);
            this.cbRMS.TabIndex = 0;
            this.cbRMS.Text = "RMS";
            this.cbRMS.UseVisualStyleBackColor = true;
            // 
            // cbPeak
            // 
            this.cbPeak.AutoSize = true;
            this.cbPeak.Location = new System.Drawing.Point(53, 1);
            this.cbPeak.Margin = new System.Windows.Forms.Padding(1);
            this.cbPeak.Name = "cbPeak";
            this.cbPeak.Size = new System.Drawing.Size(51, 19);
            this.cbPeak.TabIndex = 0;
            this.cbPeak.Text = "Peak";
            this.cbPeak.UseVisualStyleBackColor = true;
            // 
            // cbPkPk
            // 
            this.cbPkPk.AutoSize = true;
            this.cbPkPk.Location = new System.Drawing.Point(1, 22);
            this.cbPkPk.Margin = new System.Windows.Forms.Padding(1);
            this.cbPkPk.Name = "cbPkPk";
            this.cbPkPk.Size = new System.Drawing.Size(52, 19);
            this.cbPkPk.TabIndex = 0;
            this.cbPkPk.Text = "PkPk";
            this.cbPkPk.UseVisualStyleBackColor = true;
            // 
            // cbMin
            // 
            this.cbMin.AutoSize = true;
            this.cbMin.Location = new System.Drawing.Point(55, 22);
            this.cbMin.Margin = new System.Windows.Forms.Padding(1);
            this.cbMin.Name = "cbMin";
            this.cbMin.Size = new System.Drawing.Size(47, 19);
            this.cbMin.TabIndex = 0;
            this.cbMin.Text = "Min";
            this.cbMin.UseVisualStyleBackColor = true;
            // 
            // cbMax
            // 
            this.cbMax.AutoSize = true;
            this.cbMax.Location = new System.Drawing.Point(1, 43);
            this.cbMax.Margin = new System.Windows.Forms.Padding(1);
            this.cbMax.Name = "cbMax";
            this.cbMax.Size = new System.Drawing.Size(49, 19);
            this.cbMax.TabIndex = 0;
            this.cbMax.Text = "Max";
            this.cbMax.UseVisualStyleBackColor = true;
            // 
            // cbMean
            // 
            this.cbMean.AutoSize = true;
            this.cbMean.Location = new System.Drawing.Point(52, 43);
            this.cbMean.Margin = new System.Windows.Forms.Padding(1);
            this.cbMean.Name = "cbMean";
            this.cbMean.Size = new System.Drawing.Size(56, 19);
            this.cbMean.TabIndex = 0;
            this.cbMean.Text = "Mean";
            this.cbMean.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(1, 64);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(1);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(118, 29);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.OnSelectAll);
            // 
            // btnSelectInverse
            // 
            this.btnSelectInverse.Location = new System.Drawing.Point(1, 95);
            this.btnSelectInverse.Margin = new System.Windows.Forms.Padding(1);
            this.btnSelectInverse.Name = "btnSelectInverse";
            this.btnSelectInverse.Size = new System.Drawing.Size(118, 29);
            this.btnSelectInverse.TabIndex = 1;
            this.btnSelectInverse.Text = "Select Inverse";
            this.btnSelectInverse.UseVisualStyleBackColor = true;
            this.btnSelectInverse.Click += new System.EventHandler(this.OnSelectInverse);
            // 
            // lvSignalProperty
            // 
            this.lvSignalProperty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader41});
            this.lvSignalProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSignalProperty.HideSelection = false;
            this.lvSignalProperty.Location = new System.Drawing.Point(269, 583);
            this.lvSignalProperty.Margin = new System.Windows.Forms.Padding(4);
            this.lvSignalProperty.Name = "lvSignalProperty";
            this.lvSignalProperty.Size = new System.Drawing.Size(889, 137);
            this.lvSignalProperty.TabIndex = 8;
            this.lvSignalProperty.UseCompatibleStateImageBehavior = false;
            this.lvSignalProperty.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Name";
            this.columnHeader34.Width = 120;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "RMS";
            this.columnHeader35.Width = 70;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "Peak";
            this.columnHeader36.Width = 70;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "PkPk";
            this.columnHeader37.Width = 70;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Min";
            this.columnHeader38.Width = 70;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "Max";
            this.columnHeader39.Width = 70;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "Mean";
            this.columnHeader40.Width = 70;
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "Unit";
            // 
            // btnGetSignalProperty
            // 
            this.btnGetSignalProperty.AutoSize = true;
            this.btnGetSignalProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetSignalProperty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSignalProperty.Location = new System.Drawing.Point(4, 583);
            this.btnGetSignalProperty.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetSignalProperty.Name = "btnGetSignalProperty";
            this.btnGetSignalProperty.Size = new System.Drawing.Size(113, 137);
            this.btnGetSignalProperty.TabIndex = 4;
            this.btnGetSignalProperty.Text = "Get \r\nSignal \r\nProperty";
            this.btnGetSignalProperty.UseVisualStyleBackColor = true;
            this.btnGetSignalProperty.Click += new System.EventHandler(this.OnGetSignalProperty);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel21);
            this.tabPage2.Location = new System.Drawing.Point(4, 41);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1168, 730);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Proportion+Fixed Filter View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.ColumnCount = 10;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.003F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33233F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33233F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33233F));
            this.tableLayoutPanel21.Controls.Add(this.btnExportFreqVsPeak, 7, 1);
            this.tableLayoutPanel21.Controls.Add(this.ckbAutoRefresh, 8, 2);
            this.tableLayoutPanel21.Controls.Add(this.zedGraphControl1, 0, 3);
            this.tableLayoutPanel21.Controls.Add(this.label59, 0, 1);
            this.tableLayoutPanel21.Controls.Add(this.label60, 0, 2);
            this.tableLayoutPanel21.Controls.Add(this.ckbPFFV, 0, 0);
            this.tableLayoutPanel21.Controls.Add(this.label61, 1, 1);
            this.tableLayoutPanel21.Controls.Add(this.label62, 1, 2);
            this.tableLayoutPanel21.Controls.Add(this.tbPeakFreqSource, 2, 1);
            this.tableLayoutPanel21.Controls.Add(this.tbPeakValueSource, 2, 2);
            this.tableLayoutPanel21.Controls.Add(this.label63, 3, 1);
            this.tableLayoutPanel21.Controls.Add(this.label64, 3, 2);
            this.tableLayoutPanel21.Controls.Add(this.tbPeakFreqValue, 4, 1);
            this.tableLayoutPanel21.Controls.Add(this.tbPeakValue, 4, 2);
            this.tableLayoutPanel21.Controls.Add(this.lblPeakFreqUnit, 5, 1);
            this.tableLayoutPanel21.Controls.Add(this.lblPeakValueUnit, 5, 2);
            this.tableLayoutPanel21.Controls.Add(this.label65, 3, 0);
            this.tableLayoutPanel21.Controls.Add(this.nudTimestampMatchOffset, 4, 0);
            this.tableLayoutPanel21.Controls.Add(this.dataGridViewFreqVsPeak, 7, 3);
            this.tableLayoutPanel21.Controls.Add(this.label66, 5, 0);
            this.tableLayoutPanel21.Controls.Add(this.label67, 6, 0);
            this.tableLayoutPanel21.Controls.Add(this.btnRefreshFreqVsPeak, 7, 2);
            this.tableLayoutPanel21.Controls.Add(this.btnResetFreqVsPeak, 7, 0);
            this.tableLayoutPanel21.Controls.Add(this.ckbExcludedB, 8, 1);
            this.tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel21.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel21.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 4;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.Size = new System.Drawing.Size(1162, 724);
            this.tableLayoutPanel21.TabIndex = 0;
            // 
            // btnExportFreqVsPeak
            // 
            this.btnExportFreqVsPeak.AutoSize = true;
            this.btnExportFreqVsPeak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportFreqVsPeak.Location = new System.Drawing.Point(813, 34);
            this.btnExportFreqVsPeak.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnExportFreqVsPeak.Name = "btnExportFreqVsPeak";
            this.btnExportFreqVsPeak.Size = new System.Drawing.Size(114, 25);
            this.btnExportFreqVsPeak.TabIndex = 9;
            this.btnExportFreqVsPeak.Text = "Export to CSV";
            this.btnExportFreqVsPeak.UseVisualStyleBackColor = true;
            this.btnExportFreqVsPeak.Click += new System.EventHandler(this.OnExportFreqVsPeakClick);
            // 
            // ckbAutoRefresh
            // 
            this.ckbAutoRefresh.AutoSize = true;
            this.ckbAutoRefresh.Location = new System.Drawing.Point(929, 68);
            this.ckbAutoRefresh.Margin = new System.Windows.Forms.Padding(1, 6, 3, 3);
            this.ckbAutoRefresh.Name = "ckbAutoRefresh";
            this.ckbAutoRefresh.Size = new System.Drawing.Size(91, 19);
            this.ckbAutoRefresh.TabIndex = 10;
            this.ckbAutoRefresh.Text = "Auto refresh";
            this.toolTip.SetToolTip(this.ckbAutoRefresh, "Automatic refresh will cause the overall UI response to slow down, so be cautious" +
        "ly turned on.");
            this.ckbAutoRefresh.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.tableLayoutPanel21.SetColumnSpan(this.zedGraphControl1, 7);
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.IsAntiAlias = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(6, 99);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(800, 619);
            this.zedGraphControl1.TabIndex = 4;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(5, 36);
            this.label59.Margin = new System.Windows.Forms.Padding(5);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(90, 15);
            this.label59.TabIndex = 0;
            this.label59.Text = "Peak Frequency";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(5, 67);
            this.label60.Margin = new System.Windows.Forms.Padding(5);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(63, 15);
            this.label60.TabIndex = 0;
            this.label60.Text = "Peak Value";
            // 
            // ckbPFFV
            // 
            this.ckbPFFV.AutoSize = true;
            this.tableLayoutPanel21.SetColumnSpan(this.ckbPFFV, 3);
            this.ckbPFFV.Location = new System.Drawing.Point(3, 3);
            this.ckbPFFV.Name = "ckbPFFV";
            this.ckbPFFV.Size = new System.Drawing.Size(232, 19);
            this.ckbPFFV.TabIndex = 1;
            this.ckbPFFV.Text = "Enable Proportion and Fixed Filter View";
            this.ckbPFFV.UseVisualStyleBackColor = true;
            this.ckbPFFV.CheckedChanged += new System.EventHandler(this.OnPFFVCheckedChanged);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(105, 36);
            this.label61.Margin = new System.Windows.Forms.Padding(5);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(77, 15);
            this.label61.TabIndex = 0;
            this.label61.Text = "Source signal";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(105, 67);
            this.label62.Margin = new System.Windows.Forms.Padding(5);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(77, 15);
            this.label62.TabIndex = 0;
            this.label62.Text = "Source signal";
            // 
            // tbPeakFreqSource
            // 
            this.tbPeakFreqSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPeakFreqSource.Location = new System.Drawing.Point(190, 34);
            this.tbPeakFreqSource.Name = "tbPeakFreqSource";
            this.tbPeakFreqSource.Size = new System.Drawing.Size(151, 23);
            this.tbPeakFreqSource.TabIndex = 5;
            this.tbPeakFreqSource.Text = "Spectrum(Ch1)";
            // 
            // tbPeakValueSource
            // 
            this.tbPeakValueSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPeakValueSource.Location = new System.Drawing.Point(190, 65);
            this.tbPeakValueSource.Name = "tbPeakValueSource";
            this.tbPeakValueSource.Size = new System.Drawing.Size(151, 23);
            this.tbPeakValueSource.TabIndex = 5;
            this.tbPeakValueSource.Text = "Hist_Peak(Ch2)";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(349, 36);
            this.label63.Margin = new System.Windows.Forms.Padding(5);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(69, 15);
            this.label63.TabIndex = 0;
            this.label63.Text = "Latest value";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(349, 67);
            this.label64.Margin = new System.Windows.Forms.Padding(5);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(69, 15);
            this.label64.TabIndex = 0;
            this.label64.Text = "Latest value";
            // 
            // tbPeakFreqValue
            // 
            this.tbPeakFreqValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPeakFreqValue.Location = new System.Drawing.Point(475, 34);
            this.tbPeakFreqValue.Name = "tbPeakFreqValue";
            this.tbPeakFreqValue.ReadOnly = true;
            this.tbPeakFreqValue.Size = new System.Drawing.Size(143, 23);
            this.tbPeakFreqValue.TabIndex = 5;
            // 
            // tbPeakValue
            // 
            this.tbPeakValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPeakValue.Location = new System.Drawing.Point(475, 65);
            this.tbPeakValue.Name = "tbPeakValue";
            this.tbPeakValue.ReadOnly = true;
            this.tbPeakValue.Size = new System.Drawing.Size(143, 23);
            this.tbPeakValue.TabIndex = 5;
            // 
            // lblPeakFreqUnit
            // 
            this.lblPeakFreqUnit.AutoSize = true;
            this.lblPeakFreqUnit.Location = new System.Drawing.Point(626, 36);
            this.lblPeakFreqUnit.Margin = new System.Windows.Forms.Padding(5);
            this.lblPeakFreqUnit.Name = "lblPeakFreqUnit";
            this.lblPeakFreqUnit.Size = new System.Drawing.Size(29, 15);
            this.lblPeakFreqUnit.TabIndex = 0;
            this.lblPeakFreqUnit.Text = "(Hz)";
            // 
            // lblPeakValueUnit
            // 
            this.lblPeakValueUnit.AutoSize = true;
            this.lblPeakValueUnit.Location = new System.Drawing.Point(626, 67);
            this.lblPeakValueUnit.Margin = new System.Windows.Forms.Padding(5);
            this.lblPeakValueUnit.Name = "lblPeakValueUnit";
            this.lblPeakValueUnit.Size = new System.Drawing.Size(29, 15);
            this.lblPeakValueUnit.TabIndex = 0;
            this.lblPeakValueUnit.Text = "(dB)";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(349, 5);
            this.label65.Margin = new System.Windows.Forms.Padding(5);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(118, 15);
            this.label65.TabIndex = 6;
            this.label65.Text = "Timestamp tolerance";
            // 
            // nudTimestampMatchOffset
            // 
            this.nudTimestampMatchOffset.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MQTTExample.Properties.Settings.Default, "TimestampMatchOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudTimestampMatchOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudTimestampMatchOffset.Location = new System.Drawing.Point(475, 3);
            this.nudTimestampMatchOffset.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTimestampMatchOffset.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTimestampMatchOffset.Name = "nudTimestampMatchOffset";
            this.nudTimestampMatchOffset.Size = new System.Drawing.Size(143, 23);
            this.nudTimestampMatchOffset.TabIndex = 7;
            this.nudTimestampMatchOffset.Value = global::MQTTExample.Properties.Settings.Default.TimestampMatchOffset;
            this.nudTimestampMatchOffset.ValueChanged += new System.EventHandler(this.OnTimestampMatchOffsetValueChanged);
            // 
            // dataGridViewFreqVsPeak
            // 
            this.dataGridViewFreqVsPeak.AllowUserToAddRows = false;
            this.dataGridViewFreqVsPeak.AllowUserToDeleteRows = false;
            this.dataGridViewFreqVsPeak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel21.SetColumnSpan(this.dataGridViewFreqVsPeak, 3);
            this.dataGridViewFreqVsPeak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFreqVsPeak.Location = new System.Drawing.Point(815, 96);
            this.dataGridViewFreqVsPeak.Name = "dataGridViewFreqVsPeak";
            this.dataGridViewFreqVsPeak.ReadOnly = true;
            this.dataGridViewFreqVsPeak.RowTemplate.Height = 23;
            this.dataGridViewFreqVsPeak.Size = new System.Drawing.Size(344, 625);
            this.dataGridViewFreqVsPeak.TabIndex = 8;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(626, 5);
            this.label66.Margin = new System.Windows.Forms.Padding(5);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(31, 15);
            this.label66.TabIndex = 0;
            this.label66.Text = "(ms)";
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(667, 5);
            this.label67.Margin = new System.Windows.Forms.Padding(5);
            this.label67.Name = "label67";
            this.tableLayoutPanel21.SetRowSpan(this.label67, 3);
            this.label67.Size = new System.Drawing.Size(140, 82);
            this.label67.TabIndex = 0;
            this.label67.Text = "[Set a reasonable timestamp tolerance value for timestamp pairing.]";
            // 
            // btnRefreshFreqVsPeak
            // 
            this.btnRefreshFreqVsPeak.AutoSize = true;
            this.btnRefreshFreqVsPeak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshFreqVsPeak.Location = new System.Drawing.Point(813, 65);
            this.btnRefreshFreqVsPeak.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnRefreshFreqVsPeak.Name = "btnRefreshFreqVsPeak";
            this.btnRefreshFreqVsPeak.Size = new System.Drawing.Size(114, 25);
            this.btnRefreshFreqVsPeak.TabIndex = 9;
            this.btnRefreshFreqVsPeak.Text = "Refresh table";
            this.btnRefreshFreqVsPeak.UseVisualStyleBackColor = true;
            this.btnRefreshFreqVsPeak.Click += new System.EventHandler(this.OnRefreshFreqVsPeakClick);
            // 
            // btnResetFreqVsPeak
            // 
            this.btnResetFreqVsPeak.AutoSize = true;
            this.btnResetFreqVsPeak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetFreqVsPeak.Location = new System.Drawing.Point(813, 3);
            this.btnResetFreqVsPeak.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnResetFreqVsPeak.Name = "btnResetFreqVsPeak";
            this.btnResetFreqVsPeak.Size = new System.Drawing.Size(114, 25);
            this.btnResetFreqVsPeak.TabIndex = 11;
            this.btnResetFreqVsPeak.Text = "Reset";
            this.btnResetFreqVsPeak.UseVisualStyleBackColor = true;
            this.btnResetFreqVsPeak.Click += new System.EventHandler(this.OnResetFreqVsPeakClick);
            // 
            // ckbExcludedB
            // 
            this.ckbExcludedB.AutoSize = true;
            this.ckbExcludedB.Checked = true;
            this.ckbExcludedB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbExcludedB.Location = new System.Drawing.Point(929, 37);
            this.ckbExcludedB.Margin = new System.Windows.Forms.Padding(1, 6, 3, 3);
            this.ckbExcludedB.Name = "ckbExcludedB";
            this.ckbExcludedB.Size = new System.Drawing.Size(112, 19);
            this.ckbExcludedB.TabIndex = 10;
            this.ckbExcludedB.Text = "Exclude dB colum";
            this.ckbExcludedB.UseVisualStyleBackColor = true;
            // 
            // tabPageReport
            // 
            this.tabPageReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageReport.Controls.Add(this.tableLayoutPanel13);
            this.tabPageReport.Location = new System.Drawing.Point(4, 24);
            this.tabPageReport.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageReport.Name = "tabPageReport";
            this.tabPageReport.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageReport.Size = new System.Drawing.Size(1178, 777);
            this.tabPageReport.TabIndex = 4;
            this.tabPageReport.Text = "Report";
            this.tabPageReport.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 3;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel13.Controls.Add(this.lvReportNotes, 0, 4);
            this.tableLayoutPanel13.Controls.Add(this.lvReportFile, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.tbReportDir, 1, 1);
            this.tableLayoutPanel13.Controls.Add(this.btnBrowseReportDir, 2, 1);
            this.tableLayoutPanel13.Controls.Add(this.btnGenerateReport, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.btnGetReport, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.label27, 2, 0);
            this.tableLayoutPanel13.Controls.Add(this.cbxReportTemplates, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.label70, 0, 3);
            this.tableLayoutPanel13.Controls.Add(this.flowLayoutPanel10, 1, 3);
            this.tableLayoutPanel13.Controls.Add(this.label71, 2, 3);
            this.tableLayoutPanel13.Controls.Add(this.flowLayoutPanel11, 2, 4);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 5;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(1168, 767);
            this.tableLayoutPanel13.TabIndex = 0;
            // 
            // lvReportNotes
            // 
            this.lvReportNotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader47,
            this.columnHeader48});
            this.tableLayoutPanel13.SetColumnSpan(this.lvReportNotes, 2);
            this.lvReportNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportNotes.FullRowSelect = true;
            this.lvReportNotes.HideSelection = false;
            this.lvReportNotes.Location = new System.Drawing.Point(4, 447);
            this.lvReportNotes.Margin = new System.Windows.Forms.Padding(4);
            this.lvReportNotes.MultiSelect = false;
            this.lvReportNotes.Name = "lvReportNotes";
            this.lvReportNotes.Size = new System.Drawing.Size(950, 316);
            this.lvReportNotes.TabIndex = 6;
            this.lvReportNotes.UseCompatibleStateImageBehavior = false;
            this.lvReportNotes.View = System.Windows.Forms.View.Details;
            this.lvReportNotes.SelectedIndexChanged += new System.EventHandler(this.OnReportNotesSelectedIndexChanged);
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "Name";
            this.columnHeader47.Width = 200;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "Content";
            this.columnHeader48.Width = 600;
            // 
            // lvReportFile
            // 
            this.lvReportFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader25,
            this.columnHeader26});
            this.tableLayoutPanel13.SetColumnSpan(this.lvReportFile, 3);
            this.lvReportFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportFile.FullRowSelect = true;
            this.lvReportFile.HideSelection = false;
            this.lvReportFile.Location = new System.Drawing.Point(4, 84);
            this.lvReportFile.Margin = new System.Windows.Forms.Padding(4);
            this.lvReportFile.MultiSelect = false;
            this.lvReportFile.Name = "lvReportFile";
            this.lvReportFile.Size = new System.Drawing.Size(1160, 315);
            this.lvReportFile.TabIndex = 3;
            this.lvReportFile.UseCompatibleStateImageBehavior = false;
            this.lvReportFile.View = System.Windows.Forms.View.Details;
            this.lvReportFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnReportFileMouseDoubleClick);
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "File Name";
            this.columnHeader25.Width = 200;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Remote Path";
            this.columnHeader26.Width = 600;
            // 
            // tbReportDir
            // 
            this.tbReportDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbReportDir.Location = new System.Drawing.Point(213, 48);
            this.tbReportDir.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.tbReportDir.Name = "tbReportDir";
            this.tbReportDir.ReadOnly = true;
            this.tbReportDir.Size = new System.Drawing.Size(742, 23);
            this.tbReportDir.TabIndex = 1;
            // 
            // btnBrowseReportDir
            // 
            this.btnBrowseReportDir.Location = new System.Drawing.Point(962, 44);
            this.btnBrowseReportDir.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseReportDir.Name = "btnBrowseReportDir";
            this.btnBrowseReportDir.Size = new System.Drawing.Size(202, 32);
            this.btnBrowseReportDir.TabIndex = 2;
            this.btnBrowseReportDir.Tag = "";
            this.btnBrowseReportDir.Text = "Browse Report Save Directory";
            this.btnBrowseReportDir.UseVisualStyleBackColor = true;
            this.btnBrowseReportDir.Click += new System.EventHandler(this.OnBrowseReportDirClick);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateReport.Location = new System.Drawing.Point(4, 4);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(202, 32);
            this.btnGenerateReport.TabIndex = 2;
            this.btnGenerateReport.Tag = "GenerateReport";
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnGetReport
            // 
            this.btnGetReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetReport.Location = new System.Drawing.Point(4, 44);
            this.btnGetReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(202, 32);
            this.btnGetReport.TabIndex = 2;
            this.btnGetReport.Tag = "RequestReportFile";
            this.btnGetReport.Text = "Get Selected Report";
            this.btnGetReport.UseVisualStyleBackColor = true;
            this.btnGetReport.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(961, 12);
            this.label27.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(183, 15);
            this.label27.TabIndex = 0;
            this.label27.Text = "<Input or select report template>";
            // 
            // cbxReportTemplates
            // 
            this.cbxReportTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxReportTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReportTemplates.FormattingEnabled = true;
            this.cbxReportTemplates.Location = new System.Drawing.Point(213, 8);
            this.cbxReportTemplates.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cbxReportTemplates.Name = "cbxReportTemplates";
            this.cbxReportTemplates.Size = new System.Drawing.Size(742, 23);
            this.cbxReportTemplates.TabIndex = 4;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(3, 415);
            this.label70.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(92, 15);
            this.label70.TabIndex = 5;
            this.label70.Text = "List report notes";
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.button53);
            this.flowLayoutPanel10.Controls.Add(this.btnSetReportNotes);
            this.flowLayoutPanel10.Location = new System.Drawing.Point(210, 403);
            this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(298, 40);
            this.flowLayoutPanel10.TabIndex = 7;
            // 
            // button53
            // 
            this.button53.Location = new System.Drawing.Point(3, 3);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(144, 34);
            this.button53.TabIndex = 0;
            this.button53.Tag = "ListReportNotes";
            this.button53.Text = "List Report Notes";
            this.button53.UseVisualStyleBackColor = true;
            this.button53.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnSetReportNotes
            // 
            this.btnSetReportNotes.Location = new System.Drawing.Point(153, 3);
            this.btnSetReportNotes.Name = "btnSetReportNotes";
            this.btnSetReportNotes.Size = new System.Drawing.Size(117, 34);
            this.btnSetReportNotes.TabIndex = 1;
            this.btnSetReportNotes.Tag = "SetReportNotes";
            this.btnSetReportNotes.Text = "Set Report Notes";
            this.btnSetReportNotes.UseVisualStyleBackColor = true;
            this.btnSetReportNotes.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(961, 415);
            this.label71.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(0, 15);
            this.label71.TabIndex = 5;
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.Controls.Add(this.label72);
            this.flowLayoutPanel11.Controls.Add(this.tbReportNoteName);
            this.flowLayoutPanel11.Controls.Add(this.label73);
            this.flowLayoutPanel11.Controls.Add(this.tbReportNoteContent);
            this.flowLayoutPanel11.Controls.Add(this.btnUpdateReportNote);
            this.flowLayoutPanel11.Controls.Add(this.btnAddReportNote);
            this.flowLayoutPanel11.Controls.Add(this.btnDeleteReportNote);
            this.flowLayoutPanel11.Controls.Add(this.label74);
            this.flowLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel11.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel11.Location = new System.Drawing.Point(961, 446);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(204, 318);
            this.flowLayoutPanel11.TabIndex = 8;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(3, 5);
            this.label72.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(39, 15);
            this.label72.TabIndex = 0;
            this.label72.Text = "Name";
            // 
            // tbReportNoteName
            // 
            this.tbReportNoteName.Location = new System.Drawing.Point(3, 23);
            this.tbReportNoteName.Name = "tbReportNoteName";
            this.tbReportNoteName.Size = new System.Drawing.Size(180, 23);
            this.tbReportNoteName.TabIndex = 1;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(3, 49);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(50, 15);
            this.label73.TabIndex = 2;
            this.label73.Text = "Content";
            // 
            // tbReportNoteContent
            // 
            this.tbReportNoteContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReportNoteContent.Location = new System.Drawing.Point(3, 67);
            this.tbReportNoteContent.Multiline = true;
            this.tbReportNoteContent.Name = "tbReportNoteContent";
            this.tbReportNoteContent.Size = new System.Drawing.Size(194, 97);
            this.tbReportNoteContent.TabIndex = 3;
            // 
            // btnUpdateReportNote
            // 
            this.btnUpdateReportNote.Location = new System.Drawing.Point(3, 170);
            this.btnUpdateReportNote.Name = "btnUpdateReportNote";
            this.btnUpdateReportNote.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateReportNote.TabIndex = 4;
            this.btnUpdateReportNote.Text = "Update";
            this.btnUpdateReportNote.UseVisualStyleBackColor = true;
            this.btnUpdateReportNote.Click += new System.EventHandler(this.OnUpdateReportNote);
            // 
            // btnAddReportNote
            // 
            this.btnAddReportNote.Location = new System.Drawing.Point(3, 199);
            this.btnAddReportNote.Name = "btnAddReportNote";
            this.btnAddReportNote.Size = new System.Drawing.Size(75, 23);
            this.btnAddReportNote.TabIndex = 4;
            this.btnAddReportNote.Text = "Add";
            this.btnAddReportNote.UseVisualStyleBackColor = true;
            this.btnAddReportNote.Click += new System.EventHandler(this.OnAddReportNote);
            // 
            // btnDeleteReportNote
            // 
            this.btnDeleteReportNote.Location = new System.Drawing.Point(3, 228);
            this.btnDeleteReportNote.Name = "btnDeleteReportNote";
            this.btnDeleteReportNote.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteReportNote.TabIndex = 4;
            this.btnDeleteReportNote.Text = "Delete";
            this.btnDeleteReportNote.UseVisualStyleBackColor = true;
            this.btnDeleteReportNote.Click += new System.EventHandler(this.OnDeleteReportNote);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(3, 266);
            this.label74.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(194, 45);
            this.label74.TabIndex = 0;
            this.label74.Text = "Relevant changes need to be applied to EDM through Set Report Notes";
            // 
            // tabPageFile
            // 
            this.tabPageFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageFile.Controls.Add(this.tableLayoutPanel16);
            this.tabPageFile.Location = new System.Drawing.Point(4, 24);
            this.tabPageFile.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageFile.Size = new System.Drawing.Size(1178, 777);
            this.tabPageFile.TabIndex = 5;
            this.tabPageFile.Text = "File";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 3;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel16.Controls.Add(this.lvFiles, 0, 2);
            this.tableLayoutPanel16.Controls.Add(this.button30, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.btnGetRecordFile, 0, 1);
            this.tableLayoutPanel16.Controls.Add(this.lblRunFolderInfo, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.tbFileDir, 1, 1);
            this.tableLayoutPanel16.Controls.Add(this.btnBrowseFileDir, 2, 1);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel16.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 3;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(1168, 767);
            this.tableLayoutPanel16.TabIndex = 3;
            // 
            // lvFiles
            // 
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader27,
            this.columnHeader28});
            this.tableLayoutPanel16.SetColumnSpan(this.lvFiles, 3);
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(4, 84);
            this.lvFiles.Margin = new System.Windows.Forms.Padding(4);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(1160, 679);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnRecordFileMouseDoubleClick);
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "File Name";
            this.columnHeader27.Width = 200;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Remote Path";
            this.columnHeader28.Width = 600;
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(4, 4);
            this.button30.Margin = new System.Windows.Forms.Padding(4);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(202, 32);
            this.button30.TabIndex = 1;
            this.button30.Tag = "RequestRunFolder";
            this.button30.Text = "Get Run Folder";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // btnGetRecordFile
            // 
            this.btnGetRecordFile.Location = new System.Drawing.Point(4, 44);
            this.btnGetRecordFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetRecordFile.Name = "btnGetRecordFile";
            this.btnGetRecordFile.Size = new System.Drawing.Size(202, 32);
            this.btnGetRecordFile.TabIndex = 1;
            this.btnGetRecordFile.Tag = "RequestRecordFile";
            this.btnGetRecordFile.Text = "Get Selected File";
            this.btnGetRecordFile.UseVisualStyleBackColor = true;
            this.btnGetRecordFile.Click += new System.EventHandler(this.OnExecuteCommand);
            // 
            // lblRunFolderInfo
            // 
            this.lblRunFolderInfo.AutoSize = true;
            this.tableLayoutPanel16.SetColumnSpan(this.lblRunFolderInfo, 2);
            this.lblRunFolderInfo.Location = new System.Drawing.Point(216, 6);
            this.lblRunFolderInfo.Margin = new System.Windows.Forms.Padding(6);
            this.lblRunFolderInfo.Name = "lblRunFolderInfo";
            this.lblRunFolderInfo.Size = new System.Drawing.Size(98, 15);
            this.lblRunFolderInfo.TabIndex = 2;
            this.lblRunFolderInfo.Text = "<RunFolderInfo>";
            // 
            // tbFileDir
            // 
            this.tbFileDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFileDir.Location = new System.Drawing.Point(214, 44);
            this.tbFileDir.Margin = new System.Windows.Forms.Padding(4);
            this.tbFileDir.Name = "tbFileDir";
            this.tbFileDir.ReadOnly = true;
            this.tbFileDir.Size = new System.Drawing.Size(740, 23);
            this.tbFileDir.TabIndex = 3;
            // 
            // btnBrowseFileDir
            // 
            this.btnBrowseFileDir.Location = new System.Drawing.Point(962, 44);
            this.btnBrowseFileDir.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseFileDir.Name = "btnBrowseFileDir";
            this.btnBrowseFileDir.Size = new System.Drawing.Size(202, 32);
            this.btnBrowseFileDir.TabIndex = 1;
            this.btnBrowseFileDir.Tag = "";
            this.btnBrowseFileDir.Text = "Browse File Save Directory";
            this.btnBrowseFileDir.UseVisualStyleBackColor = true;
            this.btnBrowseFileDir.Click += new System.EventHandler(this.OnBrowseFileDirClick);
            // 
            // tabPageLog
            // 
            this.tabPageLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageLog.Controls.Add(this.tableLayoutPanel17);
            this.tabPageLog.Location = new System.Drawing.Point(4, 24);
            this.tabPageLog.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageLog.Size = new System.Drawing.Size(1178, 777);
            this.tabPageLog.TabIndex = 6;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 4;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.Controls.Add(this.tbMessage, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.btnPublishMessage, 2, 0);
            this.tableLayoutPanel17.Controls.Add(this.tbMessages, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.rtbMessages, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.btnClear, 3, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel17.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 2;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(1168, 767);
            this.tableLayoutPanel17.TabIndex = 4;
            // 
            // tbMessage
            // 
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessage.Location = new System.Drawing.Point(93, 4);
            this.tbMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(727, 23);
            this.tbMessage.TabIndex = 3;
            // 
            // btnPublishMessage
            // 
            this.btnPublishMessage.Location = new System.Drawing.Point(828, 4);
            this.btnPublishMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnPublishMessage.Name = "btnPublishMessage";
            this.btnPublishMessage.Size = new System.Drawing.Size(203, 32);
            this.btnPublishMessage.TabIndex = 1;
            this.btnPublishMessage.Tag = "";
            this.btnPublishMessage.Text = "Publish Message";
            this.btnPublishMessage.UseVisualStyleBackColor = true;
            this.btnPublishMessage.Click += new System.EventHandler(this.OnPublishMessage);
            // 
            // tbMessages
            // 
            this.tbMessages.AutoSize = true;
            this.tbMessages.Location = new System.Drawing.Point(6, 6);
            this.tbMessages.Margin = new System.Windows.Forms.Padding(6);
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.Size = new System.Drawing.Size(77, 15);
            this.tbMessages.TabIndex = 2;
            this.tbMessages.Text = "Text Message";
            // 
            // rtbMessages
            // 
            this.tableLayoutPanel17.SetColumnSpan(this.rtbMessages, 4);
            this.rtbMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessages.Location = new System.Drawing.Point(4, 44);
            this.rtbMessages.Margin = new System.Windows.Forms.Padding(4);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(1160, 719);
            this.rtbMessages.TabIndex = 4;
            this.rtbMessages.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1039, 4);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 32);
            this.btnClear.TabIndex = 1;
            this.btnClear.Tag = "";
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnClearMessages);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConnectionStatus,
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 805);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1186, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsConnectionStatus
            // 
            this.tsConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsConnectionStatus.ForeColor = System.Drawing.Color.Red;
            this.tsConnectionStatus.Name = "tsConnectionStatus";
            this.tsConnectionStatus.Size = new System.Drawing.Size(79, 17);
            this.tsConnectionStatus.Text = "Disconnected";
            // 
            // tsStatus
            // 
            this.tsStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblNTPTime
            // 
            this.lblNTPTime.AutoSize = true;
            this.lblNTPTime.Location = new System.Drawing.Point(641, 8);
            this.lblNTPTime.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.lblNTPTime.Name = "lblNTPTime";
            this.lblNTPTime.Size = new System.Drawing.Size(0, 15);
            this.lblNTPTime.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 827);
            this.Controls.Add(this.tabControlDemo);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MQTT Client For EDM Communication";
            this.tabControlDemo.ResumeLayout(false);
            this.tabPageMQTT.ResumeLayout(false);
            this.tabPageMQTT.PerformLayout();
            this.flpConnection.ResumeLayout(false);
            this.tlpConnection.ResumeLayout(false);
            this.tlpConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrokerPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCommunicationTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepAliveInterval)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPageSystem.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageTest.ResumeLayout(false);
            this.tabControlTest.ResumeLayout(false);
            this.tabPageStatus.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPageTestCommand.ResumeLayout(false);
            this.tabPageTestCommand.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhase)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShutdownPCDelay)).EndInit();
            this.tabPageAdvTestCommand.ResumeLayout(false);
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            this.flowLayoutPanel13.ResumeLayout(false);
            this.flowLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNTPPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNTPSynchInterval)).EndInit();
            this.tabPageDetailStatus.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tabPageChannels.ResumeLayout(false);
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            this.flowLayoutPanel12.ResumeLayout(false);
            this.flowLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChannelIndex)).EndInit();
            this.tabPageChannelStatus.ResumeLayout(false);
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tabPageParameters.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tabShaker.ResumeLayout(false);
            this.tabPageTestManager.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tabPageTHStatus.ResumeLayout(false);
            this.tabPageOutput.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSineAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSineFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSineOffset)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTriangleAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTriangleFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputIndex)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSquareAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSquareFreq)).EndInit();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWhiteNoiseRMS)).EndInit();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPinkNoiseRMS)).EndInit();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDCAmp)).EndInit();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpLowFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpHighFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChirpPeriod)).EndInit();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweptSineAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweptSineLowFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweptSineHighFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweptSinePeriod)).EndInit();
            this.tabPageGlobalParameters.ResumeLayout(false);
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPageSignal.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimestampMatchOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreqVsPeak)).EndInit();
            this.tabPageReport.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel11.PerformLayout();
            this.tabPageFile.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlDemo;
        private System.Windows.Forms.TabPage tabPageMQTT;
        private System.Windows.Forms.TableLayoutPanel tlpConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown tbBrokerPort;
        private System.Windows.Forms.TextBox tbBrokerIP;
        private System.Windows.Forms.ComboBox cbxTLS;
        private System.Windows.Forms.TabPage tabPageSystem;
        private System.Windows.Forms.TabPage tabPageTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tbCommunicationTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.ComboBox cbxProtocol;
        private System.Windows.Forms.NumericUpDown nudKeepAliveInterval;
        private System.Windows.Forms.CheckBox cbClearSession;
        private System.Windows.Forms.TextBox tbClientID;
        private System.Windows.Forms.TextBox tbTopicPrefix;
        private System.Windows.Forms.FlowLayoutPanel flpConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TabPage tabPageSignal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.ListView lvSystem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabControl tabControlTest;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTestStatus;
        private System.Windows.Forms.TabPage tabPageTestCommand;
        private System.Windows.Forms.TabPage tabPageTestManager;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblRunFolder;
        private System.Windows.Forms.Label lblMeasureStartAt;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblStage;
        private System.Windows.Forms.TabPage tabPageDetailStatus;
        private System.Windows.Forms.TabPage tabPageChannels;
        private System.Windows.Forms.TabPage tabPageParameters;
        private System.Windows.Forms.ListView lvDetailStatus;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ListView lvChannelTable;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ListView lvParameters;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblRecordStatus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.Button btnSetLevel;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.NumericUpDown nudFrequency;
        private System.Windows.Forms.Button btnSetFrequency;
        private System.Windows.Forms.Button btnSetPhase;
        private System.Windows.Forms.NumericUpDown nudPhase;
        private System.Windows.Forms.Button button42;
        private System.Windows.Forms.Button button41;
        private System.Windows.Forms.Button button40;
        private System.Windows.Forms.Button button43;
        private System.Windows.Forms.Button button44;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.RadioButton rbVCSCommand;
        private System.Windows.Forms.RadioButton rbDSACommand;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TextBox tbParameterValue;
        private System.Windows.Forms.Label lblParameterName;
        private System.Windows.Forms.Button btnSetParameter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.ListView lvTests;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button btnLoadTest;
        private System.Windows.Forms.Button btnDeleteTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbCreateTestName;
        private System.Windows.Forms.Button btnCreatTest;
        private System.Windows.Forms.ComboBox cbxCreateTestType;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.ListView lvSignals;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private ZedGraph.ZedGraphControl chart;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblRecordName;
        private System.Windows.Forms.TabPage tabPageReport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ListView lvReportFile;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.TextBox tbReportDir;
        private System.Windows.Forms.Button btnBrowseReportDir;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblLimitStatus;
        private System.Windows.Forms.Label lblLimitTest;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lblControlFlagTest;
        private System.Windows.Forms.Label lblControlFlag;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblStageTest;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button btnGetRecordFile;
        private System.Windows.Forms.Label lblRunFolderInfo;
        private System.Windows.Forms.TextBox tbFileDir;
        private System.Windows.Forms.Button btnBrowseFileDir;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btnPublishMessage;
        private System.Windows.Forms.Label tbMessages;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.TabPage tabPageTHStatus;
        private System.Windows.Forms.ListView lvTHStatus;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.Button button45;
        private System.Windows.Forms.Button btnRoRBandsOn;
        private System.Windows.Forms.Button btnSORTonesOn;
        private System.Windows.Forms.Button btnRoRBandsOff;
        private System.Windows.Forms.Button btnSORTonesOff;
        private System.Windows.Forms.TextBox tbRoRBands;
        private System.Windows.Forms.TextBox tbSoRTones;
        private System.Windows.Forms.Button btnSORTonesHold;
        private System.Windows.Forms.Button btnSORTonesRelease;
        private System.Windows.Forms.Button btnSORTonesSweepUp;
        private System.Windows.Forms.Button btnSORTonesSweepDown;
        private System.Windows.Forms.Button btnGetSignalProperty;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cbRMS;
        private System.Windows.Forms.CheckBox cbPeak;
        private System.Windows.Forms.CheckBox cbPkPk;
        private System.Windows.Forms.CheckBox cbMin;
        private System.Windows.Forms.CheckBox cbMax;
        private System.Windows.Forms.CheckBox cbMean;
        private System.Windows.Forms.ListView lvSignalProperty;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.ColumnHeader columnHeader41;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectInverse;
        private System.Windows.Forms.CheckBox rorBandFlag;
        private System.Windows.Forms.CheckBox sorBandFlag;
        private System.Windows.Forms.TabPage tabPageOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.Button button50;
        private System.Windows.Forms.Button button51;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox cbOutputSine;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown nudSineAmp;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown nudSineFreq;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown nudSineOffset;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.CheckBox cbOutputTriangle;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.NumericUpDown nudTriangleAmp;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.NumericUpDown nudTriangleFreq;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.CheckBox cbOutputSquare;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.NumericUpDown nudSquareAmp;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.NumericUpDown nudSquareFreq;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.CheckBox cbOutputWhiteNoise;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.NumericUpDown nudWhiteNoiseRMS;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.CheckBox cbOutputPinkNoise;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.NumericUpDown nudPinkNoiseRMS;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.CheckBox cbOutputDC;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.NumericUpDown nudDCAmp;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.CheckBox cbOutputChirp;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.NumericUpDown nudChirpAmp;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.NumericUpDown nudChirpLowFreq;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.NumericUpDown nudChirpHighFreq;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.NumericUpDown nudChirpPercent;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.NumericUpDown nudChirpPeriod;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.CheckBox cbOutputSweptSine;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.NumericUpDown nudSweptSineAmp;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.NumericUpDown nudSweptSineLowFreq;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.NumericUpDown nudSweptSineHighFreq;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericUpDown nudSweptSinePeriod;
        private System.Windows.Forms.Button btnSetOutputParameters;
        private System.Windows.Forms.NumericUpDown nudOutputIndex;
        private System.Windows.Forms.Button btnSetOutputIndex;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TabPage tabPageAdvTestCommand;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox tbRandomProfilePath;
        private System.Windows.Forms.TextBox tbSineProfilePath;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox tbShockProfilePath;
        private System.Windows.Forms.Button btnBrowseRandomProfile;
        private System.Windows.Forms.Button btnBrowseSineProfile;
        private System.Windows.Forms.Button btnBrowseShockProfile;
        private System.Windows.Forms.Button btnSetRandomProfile;
        private System.Windows.Forms.Button btnSetSineProfile;
        private System.Windows.Forms.Button btnSetShockProfile;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox tbChannelTablePath;
        private System.Windows.Forms.Button btnBrowseChannelTable;
        private System.Windows.Forms.Button btnSetChannelTable;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.ListView listViewGlobalParameters;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.Button btnListGlobalParameters;
        private System.Windows.Forms.Button btnGetGlobalParameter;
        private System.Windows.Forms.RichTextBox rtbGlobalParameter;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnCopyGlobalParameter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsConnectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TabPage tabPageGlobalParameters;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.CheckBox ckbPFFV;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox tbPeakFreqSource;
        private System.Windows.Forms.TextBox tbPeakValueSource;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox tbPeakFreqValue;
        private System.Windows.Forms.TextBox tbPeakValue;
        private System.Windows.Forms.Label lblPeakFreqUnit;
        private System.Windows.Forms.Label lblPeakValueUnit;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.NumericUpDown nudTimestampMatchOffset;
        private System.Windows.Forms.DataGridView dataGridViewFreqVsPeak;
        private System.Windows.Forms.Button btnExportFreqVsPeak;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Button btnRefreshFreqVsPeak;
        private System.Windows.Forms.CheckBox ckbAutoRefresh;
        private System.Windows.Forms.Button btnResetFreqVsPeak;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox ckbExcludedB;
        private System.Windows.Forms.Button btnListParameter;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.ComboBox cbxReportTemplates;
        private System.Windows.Forms.Button btnShutdownPC;
        private System.Windows.Forms.Button button48;
        private System.Windows.Forms.Button button47;
        private System.Windows.Forms.Button button46;
        private System.Windows.Forms.Button button52;
        private System.Windows.Forms.TabPage tabShaker;
        private System.Windows.Forms.ListView lvShaker;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox tbSchedulePath;
        private System.Windows.Forms.Button btnBrowseSchedule;
        private System.Windows.Forms.Button btnSetSchedule;
        private System.Windows.Forms.ListView lvReportNotes;
        private System.Windows.Forms.ColumnHeader columnHeader47;
        private System.Windows.Forms.ColumnHeader columnHeader48;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.Button button53;
        private System.Windows.Forms.Button btnSetReportNotes;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox tbReportNoteName;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox tbReportNoteContent;
        private System.Windows.Forms.Button btnUpdateReportNote;
        private System.Windows.Forms.Button btnAddReportNote;
        private System.Windows.Forms.Button btnDeleteReportNote;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectIPToolStripMenuItem;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TextBox tbCACertificateFile;
        private System.Windows.Forms.TextBox tbClientCertificateFile;
        private System.Windows.Forms.TextBox tbClientPrivateKeyFile;
        private System.Windows.Forms.Button btnBrowseCACertificateFile;
        private System.Windows.Forms.Button btnBrowseClientCertificateFile;
        private System.Windows.Forms.Button btnBrowseClientPrivateKeyFile;
        private System.Windows.Forms.NumericUpDown nudShutdownPCDelay;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TabPage tabPageChannelStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private System.Windows.Forms.Button button49;
        private System.Windows.Forms.ListView lvChannelStatus;
        private System.Windows.Forms.ColumnHeader columnHeader50;
        private System.Windows.Forms.ColumnHeader columnHeader52;
        private System.Windows.Forms.ColumnHeader columnHeader53;
        private System.Windows.Forms.ColumnHeader columnHeader54;
        private System.Windows.Forms.ColumnHeader columnHeader55;
        private System.Windows.Forms.ColumnHeader columnHeader56;
        private System.Windows.Forms.ColumnHeader columnHeader57;
        private System.Windows.Forms.ColumnHeader columnHeader58;
        private System.Windows.Forms.ColumnHeader columnHeader59;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel12;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.ComboBox cbxInputRange;
        private System.Windows.Forms.Button btnSetInputRange;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel13;
        private System.Windows.Forms.TextBox tbNTPServer;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.NumericUpDown nudNTPPort;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.NumericUpDown nudNTPSynchInterval;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Button btnSetNTP;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.NumericUpDown nudChannelIndex;
        private System.Windows.Forms.Label lblNTPTime;
    }
}

