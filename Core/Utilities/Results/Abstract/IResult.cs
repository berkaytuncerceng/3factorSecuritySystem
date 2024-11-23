namespace Core.Utilities.Results.Abstract
{
	public interface IResult
	{
		bool Succeeded { get; }
		string Message { get; }
	}
}
