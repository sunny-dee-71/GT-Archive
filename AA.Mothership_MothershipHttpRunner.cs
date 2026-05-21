using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class MothershipHttpRunner : MonoBehaviour
{
	private static MothershipHttpRunner _instance;

	public static MothershipHttpRunner instance
	{
		get
		{
			CreateInstance();
			return _instance;
		}
	}

	private static void CreateInstance()
	{
		if (_instance == null)
		{
			_instance = new GameObject(typeof(MothershipHttpRunner).Name).AddComponent<MothershipHttpRunner>();
		}
	}

	public virtual void Awake()
	{
		if (Application.isPlaying)
		{
			UnityEngine.Object.DontDestroyOnLoad(this);
		}
		if (_instance != null)
		{
			_instance = null;
			UnityEngine.Object.DestroyImmediate(base.gameObject);
		}
	}

	public void SendRequest(UnityWebRequest uwr, MothershipHTTPRequest request, Action<MothershipHTTPResponse> responseCallback)
	{
		StartCoroutine(SendRequestInternal(uwr, request, responseCallback));
	}

	private IEnumerator SendRequestInternal(UnityWebRequest uwr, MothershipHTTPRequest request, Action<MothershipHTTPResponse> responseCallback)
	{
		yield return uwr.SendWebRequest();
		MothershipHTTPResponse mothershipHTTPResponse = new MothershipHTTPResponse();
		mothershipHTTPResponse.statusCode = (int)uwr.responseCode;
		mothershipHTTPResponse.Body = uwr.downloadHandler.text;
		mothershipHTTPResponse.cbData = request.cbData;
		responseCallback(mothershipHTTPResponse);
	}
}
