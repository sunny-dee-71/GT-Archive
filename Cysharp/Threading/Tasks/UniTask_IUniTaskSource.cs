namespace Cysharp.Threading.Tasks;

public interface IUniTaskSource<out T> : IUniTaskSource
{
	new T GetResult(short token);
}
