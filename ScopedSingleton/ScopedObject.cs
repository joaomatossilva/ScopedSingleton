using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScopedSingleton
{
    public class ScopedObject
    {
        public IList<string> Data { get; } = new List<string>();
    }
}
