using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct MultipartUploadObject(string upload_id, long status)
{
	internal readonly string UploadId = upload_id;

	internal readonly long Status = status;
}
