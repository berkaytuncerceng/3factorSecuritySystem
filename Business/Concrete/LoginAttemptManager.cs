using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;
using System.Linq.Expressions;

namespace Business.Concrete
{
	public class LoginAttemptManager : ILoginAttemptService
	{
		private readonly ILoginAttemptDal _loginAttemptDal;

		public LoginAttemptManager(ILoginAttemptDal loginAttemptDal)
		{
			_loginAttemptDal = loginAttemptDal;
		}

		public IResult Add(LoginAttempt loginAttempt)
		{
			_loginAttemptDal.Add(loginAttempt);
			return new SucceededResult("Login attempt added successfully.");
		}

		public IDataResult<List<LoginAttempt>> GetAll(Expression<Func<LoginAttempt, bool>> filter = null)
		{
			var result = _loginAttemptDal.GetAll(filter);
			return new SucceededDataResult<List<LoginAttempt>>(result);
		}

		public IDataResult<LoginAttempt> GetById(int id)
		{
			var result = _loginAttemptDal.Get(x => x.AttemptId == id);
			return new SucceededDataResult<LoginAttempt>(result);
		}
	}
}
