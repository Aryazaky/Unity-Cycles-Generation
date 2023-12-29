using System;
using System.Collections.Generic;

namespace Core
{
    public interface INodeTag<T>
    {
        IEnumerable<T> Tags { get; }
        bool ContainsTag(T tag);
    }
}