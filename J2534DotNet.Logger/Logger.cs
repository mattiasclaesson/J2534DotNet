using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;

namespace J2534DotNet.Logger
{
    public static class Logger
    {
        [DllExport("PassThruOpen", CallingConvention = CallingConvention.Cdecl)]
        public static J2534Err PassThruOpen(int nada, ref int deviceId)
        {
            return Loader.Lib.Open(ref deviceId);
        }

        [DllExport("PassThruClose", CallingConvention = CallingConvention.Cdecl)]
        public static J2534Err PassThruClose(int deviceId)
        {
            return Loader.Lib.Close(deviceId);
        }

        [DllExport("PassThruConnect", CallingConvention = CallingConvention.Cdecl)]
        public static J2534Err PassThruConnect(int deviceId, ProtocolID protocolId, ConnectFlag flags, BaudRate baudRate, ref int channelId)
        {
            return Loader.Lib.Connect(deviceId, protocolId, flags, baudRate, ref channelId);
        }

        [DllExport("PassThruDisconnect", CallingConvention = CallingConvention.Cdecl)]
        public static J2534Err PassThruDisconnect(int channelId)
        {
            return Loader.Lib.Disconnect(channelId);
        }

        [DllExport("PassThruReadMsgs", CallingConvention = CallingConvention.Cdecl)]
        public static J2534Err PassThruReadMsgs(int channelId, ref List<PassThruMsg> msgs, ref int numMsgs, int timeout)
        {
            return Loader.Lib.ReadMsgs(channelId, ref msgs, ref numMsgs, timeout);
        }

        [DllExport("PassThruWriteMsgs", CallingConvention = CallingConvention.Cdecl)]
        public static J2534Err PassThruWriteMsgs(int channelId, ref UnsafePassThruMsg msg, ref int numMsgs, int timeout)
        {
            var ptmsg = J2534.ConvertPassThruMsg(msg);
            return Loader.Lib.WriteMsgs(channelId, ref ptmsg, ref numMsgs, timeout);
        }

        [DllExport("PassThruStartPeriodicMsg", CallingConvention = CallingConvention.Cdecl)]
        public static J2534Err PassThruStartPeriodicMsg(int channelId, ref UnsafePassThruMsg msg, ref int msgId, int timeInterval)
        {
            var ptmsg = J2534.ConvertPassThruMsg(msg);
            return Loader.Lib.StartPeriodicMsg(channelId, ref ptmsg, ref msgId, timeInterval);
        }

        [DllExport("PassThruStopPeriodicMsg", CallingConvention = CallingConvention.Cdecl)]
        public static J2534Err PassThruStopPeriodicMsg(int channelId, int msgId)
        {
            return Loader.Lib.StopPeriodicMsg(channelId, msgId);
        }

        [DllExport("PassThruStartMsgFilter", CallingConvention = CallingConvention.Cdecl)]
        public static int PassThruStartMsgFilter
            (
            int channelid,
            int filterType,
            ref UnsafePassThruMsg maskMsg,
            ref UnsafePassThruMsg patternMsg,
            ref UnsafePassThruMsg flowControlMsg,
            ref int filterId
            )
        {
            return -1;
        }

        [DllExport("PassThruStartPassBlockMsgFilter", CallingConvention = CallingConvention.Cdecl)]
        public static int PassThruStartPassBlockMsgFilter
            (
            int channelid,
            int filterType,
            ref UnsafePassThruMsg uMaskMsg,
            ref UnsafePassThruMsg uPatternMsg,
            int nada,
            ref int filterId
            )
        {
            return -1;
        }

        [DllExport("PassThruStopMsgFilter", CallingConvention = CallingConvention.Cdecl)]
        public static int PassThruStopMsgFilter(int channelId, int filterId)
        {
            return -1;
        }

        [DllExport("PassThruSetProgrammingVoltage", CallingConvention = CallingConvention.Cdecl)]
        public static int PassThruSetProgrammingVoltage(int deviceId, int pinNumber, int voltage)
        {
            return -1;
        }

        [DllExport("PassThruReadVersion", CallingConvention = CallingConvention.Cdecl)]
        public static int PassThruReadVersion(
            int deviceId, IntPtr firmwareVersion, IntPtr dllVersion, IntPtr apiVersion)
        {
            return -1;
        }

        [DllExport("PassThruGetLastError", CallingConvention = CallingConvention.Cdecl)]
        public static int PassThruGetLastError(IntPtr errorDescription)
        {
            return -1;
        }

        [DllExport("PassThruIoctl", CallingConvention = CallingConvention.Cdecl)]
        public static int PassThruIoctl(int channelId, int ioctlID, IntPtr input, IntPtr output)
        {
            return -1;
        }
    }
}
