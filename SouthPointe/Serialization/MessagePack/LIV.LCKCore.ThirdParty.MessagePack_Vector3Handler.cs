using UnityEngine;

namespace SouthPointe.Serialization.MessagePack;

public class Vector3Handler : ITypeHandler
{
	private readonly SerializationContext context;

	private ITypeHandler floatHandler;

	public Vector3Handler(SerializationContext context)
	{
		this.context = context;
	}

	public object Read(Format format, FormatReader reader)
	{
		if (format.IsArrayFamily)
		{
			floatHandler = floatHandler ?? context.TypeHandlers.Get<float>();
			return new Vector3
			{
				x = (float)floatHandler.Read(reader.ReadFormat(), reader),
				y = (float)floatHandler.Read(reader.ReadFormat(), reader),
				z = (float)floatHandler.Read(reader.ReadFormat(), reader)
			};
		}
		throw new FormatException(this, format, reader);
	}

	public void Write(object obj, FormatWriter writer)
	{
		Vector3 vector = (Vector3)obj;
		writer.WriteArrayHeader(3);
		writer.Write(vector.x);
		writer.Write(vector.y);
		writer.Write(vector.z);
	}
}
