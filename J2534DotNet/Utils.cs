using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace J2534DotNet
{
    public static class Utils
    {
        public static string AsString(this IntPtr ptr)
        {
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static List<PassThruMsg> AsMsgList(this IntPtr ptr, int count)
        {
            List<PassThruMsg> list = new List<PassThruMsg>(count);
            for (int index = 0; index < count; ++index)
            {
                IntPtr ptr1 = (IntPtr) (Marshal.SizeOf(typeof (UnsafePassThruMsg))*index + (int) ptr);
                list.Add(ptr1.AsNullableStruct<UnsafePassThruMsg>().ConvertPassThruMsg());
            }
            return list;
        }

        public static List<T> AsList<T>(this IntPtr ptr, int count) where T : struct
        {
            List<T> list = new List<T>(count);
            for (int index = 0; index < count; ++index)
            {
                IntPtr ptr1 = (IntPtr) ((int) ptr + index*Marshal.SizeOf(typeof (T)));
                list.Add(ptr1.AsStruct<T>());
            }
            return list;
        }

        public static T AsStruct<T>(this IntPtr ptr) where T : struct
        {
            return (T) Marshal.PtrToStructure(ptr, typeof (T));
        }

        public static T? AsNullableStruct<T>(this IntPtr ptr) where T : struct
        {
            if (ptr == IntPtr.Zero)
                return new T?();
            return new T?((T) Marshal.PtrToStructure(ptr, typeof (T)));
        }

        public static string AsString(this List<PassThruMsg> list)
        {
            string str = string.Empty;
            for (int index = 0; index < list.Count; ++index)
                str = string.Concat(new object[4]
                {
                    (object) str,
                    (object) index,
                    (object) " -------------------------------",
                    (object) Environment.NewLine
                }) + list[index].ToString() + (object) index + " -------------------------------";
            return str;
        }

        public static unsafe UnsafePassThruMsg ConvertPassThruMsg(this PassThruMsg msg)
        {
            UnsafePassThruMsg unsafePassThruMsg = new UnsafePassThruMsg();
            unsafePassThruMsg.ProtocolID = (uint) msg.ProtocolID;
            unsafePassThruMsg.RxStatus = (uint) msg.RxStatus;
            unsafePassThruMsg.Timestamp = msg.Timestamp;
            unsafePassThruMsg.TxFlags = (uint) msg.TxFlags;
            unsafePassThruMsg.ExtraDataIndex = msg.ExtraDataIndex;
            unsafePassThruMsg.DataSize = (uint) msg.Data.Length;
            for (int index = 0; index < msg.Data.Length; ++index)
            {
                unsafePassThruMsg.Data[index] = msg.Data[index];
            }
            return unsafePassThruMsg;
        }

        public static PassThruMsg ConvertPassThruMsg(this UnsafePassThruMsg? uMsg)
        {
            return !uMsg.HasValue ? (PassThruMsg) null : Utils.ConvertPassThruMsg(uMsg.Value);
        }

        public static unsafe PassThruMsg ConvertPassThruMsg(this UnsafePassThruMsg uMsg)
        {
            PassThruMsg passThruMsg = new PassThruMsg();
            passThruMsg.ProtocolID = (ProtocolID) uMsg.ProtocolID;
            passThruMsg.RxStatus = (RxStatus) uMsg.RxStatus;
            passThruMsg.Timestamp = uMsg.Timestamp;
            passThruMsg.TxFlags = (TxFlag) uMsg.TxFlags;
            passThruMsg.ExtraDataIndex = uMsg.ExtraDataIndex;
            passThruMsg.Data = new byte[uMsg.DataSize];
            for (int index = 0; (long) index < (long) uMsg.DataSize; ++index)
            {
                passThruMsg.Data[index] = uMsg.Data[index];
            }
            return passThruMsg;
        }
    }
}
