using System;
using System.Reflection;

namespace UnityEngine.Events;

internal class InvokableCall<T1, T2, T3, T4> : BaseInvokableCall
{
	protected event UnityAction<T1, T2, T3, T4> Delegate;

	public InvokableCall(object target, MethodInfo theFunction)
		: base(target, theFunction)
	{
		this.Delegate = (UnityAction<T1, T2, T3, T4>)System.Delegate.CreateDelegate(typeof(UnityAction<T1, T2, T3, T4>), target, theFunction);
	}

	public InvokableCall(UnityAction<T1, T2, T3, T4> action)
	{
		Delegate += action;
	}

	public override void Invoke(object[] args)
	{
		if (args.Length != 4)
		{
			throw new ArgumentException("Passed argument 'args' is invalid size. Expected size is 1");
		}
		BaseInvokableCall.ThrowOnInvalidArg<T1>(args[0]);
		BaseInvokableCall.ThrowOnInvalidArg<T2>(args[1]);
		BaseInvokableCall.ThrowOnInvalidArg<T3>(args[2]);
		BaseInvokableCall.ThrowOnInvalidArg<T4>(args[3]);
		if (BaseInvokableCall.AllowInvoke(this.Delegate))
		{
			this.Delegate((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3]);
		}
	}

	public void Invoke(T1 args0, T2 args1, T3 args2, T4 args3)
	{
		if (BaseInvokableCall.AllowInvoke(this.Delegate))
		{
			this.Delegate(args0, args1, args2, args3);
		}
	}

	public override bool Find(object targetObj, MethodInfo method)
	{
		return this.Delegate.Target == targetObj && this.Delegate.Method.Equals(method);
	}
}
