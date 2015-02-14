namespace J2534DotNet
{
    public unsafe struct UnsafePassThruMsg
    {
        public uint ProtocolID;
        public uint RxStatus;
        public uint TxFlags;
        public uint Timestamp;
        public uint DataSize;
        public uint ExtraDataIndex;
        public fixed byte Data[4128];

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
