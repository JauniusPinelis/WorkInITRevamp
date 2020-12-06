using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Base
{
	public class Entity
	{
		[Key]
		public int Id { get; set; }
	}
}
