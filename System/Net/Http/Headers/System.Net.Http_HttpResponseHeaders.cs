namespace System.Net.Http.Headers;

/// <summary>Represents the collection of Response Headers as defined in RFC 2616.</summary>
public sealed class HttpResponseHeaders : HttpHeaders
{
	/// <summary>Gets the value of the <see langword="Accept-Ranges" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Accept-Ranges" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<string> AcceptRanges => GetValues<string>("Accept-Ranges");

	/// <summary>Gets or sets the value of the <see langword="Age" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Age" /> header for an HTTP response.</returns>
	public TimeSpan? Age
	{
		get
		{
			return GetValue<TimeSpan?>("Age");
		}
		set
		{
			AddOrRemove("Age", value, (object l) => ((long)((TimeSpan)l).TotalSeconds).ToString());
		}
	}

	/// <summary>Gets or sets the value of the <see langword="Cache-Control" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Cache-Control" /> header for an HTTP response.</returns>
	public CacheControlHeaderValue CacheControl
	{
		get
		{
			return GetValue<CacheControlHeaderValue>("Cache-Control");
		}
		set
		{
			AddOrRemove("Cache-Control", value);
		}
	}

	/// <summary>Gets the value of the <see langword="Connection" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Connection" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<string> Connection => GetValues<string>("Connection");

	/// <summary>Gets or sets a value that indicates if the <see langword="Connection" /> header for an HTTP response contains Close.</summary>
	/// <returns>
	///   <see langword="true" /> if the <see langword="Connection" /> header contains Close, otherwise <see langword="false" />.</returns>
	public bool? ConnectionClose
	{
		get
		{
			if (connectionclose == true || Connection.Find((string l) => string.Equals(l, "close", StringComparison.OrdinalIgnoreCase)) != null)
			{
				return true;
			}
			return connectionclose;
		}
		set
		{
			if (connectionclose != value)
			{
				Connection.Remove("close");
				if (value == true)
				{
					Connection.Add("close");
				}
				connectionclose = value;
			}
		}
	}

	/// <summary>Gets or sets the value of the <see langword="Date" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Date" /> header for an HTTP response.</returns>
	public DateTimeOffset? Date
	{
		get
		{
			return GetValue<DateTimeOffset?>("Date");
		}
		set
		{
			AddOrRemove("Date", value, Parser.DateTime.ToString);
		}
	}

	/// <summary>Gets or sets the value of the <see langword="ETag" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="ETag" /> header for an HTTP response.</returns>
	public EntityTagHeaderValue ETag
	{
		get
		{
			return GetValue<EntityTagHeaderValue>("ETag");
		}
		set
		{
			AddOrRemove("ETag", value);
		}
	}

	/// <summary>Gets or sets the value of the <see langword="Location" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Location" /> header for an HTTP response.</returns>
	public Uri Location
	{
		get
		{
			return GetValue<Uri>("Location");
		}
		set
		{
			AddOrRemove("Location", value);
		}
	}

	/// <summary>Gets the value of the <see langword="Pragma" /> header for an HTTP response.</summary>
	/// <returns>Returns <see cref="T:System.Net.Http.Headers.HttpHeaderValueCollection`1" />.  
	///  The value of the <see langword="Pragma" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<NameValueHeaderValue> Pragma => GetValues<NameValueHeaderValue>("Pragma");

	/// <summary>Gets the value of the <see langword="Proxy-Authenticate" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Proxy-Authenticate" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<AuthenticationHeaderValue> ProxyAuthenticate => GetValues<AuthenticationHeaderValue>("Proxy-Authenticate");

	/// <summary>Gets or sets the value of the <see langword="Retry-After" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Retry-After" /> header for an HTTP response.</returns>
	public RetryConditionHeaderValue RetryAfter
	{
		get
		{
			return GetValue<RetryConditionHeaderValue>("Retry-After");
		}
		set
		{
			AddOrRemove("Retry-After", value);
		}
	}

	/// <summary>Gets the value of the <see langword="Server" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Server" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<ProductInfoHeaderValue> Server => GetValues<ProductInfoHeaderValue>("Server");

	/// <summary>Gets the value of the <see langword="Trailer" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Trailer" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<string> Trailer => GetValues<string>("Trailer");

	/// <summary>Gets the value of the <see langword="Transfer-Encoding" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Transfer-Encoding" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding => GetValues<TransferCodingHeaderValue>("Transfer-Encoding");

	/// <summary>Gets or sets a value that indicates if the <see langword="Transfer-Encoding" /> header for an HTTP response contains chunked.</summary>
	/// <returns>
	///   <see langword="true" /> if the <see langword="Transfer-Encoding" /> header contains chunked, otherwise <see langword="false" />.</returns>
	public bool? TransferEncodingChunked
	{
		get
		{
			if (transferEncodingChunked.HasValue)
			{
				return transferEncodingChunked;
			}
			if (TransferEncoding.Find((TransferCodingHeaderValue l) => StringComparer.OrdinalIgnoreCase.Equals(l.Value, "chunked")) == null)
			{
				return null;
			}
			return true;
		}
		set
		{
			if (value != transferEncodingChunked)
			{
				TransferEncoding.Remove((TransferCodingHeaderValue l) => l.Value == "chunked");
				if (value == true)
				{
					TransferEncoding.Add(new TransferCodingHeaderValue("chunked"));
				}
				transferEncodingChunked = value;
			}
		}
	}

	/// <summary>Gets the value of the <see langword="Upgrade" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Upgrade" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<ProductHeaderValue> Upgrade => GetValues<ProductHeaderValue>("Upgrade");

	/// <summary>Gets the value of the <see langword="Vary" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Vary" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<string> Vary => GetValues<string>("Vary");

	/// <summary>Gets the value of the <see langword="Via" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Via" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<ViaHeaderValue> Via => GetValues<ViaHeaderValue>("Via");

	/// <summary>Gets the value of the <see langword="Warning" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="Warning" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<WarningHeaderValue> Warning => GetValues<WarningHeaderValue>("Warning");

	/// <summary>Gets the value of the <see langword="WWW-Authenticate" /> header for an HTTP response.</summary>
	/// <returns>The value of the <see langword="WWW-Authenticate" /> header for an HTTP response.</returns>
	public HttpHeaderValueCollection<AuthenticationHeaderValue> WwwAuthenticate => GetValues<AuthenticationHeaderValue>("WWW-Authenticate");

	internal HttpResponseHeaders()
		: base(HttpHeaderKind.Response)
	{
	}
}
