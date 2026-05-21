using System;
using System.Collections.Generic;

namespace UnityEngine.TextCore.Text;

internal struct MaterialReference(int index, FontAsset fontAsset, SpriteAsset spriteAsset, Material material, float padding)
{
	public int index = index;

	public FontAsset fontAsset = fontAsset;

	public SpriteAsset spriteAsset = spriteAsset;

	public Material material = material;

	public bool isFallbackMaterial = false;

	public Material fallbackMaterial = null;

	public float padding = padding;

	public int referenceCount = 0;

	public static bool Contains(MaterialReference[] materialReferences, FontAsset fontAsset)
	{
		int hashCode = fontAsset.GetHashCode();
		for (int i = 0; i < materialReferences.Length && materialReferences[i].fontAsset != null; i++)
		{
			if (materialReferences[i].fontAsset.GetHashCode() == hashCode)
			{
				return true;
			}
		}
		return false;
	}

	public static int AddMaterialReference(Material material, FontAsset fontAsset, ref MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
	{
		int hashCode = material.GetHashCode();
		if (materialReferenceIndexLookup.TryGetValue(hashCode, out var value))
		{
			return value;
		}
		value = (materialReferenceIndexLookup[hashCode] = materialReferenceIndexLookup.Count);
		if (value >= materialReferences.Length)
		{
			Array.Resize(ref materialReferences, Mathf.NextPowerOfTwo(value + 1));
		}
		materialReferences[value].index = value;
		materialReferences[value].fontAsset = fontAsset;
		materialReferences[value].spriteAsset = null;
		materialReferences[value].material = material;
		materialReferences[value].referenceCount = 0;
		return value;
	}

	public static int AddMaterialReference(Material material, SpriteAsset spriteAsset, ref MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
	{
		int hashCode = material.GetHashCode();
		if (materialReferenceIndexLookup.TryGetValue(hashCode, out var value))
		{
			return value;
		}
		value = (materialReferenceIndexLookup[hashCode] = materialReferenceIndexLookup.Count);
		if (value >= materialReferences.Length)
		{
			Array.Resize(ref materialReferences, Mathf.NextPowerOfTwo(value + 1));
		}
		materialReferences[value].index = value;
		materialReferences[value].fontAsset = materialReferences[0].fontAsset;
		materialReferences[value].spriteAsset = spriteAsset;
		materialReferences[value].material = material;
		materialReferences[value].referenceCount = 0;
		return value;
	}
}
