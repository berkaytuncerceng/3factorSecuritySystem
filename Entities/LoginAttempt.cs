using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class LoginAttempt : IEntity
	{
		[Key]
		public int AttemptId { get; set; }
		public int? UserId { get; set; }
		public int? Step { get; set; }
		public bool? IsSuccessful { get; set; }
		public DateTime? AttemptTime { get; set; }
	}
}
