using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Linq;

/// <summary>Represents an expression tree and provides functionality to execute the expression tree after rewriting it.</summary>
/// <typeparam name="T">The data type of the value that results from executing the expression tree.</typeparam>
public class EnumerableExecutor<T> : EnumerableExecutor
{
	private readonly Expression _expression;

	/// <summary>Initializes a new instance of the <see cref="T:System.Linq.EnumerableExecutor`1" /> class.</summary>
	/// <param name="expression">An expression tree to associate with the new instance.</param>
	public EnumerableExecutor(Expression expression)
	{
		_expression = expression;
	}

	internal override object ExecuteBoxed()
	{
		return Execute();
	}

	internal T Execute()
	{
		return Expression.Lambda<Func<T>>(new EnumerableRewriter().Visit(_expression), (IEnumerable<ParameterExpression>)null).Compile()();
	}
}
