using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal class ExceptionTypeTests
{
	[NativeThrows]
	public unsafe static void NullReferenceException(string nativeFormat, string values)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper nativeFormat2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(nativeFormat, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(nativeFormat);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					nativeFormat2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(values);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							NullReferenceException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
							return;
						}
					}
					NullReferenceException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			nativeFormat2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(values);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					NullReferenceException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			NullReferenceException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ArgumentNullException(string argumentName)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(argumentName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(argumentName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					ArgumentNullException_Injected(ref managedSpanWrapper);
					return;
				}
			}
			ArgumentNullException_Injected(ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void ArgumentException(string nativeFormat, string values)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper nativeFormat2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(nativeFormat, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(nativeFormat);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					nativeFormat2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(values);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							ArgumentException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
							return;
						}
					}
					ArgumentException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			nativeFormat2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(values);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					ArgumentException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			ArgumentException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void InvalidOperationException(string nativeFormat, string values)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper nativeFormat2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(nativeFormat, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(nativeFormat);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					nativeFormat2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(values);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							InvalidOperationException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
							return;
						}
					}
					InvalidOperationException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			nativeFormat2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(values, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(values);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					InvalidOperationException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
					return;
				}
			}
			InvalidOperationException_Injected(ref nativeFormat2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[NativeThrows]
	public unsafe static void IndexOutOfRangeException(string nativeFormat, int index)
	{
		//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(nativeFormat, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(nativeFormat);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					IndexOutOfRangeException_Injected(ref managedSpanWrapper, index);
					return;
				}
			}
			IndexOutOfRangeException_Injected(ref managedSpanWrapper, index);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void NullReferenceException_Injected(ref ManagedSpanWrapper nativeFormat, ref ManagedSpanWrapper values);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ArgumentNullException_Injected(ref ManagedSpanWrapper argumentName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ArgumentException_Injected(ref ManagedSpanWrapper nativeFormat, ref ManagedSpanWrapper values);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InvalidOperationException_Injected(ref ManagedSpanWrapper nativeFormat, ref ManagedSpanWrapper values);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void IndexOutOfRangeException_Injected(ref ManagedSpanWrapper nativeFormat, int index);
}
