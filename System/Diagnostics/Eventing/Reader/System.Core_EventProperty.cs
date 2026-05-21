using System.Security.Permissions;
using Unity;

namespace System.Diagnostics.Eventing.Reader;

/// <summary>Contains the value of an event property that is specified by the event provider when the event is published.</summary>
[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
public sealed class EventProperty
{
	/// <summary>Gets the value of the event property that is specified by the event provider when the event is published.</summary>
	/// <returns>Returns an object.</returns>
	public object Value
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return null;
		}
	}

	internal EventProperty()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
