namespace System.Security.Cryptography;

/// <summary>Represents the standard parameters for the elliptic curve cryptography (ECC) algorithm.</summary>
public struct ECParameters
{
	/// <summary>Represents the public key <see langword="Q" /> for the elliptic curve cryptography (ECC) algorithm.</summary>
	/// <returns>The <see langword="Q" /> parameter for the elliptic curve cryptography (ECC) algorithm.</returns>
	public ECPoint Q;

	/// <summary>Represents the private key <see langword="D" /> for the elliptic curve cryptography (ECC) algorithm, stored in big-endian format.</summary>
	/// <returns>The <see langword="D" /> parameter for the elliptic curve cryptography (ECC) algorithm.</returns>
	public byte[] D;

	/// <summary>Represents the curve associated with the public key (<see cref="F:System.Security.Cryptography.ECParameters.Q" />) and the optional private key (<see cref="F:System.Security.Cryptography.ECParameters.D" />).</summary>
	/// <returns>The curve.</returns>
	public ECCurve Curve;

	/// <summary>Validates the current object.</summary>
	/// <exception cref="T:System.Security.Cryptography.CryptographicException">The key or curve parameters are not valid for the current curve type.</exception>
	public void Validate()
	{
		bool flag = false;
		if (Q.X == null || Q.Y == null || Q.X.Length != Q.Y.Length)
		{
			flag = true;
		}
		if (!flag)
		{
			if (Curve.IsExplicit)
			{
				flag = D != null && D.Length != Curve.Order.Length;
			}
			else if (Curve.IsNamed)
			{
				flag = D != null && D.Length != Q.X.Length;
			}
		}
		if (flag)
		{
			throw new CryptographicException("The specified key parameters are not valid. Q.X and Q.Y are required fields. Q.X, Q.Y must be the same length. If D is specified it must be the same length as Q.X and Q.Y for named curves or the same length as Order for explicit curves.");
		}
		Curve.Validate();
	}
}
