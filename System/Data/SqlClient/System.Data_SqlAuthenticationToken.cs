using System.Runtime.CompilerServices;
using Unity;

namespace System.Data.SqlClient;

/// <summary>Represents an AD authentication token.</summary>
public class SqlAuthenticationToken
{
	/// <summary>Gets the token string.</summary>
	/// <returns>The token string.</returns>
	public string AccessToken
	{
		[CompilerGenerated]
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return null;
		}
	}

	/// <summary>Gets the token expiration time.</summary>
	/// <returns>The token expiration time.</returns>
	public DateTimeOffset ExpiresOn
	{
		[CompilerGenerated]
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default(DateTimeOffset);
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Data.SqlClient.SqlAuthenticationToken" /> class.</summary>
	/// <param name="accessToken">The access token.</param>
	/// <param name="expiresOn">The token expiration time.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="accessToken" /> parameter is <see langword="null" /> or empty.</exception>
	public SqlAuthenticationToken(string accessToken, DateTimeOffset expiresOn)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
