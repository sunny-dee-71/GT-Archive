namespace UnityEngine.InputForUI;

internal interface IEventProviderImpl
{
	uint playerCount { get; }

	void Initialize();

	void Shutdown();

	void Update();

	void OnFocusChanged(bool focus);

	bool RequestCurrentState(Event.Type type);
}
