namespace Core.Utilities.Results.Concrete
{
	public class SucceededResult : Result
	{
		public SucceededResult(string message) : base(true, message)
		{

		}
		public SucceededResult() : base(true)
		{

		}
	}
}
