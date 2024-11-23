using Core.Utilities.Results.Abstract;
using Entities;
using System.Linq.Expressions;

namespace Business.Abstract
{
	public interface IUserService
	{
		IResult Add(User user);
		IResult Update(User user);
		IResult Delete(User user);
		IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
		IDataResult<User> GetById(int id);

		// Placeholder methods for face recognition and fingerprint scanning
		IResult VerifyFaceRecognition(string faceData);
		IResult VerifyFingerprint(string fingerprintData);

	}
}
