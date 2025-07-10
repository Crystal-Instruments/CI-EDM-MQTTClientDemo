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
        public const string METRIC_NCMD_REQUESTTESTSTATUS = "Node Control/Test/RequestTestStatus";
        public const string METRIC_NCMD_REQUESTSIGNALDATAWITHFORMAT = "Node Control/Test/RequestSignalDataWithFormat";
        public const string METRIC_NCMD_REQUESTCHANNELSTATUS = "Node Control/Test/RequestChannelStatus";
        public const string METRIC_NCMD_LISTREPORTNOTES = "Node Control/Test/ListReportNotes";
        public const string METRIC_NCMD_SETREPORTNOTES = "Node Control/Test/SetReportNotes";
        public const string METRIC_NCMD_SHUTDOWNPC = "Node Control/Test/ShutdownPC";
        public const string METRIC_NCMD_SETNTP = "Node Control/Test/SetNTP";
        public const string METRIC_NCMD_LISTGLOBALPARAMETERS = "Node Control/Test/ListGlobalParameters";
        public const string METRIC_NCMD_SETINPUTRANGE = "Node Control/Test/SetInputRange";
        public const string METRIC_NCMD_STARTTESTSEQUENCE = "Node Control/Test/StartTestSequence";
        public const string METRIC_NCMD_PAUSETESTSEQUENCE = "Node Control/Test/PauseTestSequence";
        public const string METRIC_NCMD_RESUMETESTSEQUENCE = "Node Control/Test/ResumeTestSequence";
        public const string METRIC_NCMD_STOPTESTSEQUENCE = "Node Control/Test/StopTestSequence";
        public const string METRIC_NCMD_NEXTTESTSEQUENCE = "Node Control/Test/NextTestSequence";
        public const string METRIC_NCMD_DSA_SETOUTPUTPARAMETERS = "Node Control/DSA/SetOutputParameters";
        public const string METRIC_NCMD_DSA_SETOUTPUTINDEX = "Node Control/DSA/SetOutputIndex";
        public const string METRIC_NCMD_DSA_REQUESTTRIGGERSETTINGS = "Node Control/DSA/RequestTriggerSettings";
        public const string METRIC_NCMD_DSA_SETTRIGGERSETTINGS = "Node Control/DSA/SetTriggerSettings";
        public const string METRIC_NCMD_DSA_TRIGGERACCEPT = "Node Control/DSA/TriggerAccept";
        public const string METRIC_NCMD_DSA_TRIGGERNEXT = "Node Control/DSA/TriggerNext";
        public const string METRIC_NCMD_DSA_TRIGGERREJECT = "Node Control/DSA/TriggerReject";
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
        public const string METRIC_NDATA_TEST_CHANNELSTATUS = "Properties/Test/ChannelStatus";
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
        public const string METRIC_NDATA_DSA_STATUS = "Properties/DSA/Status";
        public const string METRIC_NDATA_DSA_TRIGGERSETTINGS = "Properties/DSA/TriggerSetttings";
        public const string METRIC_NDATA_VCS_SINE_STATUS = "Properties/VCS/SineStatus";
        public const string METRIC_NDATA_VCS_RANDOM_STATUS = "Properties/VCS/RandomStatus";
        public const string METRIC_NDATA_VCS_SHOCK_STATUS = "Properties/VCS/ShockStatus";
        public const string METRIC_NDATA_VCS_TWR_STATUS = "Properties/VCS/TWRStatus";
        public const string METRIC_NDATA_THV_TH_STATUS = "Properties/THV/THStatus";
        public const string METRIC_NDATA_THV_VT_STATUS = "Properties/THV/VTStatus";


        public static List<Metric> VCSMetrics { get; set; } = new List<Metric>()
        {
                        new Metric(){Name = METRIC_NCMD_REQUESTCHANNELSTATUS, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_LISTREPORTNOTES, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_SETREPORTNOTES, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_SHUTDOWNPC, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_SETNTP, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_LISTGLOBALPARAMETERS, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_SETINPUTRANGE, DataType =  (uint)DataType.Int32, IntValue = 0},
            new Metric(){Name = METRIC_NCMD_STARTTESTSEQUENCE, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_PAUSETESTSEQUENCE, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_RESUMETESTSEQUENCE, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_STOPTESTSEQUENCE, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_NEXTTESTSEQUENCE, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_RUN, DataType = (uint)DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NCMD_CREATETEST, DataType =  (uint)DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NCMD_VCS_CHECKONLY, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_PROCEED, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SAVEHSIGNAL, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SETLEVEL, DataType =  (uint)DataType.Double, DoubleValue = 0.0},
            new Metric(){Name = METRIC_NCMD_VCS_LEVELUP, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_LEVELDOWN, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_RESTORELEVEL, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_NEXTENTRY, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SHOWPRETEST, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_ABORTCHECKON, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_ABORTCHECKOFF, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SCHEDULECLOCKTIMERON, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SCHEDULECLOCKTIMEROFF, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_CLOSEDLOOPCONTROLON, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_CLOSEDLOOPCONTROLOFF, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SETFREQUENCY, DataType =  (uint)DataType.Double, DoubleValue = 0.0},
            new Metric(){Name = METRIC_NCMD_VCS_SETPHASE, DataType =  (uint)DataType.Double, DoubleValue = 0.0},
            new Metric(){Name = METRIC_NCMD_VCS_HOLDSWEEP, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SWEEPUP, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SWEEPDOWN, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_INCREASESPEED, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_DECREASESPEED, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_INVERSEPULSEON, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_INVERSEPULSEOFF, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SINGLEPULSEON, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_SINGLEPULSEOFF, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_VCS_OUTPUTSINGLEPULSE, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NDATA_VCS_CONTROLUPDATED, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_VCS_STAGE, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_VCS_RANDOM_STATUS, DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = METRIC_NDATA_VCS_SINE_STATUS, DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = METRIC_NDATA_VCS_SHOCK_STATUS, DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = METRIC_NDATA_VCS_TWR_STATUS, DataType =  (uint)DataType.DataSet, DataSetValue = null},
            // Signal Metrics
            new Metric(){Name = "Signals/Hist_Control_RMS/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch1/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch1)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch2)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch3)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch4)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch5)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch6)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch7)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch8)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Drive)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Noise(f)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAbort(f)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAlarm(f)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAbort(f)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAlarm(f)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Control(f)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Profile(f)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/H(f)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch1)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Drive/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Drive)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch2/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch2)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch3/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch3)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch4/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch4)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch5/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch5)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch6/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch6)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch7/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch7)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch8/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch8)/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Profile_RMS/StaticProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch1/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch1)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Drive/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Drive)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch2/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch2)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch3/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch3)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch4/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch4)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch5/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch5)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch6/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch6)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch7/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch7)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch8/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch8)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAbort(f)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAlarm(f)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAbort(f)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAlarm(f)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/H(f)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Control(f)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Profile(f)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch1)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch2)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch3)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch4)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch5)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch6)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch7)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch8)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Noise(f)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Drive)/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Control_RMS/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Profile_RMS/DynamicProperties", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch1/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch1)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch2)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch3)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch4)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch5)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch6)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch7)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Ch8)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch1)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Drive/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Drive)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch2/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch2)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch3/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch3)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch4/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch4)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch5/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch5)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch6/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch6)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch7/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch7)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Ch8/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/APS(Ch8)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAbort(f)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/HighAlarm(f)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAbort(f)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/LowAlarm(f)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/H(f)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Control(f)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Profile(f)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Noise(f)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Block(Drive)/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Control_RMS/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
            new Metric(){Name = "Signals/Hist_Profile_RMS/Data", DataType =  (uint)DataType.DataSet, DataSetValue = null},
        };

        public static List<Metric> CommonMetrics { get; set; } = new List<Metric>()
        {
            new Metric(){Name = METRIC_NCMD_RUN, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_PAUSE, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_CONTINUE, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_STOP, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_CONNECT, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DISCONNECT, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_STARTRECORD, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_STOPRECORD,DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_SAVESIGNALS, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_RESETAVERAGE, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_REQUESTSIGNALDATA, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_REQUESTSIGNALPROPERTY, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_REQUESTDETAILSTATUS, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_REQUESTTESTSTATUS, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_REQUESTSIGNALDATAWITHFORMAT, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_REQUESTREPORTFILE, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_REQUESTRECORDFILE, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_REQUESTRUNFOLDER, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_LOADTEST, DataType =  (uint)DataType.String, StringValue = string.Empty},//D
            //For VCS only
            //new Metric(){Name = METRIC_NCMD_CREATETEST, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_DELETETEST, DataType =  (uint)DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NCMD_LISTTEST, DataType =  (uint)DataType.Boolean, BooleanValue = false},//D
            new Metric(){Name = METRIC_NCMD_GENERATEREPORT, DataType =  (uint)DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NCMD_SETPARAMETER, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_APP_MESSAGE, DataType =  (uint)DataType.String, StringValue = string.Empty},//D
            new Metric(){Name = METRIC_NDATA_APP_MODE, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_APP_VERSION, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_SYSTEM_NAME, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_SYSTEM_STATUS, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_SYSTEM_MODULES, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_NAME, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_TYPE, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_RUNFOLDER, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_MEASURESTARTAT, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_LIMITSTATUS, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_STATUS, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_TEST_RECORDNAME, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_TEST_RECORDSTATUS, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NDATA_TEST_SIGNALS, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_SIGNALDATA, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_CHANNELS, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_CHANNELSTATUS, DataType =  (uint)DataType.DataSet, DataSetValue = null},//d
            new Metric(){Name = METRIC_NDATA_TEST_PARAMETERS, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_LIST, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet()},//d
            new Metric(){Name = METRIC_NDATA_TEST_REPORT_NAME, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_REPORT_CONTENT, DataType =  (uint)DataType.File, BytesValue = null },//d
            new Metric(){Name = METRIC_NDATA_TEST_RECORD_NAME, DataType =  (uint)DataType.String,StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_RECORD_CONTENT, DataType =  (uint)DataType.File, BytesValue = null },//d
            new Metric(){Name = METRIC_NDATA_TEST_RUNFOLDER_NAME, DataType =  (uint)DataType.String, StringValue = string.Empty},//d
            new Metric(){Name = METRIC_NDATA_TEST_RUNFOLDER_FILES, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet() },//d
        };
        public static List<Metric> DSAMetrics { get; set; } = new List<Metric>()
        {
            new Metric(){Name = METRIC_NCMD_DSA_TRIGGERON, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_TRIGGEROFF, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_OUTPUTON, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_OUTPUTOFF, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_OUTPUTOFF, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_LIMITON, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_LIMITOFF, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_SETOUTPUTPARAMETERS, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_DSA_SETOUTPUTINDEX, DataType =  (uint)DataType.Int32, IntValue = 0},
            new Metric(){Name = METRIC_NCMD_DSA_REQUESTTRIGGERSETTINGS, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_SETTRIGGERSETTINGS, DataType =  (uint)DataType.String, StringValue = string.Empty},
            new Metric(){Name = METRIC_NCMD_DSA_TRIGGERACCEPT, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_TRIGGERNEXT, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NCMD_DSA_TRIGGERREJECT, DataType =  (uint)DataType.Boolean, BooleanValue = false},
            new Metric(){Name = METRIC_NDATA_DSA_STATUS, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet()},
            new Metric(){Name = METRIC_NDATA_DSA_TRIGGERSETTINGS, DataType =  (uint)DataType.DataSet, DataSetValue = null},
        };

        public static List<Metric> THVMetrics { get; set; } = new List<Metric>(VCSMetrics)
        {
            new Metric(){Name = METRIC_NDATA_THV_TH_STATUS, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet()},
            new Metric(){Name = METRIC_NDATA_THV_VT_STATUS, DataType =  (uint)DataType.DataSet, DataSetValue = new DataSet()},
        };
    }
}

