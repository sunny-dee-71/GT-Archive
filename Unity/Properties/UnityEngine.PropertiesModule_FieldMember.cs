using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Properties.Internal;

namespace Unity.Properties;

internal readonly struct FieldMember(FieldInfo fieldInfo) : IMemberInfo
{
	internal readonly FieldInfo m_FieldInfo = fieldInfo;

	public string Name { get; } = ReflectionUtilities.SanitizeMemberName(m_FieldInfo);

	public bool IsReadOnly => m_FieldInfo.IsInitOnly;

	public Type ValueType => m_FieldInfo.FieldType;

	public object GetValue(object obj)
	{
		return m_FieldInfo.GetValue(obj);
	}

	public void SetValue(object obj, object value)
	{
		m_FieldInfo.SetValue(obj, value);
	}

	public IEnumerable<Attribute> GetCustomAttributes()
	{
		return m_FieldInfo.GetCustomAttributes();
	}
}
