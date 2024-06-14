using EShop.Domain.Enums;

namespace EShop.Application.Results
{
	public class SuccessResult<T> : Result<T>
	{
		public SuccessResult(T data)
		{
			Data = data;
		}
		public override ResultType Type => ResultType.Success;

		public override List<string> Errors => new();

		public override T Data { get; }
	}
}
