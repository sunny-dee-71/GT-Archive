using Unity;

namespace System.Text.RegularExpressions;

/// <summary>Represents the results from a single capturing group.</summary>
[Serializable]
public class Group : Capture
{
	internal static readonly Group s_emptyGroup = new Group(string.Empty, Array.Empty<int>(), 0, string.Empty);

	internal readonly int[] _caps;

	internal int _capcount;

	internal CaptureCollection _capcoll;

	/// <summary>Gets a value indicating whether the match is successful.</summary>
	/// <returns>
	///   <see langword="true" /> if the match is successful; otherwise, <see langword="false" />.</returns>
	public bool Success => _capcount != 0;

	/// <summary>Returns the name of the capturing group represented by the current instance.</summary>
	/// <returns>The name of the capturing group represented by the current instance.</returns>
	public string Name { get; }

	/// <summary>Gets a collection of all the captures matched by the capturing group, in innermost-leftmost-first order (or innermost-rightmost-first order if the regular expression is modified with the <see cref="F:System.Text.RegularExpressions.RegexOptions.RightToLeft" /> option). The collection may have zero or more items.</summary>
	/// <returns>The collection of substrings matched by the group.</returns>
	public CaptureCollection Captures
	{
		get
		{
			if (_capcoll == null)
			{
				_capcoll = new CaptureCollection(this);
			}
			return _capcoll;
		}
	}

	internal Group(string text, int[] caps, int capcount, string name)
		: base(text, (capcount != 0) ? caps[(capcount - 1) * 2] : 0, (capcount != 0) ? caps[capcount * 2 - 1] : 0)
	{
		_caps = caps;
		_capcount = capcount;
		Name = name;
	}

	/// <summary>Returns a <see langword="Group" /> object equivalent to the one supplied that is safe to share between multiple threads.</summary>
	/// <param name="inner">The input <see cref="T:System.Text.RegularExpressions.Group" /> object.</param>
	/// <returns>A regular expression <see langword="Group" /> object.</returns>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="inner" /> is <see langword="null" />.</exception>
	public static Group Synchronized(Group inner)
	{
		if (inner == null)
		{
			throw new ArgumentNullException("inner");
		}
		CaptureCollection captures = inner.Captures;
		if (inner.Success)
		{
			captures.ForceInitialized();
		}
		return inner;
	}

	internal Group()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
