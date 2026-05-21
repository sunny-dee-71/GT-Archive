namespace System.IO;

/// <summary>Contains information on the change that occurred.</summary>
public struct WaitForChangedResult
{
	internal static readonly WaitForChangedResult TimedOutResult = new WaitForChangedResult((WatcherChangeTypes)0, null, null, timedOut: true);

	/// <summary>Gets or sets the type of change that occurred.</summary>
	/// <returns>One of the <see cref="T:System.IO.WatcherChangeTypes" /> values.</returns>
	public WatcherChangeTypes ChangeType { get; set; }

	/// <summary>Gets or sets the name of the file or directory that changed.</summary>
	/// <returns>The name of the file or directory that changed.</returns>
	public string Name { get; set; }

	/// <summary>Gets or sets the original name of the file or directory that was renamed.</summary>
	/// <returns>The original name of the file or directory that was renamed.</returns>
	public string OldName { get; set; }

	/// <summary>Gets or sets a value indicating whether the wait operation timed out.</summary>
	/// <returns>
	///   <see langword="true" /> if the <see cref="M:System.IO.FileSystemWatcher.WaitForChanged(System.IO.WatcherChangeTypes)" /> method timed out; otherwise, <see langword="false" />.</returns>
	public bool TimedOut { get; set; }

	internal WaitForChangedResult(WatcherChangeTypes changeType, string name, string oldName, bool timedOut)
	{
		ChangeType = changeType;
		Name = name;
		OldName = oldName;
		TimedOut = timedOut;
	}
}
