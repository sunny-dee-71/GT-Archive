using Newtonsoft.Json;

namespace Modio.API.SchemaDefinitions;

[JsonObject]
internal readonly struct CommentObject(long id, long game_id, long mod_id, long resource_id, UserObject user, long date_added, long reply_id, string thread_position, long karma, long karma_guest, string content, long options)
{
	internal readonly long Id = id;

	internal readonly long GameId = game_id;

	internal readonly long ModId = mod_id;

	internal readonly long ResourceId = resource_id;

	internal readonly UserObject User = user;

	internal readonly long DateAdded = date_added;

	internal readonly long ReplyId = reply_id;

	internal readonly string ThreadPosition = thread_position;

	internal readonly long Karma = karma;

	internal readonly long KarmaGuest = karma_guest;

	internal readonly string Content = content;

	internal readonly long Options = options;
}
