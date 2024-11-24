using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities;
using System.Linq.Expressions;

namespace Business.Concrete
{
	public class SystemLogManager : ISystemLogService
	{
		public IResult Add(SystemLog systemLog)
		{
			throw new NotImplementedException();
		}

		public IDataResult<List<SystemLog>> GetAll(Expression<Func<SystemLog, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public IDataResult<SystemLog> GetById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
