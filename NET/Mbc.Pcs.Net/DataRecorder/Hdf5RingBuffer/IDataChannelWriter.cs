﻿using System;

namespace Mbc.Pcs.Net.DataRecorder.Hdf5RingBuffer
{
    public interface IDataChannelWriter
    {
        void WriteChannel(string channelName, Array values);
    }
}
