using System.Collections.Generic;

namespace System.Linq.Parallel;

internal class ParallelEnumerableWrapper<T> : ParallelQuery<T>
{
	private readonly IEnumerable<T> _wrappedEnumerable;

	internal IEnumerable<T> WrappedEnumerable => _wrappedEnumerable;

	internal ParallelEnumerableWrapper(IEnumerable<T> wrappedEnumerable)
		: base(QuerySettings.Empty)
	{
		_wrappedEnumerable = wrappedEnumerable;
	}

	public override IEnumerator<T> GetEnumerator()
	{
		return _wrappedEnumerable.GetEnumerator();
	}
}
