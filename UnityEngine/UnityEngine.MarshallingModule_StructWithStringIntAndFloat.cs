using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine;

[NativeHeader("Modules/Marshalling/MarshallingTests.h")]
[ExcludeFromDocs]
internal struct StructWithStringIntAndFloat
{
	public string a;

	public int b;

	public float c;

	public override bool Equals(object other)
	{
		if (other == null)
		{
			return false;
		}
		if (other is StructWithStringIntAndFloat structWithStringIntAndFloat)
		{
			return a.Equals(structWithStringIntAndFloat.a) && b == structWithStringIntAndFloat.b && c == structWithStringIntAndFloat.c;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return a.GetHashCode();
	}
}
