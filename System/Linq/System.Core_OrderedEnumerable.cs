using System.Collections.Generic;

namespace System.Linq;

internal sealed class OrderedEnumerable<TElement, TKey> : OrderedEnumerable<TElement>
{
	private readonly OrderedEnumerable<TElement> _parent;

	private readonly Func<TElement, TKey> _keySelector;

	private readonly IComparer<TKey> _comparer;

	private readonly bool _descending;

	internal OrderedEnumerable(IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending, OrderedEnumerable<TElement> parent)
	{
		_source = source ?? throw Error.ArgumentNull("source");
		_parent = parent;
		_keySelector = keySelector ?? throw Error.ArgumentNull("keySelector");
		_comparer = comparer ?? Comparer<TKey>.Default;
		_descending = descending;
	}

	internal override EnumerableSorter<TElement> GetEnumerableSorter(EnumerableSorter<TElement> next)
	{
		EnumerableSorter<TElement> enumerableSorter = new EnumerableSorter<TElement, TKey>(_keySelector, _comparer, _descending, next);
		if (_parent != null)
		{
			enumerableSorter = _parent.GetEnumerableSorter(enumerableSorter);
		}
		return enumerableSorter;
	}

	internal override CachingComparer<TElement> GetComparer(CachingComparer<TElement> childComparer)
	{
		CachingComparer<TElement> cachingComparer = ((childComparer == null) ? new CachingComparer<TElement, TKey>(_keySelector, _comparer, _descending) : new CachingComparerWithChild<TElement, TKey>(_keySelector, _comparer, _descending, childComparer));
		if (_parent == null)
		{
			return cachingComparer;
		}
		return _parent.GetComparer(cachingComparer);
	}
}
