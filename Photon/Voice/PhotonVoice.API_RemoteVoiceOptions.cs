using System;

namespace Photon.Voice;

public struct RemoteVoiceOptions(ILogger logger, string logPrefix, VoiceInfo voiceInfo)
{
	private readonly ILogger logger = logger;

	private readonly VoiceInfo voiceInfo = voiceInfo;

	public Action OnRemoteVoiceRemoveAction { get; set; } = null;

	public IDecoder Decoder { get; set; } = null;

	internal string logPrefix { get; } = logPrefix;

	public void SetOutput(Action<FrameOut<float>> output)
	{
		if (voiceInfo.Codec == Codec.Raw)
		{
			Decoder = new RawCodec.Decoder<short>(new RawCodec.ShortToFloat(output).Output);
		}
		else
		{
			setOutput(output);
		}
	}

	public void SetOutput(Action<FrameOut<short>> output)
	{
		if (voiceInfo.Codec == Codec.Raw)
		{
			Decoder = new RawCodec.Decoder<short>(output);
		}
		else
		{
			setOutput(output);
		}
	}

	private void setOutput<T>(Action<FrameOut<T>> output)
	{
		logger.LogInfo(logPrefix + ": Creating default decoder " + voiceInfo.Codec.ToString() + " for output FrameOut<" + typeof(T)?.ToString() + ">");
		if (voiceInfo.Codec == Codec.AudioOpus)
		{
			Decoder = new OpusCodec.Decoder<T>(output, logger);
			return;
		}
		logger.LogError(logPrefix + ": FrameOut<" + typeof(T)?.ToString() + "> output set for non-audio decoder " + voiceInfo.Codec);
	}
}
