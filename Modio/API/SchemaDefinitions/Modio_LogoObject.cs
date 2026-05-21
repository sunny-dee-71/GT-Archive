using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct LogoObject(string filename, string original, string thumb_320x180, string thumb_640x360, string thumb_1280x720)
{
	internal readonly string Filename = filename;

	internal readonly string Original = original;

	internal readonly string Thumb320X180 = thumb_320x180;

	internal readonly string Thumb640X360 = thumb_640x360;

	internal readonly string Thumb1280X720 = thumb_1280x720;
}
