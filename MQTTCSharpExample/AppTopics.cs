using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public static class AppTopics
    {
        public const string TOPIC_APP_MESSAGE = "App/Message";//d
        public const string TOPIC_APP_STATUS = "App/Status";//d
        public const string TOPIC_APP_ERROR = "App/Error";//d

        public const string TOPIC_APP_SYSTEM = "App/System";//d
        public const string TOPIC_APP_SYSTEM_STATUS = "App/System/Status";//d
        public const string TOPIC_APP_SYSTEM_TIMESTATUS = "App/System/TimeStatus";//d

        public const string TOPIC_APP_TEST = "App/Test";//d
        public const string TOPIC_APP_TEST_COMMAND = "App/Test/Command";//d
        public const string TOPIC_APP_TEST_STATUS = "App/Test/Status";//d
        public const string TOPIC_APP_TEST_LIMITSTATUS = "App/Test/LimitStatus";//d
        public const string TOPIC_APP_TEST_RECORDSTATUS = "App/Test/RecordStatus";//d
        public const string TOPIC_APP_TEST_LIST = "App/Test/List";//d
        public const string TOPIC_APP_TEST_REPORTFILE = "App/Test/ReportFile";//d
        public const string TOPIC_APP_TEST_REPORTTEMPLATES = "App/Test/ReportTemplates";//d
        public const string TOPIC_APP_TEST_REPORTNOTES = "App/Test/ReportNotes";//d


        public const string TOPIC_APP_TEST_RECORDFILE = "App/Test/RecordFile";
        public const string TOPIC_APP_TEST_CHANNELS = "App/Test/Channels";
        public const string TOPIC_APP_TEST_CHANNELSTATUS = "App/Test/ChannelStatus";
        public const string TOPIC_APP_TEST_PARAMETERS = "App/Test/Parameters";
        public const string TOPIC_APP_TEST_SIGNALS = "App/Test/Signals";//d
        public const string TOPIC_APP_TEST_SIGNALDATA = "App/Test/SignalData";//d
        public const string TOPIC_APP_TEST_COMPRESSED_SIGNALDATA = "App/Test/CompressedSignalData";

        public const string TOPIC_APP_TEST_SINGLESIGNALDATA = "App/Test/SingleSignalData";//d
        public const string TOPIC_APP_TEST_COMPRESSED_SINGLESIGNALDATA = "App/Test/CompressedSingleSignalData";

        public const string TOPIC_APP_TEST_SIGNALPROPERTY = "App/Test/SignalProperty";//d
        public const string TOPIC_APP_TEST_RUNFOLDER = "App/Test/RunFolder";//d

        public const string TOPIC_APP_TEST_ADV_STATUS = "App/Test/AdvancedStatus";
    }

    public static class GlobalParameterTopics
    {
        public const string TOPIC_GLOBAL_PARAMETER_REQUEST = "GlobalParameter/Request";
        public const string TOPIC_GLOBAL_PARAMETER_RESPONSE = "GlobalParameter/Response";
    }

    public static class DSATopics
    {
        public const string TOPIC_DSA_TEST_COMMAND = "DSA/Test/Command";
        public const string TOPIC_DSA_TEST_DSA_STATUS = "DSA/Test/DSAStatus";
    }

    public static class VCSTopics
    {
        public const string TOPIC_VCS_TEST_COMMAND = "VCS/Test/Command";
        public const string TOPIC_VCS_TEST_STAGE = "VCS/Test/Stage";
        public const string TOPIC_VCS_TEST_CONTROL_UPDATED = "VCS/Test/ControlUpdated";
        public const string TOPIC_VCS_TEST_SHAKER = "VCS/Test/Shaker";


        public const string TOPIC_VCS_TEST_RANDOM_STATUS = "VCS/Test/RandomStatus";
        public const string TOPIC_VCS_TEST_SINE_STATUS = "VCS/Test/SineStatus";
        public const string TOPIC_VCS_TEST_SHOCK_STATUS = "VCS/Test/ShockStatus";
        public const string TOPIC_VCS_TEST_TWR_STATUS = "VCS/Test/TWRStatus";


    }

    public static class THVTopics
    {
        public const string TOPIC_THV_TEST_COMMAND = "THV/Test/Command";
        public const string TOPIC_THV_TEST_TH_STATUS = "THV/Test/THStatus";
        public const string TOPIC_THV_TEST_VT_STATUS = "THV/Test/VHStatus";
    }


    public static class StatusKey
    {
        public const string Paused = nameof(Paused);
        public const string Running = nameof(Running);
        public const string Stopped = nameof(Stopped);
        public const string Started = nameof(Started);
        public const string Connected = nameof(Connected);
        public const string Disconnected = nameof(Disconnected);
        public const string Detected = nameof(Detected);
        public const string NotDetected = nameof(NotDetected);
    }

    public static class CommandKey
    {
        //common
        public const string Pause = nameof(Pause);
        public const string Continue = nameof(Continue);
        public const string Run = nameof(Run);
        public const string Stop = nameof(Stop);
        public const string Connect = nameof(Connect);
        public const string Disconnect = nameof(Disconnect);
        public const string StartRecord = nameof(StartRecord);
        public const string StopRecord = nameof(StopRecord);
        public const string SaveSignals = nameof(SaveSignals);
        public const string ResetAverage = nameof(ResetAverage);
        public const string RequestDetailStatus = nameof(RequestDetailStatus);
        public const string RequestSignalData = nameof(RequestSignalData);
        public const string RequestSignalDataWithFormat = nameof(RequestSignalDataWithFormat);
        public const string RequestSignalProperty = nameof(RequestSignalProperty);
        public const string RequestTestStatus = nameof(RequestTestStatus);
        public const string RequestReportFile = nameof(RequestReportFile);
        public const string RequestChannelStatus = nameof(RequestChannelStatus);

        public const string ListReportNotes = nameof(ListReportNotes);
        public const string SetReportNotes = nameof(SetReportNotes);

        public const string RequestRunFolder = nameof(RequestRunFolder);
        public const string RequestRecordFile = nameof(RequestRecordFile);

        public const string LoadTest = nameof(LoadTest);
        public const string CreateTest = nameof(CreateTest);
        public const string DeleteTest = nameof(DeleteTest);
        public const string ListTest = nameof(ListTest);

        public const string GenerateReport = nameof(GenerateReport);

        public const string SetParameter = nameof(SetParameter);
        public const string ListParameters = nameof(ListParameters);

        public const string ShutdownPC = nameof(ShutdownPC);

        public const string SetNTP = nameof(SetNTP);

        //global parameters
        public const string ListGlobalParameters = nameof(ListGlobalParameters);

        //dsa
        public const string TriggerOn = nameof(TriggerOn);
        public const string TriggerOff = nameof(TriggerOff);

        public const string OutputOn = nameof(OutputOn);
        public const string OutputOff = nameof(OutputOff);
        public const string SetOutputParameters = nameof(SetOutputParameters);
        public const string SetOutputIndex = nameof(SetOutputIndex);

        public const string LimitOn = nameof(LimitOn);
        public const string LimitOff = nameof(LimitOff);

        //vcs
        public const string CheckOnly = nameof(CheckOnly);
        public const string Proceed = nameof(Proceed);
        public const string SaveHSignal = nameof(SaveHSignal);

        public const string SetLevel = nameof(SetLevel);
        public const string LevelUp = nameof(LevelUp);
        public const string LevelDown = nameof(LevelDown);
        public const string RestoreLevel = nameof(RestoreLevel);
        public const string NextEntry = nameof(NextEntry);
        public const string ShowPretest = nameof(ShowPretest);
        public const string AbortChecksOn = nameof(AbortChecksOn);
        public const string AbortChecksOff = nameof(AbortChecksOff);
        public const string ScheduleClockTimerOn = nameof(ScheduleClockTimerOn);
        public const string ScheduleClockTimerOff = nameof(ScheduleClockTimerOff);
        public const string ClosedLoopControlOn = nameof(ClosedLoopControlOn);
        public const string ClosedLoopControlOff = nameof(ClosedLoopControlOff);


        public const string SetFrequency = nameof(SetFrequency);
        public const string SetPhase = nameof(SetPhase);
        public const string HoldSweep = nameof(HoldSweep);
        public const string SweepUp = nameof(SweepUp);
        public const string SweepDown = nameof(SweepDown);
        public const string ReleaseSweep = nameof(ReleaseSweep);
        public const string IncreaseSpeed = nameof(IncreaseSpeed);
        public const string DecreaseSpeed = nameof(DecreaseSpeed);

        public const string RoRBandsOn = nameof(RoRBandsOn);
        public const string RoRBandsOff = nameof(RoRBandsOff);

        public const string SoRTonesOn = nameof(SoRTonesOn);
        public const string SoRTonesOff = nameof(SoRTonesOff);

        public const string SoRTonesHoldSweep = nameof(SoRTonesHoldSweep);
        public const string SoRTonesReleaseSweep = nameof(SoRTonesReleaseSweep);

        public const string SoRTonesSweepUp = nameof(SoRTonesSweepUp);
        public const string SoRTonesSweepDown = nameof(SoRTonesSweepDown);

        public const string InversePulseOn = nameof(InversePulseOn);
        public const string InversePulseOff = nameof(InversePulseOff);

        public const string SinglePulseOn = nameof(SinglePulseOn);
        public const string SinglePulseOff = nameof(SinglePulseOff);

        public const string OutputSinglePulse = nameof(OutputSinglePulse);

        public const string SetChannelTable = nameof(SetChannelTable);
        public const string SetRandomProfile = nameof(SetRandomProfile);
        public const string SetSineProfile = nameof(SetSineProfile);
        public const string SetShockProfile = nameof(SetShockProfile);
        public const string SetSchedule = nameof(SetSchedule);
        public const string SetInputRange = nameof(SetInputRange);

        public const string RequestPeakFrequency = nameof(RequestPeakFrequency);
        public const string RequestPeakValue = nameof(RequestPeakValue);

        //Test Sequence (FAT)
        public const string StartTestSequence = nameof(StartTestSequence);
        public const string PauseTestSequence = nameof(PauseTestSequence);
        public const string ResumeTestSequence = nameof(ResumeTestSequence);
        public const string StopTestSequence = nameof(StopTestSequence);
        public const string NextTestSequence = nameof(NextTestSequence);

        //ReportNotes


        //thv
    }

    public static class MQTTCommand
    {
        public const string CMD_MQTT_PUBLISH = nameof(CMD_MQTT_PUBLISH);
        public const string CMD_MQTT_START = nameof(CMD_MQTT_START);
        public const string CMD_MQTT_STOP = nameof(CMD_MQTT_STOP);
        public const string CMD_MQTT_CONNECT = nameof(CMD_MQTT_CONNECT);
        public const string CMD_MQTT_DISCONNECT = nameof(CMD_MQTT_DISCONNECT);
    }
}
