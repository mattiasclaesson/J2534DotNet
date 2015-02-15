using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J2534DotNet
{
    public class PassThruMsg
    {
        public PassThruMsg() { }
        public PassThruMsg(ProtocolID myProtocolId, TxFlag myTxFlag, byte[] myByteArray)
        {
            ProtocolID = myProtocolId;
            TxFlags = myTxFlag;
            Data = myByteArray;
        }
        public ProtocolID ProtocolID { get; set; }
        public RxStatus RxStatus { get; set; }
        public TxFlag TxFlags { get; set; }
        public uint Timestamp { get; set; }
        public uint ExtraDataIndex { get; set; }
        public byte[] Data { get; set; }

        public override string ToString()
        {
            return string.Format("Protocol: {1}{0}RxStatus: {2}{0}Timestamp: {3}{0}ExtraDataIndex: {4}{0}Data: {5}{0}", Environment.NewLine,
                ProtocolID,
                RxStatus,
                Timestamp,
                ExtraDataIndex,
                BitConverter.ToString(Data));
        }
    }
}
