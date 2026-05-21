using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine.Bindings;
using UnityEngineInternal;

namespace UnityEngine.Networking;

[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequest.h")]
public class UnityWebRequest : IDisposable
{
	internal enum UnityWebRequestMethod
	{
		Get,
		Post,
		Put,
		Head,
		Custom
	}

	internal enum UnityWebRequestError
	{
		OK,
		OKCached,
		Unknown,
		SDKError,
		UnsupportedProtocol,
		MalformattedUrl,
		CannotResolveProxy,
		CannotResolveHost,
		CannotConnectToHost,
		AccessDenied,
		GenericHttpError,
		WriteError,
		ReadError,
		OutOfMemory,
		Timeout,
		HTTPPostError,
		SSLCannotConnect,
		Aborted,
		TooManyRedirects,
		ReceivedNoData,
		SSLNotSupported,
		FailedToSendData,
		FailedToReceiveData,
		SSLCertificateError,
		SSLCipherNotAvailable,
		SSLCACertError,
		UnrecognizedContentEncoding,
		LoginFailed,
		SSLShutdownFailed,
		RedirectLimitInvalid,
		InvalidRedirect,
		CannotModifyRequest,
		HeaderNameContainsInvalidCharacters,
		HeaderValueContainsInvalidCharacters,
		CannotOverrideSystemHeaders,
		AlreadySent,
		InvalidMethod,
		NotImplemented,
		NoInternetConnection,
		DataProcessingError,
		InsecureConnectionNotAllowed
	}

	public enum Result
	{
		InProgress,
		Success,
		ConnectionError,
		ProtocolError,
		DataProcessingError
	}

	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(UnityWebRequest unityWebRequest)
		{
			return unityWebRequest.m_Ptr;
		}
	}

	[NonSerialized]
	internal IntPtr m_Ptr;

	[NonSerialized]
	internal DownloadHandler m_DownloadHandler;

	[NonSerialized]
	internal UploadHandler m_UploadHandler;

	[NonSerialized]
	internal CertificateHandler m_CertificateHandler;

	[NonSerialized]
	internal Uri m_Uri;

	public const string kHttpVerbGET = "GET";

	public const string kHttpVerbHEAD = "HEAD";

	public const string kHttpVerbPOST = "POST";

	public const string kHttpVerbPUT = "PUT";

	public const string kHttpVerbCREATE = "CREATE";

	public const string kHttpVerbDELETE = "DELETE";

	public bool disposeCertificateHandlerOnDispose { get; set; }

	public bool disposeDownloadHandlerOnDispose { get; set; }

	public bool disposeUploadHandlerOnDispose { get; set; }

	public string method
	{
		get
		{
			return GetMethod() switch
			{
				UnityWebRequestMethod.Get => "GET", 
				UnityWebRequestMethod.Post => "POST", 
				UnityWebRequestMethod.Put => "PUT", 
				UnityWebRequestMethod.Head => "HEAD", 
				_ => GetCustomMethod(), 
			};
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Cannot set a UnityWebRequest's method to an empty or null string");
			}
			switch (value.ToUpper())
			{
			case "GET":
				InternalSetMethod(UnityWebRequestMethod.Get);
				break;
			case "POST":
				InternalSetMethod(UnityWebRequestMethod.Post);
				break;
			case "PUT":
				InternalSetMethod(UnityWebRequestMethod.Put);
				break;
			case "HEAD":
				InternalSetMethod(UnityWebRequestMethod.Head);
				break;
			default:
				InternalSetCustomMethod(value.ToUpper());
				break;
			}
		}
	}

	public string error
	{
		get
		{
			switch (result)
			{
			case Result.InProgress:
			case Result.Success:
				return null;
			case Result.ProtocolError:
				return $"HTTP/1.1 {responseCode} {GetHTTPStatusString(responseCode)}";
			default:
				return GetWebErrorString(GetError());
			}
		}
	}

	private bool use100Continue
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_use100Continue_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_use100Continue_Injected(intPtr, value);
		}
	}

	public bool useHttpContinue
	{
		get
		{
			return use100Continue;
		}
		set
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent and its 100-Continue setting cannot be altered");
			}
			use100Continue = value;
		}
	}

	public string url
	{
		get
		{
			return GetUrl();
		}
		set
		{
			string localUrl = "https://localhost/";
			InternalSetUrl(WebRequestUtils.MakeInitialUrl(value, localUrl));
		}
	}

	public Uri uri
	{
		get
		{
			return new Uri(GetUrl());
		}
		set
		{
			if (!value.IsAbsoluteUri)
			{
				throw new ArgumentException("URI must be absolute");
			}
			InternalSetUrl(WebRequestUtils.MakeUriString(value, value.OriginalString, prependProtocol: false));
			m_Uri = value;
		}
	}

	public long responseCode
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_responseCode_Injected(intPtr);
		}
	}

	public float uploadProgress
	{
		get
		{
			if (!IsExecuting() && !isDone)
			{
				return -1f;
			}
			return GetUploadProgress();
		}
	}

	public bool isModifiable
	{
		[NativeMethod("IsModifiable")]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_isModifiable_Injected(intPtr);
		}
	}

	public bool isDone => result != Result.InProgress;

	[Obsolete("UnityWebRequest.isNetworkError is deprecated. Use (UnityWebRequest.result == UnityWebRequest.Result.ConnectionError) instead.", false)]
	public bool isNetworkError => result == Result.ConnectionError;

	[Obsolete("UnityWebRequest.isHttpError is deprecated. Use (UnityWebRequest.result == UnityWebRequest.Result.ProtocolError) instead.", false)]
	public bool isHttpError => result == Result.ProtocolError;

	public Result result
	{
		[NativeMethod("GetResult")]
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_result_Injected(intPtr);
		}
	}

	public float downloadProgress
	{
		get
		{
			if (!IsExecuting() && !isDone)
			{
				return -1f;
			}
			return GetDownloadProgress();
		}
	}

	public ulong uploadedBytes
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_uploadedBytes_Injected(intPtr);
		}
	}

	public ulong downloadedBytes
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_downloadedBytes_Injected(intPtr);
		}
	}

	public int redirectLimit
	{
		get
		{
			return GetRedirectLimit();
		}
		set
		{
			SetRedirectLimitFromScripting(value);
		}
	}

	[Obsolete("HTTP/2 and many HTTP/1.1 servers don't support this; we recommend leaving it set to false (default).", false)]
	public bool chunkedTransfer
	{
		get
		{
			return GetChunked();
		}
		set
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent and its chunked transfer encoding setting cannot be altered");
			}
			UnityWebRequestError unityWebRequestError = SetChunked(value);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
		}
	}

	public UploadHandler uploadHandler
	{
		get
		{
			return m_UploadHandler;
		}
		set
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the upload handler");
			}
			UnityWebRequestError unityWebRequestError = SetUploadHandler(value);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
			m_UploadHandler = value;
		}
	}

	public DownloadHandler downloadHandler
	{
		get
		{
			return m_DownloadHandler;
		}
		set
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the download handler");
			}
			UnityWebRequestError unityWebRequestError = SetDownloadHandler(value);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
			m_DownloadHandler = value;
		}
	}

	public CertificateHandler certificateHandler
	{
		get
		{
			return m_CertificateHandler;
		}
		set
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the certificate handler");
			}
			UnityWebRequestError unityWebRequestError = SetCertificateHandler(value);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
			m_CertificateHandler = value;
		}
	}

	public int timeout
	{
		get
		{
			return GetTimeoutMsec() / 1000;
		}
		set
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the timeout");
			}
			value = Math.Max(value, 0);
			UnityWebRequestError unityWebRequestError = SetTimeoutMsec(value * 1000);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
		}
	}

	internal bool suppressErrorsToConsole
	{
		get
		{
			return GetSuppressErrorsToConsole();
		}
		set
		{
			if (!isModifiable)
			{
				throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the timeout");
			}
			UnityWebRequestError unityWebRequestError = SetSuppressErrorsToConsole(value);
			if (unityWebRequestError != UnityWebRequestError.OK)
			{
				throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
			}
		}
	}

	[NativeMethod(IsThreadSafe = true)]
	[NativeConditional("ENABLE_UNITYWEBREQUEST")]
	private static string GetWebErrorString(UnityWebRequestError err)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetWebErrorString_Injected(err, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[VisibleToOtherModules]
	internal static string GetHTTPStatusString(long responseCode)
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			GetHTTPStatusString_Injected(responseCode, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	public static void ClearCookieCache()
	{
		ClearCookieCache(null, null);
	}

	public static void ClearCookieCache(Uri uri)
	{
		if (uri == null)
		{
			ClearCookieCache(null, null);
			return;
		}
		string host = uri.Host;
		string text = uri.AbsolutePath;
		if (text == "/")
		{
			text = null;
		}
		ClearCookieCache(host, text);
	}

	private unsafe static void ClearCookieCache(string domain, string path)
	{
		//The blocks IL_0029, IL_0036, IL_0044, IL_0052, IL_0057 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0057 are reachable both inside and outside the pinned region starting at IL_0044. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper domain2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(domain, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(domain);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					domain2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(path);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							ClearCookieCache_Injected(ref domain2, ref managedSpanWrapper2);
							return;
						}
					}
					ClearCookieCache_Injected(ref domain2, ref managedSpanWrapper2);
					return;
				}
			}
			domain2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(path);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					ClearCookieCache_Injected(ref domain2, ref managedSpanWrapper2);
					return;
				}
			}
			ClearCookieCache_Injected(ref domain2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	internal static extern IntPtr Create();

	[NativeMethod(IsThreadSafe = true)]
	private void Release()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Release_Injected(intPtr);
	}

	internal void InternalDestroy()
	{
		if (m_Ptr != IntPtr.Zero)
		{
			Abort();
			Release();
			m_Ptr = IntPtr.Zero;
		}
	}

	private void InternalSetDefaults()
	{
		disposeDownloadHandlerOnDispose = true;
		disposeUploadHandlerOnDispose = true;
		disposeCertificateHandlerOnDispose = true;
	}

	public UnityWebRequest()
	{
		m_Ptr = Create();
		InternalSetDefaults();
	}

	public UnityWebRequest(string url)
	{
		m_Ptr = Create();
		InternalSetDefaults();
		this.url = url;
	}

	public UnityWebRequest(Uri uri)
	{
		m_Ptr = Create();
		InternalSetDefaults();
		this.uri = uri;
	}

	public UnityWebRequest(string url, string method)
	{
		m_Ptr = Create();
		InternalSetDefaults();
		this.url = url;
		this.method = method;
	}

	public UnityWebRequest(Uri uri, string method)
	{
		m_Ptr = Create();
		InternalSetDefaults();
		this.uri = uri;
		this.method = method;
	}

	public UnityWebRequest(string url, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler)
	{
		m_Ptr = Create();
		InternalSetDefaults();
		this.url = url;
		this.method = method;
		this.downloadHandler = downloadHandler;
		this.uploadHandler = uploadHandler;
	}

	public UnityWebRequest(Uri uri, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler)
	{
		m_Ptr = Create();
		InternalSetDefaults();
		this.uri = uri;
		this.method = method;
		this.downloadHandler = downloadHandler;
		this.uploadHandler = uploadHandler;
	}

	~UnityWebRequest()
	{
		DisposeHandlers();
		InternalDestroy();
	}

	public void Dispose()
	{
		DisposeHandlers();
		InternalDestroy();
		GC.SuppressFinalize(this);
	}

	private void DisposeHandlers()
	{
		if (disposeDownloadHandlerOnDispose)
		{
			downloadHandler?.Dispose();
		}
		if (disposeUploadHandlerOnDispose)
		{
			uploadHandler?.Dispose();
		}
		if (disposeCertificateHandlerOnDispose)
		{
			certificateHandler?.Dispose();
		}
	}

	[NativeThrows]
	internal UnityWebRequestAsyncOperation BeginWebRequest()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		IntPtr intPtr2 = BeginWebRequest_Injected(intPtr);
		return (intPtr2 == (IntPtr)0) ? null : UnityWebRequestAsyncOperation.BindingsMarshaller.ConvertToManaged(intPtr2);
	}

	[Obsolete("Use SendWebRequest.  It returns a UnityWebRequestAsyncOperation which contains a reference to the WebRequest object.", false)]
	public AsyncOperation Send()
	{
		return SendWebRequest();
	}

	public UnityWebRequestAsyncOperation SendWebRequest()
	{
		UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = BeginWebRequest();
		if (unityWebRequestAsyncOperation != null)
		{
			unityWebRequestAsyncOperation.webRequest = this;
		}
		return unityWebRequestAsyncOperation;
	}

	[NativeMethod(IsThreadSafe = true)]
	public void Abort()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Abort_Injected(intPtr);
	}

	private UnityWebRequestError SetMethod(UnityWebRequestMethod methodType)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetMethod_Injected(intPtr, methodType);
	}

	internal void InternalSetMethod(UnityWebRequestMethod methodType)
	{
		if (!isModifiable)
		{
			throw new InvalidOperationException("UnityWebRequest has already been sent and its request method can no longer be altered");
		}
		UnityWebRequestError unityWebRequestError = SetMethod(methodType);
		if (unityWebRequestError != UnityWebRequestError.OK)
		{
			throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
		}
	}

	private unsafe UnityWebRequestError SetCustomMethod(string customMethodName)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(customMethodName, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(customMethodName);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return SetCustomMethod_Injected(intPtr, ref managedSpanWrapper);
				}
			}
			return SetCustomMethod_Injected(intPtr, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	internal void InternalSetCustomMethod(string customMethodName)
	{
		if (!isModifiable)
		{
			throw new InvalidOperationException("UnityWebRequest has already been sent and its request method can no longer be altered");
		}
		UnityWebRequestError unityWebRequestError = SetCustomMethod(customMethodName);
		if (unityWebRequestError != UnityWebRequestError.OK)
		{
			throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
		}
	}

	internal UnityWebRequestMethod GetMethod()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetMethod_Injected(intPtr);
	}

	internal string GetCustomMethod()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetCustomMethod_Injected(intPtr, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	private UnityWebRequestError GetError()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetError_Injected(intPtr);
	}

	private string GetUrl()
	{
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetUrl_Injected(intPtr, out ret);
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	private unsafe UnityWebRequestError SetUrl(string url)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(url, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(url);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return SetUrl_Injected(intPtr, ref managedSpanWrapper);
				}
			}
			return SetUrl_Injected(intPtr, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	private void InternalSetUrl(string url)
	{
		if (!isModifiable)
		{
			throw new InvalidOperationException("UnityWebRequest has already been sent and its URL cannot be altered");
		}
		UnityWebRequestError unityWebRequestError = SetUrl(url);
		if (unityWebRequestError != UnityWebRequestError.OK)
		{
			throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
		}
	}

	private float GetUploadProgress()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetUploadProgress_Injected(intPtr);
	}

	private bool IsExecuting()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return IsExecuting_Injected(intPtr);
	}

	private float GetDownloadProgress()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetDownloadProgress_Injected(intPtr);
	}

	private int GetRedirectLimit()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetRedirectLimit_Injected(intPtr);
	}

	[NativeThrows]
	private void SetRedirectLimitFromScripting(int limit)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetRedirectLimitFromScripting_Injected(intPtr, limit);
	}

	private bool GetChunked()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetChunked_Injected(intPtr);
	}

	private UnityWebRequestError SetChunked(bool chunked)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetChunked_Injected(intPtr, chunked);
	}

	public unsafe string GetRequestHeader(string name)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					GetRequestHeader_Injected(intPtr, ref managedSpanWrapper, out ret);
				}
			}
			else
			{
				GetRequestHeader_Injected(intPtr, ref managedSpanWrapper, out ret);
			}
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	[NativeMethod("SetRequestHeader")]
	internal unsafe UnityWebRequestError InternalSetRequestHeader(string name, string value)
	{
		//The blocks IL_0039, IL_0046, IL_0054, IL_0062, IL_0067 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0067 are reachable both inside and outside the pinned region starting at IL_0054. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			ref ManagedSpanWrapper name2;
			ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
			ReadOnlySpan<char> readOnlySpan2;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					name2 = ref managedSpanWrapper;
					if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper2))
					{
						readOnlySpan2 = MemoryExtensions.AsSpan(value);
						fixed (char* begin2 = readOnlySpan2)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
							return InternalSetRequestHeader_Injected(intPtr, ref name2, ref managedSpanWrapper2);
						}
					}
					return InternalSetRequestHeader_Injected(intPtr, ref name2, ref managedSpanWrapper2);
				}
			}
			name2 = ref managedSpanWrapper;
			if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper2))
			{
				readOnlySpan2 = MemoryExtensions.AsSpan(value);
				fixed (char* begin2 = readOnlySpan2)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
					return InternalSetRequestHeader_Injected(intPtr, ref name2, ref managedSpanWrapper2);
				}
			}
			return InternalSetRequestHeader_Injected(intPtr, ref name2, ref managedSpanWrapper2);
		}
		finally
		{
		}
	}

	public void SetRequestHeader(string name, string value)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentException("Cannot set a Request Header with a null or empty name");
		}
		if (value == null)
		{
			throw new ArgumentException("Cannot set a Request header with a null");
		}
		if (!isModifiable)
		{
			throw new InvalidOperationException("UnityWebRequest has already been sent and its request headers cannot be altered");
		}
		UnityWebRequestError unityWebRequestError = InternalSetRequestHeader(name, value);
		if (unityWebRequestError != UnityWebRequestError.OK)
		{
			throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
		}
	}

	public unsafe string GetResponseHeader(string name)
	{
		//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		ManagedSpanWrapper ret = default(ManagedSpanWrapper);
		string stringAndDispose;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					GetResponseHeader_Injected(intPtr, ref managedSpanWrapper, out ret);
				}
			}
			else
			{
				GetResponseHeader_Injected(intPtr, ref managedSpanWrapper, out ret);
			}
		}
		finally
		{
			stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
		}
		return stringAndDispose;
	}

	internal string[] GetResponseHeaderKeys()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetResponseHeaderKeys_Injected(intPtr);
	}

	public Dictionary<string, string> GetResponseHeaders()
	{
		string[] responseHeaderKeys = GetResponseHeaderKeys();
		if (responseHeaderKeys == null || responseHeaderKeys.Length == 0)
		{
			return null;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>(responseHeaderKeys.Length, StringComparer.OrdinalIgnoreCase);
		for (int i = 0; i < responseHeaderKeys.Length; i++)
		{
			string responseHeader = GetResponseHeader(responseHeaderKeys[i]);
			dictionary.Add(responseHeaderKeys[i], responseHeader);
		}
		return dictionary;
	}

	private UnityWebRequestError SetUploadHandler(UploadHandler uh)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetUploadHandler_Injected(intPtr, (uh == null) ? ((IntPtr)0) : UploadHandler.BindingsMarshaller.ConvertToNative(uh));
	}

	private UnityWebRequestError SetDownloadHandler(DownloadHandler dh)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetDownloadHandler_Injected(intPtr, (dh == null) ? ((IntPtr)0) : DownloadHandler.BindingsMarshaller.ConvertToNative(dh));
	}

	private UnityWebRequestError SetCertificateHandler(CertificateHandler ch)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetCertificateHandler_Injected(intPtr, (ch == null) ? ((IntPtr)0) : CertificateHandler.BindingsMarshaller.ConvertToNative(ch));
	}

	private int GetTimeoutMsec()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetTimeoutMsec_Injected(intPtr);
	}

	private UnityWebRequestError SetTimeoutMsec(int timeout)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetTimeoutMsec_Injected(intPtr, timeout);
	}

	private bool GetSuppressErrorsToConsole()
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetSuppressErrorsToConsole_Injected(intPtr);
	}

	private UnityWebRequestError SetSuppressErrorsToConsole(bool suppress)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return SetSuppressErrorsToConsole_Injected(intPtr, suppress);
	}

	public static UnityWebRequest Get(string uri)
	{
		return new UnityWebRequest(uri, "GET", new DownloadHandlerBuffer(), null);
	}

	public static UnityWebRequest Get(Uri uri)
	{
		return new UnityWebRequest(uri, "GET", new DownloadHandlerBuffer(), null);
	}

	public static UnityWebRequest Delete(string uri)
	{
		return new UnityWebRequest(uri, "DELETE");
	}

	public static UnityWebRequest Delete(Uri uri)
	{
		return new UnityWebRequest(uri, "DELETE");
	}

	public static UnityWebRequest Head(string uri)
	{
		return new UnityWebRequest(uri, "HEAD");
	}

	public static UnityWebRequest Head(Uri uri)
	{
		return new UnityWebRequest(uri, "HEAD");
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestTexture.GetTexture(*)", true)]
	public static UnityWebRequest GetTexture(string uri)
	{
		throw new NotSupportedException("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead.");
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestTexture.GetTexture(*)", true)]
	public static UnityWebRequest GetTexture(string uri, bool nonReadable)
	{
		throw new NotSupportedException("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead.");
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("UnityWebRequest.GetAudioClip is obsolete. Use UnityWebRequestMultimedia.GetAudioClip instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestMultimedia.GetAudioClip(*)", true)]
	public static UnityWebRequest GetAudioClip(string uri, AudioType audioType)
	{
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
	public static UnityWebRequest GetAssetBundle(string uri)
	{
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
	public static UnityWebRequest GetAssetBundle(string uri, uint crc)
	{
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
	public static UnityWebRequest GetAssetBundle(string uri, uint version, uint crc)
	{
		return null;
	}

	[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static UnityWebRequest GetAssetBundle(string uri, Hash128 hash, uint crc)
	{
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
	public static UnityWebRequest GetAssetBundle(string uri, CachedAssetBundle cachedAssetBundle, uint crc)
	{
		return null;
	}

	public static UnityWebRequest Put(string uri, byte[] bodyData)
	{
		return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(bodyData));
	}

	public static UnityWebRequest Put(Uri uri, byte[] bodyData)
	{
		return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(bodyData));
	}

	public static UnityWebRequest Put(string uri, string bodyData)
	{
		return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyData)));
	}

	public static UnityWebRequest Put(Uri uri, string bodyData)
	{
		return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyData)));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("UnityWebRequest.Post with only a string data is obsolete. Use UnityWebRequest.Post with content type argument or UnityWebRequest.PostWwwForm instead (UnityUpgradable) -> [UnityEngine] UnityWebRequest.PostWwwForm(*)", false)]
	public static UnityWebRequest Post(string uri, string postData)
	{
		return PostWwwForm(uri, postData);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("UnityWebRequest.Post with only a string data is obsolete. Use UnityWebRequest.Post with content type argument or UnityWebRequest.PostWwwForm instead (UnityUpgradable) -> [UnityEngine] UnityWebRequest.PostWwwForm(*)", false)]
	public static UnityWebRequest Post(Uri uri, string postData)
	{
		return PostWwwForm(uri, postData);
	}

	public static UnityWebRequest PostWwwForm(string uri, string form)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPostWwwForm(request, form);
		return request;
	}

	public static UnityWebRequest PostWwwForm(Uri uri, string form)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPostWwwForm(request, form);
		return request;
	}

	private static void SetupPostWwwForm(UnityWebRequest request, string postData)
	{
		request.downloadHandler = new DownloadHandlerBuffer();
		if (!string.IsNullOrEmpty(postData))
		{
			byte[] array = null;
			string s = WWWTranscoder.DataEncode(postData, Encoding.UTF8);
			array = Encoding.UTF8.GetBytes(s);
			request.uploadHandler = new UploadHandlerRaw(array);
			request.uploadHandler.contentType = "application/x-www-form-urlencoded";
		}
	}

	public static UnityWebRequest Post(string uri, string postData, string contentType)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPost(request, postData, contentType);
		return request;
	}

	public static UnityWebRequest Post(Uri uri, string postData, string contentType)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPost(request, postData, contentType);
		return request;
	}

	private static void SetupPost(UnityWebRequest request, string postData, string contentType)
	{
		request.downloadHandler = new DownloadHandlerBuffer();
		if (string.IsNullOrEmpty(postData))
		{
			request.SetRequestHeader("Content-Type", contentType);
			return;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(postData);
		request.uploadHandler = new UploadHandlerRaw(bytes);
		request.uploadHandler.contentType = contentType;
	}

	public static UnityWebRequest Post(string uri, WWWForm formData)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPost(request, formData);
		return request;
	}

	public static UnityWebRequest Post(Uri uri, WWWForm formData)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPost(request, formData);
		return request;
	}

	private static void SetupPost(UnityWebRequest request, WWWForm formData)
	{
		request.downloadHandler = new DownloadHandlerBuffer();
		if (formData == null)
		{
			return;
		}
		byte[] array = null;
		array = formData.data;
		if (array.Length == 0)
		{
			array = null;
		}
		if (array != null)
		{
			request.uploadHandler = new UploadHandlerRaw(array);
		}
		Dictionary<string, string> headers = formData.headers;
		foreach (KeyValuePair<string, string> item in headers)
		{
			request.SetRequestHeader(item.Key, item.Value);
		}
	}

	public static UnityWebRequest Post(string uri, List<IMultipartFormSection> multipartFormSections)
	{
		byte[] boundary = GenerateBoundary();
		return Post(uri, multipartFormSections, boundary);
	}

	public static UnityWebRequest Post(Uri uri, List<IMultipartFormSection> multipartFormSections)
	{
		byte[] boundary = GenerateBoundary();
		return Post(uri, multipartFormSections, boundary);
	}

	public static UnityWebRequest Post(string uri, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPost(request, multipartFormSections, boundary);
		return request;
	}

	public static UnityWebRequest Post(Uri uri, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPost(request, multipartFormSections, boundary);
		return request;
	}

	private static void SetupPost(UnityWebRequest request, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
	{
		request.downloadHandler = new DownloadHandlerBuffer();
		byte[] array = null;
		if (multipartFormSections != null && multipartFormSections.Count != 0)
		{
			array = SerializeFormSections(multipartFormSections, boundary);
		}
		if (array != null)
		{
			UploadHandler uploadHandler = new UploadHandlerRaw(array);
			uploadHandler.contentType = "multipart/form-data; boundary=" + Encoding.UTF8.GetString(boundary, 0, boundary.Length);
			request.uploadHandler = uploadHandler;
		}
	}

	public static UnityWebRequest Post(string uri, Dictionary<string, string> formFields)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPost(request, formFields);
		return request;
	}

	public static UnityWebRequest Post(Uri uri, Dictionary<string, string> formFields)
	{
		UnityWebRequest request = new UnityWebRequest(uri, "POST");
		SetupPost(request, formFields);
		return request;
	}

	private static void SetupPost(UnityWebRequest request, Dictionary<string, string> formFields)
	{
		request.downloadHandler = new DownloadHandlerBuffer();
		byte[] array = null;
		if (formFields != null && formFields.Count != 0)
		{
			array = SerializeSimpleForm(formFields);
		}
		if (array != null)
		{
			UploadHandler uploadHandler = new UploadHandlerRaw(array);
			uploadHandler.contentType = "application/x-www-form-urlencoded";
			request.uploadHandler = uploadHandler;
		}
	}

	public static string EscapeURL(string s)
	{
		return EscapeURL(s, Encoding.UTF8);
	}

	public static string EscapeURL(string s, Encoding e)
	{
		if (s == null)
		{
			return null;
		}
		if (s == "")
		{
			return "";
		}
		if (e == null)
		{
			return null;
		}
		byte[] bytes = e.GetBytes(s);
		byte[] bytes2 = WWWTranscoder.URLEncode(bytes);
		return e.GetString(bytes2);
	}

	public static string UnEscapeURL(string s)
	{
		return UnEscapeURL(s, Encoding.UTF8);
	}

	public static string UnEscapeURL(string s, Encoding e)
	{
		if (s == null)
		{
			return null;
		}
		if (s.IndexOf('%') == -1 && s.IndexOf('+') == -1)
		{
			return s;
		}
		byte[] bytes = e.GetBytes(s);
		byte[] bytes2 = WWWTranscoder.URLDecode(bytes);
		return e.GetString(bytes2);
	}

	public static byte[] SerializeFormSections(List<IMultipartFormSection> multipartFormSections, byte[] boundary)
	{
		if (multipartFormSections == null || multipartFormSections.Count == 0)
		{
			return null;
		}
		byte[] bytes = Encoding.UTF8.GetBytes("\r\n");
		byte[] bytes2 = WWWForm.DefaultEncoding.GetBytes("--");
		int num = 0;
		foreach (IMultipartFormSection multipartFormSection in multipartFormSections)
		{
			num += 64 + multipartFormSection.sectionData.Length;
		}
		List<byte> list = new List<byte>(num);
		foreach (IMultipartFormSection multipartFormSection2 in multipartFormSections)
		{
			string text = "form-data";
			string sectionName = multipartFormSection2.sectionName;
			string fileName = multipartFormSection2.fileName;
			string text2 = "Content-Disposition: " + text;
			if (!string.IsNullOrEmpty(sectionName))
			{
				text2 = text2 + "; name=\"" + sectionName + "\"";
			}
			if (!string.IsNullOrEmpty(fileName))
			{
				text2 = text2 + "; filename=\"" + fileName + "\"";
			}
			text2 += "\r\n";
			string contentType = multipartFormSection2.contentType;
			if (!string.IsNullOrEmpty(contentType))
			{
				text2 = text2 + "Content-Type: " + contentType + "\r\n";
			}
			list.AddRange(bytes);
			list.AddRange(bytes2);
			list.AddRange(boundary);
			list.AddRange(bytes);
			list.AddRange(Encoding.UTF8.GetBytes(text2));
			list.AddRange(bytes);
			list.AddRange(multipartFormSection2.sectionData);
		}
		list.AddRange(bytes);
		list.AddRange(bytes2);
		list.AddRange(boundary);
		list.AddRange(bytes2);
		list.AddRange(bytes);
		return list.ToArray();
	}

	public static byte[] GenerateBoundary()
	{
		byte[] array = new byte[40];
		for (int i = 0; i < 40; i++)
		{
			int num = Random.Range(48, 110);
			if (num > 57)
			{
				num += 7;
			}
			if (num > 90)
			{
				num += 6;
			}
			array[i] = (byte)num;
		}
		return array;
	}

	public static byte[] SerializeSimpleForm(Dictionary<string, string> formFields)
	{
		string text = "";
		foreach (KeyValuePair<string, string> formField in formFields)
		{
			if (text.Length > 0)
			{
				text += "&";
			}
			text = text + WWWTranscoder.DataEncode(formField.Key) + "=" + WWWTranscoder.DataEncode(formField.Value);
		}
		return Encoding.UTF8.GetBytes(text);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetWebErrorString_Injected(UnityWebRequestError err, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetHTTPStatusString_Injected(long responseCode, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearCookieCache_Injected(ref ManagedSpanWrapper domain, ref ManagedSpanWrapper path);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Release_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr BeginWebRequest_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Abort_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError SetMethod_Injected(IntPtr _unity_self, UnityWebRequestMethod methodType);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError SetCustomMethod_Injected(IntPtr _unity_self, ref ManagedSpanWrapper customMethodName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestMethod GetMethod_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetCustomMethod_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError GetError_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_use100Continue_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_use100Continue_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetUrl_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError SetUrl_Injected(IntPtr _unity_self, ref ManagedSpanWrapper url);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern long get_responseCode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetUploadProgress_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsExecuting_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_isModifiable_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Result get_result_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float GetDownloadProgress_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ulong get_uploadedBytes_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ulong get_downloadedBytes_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetRedirectLimit_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetRedirectLimitFromScripting_Injected(IntPtr _unity_self, int limit);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetChunked_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError SetChunked_Injected(IntPtr _unity_self, bool chunked);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetRequestHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError InternalSetRequestHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetResponseHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] GetResponseHeaderKeys_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError SetUploadHandler_Injected(IntPtr _unity_self, IntPtr uh);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError SetDownloadHandler_Injected(IntPtr _unity_self, IntPtr dh);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError SetCertificateHandler_Injected(IntPtr _unity_self, IntPtr ch);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetTimeoutMsec_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError SetTimeoutMsec_Injected(IntPtr _unity_self, int timeout);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetSuppressErrorsToConsole_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern UnityWebRequestError SetSuppressErrorsToConsole_Injected(IntPtr _unity_self, bool suppress);
}
