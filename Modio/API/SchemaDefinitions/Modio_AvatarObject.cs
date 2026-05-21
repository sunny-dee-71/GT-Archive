using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct AvatarObject(string filename, string original, string thumb_50x50, string thumb_100x100)
{
	internal readonly string Filename = filename;

	internal readonly string Original = original;

	internal readonly string Thumb50X50 = thumb_50x50;

	internal readonly string Thumb100X100 = thumb_100x100;
}
