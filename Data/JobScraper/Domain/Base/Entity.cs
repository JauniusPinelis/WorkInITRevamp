using System.ComponentModel.DataAnnotations;

namespace Domain.Base
{
	public class Entity
	{
		[Key]
		public int Id { get; set; }
	}
}
