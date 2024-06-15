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

		public override string Error => string.Empty;

		public override T Data { get; }
	}
}
