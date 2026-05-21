using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct ModMediaObject(string[] youtube, string[] sketchfab, ImageObject[] images)
{
	internal readonly string[] Youtube = youtube;

	internal readonly string[] Sketchfab = sketchfab;

	internal readonly ImageObject[] Images = images;
}
