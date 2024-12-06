using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class Face : IEntity
	{
		[Key]
		public int FaceId { get; set; } // Yüz kaydını tanımlayan benzersiz kimlik
		public int UserId { get; set; } // Yüz verisinin hangi kullanıcıya ait olduğu
		public byte[]? FaceData { get; set; } // Yüz verisi (resim verisi)
		public virtual User? User { get; set; }

	}
}
