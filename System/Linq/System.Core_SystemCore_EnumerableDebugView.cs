using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Linq;

internal sealed class SystemCore_EnumerableDebugView
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IEnumerable _enumerable;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public object[] Items
	{
		get
		{
			List<object> list = new List<object>();
			foreach (object item in _enumerable)
			{
				list.Add(item);
			}
			if (list.Count == 0)
			{
				throw new SystemCore_EnumerableDebugViewEmptyException();
			}
			return list.ToArray();
		}
	}

	public SystemCore_EnumerableDebugView(IEnumerable enumerable)
	{
		_enumerable = enumerable ?? throw Error.ArgumentNull("enumerable");
	}
}
