using Core.Entities;

namespace Entities
{
	public class SystemLog : IEntity
	{
		public int LogId { get; set; }
		public int? UserId { get; set; }
		public string? LogMessage { get; set; }
		public DateTime? LogTime { get; set; }
	}
}
