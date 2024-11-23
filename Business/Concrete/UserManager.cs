using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;
using System.Linq.Expressions;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		private readonly IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public IResult Add(User user)
		{
			try
			{
				_userDal.Add(user);
				return new SucceededResult("Kullanıcı başarıyla eklendi.");
			}
			catch (Exception ex)
			{
				return new ErrorResult("Kullanıcı eklenirken bir hata oluştu: " + ex.Message);
			}
		}

		public IResult Update(User user)
		{
			try
			{
				_userDal.Update(user);
				return new SucceededResult("Kullanıcı başarıyla güncellendi.");
			}
			catch (Exception ex)
			{
				return new ErrorResult("Kullanıcı güncellenirken bir hata oluştu: " + ex.Message);
			}
		}

		public IResult Delete(User user)
		{
			try
			{
				_userDal.Delete(user);
				return new SucceededResult("Kullanıcı başarıyla silindi.");
			}
			catch (Exception ex)
			{
				return new ErrorResult("Kullanıcı silinirken bir hata oluştu: " + ex.Message);
			}
		}

		public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
		{
			try
			{
				var users = _userDal.GetAll(filter);
				return new SucceededDataResult<List<User>>(users, "Kullanıcılar başarıyla listelendi.");
			}
			catch (Exception ex)
			{
				return new ErrorDataResult<List<User>>("Kullanıcılar listelenirken bir hata oluştu: " + ex.Message);
			}
		}

		public IDataResult<User> GetById(int id)
		{
			try
			{
				var user = _userDal.Get(u => u.UserId == id);
				return new SucceededDataResult<User>(user, "Kullanıcı başarıyla getirildi.");
			}
			catch (Exception ex)
			{
				return new ErrorDataResult<User>("Kullanıcı getirilirken bir hata oluştu: " + ex.Message);
			}
		}

		// Placeholder methods for face recognition and fingerprint scanning
		public IResult VerifyFaceRecognition(string faceData)
		{
			// Placeholder logic for face recognition
			return new SucceededResult("Yüz tanıma işlemi başarılı (bu kısım daha sonra geliştirilecek).");
		}

		public IResult VerifyFingerprint(string fingerprintData)
		{
			// Placeholder logic for fingerprint verification
			return new SucceededResult("Parmak izi doğrulama işlemi başarılı (bu kısım daha sonra geliştirilecek).");
		}
	}
}
