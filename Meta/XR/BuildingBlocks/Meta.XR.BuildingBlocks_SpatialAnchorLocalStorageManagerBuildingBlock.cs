using System;
using System.Collections.Generic;
using UnityEngine;

namespace Meta.XR.BuildingBlocks;

public class SpatialAnchorLocalStorageManagerBuildingBlock : MonoBehaviour
{
	private SpatialAnchorCoreBuildingBlock _spatialAnchorCore;

	private const string NumUuidsPlayerPref = "numUuids";

	private void Start()
	{
		_spatialAnchorCore = SpatialAnchorCoreBuildingBlock.GetFirstInstance();
		_spatialAnchorCore.OnAnchorCreateCompleted.AddListener(SaveAnchorUuidToLocalStorage);
		_spatialAnchorCore.OnAnchorEraseCompleted.AddListener(RemoveAnchorFromLocalStorage);
	}

	internal void SaveAnchorUuidToLocalStorage(OVRSpatialAnchor anchor, OVRSpatialAnchor.OperationResult result)
	{
		if (result == OVRSpatialAnchor.OperationResult.Success)
		{
			if (!PlayerPrefs.HasKey("numUuids"))
			{
				PlayerPrefs.SetInt("numUuids", 0);
			}
			int num = PlayerPrefs.GetInt("numUuids");
			PlayerPrefs.SetString("uuid" + num, anchor.Uuid.ToString());
			PlayerPrefs.SetInt("numUuids", ++num);
		}
	}

	internal void RemoveAnchorFromLocalStorage(OVRSpatialAnchor anchor, OVRSpatialAnchor.OperationResult result)
	{
		Guid uuid = anchor.Uuid;
		if (result == OVRSpatialAnchor.OperationResult.Failure)
		{
			return;
		}
		int num = PlayerPrefs.GetInt("numUuids", 0);
		for (int i = 0; i < num; i++)
		{
			string key = "uuid" + i;
			if (PlayerPrefs.GetString(key, "").Equals(uuid.ToString()))
			{
				string key2 = "uuid" + (num - 1);
				string value = PlayerPrefs.GetString(key2);
				PlayerPrefs.SetString(key, value);
				PlayerPrefs.DeleteKey(key2);
				num--;
				if (num < 0)
				{
					num = 0;
				}
				PlayerPrefs.SetInt("numUuids", num);
				break;
			}
		}
	}

	internal void GetAnchorAnchorUuidFromLocalStorage(List<Guid> uuids)
	{
		if (!PlayerPrefs.HasKey("numUuids"))
		{
			Reset();
			Debug.Log("[SpatialAnchorLocalStorageManagerBuildingBlock] Anchor not found.");
			return;
		}
		uuids.Clear();
		int num = PlayerPrefs.GetInt("numUuids");
		for (int i = 0; i < num; i++)
		{
			string key = "uuid" + i;
			if (PlayerPrefs.HasKey(key))
			{
				string g = PlayerPrefs.GetString(key);
				uuids.Add(new Guid(g));
			}
		}
	}

	public void Reset()
	{
		PlayerPrefs.SetInt("numUuids", 0);
	}

	private void OnDestroy()
	{
		_spatialAnchorCore.OnAnchorCreateCompleted.RemoveAllListeners();
	}
}
