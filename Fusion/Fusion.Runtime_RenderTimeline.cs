using System.Runtime.InteropServices;

namespace Fusion;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct RenderTimeline
{
	public unsafe static void GetRenderBuffers(NetworkBehaviour behaviour, out NetworkBehaviourBuffer from, out NetworkBehaviourBuffer to, out float alpha)
	{
		NetworkObjectMeta meta = behaviour.Object.Meta;
		Simulation simulation = behaviour.Object.Runner.Simulation;
		RenderTimeframe renderTimeframe = meta.Instance.RenderTimeframe;
		RenderSource renderSource = meta.Instance.RenderSource;
		while (true)
		{
			if (renderTimeframe == RenderTimeframe.Local || simulation.IsServer)
			{
				to._ptr = behaviour.Ptr;
				to._tick = simulation.Tick;
				to._length = behaviour.WordCount;
				from._ptr = meta.Previous.GetBehaviourPtr(behaviour);
				from._tick = simulation.TickPrevious;
				from._length = behaviour.WordCount;
				alpha = simulation.LocalAlpha;
				switch (renderSource)
				{
				case RenderSource.To:
				case RenderSource.Latest:
					from = to;
					alpha = 1f;
					break;
				case RenderSource.From:
					to = from;
					alpha = 0f;
					break;
				}
				return;
			}
			if (renderSource != RenderSource.Latest)
			{
				InterpolationParams interpolationParams = meta.Timeline.Params;
				if (meta.TryFindSnapshot(interpolationParams.From, out var snapshot) && meta.TryFindSnapshot(interpolationParams.To, out var snapshot2))
				{
					from._ptr = snapshot.GetBehaviourPtr(behaviour);
					from._tick = interpolationParams.From;
					from._length = behaviour.WordCount;
					to._ptr = snapshot2.GetBehaviourPtr(behaviour);
					to._tick = interpolationParams.To;
					to._length = behaviour.WordCount;
					alpha = interpolationParams.Alpha;
					switch (renderSource)
					{
					case RenderSource.From:
						to = from;
						alpha = 0f;
						break;
					case RenderSource.To:
						from = to;
						alpha = 1f;
						break;
					}
					return;
				}
			}
			if (meta.HasSnapshots)
			{
				break;
			}
			renderTimeframe = RenderTimeframe.Local;
		}
		to._ptr = meta.SnapshotLatest.GetBehaviourPtr(behaviour);
		to._tick = meta.SnapshotLatest.Tick;
		to._length = behaviour.WordCount;
		from = to;
		alpha = 1f;
	}
}
