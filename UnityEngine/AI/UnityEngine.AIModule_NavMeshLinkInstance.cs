using System;

namespace UnityEngine.AI;

public struct NavMeshLinkInstance
{
	internal int id { get; set; }

	[Obsolete("valid has been deprecated. Use NavMesh.IsLinkValid() instead.")]
	public bool valid => NavMesh.IsValidLinkHandle(id);

	[Obsolete("owner has been deprecated. Use NavMesh.GetLinkOwner() and NavMesh.SetLinkOwner() instead.")]
	public Object owner
	{
		get
		{
			return NavMesh.InternalGetLinkOwner(id);
		}
		set
		{
			int ownerID = ((value != null) ? value.GetInstanceID() : 0);
			if (!NavMesh.InternalSetLinkOwner(id, ownerID))
			{
				Debug.LogError("Cannot set 'owner' on an invalid NavMeshLinkInstance");
			}
		}
	}

	[Obsolete("Remove() has been deprecated. Use NavMesh.RemoveLink() instead.")]
	public void Remove()
	{
		NavMesh.RemoveLinkInternal(id);
	}
}
