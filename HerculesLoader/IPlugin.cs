using System;
using System.Collections.Generic;
using System.Text;

namespace HerculesLoader
{
    public interface IPlugin
    {
        string Name { get; }
        void Initialize();
    }
}
