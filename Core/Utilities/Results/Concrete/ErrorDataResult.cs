namespace Core.Utilities.Results.Concrete
{
	public class ErrorDataResult<T> : DataResult<T>
	{
		public ErrorDataResult(T data, bool succeeded, string message) : base(data, false, message)
		{

		}
		public ErrorDataResult(T data, bool succeeded) : base(data, false)
		{

		}
		// Yeni yapıcı: sadece hata mesajı ile
		public ErrorDataResult(string message) : base(default(T), false, message)
		{

		}
	}
}
