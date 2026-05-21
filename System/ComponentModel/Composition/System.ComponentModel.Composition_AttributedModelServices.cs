using System.Collections.Generic;
using System.ComponentModel.Composition.AttributedModel;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Linq;
using System.Reflection;
using Microsoft.Internal;

namespace System.ComponentModel.Composition;

/// <summary>Contains helper methods for using the MEF attributed programming model with composition.</summary>
public static class AttributedModelServices
{
	/// <summary>Gets a metadata view object from a dictionary of loose metadata.</summary>
	/// <param name="metadata">A collection of loose metadata.</param>
	/// <typeparam name="TMetadataView">The type of the metadata view object to get.</typeparam>
	/// <returns>A metadata view containing the specified metadata.</returns>
	public static TMetadataView GetMetadataView<TMetadataView>(IDictionary<string, object> metadata)
	{
		Requires.NotNull(metadata, "metadata");
		return MetadataViewProvider.GetMetadataView<TMetadataView>(metadata);
	}

	/// <summary>Creates a composable part from the specified attributed object.</summary>
	/// <param name="attributedPart">The attributed object.</param>
	/// <returns>The created part.</returns>
	public static ComposablePart CreatePart(object attributedPart)
	{
		Requires.NotNull(attributedPart, "attributedPart");
		return AttributedModelDiscovery.CreatePart(attributedPart);
	}

	/// <summary>Creates a composable part from the specified attributed object, using the specified reflection context.</summary>
	/// <param name="attributedPart">The attributed object.</param>
	/// <param name="reflectionContext">The reflection context for the part.</param>
	/// <returns>The created part.</returns>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="reflectionContext" /> is <see langword="null" />.</exception>
	public static ComposablePart CreatePart(object attributedPart, ReflectionContext reflectionContext)
	{
		Requires.NotNull(attributedPart, "attributedPart");
		Requires.NotNull(reflectionContext, "reflectionContext");
		return AttributedModelDiscovery.CreatePart(attributedPart, reflectionContext);
	}

	/// <summary>Creates a composable part from the specified attributed object, using the specified part definition.</summary>
	/// <param name="partDefinition">The definition of the new part.</param>
	/// <param name="attributedPart">The attributed object.</param>
	/// <returns>The created part.</returns>
	public static ComposablePart CreatePart(ComposablePartDefinition partDefinition, object attributedPart)
	{
		Requires.NotNull(partDefinition, "partDefinition");
		Requires.NotNull(attributedPart, "attributedPart");
		return AttributedModelDiscovery.CreatePart((partDefinition as ReflectionComposablePartDefinition) ?? throw ExceptionBuilder.CreateReflectionModelInvalidPartDefinition("partDefinition", partDefinition.GetType()), attributedPart);
	}

	/// <summary>Creates a part definition with the specified type and origin.</summary>
	/// <param name="type">The type of the definition.</param>
	/// <param name="origin">The origin of the definition.</param>
	/// <returns>The new part definition.</returns>
	public static ComposablePartDefinition CreatePartDefinition(Type type, ICompositionElement origin)
	{
		Requires.NotNull(type, "type");
		return CreatePartDefinition(type, origin, ensureIsDiscoverable: false);
	}

	/// <summary>Creates a part definition with the specified type and origin.</summary>
	/// <param name="type">The type of the definition.</param>
	/// <param name="origin">The origin of the definition.</param>
	/// <param name="ensureIsDiscoverable">A value indicating whether or not the new definition should be discoverable.</param>
	/// <returns>The new part definition.</returns>
	public static ComposablePartDefinition CreatePartDefinition(Type type, ICompositionElement origin, bool ensureIsDiscoverable)
	{
		Requires.NotNull(type, "type");
		if (ensureIsDiscoverable)
		{
			return AttributedModelDiscovery.CreatePartDefinitionIfDiscoverable(type, origin);
		}
		return AttributedModelDiscovery.CreatePartDefinition(type, null, ignoreConstructorImports: false, origin);
	}

	/// <summary>Gets the unique identifier for the specified type.</summary>
	/// <param name="type">The type to examine.</param>
	/// <returns>The unique identifier for the type.</returns>
	public static string GetTypeIdentity(Type type)
	{
		Requires.NotNull(type, "type");
		return ContractNameServices.GetTypeIdentity(type);
	}

	/// <summary>Gets the unique identifier for the specified method.</summary>
	/// <param name="method">The method to examine.</param>
	/// <returns>The unique identifier for the method.</returns>
	public static string GetTypeIdentity(MethodInfo method)
	{
		Requires.NotNull(method, "method");
		return ContractNameServices.GetTypeIdentityFromMethod(method);
	}

	/// <summary>Gets a canonical contract name for the specified type.</summary>
	/// <param name="type">The type to use.</param>
	/// <returns>A contract name created from the specified type.</returns>
	public static string GetContractName(Type type)
	{
		Requires.NotNull(type, "type");
		return GetTypeIdentity(type);
	}

	/// <summary>Creates a part from the specified value and adds it to the specified batch.</summary>
	/// <param name="batch">The batch to add to.</param>
	/// <param name="exportedValue">The value to add.</param>
	/// <typeparam name="T">The type of the new part.</typeparam>
	/// <returns>The new part.</returns>
	public static ComposablePart AddExportedValue<T>(this CompositionBatch batch, T exportedValue)
	{
		Requires.NotNull(batch, "batch");
		string contractName = GetContractName(typeof(T));
		return batch.AddExportedValue(contractName, exportedValue);
	}

	/// <summary>Creates a part from the specified value and composes it in the specified composition container.</summary>
	/// <param name="container">The composition container to perform composition in.</param>
	/// <param name="exportedValue">The value to compose.</param>
	/// <typeparam name="T">The type of the new part.</typeparam>
	public static void ComposeExportedValue<T>(this CompositionContainer container, T exportedValue)
	{
		Requires.NotNull(container, "container");
		CompositionBatch batch = new CompositionBatch();
		batch.AddExportedValue(exportedValue);
		container.Compose(batch);
	}

	/// <summary>Creates a part from the specified value and adds it to the specified batch with the specified contract name.</summary>
	/// <param name="batch">The batch to add to.</param>
	/// <param name="contractName">The contract name of the export.</param>
	/// <param name="exportedValue">The value to add.</param>
	/// <typeparam name="T">The type of the new part.</typeparam>
	/// <returns>The new part.</returns>
	public static ComposablePart AddExportedValue<T>(this CompositionBatch batch, string contractName, T exportedValue)
	{
		Requires.NotNull(batch, "batch");
		string typeIdentity = GetTypeIdentity(typeof(T));
		IDictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("ExportTypeIdentity", typeIdentity);
		return batch.AddExport(new Export(contractName, dictionary, () => exportedValue));
	}

	/// <summary>Creates a part from the specified object under the specified contract name and composes it in the specified composition container.</summary>
	/// <param name="container">The composition container to perform composition in.</param>
	/// <param name="contractName">The contract name to export the part under.</param>
	/// <param name="exportedValue">The value to compose.</param>
	/// <typeparam name="T">The type of the new part.</typeparam>
	public static void ComposeExportedValue<T>(this CompositionContainer container, string contractName, T exportedValue)
	{
		Requires.NotNull(container, "container");
		CompositionBatch batch = new CompositionBatch();
		batch.AddExportedValue(contractName, exportedValue);
		container.Compose(batch);
	}

	/// <summary>Creates a composable part from the specified attributed object, and adds it to the specified composition batch.</summary>
	/// <param name="batch">The batch to add to.</param>
	/// <param name="attributedPart">The object to add.</param>
	/// <returns>The new part.</returns>
	public static ComposablePart AddPart(this CompositionBatch batch, object attributedPart)
	{
		Requires.NotNull(batch, "batch");
		Requires.NotNull(attributedPart, "attributedPart");
		ComposablePart composablePart = CreatePart(attributedPart);
		batch.AddPart(composablePart);
		return composablePart;
	}

	/// <summary>Creates composable parts from an array of attributed objects and composes them in the specified composition container.</summary>
	/// <param name="container">The composition container to perform composition in.</param>
	/// <param name="attributedParts">An array of attributed objects to compose.</param>
	public static void ComposeParts(this CompositionContainer container, params object[] attributedParts)
	{
		Requires.NotNull(container, "container");
		Requires.NotNullOrNullElements(attributedParts, "attributedParts");
		CompositionBatch batch = new CompositionBatch(attributedParts.Select((object attributedPart) => CreatePart(attributedPart)).ToArray(), Enumerable.Empty<ComposablePart>());
		container.Compose(batch);
	}

	/// <summary>Composes the specified part by using the specified composition service, with recomposition disabled.</summary>
	/// <param name="compositionService">The composition service to use.</param>
	/// <param name="attributedPart">The part to compose.</param>
	/// <returns>The composed part.</returns>
	public static ComposablePart SatisfyImportsOnce(this ICompositionService compositionService, object attributedPart)
	{
		Requires.NotNull(compositionService, "compositionService");
		Requires.NotNull(attributedPart, "attributedPart");
		ComposablePart composablePart = CreatePart(attributedPart);
		compositionService.SatisfyImportsOnce(composablePart);
		return composablePart;
	}

	/// <summary>Composes the specified part by using the specified composition service, with recomposition disabled and using the specified reflection context.</summary>
	/// <param name="compositionService">The composition service to use.</param>
	/// <param name="attributedPart">The part to compose.</param>
	/// <param name="reflectionContext">The reflection context for the part.</param>
	/// <returns>The composed part.</returns>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="reflectionContext" /> is <see langword="null" />.</exception>
	public static ComposablePart SatisfyImportsOnce(this ICompositionService compositionService, object attributedPart, ReflectionContext reflectionContext)
	{
		Requires.NotNull(compositionService, "compositionService");
		Requires.NotNull(attributedPart, "attributedPart");
		Requires.NotNull(reflectionContext, "reflectionContext");
		ComposablePart composablePart = CreatePart(attributedPart, reflectionContext);
		compositionService.SatisfyImportsOnce(composablePart);
		return composablePart;
	}

	/// <summary>Returns a value that indicates whether the specified part contains an export that matches the specified contract type.</summary>
	/// <param name="part">The part to search.</param>
	/// <param name="contractType">The contract type.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="part" /> contains an export definition that matches <paramref name="contractType" />; otherwise, <see langword="false" />.</returns>
	public static bool Exports(this ComposablePartDefinition part, Type contractType)
	{
		Requires.NotNull(part, "part");
		Requires.NotNull(contractType, "contractType");
		return part.Exports(GetContractName(contractType));
	}

	/// <summary>Returns a value that indicates whether the specified part contains an export that matches the specified contract type.</summary>
	/// <param name="part">The part to search.</param>
	/// <typeparam name="T">The contract type.</typeparam>
	/// <returns>
	///   <see langword="true" /> if <paramref name="part" /> contains an export definition of type <paramref name="T" />; otherwise, <see langword="false" />.</returns>
	public static bool Exports<T>(this ComposablePartDefinition part)
	{
		Requires.NotNull(part, "part");
		return part.Exports(typeof(T));
	}

	/// <summary>Returns a value that indicates whether the specified part contains an import that matches the specified contract type.</summary>
	/// <param name="part">The part to search.</param>
	/// <param name="contractType">The contract type.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="part" /> contains an import definition that matches <paramref name="contractType" />; otherwise, <see langword="false" />.</returns>
	public static bool Imports(this ComposablePartDefinition part, Type contractType)
	{
		Requires.NotNull(part, "part");
		Requires.NotNull(contractType, "contractType");
		return part.Imports(GetContractName(contractType));
	}

	/// <summary>Returns a value that indicates whether the specified part contains an import that matches the specified contract type.</summary>
	/// <param name="part">The part to search.</param>
	/// <typeparam name="T">The contract type.</typeparam>
	/// <returns>
	///   <see langword="true" /> if <paramref name="part" /> contains an import definition of type <paramref name="T" />; otherwise, <see langword="false" />.</returns>
	public static bool Imports<T>(this ComposablePartDefinition part)
	{
		Requires.NotNull(part, "part");
		return part.Imports(typeof(T));
	}

	/// <summary>Returns a value that indicates whether the specified part contains an import that matches the specified contract type and import cardinality.</summary>
	/// <param name="part">The part to search.</param>
	/// <param name="contractType">The contract type.</param>
	/// <param name="importCardinality">The import cardinality.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="part" /> contains an import definition that matches <paramref name="contractType" /> and <paramref name="importCardinality" />; otherwise, <see langword="false" />.</returns>
	public static bool Imports(this ComposablePartDefinition part, Type contractType, ImportCardinality importCardinality)
	{
		Requires.NotNull(part, "part");
		Requires.NotNull(contractType, "contractType");
		return part.Imports(GetContractName(contractType), importCardinality);
	}

	/// <summary>Returns a value that indicates whether the specified part contains an import that matches the specified contract type and import cardinality.</summary>
	/// <param name="part">The part to search.</param>
	/// <param name="importCardinality">The import cardinality.</param>
	/// <typeparam name="T">The contract type.</typeparam>
	/// <returns>
	///   <see langword="true" /> if <paramref name="part" /> contains an import definition of type <paramref name="T" /> that has the specified import cardinality; otherwise, <see langword="false" />.</returns>
	public static bool Imports<T>(this ComposablePartDefinition part, ImportCardinality importCardinality)
	{
		Requires.NotNull(part, "part");
		return part.Imports(typeof(T), importCardinality);
	}
}
