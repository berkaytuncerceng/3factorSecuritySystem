using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
	public class DataResult<T> : Result, IDataResult<T>
	{
		public DataResult(T data, bool succeeded, string message) : base(succeeded, message)
		{
			Data = data;
		}
		public DataResult(T data, bool succeeded) : base(succeeded)
		{
			Data = data;
		}

		public T Data { get; }



	}
}
