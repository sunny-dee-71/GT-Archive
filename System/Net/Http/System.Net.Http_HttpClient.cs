using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

/// <summary>Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.</summary>
public class HttpClient : HttpMessageInvoker
{
	private static readonly TimeSpan TimeoutDefault = TimeSpan.FromSeconds(100.0);

	private Uri base_address;

	private CancellationTokenSource cts;

	private bool disposed;

	private HttpRequestHeaders headers;

	private long buffer_size;

	private TimeSpan timeout;

	/// <summary>Gets or sets the base address of Uniform Resource Identifier (URI) of the Internet resource used when sending requests.</summary>
	/// <returns>The base address of Uniform Resource Identifier (URI) of the Internet resource used when sending requests.</returns>
	public Uri BaseAddress
	{
		get
		{
			return base_address;
		}
		set
		{
			base_address = value;
		}
	}

	/// <summary>Gets the headers which should be sent with each request.</summary>
	/// <returns>The headers which should be sent with each request.</returns>
	public HttpRequestHeaders DefaultRequestHeaders => headers ?? (headers = new HttpRequestHeaders());

	/// <summary>Gets or sets the maximum number of bytes to buffer when reading the response content.</summary>
	/// <returns>The maximum number of bytes to buffer when reading the response content. The default value for this property is 2 gigabytes.</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The size specified is less than or equal to zero.</exception>
	/// <exception cref="T:System.InvalidOperationException">An operation has already been started on the current instance.</exception>
	/// <exception cref="T:System.ObjectDisposedException">The current instance has been disposed.</exception>
	public long MaxResponseContentBufferSize
	{
		get
		{
			return buffer_size;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			buffer_size = value;
		}
	}

	/// <summary>Gets or sets the timespan to wait before the request times out.</summary>
	/// <returns>The timespan to wait before the request times out.</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The timeout specified is less than or equal to zero and is not <see cref="F:System.Threading.Timeout.InfiniteTimeSpan" />.</exception>
	/// <exception cref="T:System.InvalidOperationException">An operation has already been started on the current instance.</exception>
	/// <exception cref="T:System.ObjectDisposedException">The current instance has been disposed.</exception>
	public TimeSpan Timeout
	{
		get
		{
			return timeout;
		}
		set
		{
			if (value != System.Threading.Timeout.InfiniteTimeSpan && (value <= TimeSpan.Zero || value.TotalMilliseconds > 2147483647.0))
			{
				throw new ArgumentOutOfRangeException();
			}
			timeout = value;
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Net.Http.HttpClient" /> class.</summary>
	public HttpClient()
		: this(new HttpClientHandler(), disposeHandler: true)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Net.Http.HttpClient" /> class with a specific handler.</summary>
	/// <param name="handler">The HTTP handler stack to use for sending requests.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="handler" /> is <see langword="null" />.</exception>
	public HttpClient(HttpMessageHandler handler)
		: this(handler, disposeHandler: true)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Net.Http.HttpClient" /> class with a specific handler.</summary>
	/// <param name="handler">The <see cref="T:System.Net.Http.HttpMessageHandler" /> responsible for processing the HTTP response messages.</param>
	/// <param name="disposeHandler">
	///   <see langword="true" /> if the inner handler should be disposed of by HttpClient.Dispose, <see langword="false" /> if you intend to reuse the inner handler.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="handler" /> is <see langword="null" />.</exception>
	public HttpClient(HttpMessageHandler handler, bool disposeHandler)
		: base(handler, disposeHandler)
	{
		buffer_size = 2147483647L;
		timeout = TimeoutDefault;
		cts = new CancellationTokenSource();
	}

	/// <summary>Cancel all pending requests on this instance.</summary>
	public void CancelPendingRequests()
	{
		using CancellationTokenSource cancellationTokenSource = Interlocked.Exchange(ref cts, new CancellationTokenSource());
		cancellationTokenSource.Cancel();
	}

	/// <summary>Releases the unmanaged resources used by the <see cref="T:System.Net.Http.HttpClient" /> and optionally disposes of the managed resources.</summary>
	/// <param name="disposing">
	///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to releases only unmanaged resources.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && !disposed)
		{
			disposed = true;
			cts.Cancel();
			cts.Dispose();
		}
		base.Dispose(disposing);
	}

	/// <summary>Send a DELETE request to the specified Uri as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.InvalidOperationException">The request message was already sent by the <see cref="T:System.Net.Http.HttpClient" /> instance.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> DeleteAsync(string requestUri)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri));
	}

	/// <summary>Send a DELETE request to the specified Uri with a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.InvalidOperationException">The request message was already sent by the <see cref="T:System.Net.Http.HttpClient" /> instance.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri), cancellationToken);
	}

	/// <summary>Send a DELETE request to the specified Uri as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.InvalidOperationException">The request message was already sent by the <see cref="T:System.Net.Http.HttpClient" /> instance.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri));
	}

	/// <summary>Send a DELETE request to the specified Uri with a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.InvalidOperationException">The request message was already sent by the <see cref="T:System.Net.Http.HttpClient" /> instance.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri), cancellationToken);
	}

	/// <summary>Send a GET request to the specified Uri as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> GetAsync(string requestUri)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri));
	}

	/// <summary>Send a GET request to the specified Uri with a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), cancellationToken);
	}

	/// <summary>Send a GET request to the specified Uri with an HTTP completion option as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="completionOption">An HTTP completion option value that indicates when the operation should be considered completed.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption);
	}

	/// <summary>Send a GET request to the specified Uri with an HTTP completion option and a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="completionOption">An HTTP  completion option value that indicates when the operation should be considered completed.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption, cancellationToken);
	}

	/// <summary>Send a GET request to the specified Uri as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> GetAsync(Uri requestUri)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri));
	}

	/// <summary>Send a GET request to the specified Uri with a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), cancellationToken);
	}

	/// <summary>Send a GET request to the specified Uri with an HTTP completion option as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="completionOption">An HTTP completion option value that indicates when the operation should be considered completed.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption);
	}

	/// <summary>Send a GET request to the specified Uri with an HTTP completion option and a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="completionOption">An HTTP  completion option value that indicates when the operation should be considered completed.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption, cancellationToken);
	}

	/// <summary>Send a POST request to the specified Uri as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="content">The HTTP request content sent to the server.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Post, requestUri)
		{
			Content = content
		});
	}

	/// <summary>Send a POST request with a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="content">The HTTP request content sent to the server.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Post, requestUri)
		{
			Content = content
		}, cancellationToken);
	}

	/// <summary>Send a POST request to the specified Uri as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="content">The HTTP request content sent to the server.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Post, requestUri)
		{
			Content = content
		});
	}

	/// <summary>Send a POST request with a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="content">The HTTP request content sent to the server.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Post, requestUri)
		{
			Content = content
		}, cancellationToken);
	}

	/// <summary>Send a PUT request to the specified Uri as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="content">The HTTP request content sent to the server.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Put, requestUri)
		{
			Content = content
		});
	}

	/// <summary>Send a PUT request with a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="content">The HTTP request content sent to the server.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Put, requestUri)
		{
			Content = content
		}, cancellationToken);
	}

	/// <summary>Send a PUT request to the specified Uri as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="content">The HTTP request content sent to the server.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Put, requestUri)
		{
			Content = content
		});
	}

	/// <summary>Send a PUT request with a cancellation token as an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <param name="content">The HTTP request content sent to the server.</param>
	/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		return SendAsync(new HttpRequestMessage(HttpMethod.Put, requestUri)
		{
			Content = content
		}, cancellationToken);
	}

	/// <summary>Send an HTTP request as an asynchronous operation.</summary>
	/// <param name="request">The HTTP request message to send.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.InvalidOperationException">The request message was already sent by the <see cref="T:System.Net.Http.HttpClient" /> instance.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
	{
		return SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
	}

	/// <summary>Send an HTTP request as an asynchronous operation.</summary>
	/// <param name="request">The HTTP request message to send.</param>
	/// <param name="completionOption">When the operation should complete (as soon as a response is available or after reading the whole response content).</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.InvalidOperationException">The request message was already sent by the <see cref="T:System.Net.Http.HttpClient" /> instance.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)
	{
		return SendAsync(request, completionOption, CancellationToken.None);
	}

	/// <summary>Send an HTTP request as an asynchronous operation.</summary>
	/// <param name="request">The HTTP request message to send.</param>
	/// <param name="cancellationToken">The cancellation token to cancel operation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.InvalidOperationException">The request message was already sent by the <see cref="T:System.Net.Http.HttpClient" /> instance.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		return SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);
	}

	/// <summary>Send an HTTP request as an asynchronous operation.</summary>
	/// <param name="request">The HTTP request message to send.</param>
	/// <param name="completionOption">When the operation should complete (as soon as a response is available or after reading the whole response content).</param>
	/// <param name="cancellationToken">The cancellation token to cancel operation.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.InvalidOperationException">The request message was already sent by the <see cref="T:System.Net.Http.HttpClient" /> instance.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (request.SetIsUsed())
		{
			throw new InvalidOperationException("Cannot send the same request message multiple times");
		}
		Uri requestUri = request.RequestUri;
		if (requestUri == null)
		{
			if (base_address == null)
			{
				throw new InvalidOperationException("The request URI must either be an absolute URI or BaseAddress must be set");
			}
			request.RequestUri = base_address;
		}
		else if (!requestUri.IsAbsoluteUri || (requestUri.Scheme == Uri.UriSchemeFile && requestUri.OriginalString.StartsWith("/", StringComparison.Ordinal)))
		{
			if (base_address == null)
			{
				throw new InvalidOperationException("The request URI must either be an absolute URI or BaseAddress must be set");
			}
			request.RequestUri = new Uri(base_address, requestUri);
		}
		if (headers != null)
		{
			request.Headers.AddHeaders(headers);
		}
		return SendAsyncWorker(request, completionOption, cancellationToken);
	}

	private async Task<HttpResponseMessage> SendAsyncWorker(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
	{
		using CancellationTokenSource lcts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, cancellationToken);
		if (handler is HttpClientHandler httpClientHandler)
		{
			httpClientHandler.SetWebRequestTimeout(timeout);
		}
		lcts.CancelAfter(timeout);
		HttpResponseMessage response = await (base.SendAsync(request, lcts.Token) ?? throw new InvalidOperationException("Handler failed to return a value")).ConfigureAwait(continueOnCapturedContext: false);
		if (response == null)
		{
			throw new InvalidOperationException("Handler failed to return a response");
		}
		if (response.Content != null && (completionOption & HttpCompletionOption.ResponseHeadersRead) == 0)
		{
			await response.Content.LoadIntoBufferAsync(MaxResponseContentBufferSize).ConfigureAwait(continueOnCapturedContext: false);
		}
		return response;
	}

	/// <summary>Sends a GET request to the specified Uri and return the response body as a byte array in an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public async Task<byte[]> GetByteArrayAsync(string requestUri)
	{
		using HttpResponseMessage resp = await GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).ConfigureAwait(continueOnCapturedContext: false);
		resp.EnsureSuccessStatusCode();
		return await resp.Content.ReadAsByteArrayAsync().ConfigureAwait(continueOnCapturedContext: false);
	}

	/// <summary>Send a GET request to the specified Uri and return the response body as a byte array in an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public async Task<byte[]> GetByteArrayAsync(Uri requestUri)
	{
		using HttpResponseMessage resp = await GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).ConfigureAwait(continueOnCapturedContext: false);
		resp.EnsureSuccessStatusCode();
		return await resp.Content.ReadAsByteArrayAsync().ConfigureAwait(continueOnCapturedContext: false);
	}

	/// <summary>Send a GET request to the specified Uri and return the response body as a stream in an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public async Task<Stream> GetStreamAsync(string requestUri)
	{
		HttpResponseMessage obj = await GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(continueOnCapturedContext: false);
		obj.EnsureSuccessStatusCode();
		return await obj.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
	}

	/// <summary>Send a GET request to the specified Uri and return the response body as a stream in an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public async Task<Stream> GetStreamAsync(Uri requestUri)
	{
		HttpResponseMessage obj = await GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(continueOnCapturedContext: false);
		obj.EnsureSuccessStatusCode();
		return await obj.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
	}

	/// <summary>Send a GET request to the specified Uri and return the response body as a string in an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public async Task<string> GetStringAsync(string requestUri)
	{
		using HttpResponseMessage resp = await GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).ConfigureAwait(continueOnCapturedContext: false);
		resp.EnsureSuccessStatusCode();
		return await resp.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
	}

	/// <summary>Send a GET request to the specified Uri and return the response body as a string in an asynchronous operation.</summary>
	/// <param name="requestUri">The Uri the request is sent to.</param>
	/// <returns>The task object representing the asynchronous operation.</returns>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="requestUri" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.Net.Http.HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
	public async Task<string> GetStringAsync(Uri requestUri)
	{
		using HttpResponseMessage resp = await GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).ConfigureAwait(continueOnCapturedContext: false);
		resp.EnsureSuccessStatusCode();
		return await resp.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
	}

	public Task<HttpResponseMessage> PatchAsync(string requestUri, HttpContent content)
	{
		throw new PlatformNotSupportedException();
	}

	public Task<HttpResponseMessage> PatchAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		throw new PlatformNotSupportedException();
	}

	public Task<HttpResponseMessage> PatchAsync(Uri requestUri, HttpContent content)
	{
		throw new PlatformNotSupportedException();
	}

	public Task<HttpResponseMessage> PatchAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
	{
		throw new PlatformNotSupportedException();
	}
}
