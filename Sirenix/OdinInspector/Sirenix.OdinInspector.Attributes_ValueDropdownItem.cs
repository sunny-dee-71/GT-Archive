namespace Sirenix.OdinInspector;

public struct ValueDropdownItem<T>(string text, T value) : IValueDropdownItem
{
	public string Text = text;

	public T Value = value;

	string IValueDropdownItem.GetText()
	{
		return Text;
	}

	object IValueDropdownItem.GetValue()
	{
		return Value;
	}

	public override string ToString()
	{
		object obj = Text;
		if (obj == null)
		{
			T value = Value;
			obj = value?.ToString() ?? "";
		}
		return (string)obj;
	}
}
