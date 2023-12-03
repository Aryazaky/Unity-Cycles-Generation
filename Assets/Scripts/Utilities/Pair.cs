using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    /// <summary>
    /// Represents a pair of two items of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the pair.</typeparam>
    public class Pair<T>
    {
        public T ItemA { get; }
        public T ItemB { get; }

        public Pair(T itemA, T itemB)
        {
            ItemA = itemA;
            ItemB = itemB;
        }

        /// <summary>
        /// Checks whether a specific item exists in the pair.
        /// </summary>
        /// <param name="item">The item to check for in the pair.</param>
        public bool Contains(T item)
        {
            return EqualityComparer<T>.Default.Equals(ItemA, item) || EqualityComparer<T>.Default.Equals(ItemB, item);
        }

        /// <summary>
        /// Gets the other item in the pair based on the specified item.
        /// </summary>
        /// <param name="item">The item in the pair for which to retrieve the other item.</param>
        /// <returns>The other item in the pair.</returns>
        public T GetOther(T item)
        {
            if (EqualityComparer<T>.Default.Equals(ItemA, item))
            {
                return ItemB;
            }
            else if (EqualityComparer<T>.Default.Equals(ItemB, item))
            {
                return ItemA;
            }
            else
            {
                throw new ArgumentException("Item not found in the pair");
            }
        }
    }

    /// <summary>
    /// Represents a collection of unique pairs of items with the constraint that individual items are unique across all pairs.
    /// </summary>
    /// <typeparam name="T">The type of items in the pairs.</typeparam>
    public class PairSet<T> : ISet<Pair<T>>
    {
        private readonly HashSet<Pair<T>> pairs = new HashSet<Pair<T>>();

        /// <summary>
        /// Adds a unique pair to the PairSet, ensuring that no items in the pair already exist in other pairs.
        /// </summary>
        /// <param name="pair">The pair to add to the PairSet.</param>
        public bool Add(Pair<T> pair)
        {
            if (pair == null)
            {
                throw new ArgumentNullException(nameof(pair), "Pair cannot be null");
            }

            if (pairs.Any(p => p.Contains(pair.ItemA) || p.Contains(pair.ItemB)))
            {
                return false;
            }

            pairs.Add(pair);
            return true;
        }

        /// <summary>
        /// Gets the other item in the pair based on the specified item.
        /// </summary>
        /// <param name="item">The item in the pair for which to retrieve the other item.</param>
        public T this[T item]
        {
            get
            {
                foreach (var pair in pairs)
                {
                    if (pair.Contains(item))
                    {
                        return pair.GetOther(item);
                    }
                }
                throw new ArgumentException("Item not found in any pair");
            }
        }
        
        /// <summary>
        /// Checks whether a specific item exists in any pair within the PairSet.
        /// </summary>
        /// <param name="item">The item to check for in the pairs.</param>
        public bool Contains(T item) => pairs.Any(pair => pair.Contains(item));

        public void ExceptWith(IEnumerable<Pair<T>> other) => pairs.ExceptWith(other);

        public void IntersectWith(IEnumerable<Pair<T>> other) => pairs.IntersectWith(other);

        public bool IsProperSubsetOf(IEnumerable<Pair<T>> other) => pairs.IsProperSubsetOf(other);

        public bool IsProperSupersetOf(IEnumerable<Pair<T>> other) => pairs.IsProperSupersetOf(other);

        public bool IsSubsetOf(IEnumerable<Pair<T>> other) => pairs.IsSubsetOf(other);

        public bool IsSupersetOf(IEnumerable<Pair<T>> other) => pairs.IsSupersetOf(other);

        public bool Overlaps(IEnumerable<Pair<T>> other) => pairs.Overlaps(other);

        public bool SetEquals(IEnumerable<Pair<T>> other) => pairs.SetEquals(other);

        public void SymmetricExceptWith(IEnumerable<Pair<T>> other) => pairs.SymmetricExceptWith(other);

        public void UnionWith(IEnumerable<Pair<T>> other) => pairs.UnionWith(other);

        void ICollection<Pair<T>>.Add(Pair<T> item) => Add(item ?? throw new ArgumentNullException(nameof(item)));

        public void Clear() => pairs.Clear();

        public bool Contains(Pair<T> item) => pairs.Contains(item);

        public void CopyTo(Pair<T>[] array, int arrayIndex) => pairs.CopyTo(array, arrayIndex);

        public bool Remove(Pair<T> item) => pairs.Remove(item);

        public int Count => pairs.SelectMany(p => new[] { p.ItemA, p.ItemB }).Distinct().Count();

        public bool IsReadOnly => false;

        public IEnumerator<Pair<T>> GetEnumerator()
        {
            return pairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}