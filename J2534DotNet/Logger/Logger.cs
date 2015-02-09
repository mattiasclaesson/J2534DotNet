using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;

namespace J2534DotNet.Logger
{
    public static class Logger
    {
        [DllExport("PassThruOpen")]
        public static J2534Err PassThruOpen(IntPtr name, ref int deviceId)
        {
            Writer.Write("PassThruOpen start");

            var result = Loader.Lib.PassThruOpen(name, ref deviceId);

            Writer.Write("PassThruOpen result " + result);
            return result;
        }

        [DllExport("PassThruClose")]
        public static J2534Err PassThruClose(int deviceId)
        {
            Writer.Write("PassThruClose start");

            var result = Loader.Lib.PassThruClose(deviceId);

            Writer.Write("PassThruClose result " + result);
            return result;
        }

        [DllExport("PassThruConnect")]
        public static J2534Err PassThruConnect(int deviceId, ProtocolID protocolId, ConnectFlag flags, BaudRate baudRate, ref int channelId)
        {
            Writer.Write("PassThruConnect start");

            var result = Loader.Lib.PassThruConnect(deviceId, protocolId, flags, baudRate, ref channelId);

            Writer.Write("PassThruConnect result " + result);
            return result;
        }

        [DllExport("PassThruDisconnect")]
        public static J2534Err PassThruDisconnect(int channelId)
        {
            Writer.Write("PassThruDisconnect start");

            var result = Loader.Lib.PassThruDisconnect(channelId);

            Writer.Write("PassThruDisconnect result " + result);
            return result;
        }

        [DllExport("PassThruReadMsgs")]
        public static J2534Err PassThruReadMsgs(int channelId, IntPtr msgs, ref int numMsgs, int timeout)
        {
            Writer.Write("PassThruReadMsgs start");

            var result = Loader.Lib.PassThruReadMsgs(channelId, msgs, ref numMsgs, timeout);

            Writer.Write("PassThruReadMsgs result " + result);
            return result;
        }

        [DllExport("PassThruWriteMsgs")]
        public static J2534Err PassThruWriteMsgs(int channelId, ref UnsafePassThruMsg msg, ref int numMsgs, int timeout)
        {
            Writer.Write("PassThruWriteMsgs start");
            
            var result = Loader.Lib.PassThruWriteMsgs(channelId, ref msg, ref numMsgs, timeout);
            
            Writer.Write("PassThruWriteMsgs result " + result);
            return result;
        }

        [DllExport("PassThruStartPeriodicMsg")]
        public static J2534Err PassThruStartPeriodicMsg(int channelId, ref UnsafePassThruMsg msg, ref int msgId, int timeInterval)
        {
            Writer.Write("PassThruStartPeriodicMsg start");
            
            var result = Loader.Lib.PassThruStartPeriodicMsg(channelId, ref msg, ref msgId, timeInterval);
            
            Writer.Write("PassThruStartPeriodicMsg result " + result);
            return result;
        }

        [DllExport("PassThruStopPeriodicMsg")]
        public static J2534Err PassThruStopPeriodicMsg(int channelId, int msgId)
        {
            Writer.Write("PassThruStopPeriodicMsg start");

            var result = Loader.Lib.PassThruStopPeriodicMsg(channelId, msgId);

            Writer.Write("PassThruStopPeriodicMsg result " + result);
            return result;
        }

        [DllExport("PassThruStartMsgFilter")]
        public static J2534Err PassThruStartMsgFilter(int channelid, int filterType, ref UnsafePassThruMsg maskMsg,
            ref UnsafePassThruMsg patternMsg, ref UnsafePassThruMsg flowControlMsg, ref int filterId)
        {
            Writer.Write("PassThruStartMsgFilter start");

            var result = Loader.Lib.PassThruStartMsgFilter(channelid, (FilterType)filterType, ref maskMsg,
                ref patternMsg, ref flowControlMsg, ref filterId);

            Writer.Write("PassThruStartMsgFilter result " + result);
            return result;
        }

        [DllExport("PassThruStopMsgFilter")]
        public static J2534Err PassThruStopMsgFilter(int channelId, int filterId)
        {
            Writer.Write("PassThruStopMsgFilter start");

            var result = Loader.Lib.PassThruStopMsgFilter(channelId, filterId);

            Writer.Write("PassThruStopMsgFilter result " + result);
            return result;
        }

        [DllExport("PassThruSetProgrammingVoltage")]
        public static J2534Err PassThruSetProgrammingVoltage(int deviceId, int pinNumber, int voltage)
        {
            Writer.Write("PassThruSetProgrammingVoltage start");

            var result = Loader.Lib.PassThruSetProgrammingVoltage(deviceId, (PinNumber)pinNumber, voltage);

            Writer.Write("PassThruSetProgrammingVoltage result " + result);
            return result;
        }

        [DllExport("PassThruReadVersion")]
        public static J2534Err PassThruReadVersion(
            int deviceId, IntPtr firmwareVersion, IntPtr dllVersion, IntPtr apiVersion)
        {
            Writer.Write("PassThruReadVersion start");

            var result = Loader.Lib.PassThruReadVersion(deviceId, firmwareVersion, dllVersion, apiVersion);
            
            Writer.Write("PassThruReadVersion result {0}, firmwareVersion: {1}, dllVersion: {2}, apiVersion: {3}",
                result, firmwareVersion.AsString(), dllVersion.AsString(), apiVersion.AsString());
            return result;
        }

        [DllExport("PassThruGetLastError")]
        public static J2534Err PassThruGetLastError(IntPtr errorDescription)
        {
            Writer.Write("PassThruGetLastError start");

            var result = Loader.Lib.PassThruGetLastError(errorDescription);

            Writer.Write("PassThruGetLastError result: {0}, error text: {1}", result, errorDescription.AsString());
            
            return result;
        }

        [DllExport("PassThruIoctl")]
        public static int PassThruIoctl(int channelId, int ioctlID, IntPtr input, IntPtr output)
        {
            Writer.Write("PassThruIoctl start");

            var result = Loader.Lib.PassThruIoctl(channelId, ioctlID, input, output);

            Writer.Write("PassThruIoctl result " + result);
            return (int) result;
        }
    }
}
