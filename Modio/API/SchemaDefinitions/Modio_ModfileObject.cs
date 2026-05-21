using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject(MemberSerialization.Fields)]
internal readonly struct ModfileObject(long id, long mod_id, long date_added, long date_updated, long date_scanned, long virus_status, long virus_positive, string virustotal_hash, long filesize, long filesize_uncompressed, FilehashObject filehash, string filename, string version, string changelog, string metadata_blob, DownloadObject download, ModfilePlatformObject[] platforms)
{
	internal readonly long Id = id;

	internal readonly long ModId = mod_id;

	internal readonly long DateAdded = date_added;

	internal readonly long DateUpdated = date_updated;

	internal readonly long DateScanned = date_scanned;

	internal readonly long VirusStatus = virus_status;

	internal readonly long VirusPositive = virus_positive;

	internal readonly string VirustotalHash = virustotal_hash;

	internal readonly long Filesize = filesize;

	internal readonly long FilesizeUncompressed = filesize_uncompressed;

	internal readonly FilehashObject Filehash = filehash;

	internal readonly string Filename = filename;

	internal readonly string Version = version;

	internal readonly string Changelog = changelog;

	internal readonly string MetadataBlob = metadata_blob;

	internal readonly DownloadObject Download = download;

	internal readonly ModfilePlatformObject[] Platforms = platforms;
}
