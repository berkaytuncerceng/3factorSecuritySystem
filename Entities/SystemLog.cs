using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class SystemLog : IEntity
	{
		[Key] 
		public int LogId { get; set; }
		public int? UserId { get; set; }
		public string? LogMessage { get; set; }
		public DateTime? LogTime { get; set; }
	}
}
