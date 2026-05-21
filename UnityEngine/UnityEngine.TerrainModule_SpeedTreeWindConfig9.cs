using System;
using System.Runtime.InteropServices;

namespace UnityEngine;

internal struct SpeedTreeWindConfig9
{
	public float strengthResponse = 5f;

	public float directionResponse = 2.5f;

	public float gustFrequency = 0f;

	public float gustStrengthMin = 0.5f;

	public float gustStrengthMax = 1f;

	public float gustDurationMin = 1f;

	public float gustDurationMax = 4f;

	public float gustRiseScalar = 1f;

	public float gustFallScalar = 1f;

	public float branch1StretchLimit = 1f;

	public float branch2StretchLimit = 1f;

	public float sharedHeightStart = 0f;

	public unsafe fixed float bendShared[20];

	public unsafe fixed float oscillationShared[20];

	public unsafe fixed float speedShared[20];

	public unsafe fixed float turbulenceShared[20];

	public unsafe fixed float flexibilityShared[20];

	public float independenceShared = 0f;

	public unsafe fixed float bendBranch1[20];

	public unsafe fixed float oscillationBranch1[20];

	public unsafe fixed float speedBranch1[20];

	public unsafe fixed float turbulenceBranch1[20];

	public unsafe fixed float flexibilityBranch1[20];

	public float independenceBranch1 = 0f;

	public unsafe fixed float bendBranch2[20];

	public unsafe fixed float oscillationBranch2[20];

	public unsafe fixed float speedBranch2[20];

	public unsafe fixed float turbulenceBranch2[20];

	public unsafe fixed float flexibilityBranch2[20];

	public float independenceBranch2 = 0f;

	public unsafe fixed float planarRipple[20];

	public unsafe fixed float directionalRipple[20];

	public unsafe fixed float speedRipple[20];

	public unsafe fixed float flexibilityRipple[20];

	public float independenceRipple = 0f;

	public float shimmerRipple = 0f;

	public float treeExtentX = 0f;

	public float treeExtentY = 0f;

	public float treeExtentZ = 0f;

	public float windIndependence = 0f;

	public int doShared = 0;

	public int doBranch1 = 0;

	public int doBranch2 = 0;

	public int doRipple = 0;

	public int doShimmer = 0;

	public int lodFade = 0;

	public float importScale = 1f;

	public readonly bool IsWindEnabled => doShared != 0 || doBranch1 != 0 || doBranch2 != 0 || doRipple != 0;

	public SpeedTreeWindConfig9()
	{
	}

	public static byte[] Serialize(SpeedTreeWindConfig9 config)
	{
		int num = Marshal.SizeOf(config);
		byte[] array = new byte[num];
		GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
		try
		{
			IntPtr ptr = gCHandle.AddrOfPinnedObject();
			Marshal.StructureToPtr(config, ptr, fDeleteOld: false);
		}
		finally
		{
			gCHandle.Free();
		}
		return array;
	}
}
