namespace System.Runtime.CompilerServices;

/// <summary>Marks a program element as read-only.</summary>
[AttributeUsage(AttributeTargets.All, Inherited = false)]
public sealed class IsReadOnlyAttribute : Attribute
{
	/// <summary>Creates a new instance of the <see cref="T:System.Runtime.CompilerServices.IsReadOnlyAttribute" /> class.</summary>
	public IsReadOnlyAttribute()
	{
	}
}
