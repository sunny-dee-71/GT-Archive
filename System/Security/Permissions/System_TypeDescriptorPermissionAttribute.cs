using Unity;

namespace System.Security.Permissions;

/// <summary>Determines the permission flags that apply to a <see cref="T:System.ComponentModel.TypeDescriptor" />.</summary>
[Serializable]
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public sealed class TypeDescriptorPermissionAttribute : CodeAccessSecurityAttribute
{
	/// <summary>Gets or sets the <see cref="T:System.Security.Permissions.TypeDescriptorPermissionFlags" /> for the <see cref="T:System.ComponentModel.TypeDescriptor" />.</summary>
	/// <returns>The <see cref="T:System.Security.Permissions.TypeDescriptorPermissionFlags" /> for the <see cref="T:System.ComponentModel.TypeDescriptor" />.</returns>
	public TypeDescriptorPermissionFlags Flags
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default(TypeDescriptorPermissionFlags);
		}
		set
		{
		}
	}

	/// <summary>Gets or sets a value that indicates whether the type descriptor can be accessed from partial trust.</summary>
	/// <returns>
	///   <see langword="true" /> if the type descriptor can be accessed from partial trust; otherwise, <see langword="false" />.</returns>
	public bool RestrictedRegistrationAccess
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default(bool);
		}
		set
		{
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.TypeDescriptorPermissionAttribute" /> class with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
	/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
	public TypeDescriptorPermissionAttribute(SecurityAction action)
	{
	}

	/// <summary>When overridden in a derived class, creates a permission object that can then be serialized into binary form and persistently stored along with the <see cref="T:System.Security.Permissions.SecurityAction" /> in an assembly's metadata.</summary>
	/// <returns>A serializable permission object.</returns>
	public override IPermission CreatePermission()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
		return null;
	}
}
