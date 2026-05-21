using System;
using VYaml.Emitter;
using VYaml.Parser;

namespace VYaml.Serialization;

public class TupleFormatter<T1, T2, T3, T4, T5, T6, T7, T8> : IYamlFormatter<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>?>, IYamlFormatter where T8 : notnull
{
	public void Serialize(ref Utf8YamlEmitter emitter, Tuple<T1, T2, T3, T4, T5, T6, T7, T8>? value, YamlSerializationContext context)
	{
		if (value == null)
		{
			emitter.WriteNull();
			return;
		}
		emitter.BeginSequence(SequenceStyle.Flow);
		context.Serialize(ref emitter, value.Item1);
		context.Serialize(ref emitter, value.Item2);
		context.Serialize(ref emitter, value.Item3);
		context.Serialize(ref emitter, value.Item4);
		context.Serialize(ref emitter, value.Item5);
		context.Serialize(ref emitter, value.Item6);
		context.Serialize(ref emitter, value.Item7);
		context.Serialize(ref emitter, value.Rest);
		emitter.EndSequence();
	}

	public Tuple<T1, T2, T3, T4, T5, T6, T7, T8>? Deserialize(ref YamlParser parser, YamlDeserializationContext context)
	{
		if (parser.IsNullScalar())
		{
			return null;
		}
		parser.ReadWithVerify(ParseEventType.SequenceStart);
		T1 item = context.DeserializeWithAlias<T1>(ref parser);
		T2 item2 = context.DeserializeWithAlias<T2>(ref parser);
		T3 item3 = context.DeserializeWithAlias<T3>(ref parser);
		T4 item4 = context.DeserializeWithAlias<T4>(ref parser);
		T5 item5 = context.DeserializeWithAlias<T5>(ref parser);
		T6 item6 = context.DeserializeWithAlias<T6>(ref parser);
		T7 item7 = context.DeserializeWithAlias<T7>(ref parser);
		T8 rest = context.DeserializeWithAlias<T8>(ref parser);
		parser.ReadWithVerify(ParseEventType.SequenceEnd);
		return new Tuple<T1, T2, T3, T4, T5, T6, T7, T8>(item, item2, item3, item4, item5, item6, item7, rest);
	}
}
