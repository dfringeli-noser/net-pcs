﻿using System.Collections.Generic;

namespace Mbc.Pcs.Net
{
    public interface ICommandOutput
    {
        IEnumerable<string> GetOutputNames();

        void SetOutputData<T>(string name, T value);

        T GetOutputData<T>(string name);
    }
}
