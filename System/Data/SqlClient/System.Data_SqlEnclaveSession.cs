using System.Runtime.CompilerServices;
using Unity;

namespace System.Data.SqlClient;

/// <summary>Encapsulates the state of a secure session between SqlClient and an enclave inside SQL Server, which can be used for computations on encrypted columns protected with Always Encrypted.</summary>
public class SqlEnclaveSession
{
	/// <summary>Gets the session ID.</summary>
	/// <returns>The session ID.</returns>
	public long SessionId
	{
		[CompilerGenerated]
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default(long);
		}
	}

	/// <summary>Instantiates a new instance of the <see cref="T:System.Data.SqlClient.SqlEnclaveSession" /> class.</summary>
	/// <param name="sessionKey">The symmetric key used to encrypt all the information sent using the session.</param>
	/// <param name="sessionId">The session ID.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="sessionKey" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="sessionKey" /> has zero length.</exception>
	public SqlEnclaveSession(byte[] sessionKey, long sessionId)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}

	/// <summary>Gets the symmetric key that SqlClient uses to encrypt all the information it sends to the enclave using the session.</summary>
	/// <returns>The symmetric key.</returns>
	public byte[] GetSessionKey()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
		return null;
	}
}
