using UnityEngine;

namespace SouthPointe.Serialization.MessagePack;

public class Vector4Handler : ITypeHandler
{
	private readonly SerializationContext context;

	private ITypeHandler floatHandler;

	public Vector4Handler(SerializationContext context)
	{
		this.context = context;
	}

	public object Read(Format format, FormatReader reader)
	{
		if (format.IsArrayFamily)
		{
			floatHandler = floatHandler ?? context.TypeHandlers.Get<float>();
			return new Vector4
			{
				x = (float)floatHandler.Read(reader.ReadFormat(), reader),
				y = (float)floatHandler.Read(reader.ReadFormat(), reader),
				z = (float)floatHandler.Read(reader.ReadFormat(), reader),
				w = (float)floatHandler.Read(reader.ReadFormat(), reader)
			};
		}
		throw new FormatException(this, format, reader);
	}

	public void Write(object obj, FormatWriter writer)
	{
		Vector4 vector = (Vector4)obj;
		writer.WriteArrayHeader(4);
		writer.Write(vector.x);
		writer.Write(vector.y);
		writer.Write(vector.z);
		writer.Write(vector.w);
	}
}
