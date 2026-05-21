namespace UnityEngine.Networking;

public struct DownloadedTextureParams
{
	public DownloadedTextureFlags flags;

	public int mipmapCount;

	public static DownloadedTextureParams Default => new DownloadedTextureParams
	{
		flags = (DownloadedTextureFlags.Readable | DownloadedTextureFlags.MipmapChain),
		mipmapCount = -1
	};

	public bool readable
	{
		get
		{
			return flags.HasFlag(DownloadedTextureFlags.Readable);
		}
		set
		{
			SetFlags(DownloadedTextureFlags.Readable, value);
		}
	}

	public bool mipmapChain
	{
		get
		{
			return flags.HasFlag(DownloadedTextureFlags.MipmapChain);
		}
		set
		{
			SetFlags(DownloadedTextureFlags.MipmapChain, value);
		}
	}

	public bool linearColorSpace
	{
		get
		{
			return flags.HasFlag(DownloadedTextureFlags.LinearColorSpace);
		}
		set
		{
			SetFlags(DownloadedTextureFlags.LinearColorSpace, value);
		}
	}

	private void SetFlags(DownloadedTextureFlags flgs, bool add)
	{
		if (add)
		{
			flags |= flgs;
		}
		else
		{
			flags &= ~flgs;
		}
	}
}
