using System;
using UnityEngine;

namespace Meta.WitAi.Data.Info;

[Serializable]
public struct WitVersionTagInfo(string name, string createdAt, string updatedAt, string description)
{
	[SerializeField]
	public string name = name;

	[SerializeField]
	public string created_at = createdAt;

	[SerializeField]
	public string updated_at = updatedAt;

	[SerializeField]
	public string desc = description;
}
