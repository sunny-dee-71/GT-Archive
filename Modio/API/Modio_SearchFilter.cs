using System.Collections.Generic;

namespace Modio.API;

public abstract class SearchFilter
{
	internal int PageIndex;

	internal int PageSize;

	internal readonly Dictionary<string, object> Parameters;

	protected SearchFilter(int pageIndex, int pageSize)
	{
		Parameters = new Dictionary<string, object>();
		PageIndex = pageIndex;
		PageSize = pageSize;
	}
}
