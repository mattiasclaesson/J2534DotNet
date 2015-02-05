namespace J2534DotNet
{
    public unsafe struct UnsafePassThruMsg
    {
        public int ProtocolID;
        public int RxStatus;
        public int TxFlags;
        public int Timestamp;
        public int DataSize;
        public int ExtraDataIndex;
        public fixed byte Data[4128];
    }
}
