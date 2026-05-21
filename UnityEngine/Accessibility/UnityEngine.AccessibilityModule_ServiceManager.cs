using System;
using System.Collections.Generic;

namespace UnityEngine.Accessibility;

internal class ServiceManager
{
	private readonly IDictionary<Type, IService> m_Services;

	public ServiceManager()
	{
		m_Services = new Dictionary<Type, IService>();
		AccessibilityManager.screenReaderStatusChanged += ScreenReaderStatusChanged;
		UpdateServices(AssistiveSupport.isScreenReaderEnabled);
	}

	public T GetService<T>() where T : IService
	{
		Type typeFromHandle = typeof(T);
		m_Services.TryGetValue(typeFromHandle, out var value);
		return (T)value;
	}

	private void StartService<T>() where T : IService
	{
		T service = GetService<T>();
		if (service == null)
		{
			Type typeFromHandle = typeof(T);
			service = (T)Activator.CreateInstance(typeFromHandle);
			service.Start();
			m_Services.Add(typeFromHandle, service);
		}
	}

	private void StopService<T>() where T : IService
	{
		T service = GetService<T>();
		if (service != null)
		{
			service.Stop();
			m_Services.Remove(typeof(T));
		}
	}

	private void UpdateServices(bool isScreenReaderEnabled)
	{
		if (isScreenReaderEnabled)
		{
			if (!m_Services.ContainsKey(typeof(AccessibilityHierarchyService)))
			{
				AccessibilityHierarchyService accessibilityHierarchyService = new AccessibilityHierarchyService();
				accessibilityHierarchyService.Start();
				m_Services.Add(typeof(AccessibilityHierarchyService), accessibilityHierarchyService);
			}
		}
		else
		{
			StopService<AccessibilityHierarchyService>();
		}
	}

	protected void ScreenReaderStatusChanged(bool isScreenReaderEnabled)
	{
		UpdateServices(isScreenReaderEnabled);
	}
}
