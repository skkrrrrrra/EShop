using EShop.Domain.Enums;

namespace EShop.Application.Results
{
	public class InvalidResult<T> : Result<T>
	{
		public InvalidResult(List<string> errors)
		{
			Errors = errors;
		}

		public override ResultType Type => ResultType.Invalid;

		public override T Data { get; }

		public override List<string> Errors { get; }
	}
}
