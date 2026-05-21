using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct MultipartUploadPartObject(string upload_id, long part_number, long part_size, long date_added)
{
	internal readonly string UploadId = upload_id;

	internal readonly long PartNumber = part_number;

	internal readonly long PartSize = part_size;

	internal readonly long DateAdded = date_added;
}
