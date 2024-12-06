namespace Business.Abstract
{
	public interface IFaceRecognitionService
	{
			Task<bool> RegisterFaceAsync(string username, Stream imageStream);
			Task<bool> ValidateFaceAsync(string username, Stream imageStream);
	}
}
