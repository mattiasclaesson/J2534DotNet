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

        private const string tab = "    ";

        public override string ToString()
        {
            return
                string.Format(
                    "{6}{5}Protocol: {0}{6}{5}RxStatus: {1}{6}{5}Timestamp: {2}{6}{5}ExtraDataIndex: {3}{6}{5}Data: {4}",
                    ProtocolID,
                    RxStatus,
                    Timestamp,
                    ExtraDataIndex,
                    BitConverter.ToString(Data),
                    tab,
                    Environment.NewLine);
        }
    }
}
