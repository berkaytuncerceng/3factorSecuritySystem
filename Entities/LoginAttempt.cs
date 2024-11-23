using Core.Entities;

namespace Entities
{
	public class LoginAttempt : IEntity
	{
		public int AttemptId { get; set; }
		public int? UserId { get; set; }
		public int? Step { get; set; }
		public bool? IsSuccessful { get; set; }
		public DateTime? AttemptTime { get; set; }
	}
}
