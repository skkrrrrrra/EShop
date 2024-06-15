using EShop.Domain.Enums;

namespace EShop.Application.Results
{
	public class InvalidResult<T> : Result<T>
	{
		public InvalidResult(string error)
		{
			Error = error;
		}

		public override ResultType Type => ResultType.Invalid;

		public override T Data { get; }

		public override string Error { get; }
	}
}
