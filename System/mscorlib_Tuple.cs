using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace System;

/// <summary>Represents an n-tuple, where n is 8 or greater.</summary>
/// <typeparam name="T1">The type of the tuple's first component.</typeparam>
/// <typeparam name="T2">The type of the tuple's second component.</typeparam>
/// <typeparam name="T3">The type of the tuple's third component.</typeparam>
/// <typeparam name="T4">The type of the tuple's fourth component.</typeparam>
/// <typeparam name="T5">The type of the tuple's fifth component.</typeparam>
/// <typeparam name="T6">The type of the tuple's sixth component.</typeparam>
/// <typeparam name="T7">The type of the tuple's seventh component.</typeparam>
/// <typeparam name="TRest">Any generic <see langword="Tuple" /> object that defines the types of the tuple's remaining components.</typeparam>
[Serializable]
public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
{
	private readonly T1 m_Item1;

	private readonly T2 m_Item2;

	private readonly T3 m_Item3;

	private readonly T4 m_Item4;

	private readonly T5 m_Item5;

	private readonly T6 m_Item6;

	private readonly T7 m_Item7;

	private readonly TRest m_Rest;

	/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's first component.</summary>
	/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's first component.</returns>
	public T1 Item1 => m_Item1;

	/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's second component.</summary>
	/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's second component.</returns>
	public T2 Item2 => m_Item2;

	/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's third component.</summary>
	/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's third component.</returns>
	public T3 Item3 => m_Item3;

	/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's fourth component.</summary>
	/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's fourth component.</returns>
	public T4 Item4 => m_Item4;

	/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's fifth component.</summary>
	/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's fifth component.</returns>
	public T5 Item5 => m_Item5;

	/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's sixth component.</summary>
	/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's sixth component.</returns>
	public T6 Item6 => m_Item6;

	/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's seventh component.</summary>
	/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's seventh component.</returns>
	public T7 Item7 => m_Item7;

	/// <summary>Gets the current <see cref="T:System.Tuple`8" /> object's remaining components.</summary>
	/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's remaining components.</returns>
	public TRest Rest => m_Rest;

	/// <summary>Gets the number of elements in the <see langword="Tuple" />.</summary>
	/// <returns>The number of elements in the <see langword="Tuple" />.</returns>
	int ITuple.Length => 7 + ((ITupleInternal)(object)Rest).Length;

	/// <summary>Gets the value of the specified <see langword="Tuple" /> element.</summary>
	/// <param name="index">The index of the specified <see langword="Tuple" /> element. <paramref name="index" /> can range from 0 for <see langword="Item1" /> to one less than the number of elements in the <see langword="Tuple" />.</param>
	/// <returns>The value of the <see langword="Tuple" /> element at the specified position.</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">
	///   <paramref name="index" /> is less than 0.  
	/// -or-  
	/// <paramref name="index" /> is greater than or equal to <see cref="P:System.Tuple`8.System#Runtime#CompilerServices#ITuple#Length" />.</exception>
	object ITuple.this[int index] => index switch
	{
		0 => Item1, 
		1 => Item2, 
		2 => Item3, 
		3 => Item4, 
		4 => Item5, 
		5 => Item6, 
		6 => Item7, 
		_ => ((ITupleInternal)(object)Rest)[index - 7], 
	};

	/// <summary>Initializes a new instance of the <see cref="T:System.Tuple`8" /> class.</summary>
	/// <param name="item1">The value of the tuple's first component.</param>
	/// <param name="item2">The value of the tuple's second component.</param>
	/// <param name="item3">The value of the tuple's third component.</param>
	/// <param name="item4">The value of the tuple's fourth component</param>
	/// <param name="item5">The value of the tuple's fifth component.</param>
	/// <param name="item6">The value of the tuple's sixth component.</param>
	/// <param name="item7">The value of the tuple's seventh component.</param>
	/// <param name="rest">Any generic <see langword="Tuple" /> object that contains the values of the tuple's remaining components.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="rest" /> is not a generic <see langword="Tuple" /> object.</exception>
	public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
	{
		if (!(rest is ITupleInternal))
		{
			throw new ArgumentException("The last element of an eight element tuple must be a Tuple.");
		}
		m_Item1 = item1;
		m_Item2 = item2;
		m_Item3 = item3;
		m_Item4 = item4;
		m_Item5 = item5;
		m_Item6 = item6;
		m_Item7 = item7;
		m_Rest = rest;
	}

	/// <summary>Returns a value that indicates whether the current <see cref="T:System.Tuple`8" /> object is equal to a specified object.</summary>
	/// <param name="obj">The object to compare with this instance.</param>
	/// <returns>
	///   <see langword="true" /> if the current instance is equal to the specified object; otherwise, <see langword="false" />.</returns>
	public override bool Equals(object obj)
	{
		return ((IStructuralEquatable)this).Equals(obj, (IEqualityComparer)EqualityComparer<object>.Default);
	}

	/// <summary>Returns a value that indicates whether the current <see cref="T:System.Tuple`8" /> object is equal to a specified object based on a specified comparison method.</summary>
	/// <param name="other">The object to compare with this instance.</param>
	/// <param name="comparer">An object that defines the method to use to evaluate whether the two objects are equal.</param>
	/// <returns>
	///   <see langword="true" /> if the current instance is equal to the specified object; otherwise, <see langword="false" />.</returns>
	bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
	{
		if (other == null)
		{
			return false;
		}
		if (!(other is Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple))
		{
			return false;
		}
		if (comparer.Equals(m_Item1, tuple.m_Item1) && comparer.Equals(m_Item2, tuple.m_Item2) && comparer.Equals(m_Item3, tuple.m_Item3) && comparer.Equals(m_Item4, tuple.m_Item4) && comparer.Equals(m_Item5, tuple.m_Item5) && comparer.Equals(m_Item6, tuple.m_Item6) && comparer.Equals(m_Item7, tuple.m_Item7))
		{
			return comparer.Equals(m_Rest, tuple.m_Rest);
		}
		return false;
	}

	/// <summary>Compares the current <see cref="T:System.Tuple`8" /> object to a specified object and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
	/// <param name="obj">An object to compare with the current instance.</param>
	/// <returns>A signed integer that indicates the relative position of this instance and <paramref name="obj" /> in the sort order, as shown in the following table.  
	///   Value  
	///
	///   Description  
	///
	///   A negative integer  
	///
	///   This instance precedes <paramref name="obj" />.  
	///
	///   Zero  
	///
	///   This instance and <paramref name="obj" /> have the same position in the sort order.  
	///
	///   A positive integer  
	///
	///   This instance follows <paramref name="obj" />.</returns>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="obj" /> is not a <see cref="T:System.Tuple`8" /> object.</exception>
	int IComparable.CompareTo(object obj)
	{
		return ((IStructuralComparable)this).CompareTo(obj, (IComparer)Comparer<object>.Default);
	}

	/// <summary>Compares the current <see cref="T:System.Tuple`8" /> object to a specified object by using a specified comparer and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
	/// <param name="other">An object to compare with the current instance.</param>
	/// <param name="comparer">An object that provides custom rules for comparison.</param>
	/// <returns>A signed integer that indicates the relative position of this instance and <paramref name="other" /> in the sort order, as shown in the following table.  
	///   Value  
	///
	///   Description  
	///
	///   A negative integer  
	///
	///   This instance precedes <paramref name="other" />.  
	///
	///   Zero  
	///
	///   This instance and <paramref name="other" /> have the same position in the sort order.  
	///
	///   A positive integer  
	///
	///   This instance follows <paramref name="other" />.</returns>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="other" /> is not a <see cref="T:System.Tuple`8" /> object.</exception>
	int IStructuralComparable.CompareTo(object other, IComparer comparer)
	{
		if (other == null)
		{
			return 1;
		}
		if (!(other is Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple))
		{
			throw new ArgumentException(SR.Format("Argument must be of type {0}.", GetType().ToString()), "other");
		}
		int num = 0;
		num = comparer.Compare(m_Item1, tuple.m_Item1);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(m_Item2, tuple.m_Item2);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(m_Item3, tuple.m_Item3);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(m_Item4, tuple.m_Item4);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(m_Item5, tuple.m_Item5);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(m_Item6, tuple.m_Item6);
		if (num != 0)
		{
			return num;
		}
		num = comparer.Compare(m_Item7, tuple.m_Item7);
		if (num != 0)
		{
			return num;
		}
		return comparer.Compare(m_Rest, tuple.m_Rest);
	}

	/// <summary>Calculates the hash code for the current <see cref="T:System.Tuple`8" /> object.</summary>
	/// <returns>A 32-bit signed integer hash code.</returns>
	public override int GetHashCode()
	{
		return ((IStructuralEquatable)this).GetHashCode((IEqualityComparer)EqualityComparer<object>.Default);
	}

	/// <summary>Calculates the hash code for the current <see cref="T:System.Tuple`8" /> object by using a specified computation method.</summary>
	/// <param name="comparer">An object whose <see cref="M:System.Collections.IEqualityComparer.GetHashCode(System.Object)" /> method calculates the hash code of the current <see cref="T:System.Tuple`8" /> object.</param>
	/// <returns>A 32-bit signed integer hash code.</returns>
	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		ITupleInternal tupleInternal = (ITupleInternal)(object)m_Rest;
		if (tupleInternal.Length >= 8)
		{
			return tupleInternal.GetHashCode(comparer);
		}
		return (8 - tupleInternal.Length) switch
		{
			1 => Tuple.CombineHashCodes(comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer)), 
			2 => Tuple.CombineHashCodes(comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer)), 
			3 => Tuple.CombineHashCodes(comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer)), 
			4 => Tuple.CombineHashCodes(comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer)), 
			5 => Tuple.CombineHashCodes(comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer)), 
			6 => Tuple.CombineHashCodes(comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer)), 
			7 => Tuple.CombineHashCodes(comparer.GetHashCode(m_Item1), comparer.GetHashCode(m_Item2), comparer.GetHashCode(m_Item3), comparer.GetHashCode(m_Item4), comparer.GetHashCode(m_Item5), comparer.GetHashCode(m_Item6), comparer.GetHashCode(m_Item7), tupleInternal.GetHashCode(comparer)), 
			_ => -1, 
		};
	}

	int ITupleInternal.GetHashCode(IEqualityComparer comparer)
	{
		return ((IStructuralEquatable)this).GetHashCode(comparer);
	}

	/// <summary>Returns a string that represents the value of this <see cref="T:System.Tuple`8" /> instance.</summary>
	/// <returns>The string representation of this <see cref="T:System.Tuple`8" /> object.</returns>
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('(');
		return ((ITupleInternal)this).ToString(stringBuilder);
	}

	string ITupleInternal.ToString(StringBuilder sb)
	{
		sb.Append(m_Item1);
		sb.Append(", ");
		sb.Append(m_Item2);
		sb.Append(", ");
		sb.Append(m_Item3);
		sb.Append(", ");
		sb.Append(m_Item4);
		sb.Append(", ");
		sb.Append(m_Item5);
		sb.Append(", ");
		sb.Append(m_Item6);
		sb.Append(", ");
		sb.Append(m_Item7);
		sb.Append(", ");
		return ((ITupleInternal)(object)m_Rest).ToString(sb);
	}
}
