using UnityEngine;

namespace SouthPointe.Serialization.MessagePack;

public class Vector2Handler : ITypeHandler
{
	private readonly SerializationContext context;

	private ITypeHandler floatHandler;

	public Vector2Handler(SerializationContext context)
	{
		this.context = context;
	}

	public object Read(Format format, FormatReader reader)
	{
		if (format.IsArrayFamily)
		{
			floatHandler = floatHandler ?? context.TypeHandlers.Get<float>();
			return new Vector2
			{
				x = (float)floatHandler.Read(reader.ReadFormat(), reader),
				y = (float)floatHandler.Read(reader.ReadFormat(), reader)
			};
		}
		throw new FormatException(this, format, reader);
	}

	public void Write(object obj, FormatWriter writer)
	{
		Vector2 vector = (Vector2)obj;
		writer.WriteArrayHeader(2);
		writer.Write(vector.x);
		writer.Write(vector.y);
	}
}
