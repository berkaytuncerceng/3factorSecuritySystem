using Core.Utilities.Results.Abstract;
using Entities;
using System.Linq.Expressions;

namespace Business.Abstract
{
	public interface ILoginAttemptService
	{
		IResult Add(LoginAttempt loginAttempt);
		IDataResult<List<LoginAttempt>> GetAll(Expression<Func<LoginAttempt, bool>> filter = null);
		IDataResult<LoginAttempt> GetById(int id);
	}
}
