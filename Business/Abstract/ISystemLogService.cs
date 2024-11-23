using Core.Utilities.Results.Abstract;
using Entities;
using System.Linq.Expressions;

namespace Business.Abstract
{
	public interface ISystemLogService
	{
		IResult Add(SystemLog systemLog);
		IDataResult<List<SystemLog>> GetAll(Expression<Func<SystemLog, bool>> filter = null);
		IDataResult<SystemLog> GetById(int id);
	}
}
