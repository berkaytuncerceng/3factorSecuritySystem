namespace Core.Utilities.Results.Concrete
{
	public class SucceededDataResult<T> : DataResult<T>
	{
		public SucceededDataResult(T data, string message) : base(data, true, message)
		{

		}
		public SucceededDataResult(T data) : base(data, true)
		{

		}

	}
}
