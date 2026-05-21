using System;

namespace Modio.Customizations;

[Serializable]
internal struct WssMessages(params WssMessage[] messages)
{
	public WssMessage[] messages = messages;
}
