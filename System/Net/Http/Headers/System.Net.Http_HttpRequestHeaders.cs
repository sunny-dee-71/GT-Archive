using System.Collections.Generic;

namespace System.Net.Http.Headers;

/// <summary>Represents the collection of Request Headers as defined in RFC 2616.</summary>
public sealed class HttpRequestHeaders : HttpHeaders
{
	private bool? expectContinue;

	/// <summary>Gets the value of the <see langword="Accept" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Accept" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> Accept => GetValues<MediaTypeWithQualityHeaderValue>("Accept");

	/// <summary>Gets the value of the <see langword="Accept-Charset" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Accept-Charset" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptCharset => GetValues<StringWithQualityHeaderValue>("Accept-Charset");

	/// <summary>Gets the value of the <see langword="Accept-Encoding" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Accept-Encoding" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptEncoding => GetValues<StringWithQualityHeaderValue>("Accept-Encoding");

	/// <summary>Gets the value of the <see langword="Accept-Language" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Accept-Language" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptLanguage => GetValues<StringWithQualityHeaderValue>("Accept-Language");

	/// <summary>Gets or sets the value of the <see langword="Authorization" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Authorization" /> header for an HTTP request.</returns>
	public AuthenticationHeaderValue Authorization
	{
		get
		{
			return GetValue<AuthenticationHeaderValue>("Authorization");
		}
		set
		{
			AddOrRemove("Authorization", value);
		}
	}

	/// <summary>Gets or sets the value of the <see langword="Cache-Control" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Cache-Control" /> header for an HTTP request.</returns>
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

	/// <summary>Gets the value of the <see langword="Connection" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Connection" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<string> Connection => GetValues<string>("Connection");

	/// <summary>Gets or sets a value that indicates if the <see langword="Connection" /> header for an HTTP request contains Close.</summary>
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

	internal bool ConnectionKeepAlive => Connection.Find((string l) => string.Equals(l, "Keep-Alive", StringComparison.OrdinalIgnoreCase)) != null;

	/// <summary>Gets or sets the value of the <see langword="Date" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Date" /> header for an HTTP request.</returns>
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

	/// <summary>Gets the value of the <see langword="Expect" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Expect" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<NameValueWithParametersHeaderValue> Expect => GetValues<NameValueWithParametersHeaderValue>("Expect");

	/// <summary>Gets or sets a value that indicates if the <see langword="Expect" /> header for an HTTP request contains Continue.</summary>
	/// <returns>
	///   <see langword="true" /> if the <see langword="Expect" /> header contains Continue, otherwise <see langword="false" />.</returns>
	public bool? ExpectContinue
	{
		get
		{
			if (expectContinue.HasValue)
			{
				return expectContinue;
			}
			if (TransferEncoding.Find((TransferCodingHeaderValue l) => string.Equals(l.Value, "100-continue", StringComparison.OrdinalIgnoreCase)) == null)
			{
				return null;
			}
			return true;
		}
		set
		{
			if (expectContinue != value)
			{
				Expect.Remove((NameValueWithParametersHeaderValue l) => l.Name == "100-continue");
				if (value == true)
				{
					Expect.Add(new NameValueWithParametersHeaderValue("100-continue"));
				}
				expectContinue = value;
			}
		}
	}

	/// <summary>Gets or sets the value of the <see langword="From" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="From" /> header for an HTTP request.</returns>
	public string From
	{
		get
		{
			return GetValue<string>("From");
		}
		set
		{
			if (!string.IsNullOrEmpty(value) && !Parser.EmailAddress.TryParse(value, out value))
			{
				throw new FormatException();
			}
			AddOrRemove("From", value);
		}
	}

	/// <summary>Gets or sets the value of the <see langword="Host" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Host" /> header for an HTTP request.</returns>
	public string Host
	{
		get
		{
			return GetValue<string>("Host");
		}
		set
		{
			AddOrRemove("Host", value);
		}
	}

	/// <summary>Gets the value of the <see langword="If-Match" /> header for an HTTP request.</summary>
	/// <returns>Returns <see cref="T:System.Net.Http.Headers.HttpHeaderValueCollection`1" />.  
	///  The value of the <see langword="If-Match" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<EntityTagHeaderValue> IfMatch => GetValues<EntityTagHeaderValue>("If-Match");

	/// <summary>Gets or sets the value of the <see langword="If-Modified-Since" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="If-Modified-Since" /> header for an HTTP request.</returns>
	public DateTimeOffset? IfModifiedSince
	{
		get
		{
			return GetValue<DateTimeOffset?>("If-Modified-Since");
		}
		set
		{
			AddOrRemove("If-Modified-Since", value, Parser.DateTime.ToString);
		}
	}

	/// <summary>Gets the value of the <see langword="If-None-Match" /> header for an HTTP request.</summary>
	/// <returns>Gets the value of the <see langword="If-None-Match" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<EntityTagHeaderValue> IfNoneMatch => GetValues<EntityTagHeaderValue>("If-None-Match");

	/// <summary>Gets or sets the value of the <see langword="If-Range" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="If-Range" /> header for an HTTP request.</returns>
	public RangeConditionHeaderValue IfRange
	{
		get
		{
			return GetValue<RangeConditionHeaderValue>("If-Range");
		}
		set
		{
			AddOrRemove("If-Range", value);
		}
	}

	/// <summary>Gets or sets the value of the <see langword="If-Unmodified-Since" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="If-Unmodified-Since" /> header for an HTTP request.</returns>
	public DateTimeOffset? IfUnmodifiedSince
	{
		get
		{
			return GetValue<DateTimeOffset?>("If-Unmodified-Since");
		}
		set
		{
			AddOrRemove("If-Unmodified-Since", value, Parser.DateTime.ToString);
		}
	}

	/// <summary>Gets or sets the value of the <see langword="Max-Forwards" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Max-Forwards" /> header for an HTTP request.</returns>
	public int? MaxForwards
	{
		get
		{
			return GetValue<int?>("Max-Forwards");
		}
		set
		{
			AddOrRemove("Max-Forwards", value);
		}
	}

	/// <summary>Gets the value of the <see langword="Pragma" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Pragma" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<NameValueHeaderValue> Pragma => GetValues<NameValueHeaderValue>("Pragma");

	/// <summary>Gets or sets the value of the <see langword="Proxy-Authorization" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Proxy-Authorization" /> header for an HTTP request.</returns>
	public AuthenticationHeaderValue ProxyAuthorization
	{
		get
		{
			return GetValue<AuthenticationHeaderValue>("Proxy-Authorization");
		}
		set
		{
			AddOrRemove("Proxy-Authorization", value);
		}
	}

	/// <summary>Gets or sets the value of the <see langword="Range" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Range" /> header for an HTTP request.</returns>
	public RangeHeaderValue Range
	{
		get
		{
			return GetValue<RangeHeaderValue>("Range");
		}
		set
		{
			AddOrRemove("Range", value);
		}
	}

	/// <summary>Gets or sets the value of the <see langword="Referer" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Referer" /> header for an HTTP request.</returns>
	public Uri Referrer
	{
		get
		{
			return GetValue<Uri>("Referer");
		}
		set
		{
			AddOrRemove("Referer", value);
		}
	}

	/// <summary>Gets the value of the <see langword="TE" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="TE" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<TransferCodingWithQualityHeaderValue> TE => GetValues<TransferCodingWithQualityHeaderValue>("TE");

	/// <summary>Gets the value of the <see langword="Trailer" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Trailer" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<string> Trailer => GetValues<string>("Trailer");

	/// <summary>Gets the value of the <see langword="Transfer-Encoding" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Transfer-Encoding" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding => GetValues<TransferCodingHeaderValue>("Transfer-Encoding");

	/// <summary>Gets or sets a value that indicates if the <see langword="Transfer-Encoding" /> header for an HTTP request contains chunked.</summary>
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
			if (TransferEncoding.Find((TransferCodingHeaderValue l) => string.Equals(l.Value, "chunked", StringComparison.OrdinalIgnoreCase)) == null)
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

	/// <summary>Gets the value of the <see langword="Upgrade" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Upgrade" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<ProductHeaderValue> Upgrade => GetValues<ProductHeaderValue>("Upgrade");

	/// <summary>Gets the value of the <see langword="User-Agent" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="User-Agent" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent => GetValues<ProductInfoHeaderValue>("User-Agent");

	/// <summary>Gets the value of the <see langword="Via" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Via" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<ViaHeaderValue> Via => GetValues<ViaHeaderValue>("Via");

	/// <summary>Gets the value of the <see langword="Warning" /> header for an HTTP request.</summary>
	/// <returns>The value of the <see langword="Warning" /> header for an HTTP request.</returns>
	public HttpHeaderValueCollection<WarningHeaderValue> Warning => GetValues<WarningHeaderValue>("Warning");

	internal HttpRequestHeaders()
		: base(HttpHeaderKind.Request)
	{
	}

	internal void AddHeaders(HttpRequestHeaders headers)
	{
		foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
		{
			TryAddWithoutValidation(header.Key, header.Value);
		}
	}
}
