using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

[NativeType("Modules/Marshalling/MarshallingTests.h")]
internal class ValueTypeListOfTTests
{
	[NativeThrows]
	public unsafe static void ParameterListOfIntRead(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntRead_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntRead_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntReadChangeVaules(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntReadChangeVaules_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntReadChangeVaules_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntAddNoGrow(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntAddNoGrow_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntAddNoGrow_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntAddAndGrow(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntAddAndGrow_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntAddAndGrow_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntPassNullThrow([NotNull] List<int> param)
	{
		if (param == null)
		{
			ThrowHelper.ThrowArgumentNullException(param, "param");
		}
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
			{
				BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
				if (array.Length != 0)
				{
					arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
				}
				param2 = new BlittableListWrapper(arrayWrapper, list.Count);
				ParameterListOfIntPassNullThrow_Injected(ref param2);
			}
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntPassNullNoThrow(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntPassNullNoThrow_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntPassNullNoThrow_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntNativeAllocateSmaller(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntNativeAllocateSmaller_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntNativeAllocateSmaller_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntNativeAttachOtherMemoryBlock(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntNativeAttachOtherMemoryBlock_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntNativeAttachOtherMemoryBlock_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfIntNativeCallsClear(List<int> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<int> list = default(List<int>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (int[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfIntNativeCallsClear_Injected(ref param2);
					return;
				}
			}
			ParameterListOfIntNativeCallsClear_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfBoolReadWrite(List<bool> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<bool> list = default(List<bool>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (bool[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfBoolReadWrite_Injected(ref param2);
					return;
				}
			}
			ParameterListOfBoolReadWrite_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfCharReadWrite(List<char> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<char> list = default(List<char>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (char[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfCharReadWrite_Injected(ref param2);
					return;
				}
			}
			ParameterListOfCharReadWrite_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfEnumReadWrite(List<SomeEnum> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<SomeEnum> list = default(List<SomeEnum>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (SomeEnum[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfEnumReadWrite_Injected(ref param2);
					return;
				}
			}
			ParameterListOfEnumReadWrite_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[NativeThrows]
	public unsafe static void ParameterListOfCornerCaseStructReadWrite(List<BlittableCornerCases> param)
	{
		//The blocks IL_0031 are reachable both inside and outside the pinned region starting at IL_000d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		List<BlittableCornerCases> list = default(List<BlittableCornerCases>);
		BlittableListWrapper param2 = default(BlittableListWrapper);
		try
		{
			list = param;
			if (list != null)
			{
				fixed (BlittableCornerCases[] array = NoAllocHelpers.ExtractArrayFromList(list))
				{
					BlittableArrayWrapper arrayWrapper = default(BlittableArrayWrapper);
					if (array.Length != 0)
					{
						arrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					param2 = new BlittableListWrapper(arrayWrapper, list.Count);
					ParameterListOfCornerCaseStructReadWrite_Injected(ref param2);
					return;
				}
			}
			ParameterListOfCornerCaseStructReadWrite_Injected(ref param2);
		}
		finally
		{
			param2.Unmarshal(list);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntRead_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntReadChangeVaules_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntAddNoGrow_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntAddAndGrow_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntPassNullThrow_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntPassNullNoThrow_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntNativeAllocateSmaller_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntNativeAttachOtherMemoryBlock_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfIntNativeCallsClear_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfBoolReadWrite_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfCharReadWrite_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfEnumReadWrite_Injected(ref BlittableListWrapper param);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ParameterListOfCornerCaseStructReadWrite_Injected(ref BlittableListWrapper param);
}
