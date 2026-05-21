namespace System.Runtime.Serialization;

/// <summary>Specifies that the type defines or implements a data contract and is serializable by a serializer, such as the <see cref="T:System.Runtime.Serialization.DataContractSerializer" />. To make their type serializable, type authors must define a data contract for their type.</summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
public sealed class DataContractAttribute : Attribute
{
	private string name;

	private string ns;

	private bool isNameSetExplicitly;

	private bool isNamespaceSetExplicitly;

	private bool isReference;

	private bool isReferenceSetExplicitly;

	/// <summary>Gets or sets a value that indicates whether to preserve object reference data.</summary>
	/// <returns>
	///   <see langword="true" /> to keep object reference data using standard XML; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
	public bool IsReference
	{
		get
		{
			return isReference;
		}
		set
		{
			isReference = value;
			isReferenceSetExplicitly = true;
		}
	}

	/// <summary>Gets whether <see cref="P:System.Runtime.Serialization.DataContractAttribute.IsReference" /> has been explicitly set.</summary>
	/// <returns>
	///   <see langword="true" /> if the reference has been explicitly set; otherwise, <see langword="false" />.</returns>
	public bool IsReferenceSetExplicitly => isReferenceSetExplicitly;

	/// <summary>Gets or sets the namespace for the data contract for the type.</summary>
	/// <returns>The namespace of the contract.</returns>
	public string Namespace
	{
		get
		{
			return ns;
		}
		set
		{
			ns = value;
			isNamespaceSetExplicitly = true;
		}
	}

	/// <summary>Gets whether <see cref="P:System.Runtime.Serialization.DataContractAttribute.Namespace" /> has been explicitly set.</summary>
	/// <returns>
	///   <see langword="true" /> if the namespace has been explicitly set; otherwise, <see langword="false" />.</returns>
	public bool IsNamespaceSetExplicitly => isNamespaceSetExplicitly;

	/// <summary>Gets or sets the name of the data contract for the type.</summary>
	/// <returns>The local name of a data contract. The default is the name of the class that the attribute is applied to.</returns>
	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
			isNameSetExplicitly = true;
		}
	}

	/// <summary>Gets whether <see cref="P:System.Runtime.Serialization.DataContractAttribute.Name" /> has been explicitly set.</summary>
	/// <returns>
	///   <see langword="true" /> if the name has been explicitly set; otherwise, <see langword="false" />.</returns>
	public bool IsNameSetExplicitly => isNameSetExplicitly;

	/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Serialization.DataContractAttribute" /> class.</summary>
	public DataContractAttribute()
	{
	}
}
