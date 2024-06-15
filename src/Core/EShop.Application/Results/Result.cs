using EShop.Domain.Enums;

namespace EShop.Application.Results;

public abstract class Result<T>
{
	public abstract ResultType Type { get; }
	public abstract T Data { get; }
	public abstract string Error { get; }
}
