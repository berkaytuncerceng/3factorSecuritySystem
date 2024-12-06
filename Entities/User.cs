using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class User : IEntity
	{
		[Key] 
		public int UserId { get; set; }
		public string? Username { get; set; }
		public string? Pin { get; set; }
		//public byte[]? FaceData { get; set; }
		//public byte[]? FingerprintData { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public virtual Face? Face { get; set; }

	}
}
