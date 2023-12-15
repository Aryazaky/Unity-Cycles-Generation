using System;
using System.Collections.Generic;

namespace Core
{
    public interface INodeTag<T> where T : IEquatable<T>
    {
        IEnumerable<T> Tags { get; }
        bool ContainsTag(T tag);
    }
}