using System.Text;

namespace Fusion;

public static class LogUtils
{
	public unsafe readonly struct DumpDeferredPtr<T>(T* ptr) where T : unmanaged, ILogDumpable
	{
		public unsafe override string ToString()
		{
			if (ptr != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				ptr->Dump(stringBuilder);
				return stringBuilder.ToString();
			}
			return "null";
		}
	}

	public readonly struct DumpDeferredStruct<T>(T obj) where T : unmanaged, ILogDumpable
	{
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			obj.Dump(stringBuilder);
			return stringBuilder.ToString();
		}
	}

	public readonly struct DumpDeferredClass(ILogDumpable obj)
	{
		public readonly ILogDumpable Obj = obj;

		public override string ToString()
		{
			if (Obj != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				Obj.Dump(stringBuilder);
				return stringBuilder.ToString();
			}
			return "null";
		}
	}

	public unsafe static DumpDeferredPtr<T> GetDump<T>(T* ptr) where T : unmanaged, ILogDumpable
	{
		return new DumpDeferredPtr<T>(ptr);
	}

	public static DumpDeferredClass GetDump<T>(T obj) where T : class, ILogDumpable
	{
		return new DumpDeferredClass(obj);
	}
}
