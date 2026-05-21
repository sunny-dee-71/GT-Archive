using System.Collections.Generic;
using System.Linq;
using Microsoft.Internal.Collections;

namespace System.ComponentModel.Composition;

internal struct CompositionResult<T>
{
	private readonly IEnumerable<CompositionError> _errors;

	private readonly T _value;

	public bool Succeeded
	{
		get
		{
			if (_errors != null)
			{
				return !_errors.FastAny();
			}
			return true;
		}
	}

	public IEnumerable<CompositionError> Errors => _errors ?? Enumerable.Empty<CompositionError>();

	public T Value
	{
		get
		{
			ThrowOnErrors();
			return _value;
		}
	}

	public CompositionResult(T value)
		: this(value, null)
	{
	}

	public CompositionResult(params CompositionError[] errors)
		: this(default(T), errors)
	{
	}

	public CompositionResult(IEnumerable<CompositionError> errors)
		: this(default(T), errors)
	{
	}

	internal CompositionResult(T value, IEnumerable<CompositionError> errors)
	{
		_errors = errors;
		_value = value;
	}

	internal CompositionResult<TValue> ToResult<TValue>()
	{
		return new CompositionResult<TValue>(_errors);
	}

	internal CompositionResult ToResult()
	{
		return new CompositionResult(_errors);
	}

	private void ThrowOnErrors()
	{
		if (!Succeeded)
		{
			throw new CompositionException(_errors);
		}
	}
}
