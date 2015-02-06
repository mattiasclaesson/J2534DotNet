using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;

namespace J2534DotNet.Logger
{
    public static class Logger
    {
        [DllExport("PassThruOpen")]
        public static J2534Err PassThruOpen(int nada, ref int deviceId)
        {
            Writer.Write("PassThruOpen start");

            var result = Loader.Lib.Open(ref deviceId);

            Writer.Write("PassThruOpen result " + result);
            return result;
        }

        [DllExport("PassThruClose")]
        public static J2534Err PassThruClose(int deviceId)
        {
            Writer.Write("PassThruClose start");

            var result = Loader.Lib.Close(deviceId);

            Writer.Write("PassThruClose result " + result);
            return result;
        }

        [DllExport("PassThruConnect")]
        public static J2534Err PassThruConnect(int deviceId, ProtocolID protocolId, ConnectFlag flags, BaudRate baudRate, ref int channelId)
        {
            Writer.Write("PassThruConnect start");

            var result = Loader.Lib.Connect(deviceId, protocolId, flags, baudRate, ref channelId);

            Writer.Write("PassThruConnect result " + result);
            return result;
        }

        [DllExport("PassThruDisconnect")]
        public static J2534Err PassThruDisconnect(int channelId)
        {
            Writer.Write("PassThruDisconnect start");

            var result = Loader.Lib.Disconnect(channelId);

            Writer.Write("PassThruDisconnect result " + result);
            return result;
        }

        [DllExport("PassThruReadMsgs")]
        public static J2534Err PassThruReadMsgs(int channelId, ref List<PassThruMsg> msgs, ref int numMsgs, int timeout)
        {
            Writer.Write("PassThruReadMsgs start");

            var result = Loader.Lib.ReadMsgs(channelId, ref msgs, ref numMsgs, timeout);

            Writer.Write("PassThruReadMsgs result " + result);
            return result;
        }

        [DllExport("PassThruWriteMsgs")]
        public static J2534Err PassThruWriteMsgs(int channelId, ref UnsafePassThruMsg msg, ref int numMsgs, int timeout)
        {
            Writer.Write("PassThruWriteMsgs start");

            var ptmsg = J2534.ConvertPassThruMsg(msg);
            var result = Loader.Lib.WriteMsgs(channelId, ref ptmsg, ref numMsgs, timeout);
            msg = J2534.ConvertPassThruMsg(ptmsg);

            Writer.Write("PassThruWriteMsgs result " + result);
            return result;
        }

        [DllExport("PassThruStartPeriodicMsg")]
        public static J2534Err PassThruStartPeriodicMsg(int channelId, ref UnsafePassThruMsg msg, ref int msgId, int timeInterval)
        {
            Writer.Write("PassThruStartPeriodicMsg start");

            var ptmsg = J2534.ConvertPassThruMsg(msg);
            var result = Loader.Lib.StartPeriodicMsg(channelId, ref ptmsg, ref msgId, timeInterval);
            msg = J2534.ConvertPassThruMsg(ptmsg);

            Writer.Write("PassThruStartPeriodicMsg result " + result);
            return result;
        }

        [DllExport("PassThruStopPeriodicMsg")]
        public static J2534Err PassThruStopPeriodicMsg(int channelId, int msgId)
        {
            Writer.Write("PassThruStopPeriodicMsg start");

            var result = Loader.Lib.StopPeriodicMsg(channelId, msgId);

            Writer.Write("PassThruStopPeriodicMsg result " + result);
            return result;
        }

        [DllExport("PassThruStartMsgFilter")]
        public static J2534Err PassThruStartMsgFilter(int channelid, int filterType, ref UnsafePassThruMsg maskMsg,
            ref UnsafePassThruMsg patternMsg, ref UnsafePassThruMsg flowControlMsg, ref int filterId)
        {
            Writer.Write("PassThruStartMsgFilter start");

            var localMaskMsg = J2534.ConvertPassThruMsg(maskMsg);
            var localpatternMsg = J2534.ConvertPassThruMsg(patternMsg);
            var localflowControlMsg = J2534.ConvertPassThruMsg(flowControlMsg);

            var result = Loader.Lib.StartMsgFilter(channelid, (FilterType) filterType, ref localMaskMsg,
                ref localpatternMsg, ref localflowControlMsg, ref filterId);

            maskMsg = J2534.ConvertPassThruMsg(localMaskMsg);
            patternMsg = J2534.ConvertPassThruMsg(localpatternMsg);
            flowControlMsg = J2534.ConvertPassThruMsg(localflowControlMsg);

            Writer.Write("PassThruStartMsgFilter result " + result);
            return result;
        }

        [DllExport("PassThruStartPassBlockMsgFilter")]
        public static int PassThruStartPassBlockMsgFilter(int channelid, int filterType, ref UnsafePassThruMsg maskMsg,
            ref UnsafePassThruMsg patternMsg, int nada, ref int filterId)
        {
            return 0;
        }

        [DllExport("PassThruStopMsgFilter")]
        public static J2534Err PassThruStopMsgFilter(int channelId, int filterId)
        {
            Writer.Write("PassThruStopMsgFilter start");

            var result = Loader.Lib.StopMsgFilter(channelId, filterId);

            Writer.Write("PassThruStopMsgFilter result " + result);
            return result;
        }

        [DllExport("PassThruSetProgrammingVoltage")]
        public static J2534Err PassThruSetProgrammingVoltage(int deviceId, int pinNumber, int voltage)
        {
            Writer.Write("PassThruSetProgrammingVoltage start");

            var result = Loader.Lib.SetProgrammingVoltage(deviceId, (PinNumber)pinNumber, voltage);

            Writer.Write("PassThruSetProgrammingVoltage result " + result);
            return result;
        }

        [DllExport("PassThruReadVersion")]
        public static J2534Err PassThruReadVersion(
            int deviceId, IntPtr firmwareVersion, IntPtr dllVersion, IntPtr apiVersion)
        {
            Writer.Write("PassThruReadVersion start");

            string strFirmwareVersion = string.Empty;
            string strDllVersion = string.Empty;
            string strAPIVersion = string.Empty;

            var result = Loader.Lib.ReadVersion(deviceId, ref strFirmwareVersion, ref strDllVersion, ref strAPIVersion);

            var ptr = Marshal.StringToHGlobalUni(strFirmwareVersion);
            CopyMemory(firmwareVersion, ptr, 200);

            ptr = Marshal.StringToHGlobalUni(strDllVersion);
            CopyMemory(dllVersion, ptr, 200);
                
            ptr = Marshal.StringToHGlobalUni(strAPIVersion);
            CopyMemory(apiVersion, ptr, 200);

            Writer.Write("PassThruReadVersion result {0}, firmwareVersion: {1}, dllVersion: {2}, apiVersion: {3}",
                result, strFirmwareVersion, strDllVersion, strAPIVersion);
            return result;
        }

        [DllExport("PassThruGetLastError")]
        public static J2534Err PassThruGetLastError(IntPtr errorDescription)
        {
            Writer.Write("PassThruGetLastError start");

            string strError = string.Empty;
            var result = Loader.Lib.GetLastError(ref strError);

            var error = Marshal.StringToHGlobalUni(strError);
            CopyMemory(errorDescription, error, 200);

            Writer.Write("PassThruGetLastError result: {0}, error text: {1}", result, strError);
            return result;
        }

        [DllExport("PassThruIoctl")]
        public static int PassThruIoctl(int channelId, int ioctlID, IntPtr input, IntPtr output)
        {
            Writer.Write("PassThruIoctl start");

            var result = Loader.Lib.RawIoctl(channelId, ioctlID, input, output);

            Writer.Write("PassThruIoctl result " + result);
            return (int) result;
        }


        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
    }
}
