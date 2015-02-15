using System;
using RGiesecke.DllExport;

namespace J2534DotNet.Logger
{
    public static class Logger
    {
        [DllExport("PassThruOpen")]
        public static J2534Err PassThruOpen(IntPtr name, ref int deviceId)
        {
            Log.Write("PassThruOpen(IntPtr name, ref int deviceId)");
            Log.Write("PassThruOpen({0}, {1})", name.AsString(), deviceId);

            var result = Loader.Lib.PassThruOpen(name, ref deviceId);

            Log.Write("PassThruOpen result: " + result);

            return result;
        }

        [DllExport("PassThruClose")]
        public static J2534Err PassThruClose(int deviceId)
        {
            Log.Write("PassThruClose(int deviceId)");
            Log.Write("PassThruClose({0})", deviceId);

            var result = Loader.Lib.PassThruClose(deviceId);

            Log.Write("PassThruClose result: " + result);

            return result;
        }

        [DllExport("PassThruConnect")]
        public static J2534Err PassThruConnect(int deviceId, ProtocolID protocolId, ConnectFlag flags, BaudRate baudRate, ref int channelId)
        {
            Log.Write("PassThruConnect(int deviceId, ProtocolID protocolId, ConnectFlag flags, BaudRate baudRate, ref int channelId)");
            Log.Write("PassThruConnect({0}, {1}, {2}, {3}, {4})", deviceId, protocolId, flags, baudRate, channelId);

            var result = Loader.Lib.PassThruConnect(deviceId, protocolId, flags, baudRate, ref channelId);

            Log.Write("PassThruConnect result: " + result);

            return result;
        }

        [DllExport("PassThruDisconnect")]
        public static J2534Err PassThruDisconnect(int channelId)
        {
            Log.Write("PassThruDisconnect(int channelId)");
            Log.Write("PassThruDisconnect({0})", channelId);

            var result = Loader.Lib.PassThruDisconnect(channelId);

            Log.Write("PassThruDisconnect result: " + result);

            return result;
        }

        [DllExport("PassThruReadMsgs")]
        public static J2534Err PassThruReadMsgs(int channelId, IntPtr msgs, ref int numMsgs, int timeout)
        {
            Log.Write("PassThruReadMsgs(int channelId, IntPtr msgs, ref int numMsgs, int timeout)");
            Log.Write("PassThruReadMsgs({0}, {1}, {2}, {3})", channelId, msgs, numMsgs, timeout);

            var result = Loader.Lib.PassThruReadMsgs(channelId, msgs, ref numMsgs, timeout);

            Log.Write("PassThruReadMsgs result: " + result);
            Log.Write(msgs.AsMsgList(numMsgs).AsString());
            Log.Write("PassThruReadMsgs end");

            return result;
        }

        [DllExport("PassThruWriteMsgs")]
        public static J2534Err PassThruWriteMsgs(int channelId, IntPtr msgs, ref int numMsgs, int timeout)
        {
            Log.Write("PassThruWriteMsgs(int channelId, IntPtr msgs, ref int numMsgs, int timeout)");
            Log.Write("PassThruWriteMsgs({0}, {1}, {2}, {3})", channelId, msgs, numMsgs, timeout);
            Log.Write(msgs.AsMsgList(numMsgs).AsString());

            var result = Loader.Lib.PassThruWriteMsgs(channelId, msgs, ref numMsgs, timeout);

            Log.Write("PassThruWriteMsgs result: " + result);

            return result;
        }

        [DllExport("PassThruStartPeriodicMsg")]
        public static J2534Err PassThruStartPeriodicMsg(int channelId, ref UnsafePassThruMsg msg, ref int msgId, int timeInterval)
        {
            Log.Write("PassThruStartPeriodicMsg(int channelId, ref UnsafePassThruMsg msg, ref int msgId, int timeInterval)");
            Log.Write("PassThruStartPeriodicMsg({0}, {1}, {2}, {3})", channelId, msg, msgId, timeInterval);
            Log.Write(msg.ConvertPassThruMsg().ToString());

            var result = Loader.Lib.PassThruStartPeriodicMsg(channelId, ref msg, ref msgId, timeInterval);

            Log.Write("PassThruStartPeriodicMsg result: " + result);

            return result;
        }

        [DllExport("PassThruStopPeriodicMsg")]
        public static J2534Err PassThruStopPeriodicMsg(int channelId, int msgId)
        {
            Log.Write("PassThruStopPeriodicMsg(int channelId, int msgId)");
            Log.Write("PassThruStopPeriodicMsg({0}, {1})", channelId, msgId);

            var result = Loader.Lib.PassThruStopPeriodicMsg(channelId, msgId);

            Log.Write("PassThruStopPeriodicMsg result: " + result);

            return result;
        }

        [DllExport("PassThruStartMsgFilter")]
        public static J2534Err PassThruStartMsgFilter(int channelid, int filterType, ref UnsafePassThruMsg maskMsg,
            ref UnsafePassThruMsg patternMsg, ref UnsafePassThruMsg flowControlMsg, ref int filterId)
        {
            Log.Write("PassThruStartMsgFilter(int channelid, int filterType, ref UnsafePassThruMsg maskMsg, " +
                      "ref UnsafePassThruMsg patternMsg, ref UnsafePassThruMsg flowControlMsg, ref int filterId)");
            Log.Write("PassThruStartMsgFilter({0}, {1}, {2}, {3}, {4}, {5})", channelid, filterType, maskMsg, patternMsg,
                flowControlMsg, filterId);
            Log.Write("maskMsg: " + Environment.NewLine + maskMsg.ConvertPassThruMsg());
            Log.Write("patternMsg: " + Environment.NewLine + patternMsg.ConvertPassThruMsg());
            Log.Write("flowControlMsg: " + Environment.NewLine + flowControlMsg.ConvertPassThruMsg());

            var result = Loader.Lib.PassThruStartMsgFilter(channelid, (FilterType)filterType, ref maskMsg,
                ref patternMsg, ref flowControlMsg, ref filterId);

            Log.Write("PassThruStartMsgFilter result: " + result);

            return result;
        }

        [DllExport("PassThruStopMsgFilter")]
        public static J2534Err PassThruStopMsgFilter(int channelId, int filterId)
        {
            Log.Write("PassThruStopMsgFilter(int channelId, int filterId)");
            Log.Write("PassThruStopMsgFilter({0}, {1})", channelId, filterId);

            var result = Loader.Lib.PassThruStopMsgFilter(channelId, filterId);

            Log.Write("PassThruStopMsgFilter result: " + result);

            return result;
        }

        [DllExport("PassThruSetProgrammingVoltage")]
        public static J2534Err PassThruSetProgrammingVoltage(int deviceId, PinNumber pinNumber, int voltage)
        {
            Log.Write("PassThruSetProgrammingVoltage(int deviceId, PinNumber pinNumber, int voltage)");
            Log.Write("PassThruSetProgrammingVoltage({0}, {1}, {2})", deviceId, pinNumber, voltage);

            var result = Loader.Lib.PassThruSetProgrammingVoltage(deviceId, pinNumber, voltage);

            Log.Write("PassThruSetProgrammingVoltage result: " + result);

            return result;
        }

        [DllExport("PassThruReadVersion")]
        public static J2534Err PassThruReadVersion(
            int deviceId, IntPtr firmwareVersion, IntPtr dllVersion, IntPtr apiVersion)
        {
            Log.Write("PassThruReadVersion(int deviceId, IntPtr firmwareVersion, IntPtr dllVersion, IntPtr apiVersion)");
            Log.Write("PassThruReadVersion({0}, {1}, {2}, {3})", deviceId, firmwareVersion, dllVersion, apiVersion);

            var result = Loader.Lib.PassThruReadVersion(deviceId, firmwareVersion, dllVersion, apiVersion);

            Log.Write("firmwareVersion: {1}{0}dllVersion: {2}{0}apiVersion: {3}", Environment.NewLine, firmwareVersion.AsString(),
                dllVersion.AsString(), apiVersion.AsString());
            Log.Write("PassThruReadVersion result: " + result);

            return result;
        }

        [DllExport("PassThruGetLastError")]
        public static J2534Err PassThruGetLastError(IntPtr errorDescription)
        {
            Log.Write("PassThruGetLastError(IntPtr errorDescription)");
            Log.Write("PassThruGetLastError({0})", errorDescription);

            var result = Loader.Lib.PassThruGetLastError(errorDescription);

            Log.Write("Error: " + errorDescription.AsString());
            Log.Write("PassThruGetLastError result: " + result);

            return result;
        }

        [DllExport("PassThruIoctl")]
        public static int PassThruIoctl(int channelId, int ioctlID, IntPtr input, IntPtr output)
        {
            Log.Write("PassThruIoctl(int channelId, int ioctlID, IntPtr input, IntPtr output)");
            Log.Write("PassThruIoctl({0}, {1}, {2}, {3})", channelId, ioctlID, input, output);

            var result = Loader.Lib.PassThruIoctl(channelId, ioctlID, input, output);

            Log.Write("PassThruIoctl result: " + result);

            return (int)result;
        }
    }
}
