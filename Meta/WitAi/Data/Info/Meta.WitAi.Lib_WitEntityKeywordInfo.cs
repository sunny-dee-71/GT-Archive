using System;
using System.Collections.Generic;
using UnityEngine;

namespace Meta.WitAi.Data.Info;

[Serializable]
public struct WitEntityKeywordInfo(string keyword, List<string> synonyms = null)
{
	public string keyword = keyword;

	[NonReorderable]
	public List<string> synonyms = synonyms ?? new List<string>();

	public override bool Equals(object obj)
	{
		if (obj is WitEntityKeywordInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(WitEntityKeywordInfo other)
	{
		if (keyword == other.keyword)
		{
			return synonyms.Equivalent(other.synonyms);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (17 * 31 + keyword.GetHashCode()) * 31 + synonyms.GetHashCode();
	}
}
