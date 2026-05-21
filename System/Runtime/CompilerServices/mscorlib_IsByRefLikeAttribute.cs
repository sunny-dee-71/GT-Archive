namespace System.Runtime.CompilerServices;

/// <summary>Indicates that a structure is byref-like.</summary>
[AttributeUsage(AttributeTargets.Struct)]
public sealed class IsByRefLikeAttribute : Attribute
{
	/// <summary>Creates a new instance of the <see cref="T:System.Runtime.CompilerServices.IsByRefLikeAttribute" /> class.</summary>
	public IsByRefLikeAttribute()
	{
	}
}
