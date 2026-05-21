using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fusion;

public readonly struct SceneLoadDoneArgs(SceneRef sceneRef, NetworkObject[] sceneObjects, Scene scene = default(Scene), GameObject[] rootGameObjects = null)
{
	public readonly SceneRef SceneRef = sceneRef;

	public readonly NetworkObject[] SceneObjects = sceneObjects;

	public readonly Scene Scene = scene;

	public readonly GameObject[] RootGameObjects = rootGameObjects;
}
