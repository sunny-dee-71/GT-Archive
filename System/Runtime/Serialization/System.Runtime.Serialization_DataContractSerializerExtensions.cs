using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;

namespace System.Runtime.Serialization;

/// <summary>Extends the <see cref="T:System.Runtime.Serialization.DataContractSerializer" /> class by providing methods for setting and getting an <see cref="T:System.Runtime.Serialization.ISerializationSurrogateProvider" />.</summary>
public static class DataContractSerializerExtensions
{
	private class SurrogateProviderAdapter : IDataContractSurrogate
	{
		private ISerializationSurrogateProvider _provider;

		public ISerializationSurrogateProvider Provider => _provider;

		public SurrogateProviderAdapter(ISerializationSurrogateProvider provider)
		{
			_provider = provider;
		}

		public object GetCustomDataToExport(Type clrType, Type dataContractType)
		{
			throw System.NotImplemented.ByDesign;
		}

		public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
		{
			throw System.NotImplemented.ByDesign;
		}

		public Type GetDataContractType(Type type)
		{
			return _provider.GetSurrogateType(type);
		}

		public object GetDeserializedObject(object obj, Type targetType)
		{
			return _provider.GetDeserializedObject(obj, targetType);
		}

		public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
		{
			throw System.NotImplemented.ByDesign;
		}

		public object GetObjectToSerialize(object obj, Type targetType)
		{
			return _provider.GetObjectToSerialize(obj, targetType);
		}

		public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
		{
			throw System.NotImplemented.ByDesign;
		}

		public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
		{
			throw System.NotImplemented.ByDesign;
		}
	}

	/// <summary>Returns the surrogate serialization provider for this serializer.</summary>
	/// <param name="serializer">The serializer which is being surrogated.</param>
	/// <returns>The surrogate serializer.</returns>
	public static ISerializationSurrogateProvider GetSerializationSurrogateProvider(this DataContractSerializer serializer)
	{
		if (serializer.DataContractSurrogate is SurrogateProviderAdapter surrogateProviderAdapter)
		{
			return surrogateProviderAdapter.Provider;
		}
		return null;
	}

	/// <summary>Specifies a surrogate serialization provider for this <see cref="T:System.Runtime.Serialization.DataContractSerializer" />.</summary>
	/// <param name="serializer">The serializer which is being surrogated.</param>
	/// <param name="provider">The surrogate serialization provider.</param>
	public static void SetSerializationSurrogateProvider(this DataContractSerializer serializer, ISerializationSurrogateProvider provider)
	{
		IDataContractSurrogate value = ((provider != null) ? new SurrogateProviderAdapter(provider) : null);
		typeof(DataContractSerializer).GetField("dataContractSurrogate", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(serializer, value);
	}
}
