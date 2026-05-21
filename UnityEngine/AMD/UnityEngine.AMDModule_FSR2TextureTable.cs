namespace UnityEngine.AMD;

public struct FSR2TextureTable
{
	public Texture colorInput { get; set; }

	public Texture colorOutput { get; set; }

	public Texture depth { get; set; }

	public Texture motionVectors { get; set; }

	public Texture transparencyMask { get; set; }

	public Texture exposureTexture { get; set; }

	public Texture reactiveMask { get; set; }

	public Texture biasColorMask { get; set; }
}
