using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfLoginAttemptDal : EfEntityRepositoryBase<LoginAttempt, BitirmeDbContext>, ILoginAttemptDal
	{
	}
}
