using System.IO;

namespace Modio.API;

public struct ModioAPIFileParameter
{
	public bool Unused;

	public string Name;

	public readonly string ContentType;

	public readonly string MediaType;

	public string Path;

	private readonly Stream _stream;

	public static ModioAPIFileParameter None => new ModioAPIFileParameter
	{
		Unused = true
	};

	public ModioAPIFileParameter(string name, string contentType, string path)
	{
		Name = name;
		ContentType = contentType;
		MediaType = "multipart/form-data";
		Path = path;
		Unused = false;
		_stream = null;
	}

	public ModioAPIFileParameter(Stream stream)
	{
		this = default(ModioAPIFileParameter);
		_stream = stream;
	}

	public ModioAPIFileParameter(Stream stream, string name, string contentType)
	{
		this = default(ModioAPIFileParameter);
		_stream = stream;
		ContentType = contentType;
		Name = name;
	}

	public Stream GetContent()
	{
		object obj = _stream;
		if (obj == null)
		{
			if (Path != null)
			{
				return new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			}
			obj = null;
		}
		return (Stream)obj;
	}
}
