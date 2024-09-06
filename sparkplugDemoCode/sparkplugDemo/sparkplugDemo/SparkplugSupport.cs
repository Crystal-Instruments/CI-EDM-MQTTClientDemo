using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SparkplugNet.VersionB.Data;
using System.IO;
using MQTTnet.Channel;

namespace sparkplugDemo
{
    public static class MetricNames
    {
        public const string METRIC_NCMD_RUN = "Node Control/Test/Run";
        public const string METRIC_NCMD_PAUSE = "Node Control/Test/Pause";
        public const string METRIC_NCMD_CONTINUE = "Node Control/Test/Continue";
        public const string METRIC_NCMD_STOP = "Node Control/Test/Stop";
        public const string METRIC_NCMD_CONNECT = "Node Control/Test/Connect";
        public const string METRIC_NCMD_DISCONNECT = "Node Control/Test/Disconnect";
        public const string METRIC_NCMD_STARTRECORD = "Node Control/Test/StartRecord";
        public const string METRIC_NCMD_STOPRECORD = "Node Control/Test/StopRecord";
        public const string METRIC_NCMD_SAVESIGNALS = "Node Control/Test/SaveSignals";
        public const string METRIC_NCMD_RESETAVERAGE = "Node Control/Test/ResetAverage";
        public const string METRIC_NCMD_REQUESTSIGNALDATA = "Node Control/Test/RequestSignalData";
        public const string METRIC_NCMD_REQUESTSIGNALPROPERTY = "Node Control/Test/RequestSignalProperty";
        public const string METRIC_NCMD_REQUESTDETAILSTATUS = "Node Control/Test/RequestDetailStatus";
        public const string METRIC_NCMD_REQUESTREPORTFILE = "Node Control/Test/RequestReportFile";
        public const string METRIC_NCMD_REQUESTRECORDFILE = "Node Control/Test/RequestRecordFile";
        public const string METRIC_NCMD_REQUESTRUNFOLDER = "Node Control/Test/RequestRunFolder";
        public const string METRIC_NCMD_LOADTEST = "Node Control/Test/LoadTest";
        public const string METRIC_NCMD_CREATETEST = "Node Control/Test/CreateTest";
        public const string METRIC_NCMD_DELETETEST = "Node Control/Test/DeleteTest";
        public const string METRIC_NCMD_LISTTEST = "Node Control/Test/ListTest";
        public const string METRIC_NCMD_GENERATEREPORT = "Node Control/Test/GenerateReport";
        public const string METRIC_NCMD_SETPARAMETER = "Node Control/Test/SetParameter";//key;value;key;value


        public const string METRIC_NDATA_APP_MESSAGE = "Properties/App/Message";

        public const string METRIC_NDATA_APP_MODE = "Properties/App/Mode";
        public const string METRIC_NDATA_APP_VERSION = "Properties/App/Version";

        public const string METRIC_NDATA_SYSTEM_NAME = "Properties/System/Name";
        public const string METRIC_NDATA_SYSTEM_STATUS = "Properties/System/Status";
        public const string METRIC_NDATA_SYSTEM_MODULES = "Properties/System/Modules";
        //public const string METRIC_NDATA_SYSTEM_LIST = "Properties/System/List";


        public const string METRIC_NDATA_TEST_NAME = "Properties/Test/Name";
        public const string METRIC_NDATA_TEST_TYPE = "Properties/Test/Type";
        public const string METRIC_NDATA_TEST_RUNFOLDER = "Properties/Test/RunFolder";
        public const string METRIC_NDATA_TEST_MEASURESTARTAT = "Properties/Test/MeasureStartAt";
        public const string METRIC_NDATA_TEST_LIMITSTATUS = "Properties/Test/LimitStatus";

        public const string METRIC_NDATA_TEST_STATUS = "Properties/Test/Status";
        public const string METRIC_NDATA_TEST_LIST = "Properties/Test/List";

        public const string METRIC_NDATA_TEST_RECORDSTATUS = "Properties/Test/RecordStatus";
        public const string METRIC_NDATA_TEST_RECORDNAME = "Properties/Test/RecordName";

        public const string METRIC_NDATA_TEST_SIGNALS = "Properties/Test/Signals";
        public const string METRIC_NDATA_TEST_CHANNELS = "Properties/Test/Channels";
        public const string METRIC_NDATA_TEST_PARAMETERS = "Properties/Test/Parameters";
        public const string METRIC_NDATA_TEST_SIGNALDATA = "Properties/Test/SignalData";
        //public const string METRIC_NDATA_TEST_DETAILSTATUS = "Properties/Test/DetailStatus";
        public const string METRIC_NDATA_TEST_REPORT_NAME = "Properties/Test/ReportName";
        public const string METRIC_NDATA_TEST_REPORT_CONTENT = "Properties/Test/ReportContent";
        public const string METRIC_NDATA_TEST_RECORD_NAME = "Properties/Test/RecordName";
        public const string METRIC_NDATA_TEST_RECORD_CONTENT = "Properties/Test/RecordContent";
        public const string METRIC_NDATA_TEST_RUNFOLDER_NAME = "Properties/Test/RunFolderName";
        public const string METRIC_NDATA_TEST_RUNFOLDER_FILES = "Properties/Test/RunFolderFiles";


        public const string METRIC_NCMD_DSA_TRIGGERON = "Node Control/DSA/TriggerOn";
        public const string METRIC_NCMD_DSA_TRIGGEROFF = "Node Control/DSA/TriggerOff";
        public const string METRIC_NCMD_DSA_OUTPUTON = "Node Control/DSA/OutputOn";
        public const string METRIC_NCMD_DSA_OUTPUTOFF = "Node Control/DSA/OutputOff";
        public const string METRIC_NCMD_DSA_LIMITON = "Node Control/DSA/LimitOn";
        public const string METRIC_NCMD_DSA_LIMITOFF = "Node Control/DSA/LimitOff";

        public const string METRIC_NCMD_VCS_CHECKONLY = "Node Control/VCS/CheckOnly";
        public const string METRIC_NCMD_VCS_PROCEED = "Node Control/VCS/Proceed";
        public const string METRIC_NCMD_VCS_SAVEHSIGNAL = "Node Control/VCS/SaveHSignal";
        public const string METRIC_NCMD_VCS_SETLEVEL = "Node Control/VCS/SetLevel";
        public const string METRIC_NCMD_VCS_LEVELUP = "Node Control/VCS/LevelUp";
        public const string METRIC_NCMD_VCS_LEVELDOWN = "Node Control/VCS/LevelDown";
        public const string METRIC_NCMD_VCS_RESTORELEVEL = "Node Control/VCS/RestoreLevel";
        public const string METRIC_NCMD_VCS_NEXTENTRY = "Node Control/VCS/NextEntry";
        public const string METRIC_NCMD_VCS_SHOWPRETEST = "Node Control/VCS/ShowPretest";
        public const string METRIC_NCMD_VCS_ABORTCHECKON = "Node Control/VCS/AbortChecksOn";
        public const string METRIC_NCMD_VCS_ABORTCHECKOFF = "Node Control/VCS/AbortChecksOff";
        public const string METRIC_NCMD_VCS_SCHEDULECLOCKTIMERON = "Node Control/VCS/ScheduleClockTimerOn";
        public const string METRIC_NCMD_VCS_SCHEDULECLOCKTIMEROFF = "Node Control/VCS/ScheduleClockTimerOff";
        public const string METRIC_NCMD_VCS_CLOSEDLOOPCONTROLON = "Node Control/VCS/ClosedLoopControlOn";
        public const string METRIC_NCMD_VCS_CLOSEDLOOPCONTROLOFF = "Node Control/VCS/ClosedLoopControlOff";
        public const string METRIC_NCMD_VCS_SETFREQUENCY = "Node Control/VCS/SetFrequency";
        public const string METRIC_NCMD_VCS_SETPHASE = "Node Control/VCS/SetPhase";
        public const string METRIC_NCMD_VCS_HOLDSWEEP = "Node Control/VCS/HoldSweep";
        public const string METRIC_NCMD_VCS_SWEEPUP = "Node Control/VCS/SweepUp";
        public const string METRIC_NCMD_VCS_SWEEPDOWN = "Node Control/VCS/SweepDown";
        public const string METRIC_NCMD_VCS_INCREASESPEED = "Node Control/VCS/IncreaseSpeed";
        public const string METRIC_NCMD_VCS_DECREASESPEED = "Node Control/VCS/DecreaseSpeed";
        public const string METRIC_NCMD_VCS_INVERSEPULSEON = "Node Control/VCS/InversePulseOn";
        public const string METRIC_NCMD_VCS_INVERSEPULSEOFF = "Node Control/VCS/InversePulseOff";
        public const string METRIC_NCMD_VCS_SINGLEPULSEON = "Node Control/VCS/SinglePulseOn";
        public const string METRIC_NCMD_VCS_SINGLEPULSEOFF = "Node Control/VCS/SinglePulseOff";
        public const string METRIC_NCMD_VCS_OUTPUTSINGLEPULSE = "Node Control/VCS/OutputSinglePulse";

        public const string METRIC_NDATA_VCS_CONTROLUPDATED = "Properties/VCS/ControlUpdated";
        public const string METRIC_NDATA_VCS_STAGE = "Properties/VCS/Stage";
        public const string METRIC_NDATA_VCS_SHAKER = "Properties/VCS/Shaker";

        public const string METRIC_NDATA_DSA_STATUS = "Properties/DSA/Stats";

        public const string METRIC_NDATA_VCS_SINE_STATUS = "Properties/VCS/SineStatus";
        public const string METRIC_NDATA_VCS_RANDOM_STATUS = "Properties/VCS/RandomStatus";
        public const string METRIC_NDATA_VCS_SHOCK_STATUS = "Properties/VCS/ShockStatus";
        public const string METRIC_NDATA_VCS_TWR_STATUS = "Properties/VCS/TWRStatus";

        public const string METRIC_NDATA_THV_TH_STATUS = "Properties/THV/THStatus";
        public const string METRIC_NDATA_THV_VT_STATUS = "Properties/THV/VTStatus";


        public static List<Metric> VCSMetrics { get; set; } = new List<Metric>()
        {
            new Metric(){Name = METRIC_NCMD_RUN, DataType = DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NCMD_CREATETEST, DataType =  DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NCMD_VCS_CHECKONLY, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_PROCEED, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SAVEHSIGNAL, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SETLEVEL, DataType =  DataType.Double, DoubleValue = 0.0},
            new Metric(){Name = METRIC_NCMD_VCS_LEVELUP, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_LEVELDOWN, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_RESTORELEVEL, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_NEXTENTRY, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SHOWPRETEST, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_ABORTCHECKON, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_ABORTCHECKOFF, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SCHEDULECLOCKTIMERON, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SCHEDULECLOCKTIMEROFF, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_CLOSEDLOOPCONTROLON, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_CLOSEDLOOPCONTROLOFF, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SETFREQUENCY, DataType =  DataType.Double, DoubleValue = 0.0},
            new Metric(){Name = METRIC_NCMD_VCS_SETPHASE, DataType =  DataType.Double, DoubleValue = 0.0},
            new Metric(){Name = METRIC_NCMD_VCS_HOLDSWEEP, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SWEEPUP, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SWEEPDOWN, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_INCREASESPEED, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_DECREASESPEED, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_INVERSEPULSEON, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_INVERSEPULSEOFF, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SINGLEPULSEON, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SINGLEPULSEOFF, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_OUTPUTSINGLEPULSE, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NDATA_VCS_CONTROLUPDATED, DataType =  DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_VCS_STAGE, DataType =  DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_VCS_RANDOM_STATUS, DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = METRIC_NDATA_VCS_SINE_STATUS, DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = METRIC_NDATA_VCS_SHOCK_STATUS, DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = METRIC_NDATA_VCS_TWR_STATUS, DataType =  DataType.DataSet, DataSetValue = null},
            
            // Signal Metrics
            new Metric(){Name = "Signals/Hist_Control_RMS/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch1/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch1)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch2)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch3)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch4)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch5)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch6)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch7)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch8)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Drive)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Noise(f)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAbort(f)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAlarm(f)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAbort(f)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAlarm(f)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Control(f)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Profile(f)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/H(f)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch1)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Drive/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Drive)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch2/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch2)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch3/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch3)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch4/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch4)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch5/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch5)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch6/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch6)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch7/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch7)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch8/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch8)/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Profile_RMS/StaticProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch1/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch1)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Drive/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Drive)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch2/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch2)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch3/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch3)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch4/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch4)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch5/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch5)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch6/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch6)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch7/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch7)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch8/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch8)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAbort(f)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAlarm(f)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAbort(f)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAlarm(f)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/H(f)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Control(f)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Profile(f)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch1)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch2)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch3)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch4)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch5)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch6)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch7)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch8)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Noise(f)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Drive)/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Control_RMS/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Profile_RMS/DynamicProperties", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch1/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch1)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch2)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch3)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch4)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch5)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch6)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch7)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch8)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch1)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Drive/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Drive)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch2/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch2)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch3/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch3)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch4/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch4)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch5/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch5)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch6/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch6)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch7/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch7)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch8/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch8)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAbort(f)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAlarm(f)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAbort(f)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAlarm(f)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/H(f)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Control(f)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Profile(f)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Noise(f)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Drive)/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Control_RMS/Data", DataType =  DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Profile_RMS/Data", DataType =  DataType.DataSet, DataSetValue = null},
        };

        public static List<Metric> CommonMetrics { get; set; } = new List<Metric>()
        {
            new Metric(){Name = METRIC_NCMD_RUN, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_PAUSE, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_CONTINUE, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_STOP, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_CONNECT, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DISCONNECT, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_STARTRECORD, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_STOPRECORD,DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_SAVESIGNALS, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_RESETAVERAGE, DataType =  DataType.Boolean, BooleanValue = false},

            new Metric(){Name = METRIC_NCMD_REQUESTSIGNALDATA, DataType =  DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_REQUESTSIGNALPROPERTY, DataType =  DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_REQUESTDETAILSTATUS, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_REQUESTREPORTFILE, DataType =  DataType.String, StringValue = string.Empty},

            new Metric(){Name = METRIC_NCMD_REQUESTRECORDFILE, DataType =  DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_REQUESTRUNFOLDER, DataType =  DataType.String, StringValue = string.Empty},


            new Metric(){Name = METRIC_NCMD_LOADTEST, DataType =  DataType.String, StringValue = string.Empty},//D
            //For VCS only
            //new Metric(){Name = METRIC_NCMD_CREATETEST, DataType =  DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_DELETETEST, DataType =  DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NCMD_LISTTEST, DataType =  DataType.Boolean, BooleanValue = false},//D
            new Metric(){Name = METRIC_NCMD_GENERATEREPORT, DataType =  DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NCMD_SETPARAMETER, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_APP_MESSAGE, DataType =  DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NDATA_APP_MODE, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_APP_VERSION, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_SYSTEM_NAME, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_SYSTEM_STATUS, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_SYSTEM_MODULES, DataType =  DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_NAME, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_TYPE, DataType =  DataType.String, StringValue = string.Empty},//d

            new Metric(){Name = METRIC_NDATA_TEST_RUNFOLDER, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_MEASURESTARTAT, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_LIMITSTATUS, DataType =  DataType.String, StringValue = string.Empty},//d

            new Metric(){Name = METRIC_NDATA_TEST_STATUS, DataType =  DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_TEST_RECORDNAME, DataType =  DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_TEST_RECORDSTATUS, DataType =  DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_TEST_SIGNALS, DataType =  DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_SIGNALDATA, DataType =  DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_CHANNELS, DataType =  DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_PARAMETERS, DataType =  DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_LIST, DataType =  DataType.DataSet, DataSetValue = new DataSet()},//d

            new Metric(){Name = METRIC_NDATA_TEST_REPORT_NAME, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_REPORT_CONTENT, DataType =  DataType.File, BytesValue = null },//d

              new Metric(){Name = METRIC_NDATA_TEST_RECORD_NAME, DataType =  DataType.String,StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_RECORD_CONTENT, DataType =  DataType.File, BytesValue = null },//d

              new Metric(){Name = METRIC_NDATA_TEST_RUNFOLDER_NAME, DataType =  DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_RUNFOLDER_FILES, DataType =  DataType.DataSet, DataSetValue = new DataSet() },//d
        };
        public static List<Metric> DSAMetrics { get; set; } = new List<Metric>()
        {
            new Metric(){Name = METRIC_NCMD_DSA_TRIGGERON, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_TRIGGEROFF, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_OUTPUTON, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_OUTPUTOFF, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_OUTPUTOFF, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_LIMITON, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_LIMITOFF, DataType =  DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NDATA_DSA_STATUS, DataType =  DataType.DataSet, DataSetValue = new DataSet()},
        };

        public static List<Metric> THVMetrics { get; set; } = new List<Metric>(VCSMetrics)
        {
            new Metric(){Name = METRIC_NDATA_THV_TH_STATUS, DataType =  DataType.DataSet, DataSetValue = new DataSet()},
            new Metric(){Name = METRIC_NDATA_THV_VT_STATUS, DataType =  DataType.DataSet, DataSetValue = new DataSet()},
        };
    }
}

