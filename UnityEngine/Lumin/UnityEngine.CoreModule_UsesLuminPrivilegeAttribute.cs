using System;

namespace UnityEngine.Lumin;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[Obsolete("Lumin is no longer supported in Unity 2022.2")]
public sealed class UsesLuminPrivilegeAttribute : Attribute
{
	private readonly string m_Privilege;

	public string privilege => m_Privilege;

	public UsesLuminPrivilegeAttribute(string privilege)
	{
		m_Privilege = privilege;
	}
}
