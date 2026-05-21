using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct IconObject(string filename, string original, string thumb_64x64, string thumb_128x128, string thumb_256x256)
{
	internal readonly string Filename = filename;

	internal readonly string Original = original;

	internal readonly string Thumb64X64 = thumb_64x64;

	internal readonly string Thumb128X128 = thumb_128x128;

	internal readonly string Thumb256X256 = thumb_256x256;
}
