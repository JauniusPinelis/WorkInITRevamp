using Domain.Models;
using Domain.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Interfaces
{
	public interface IReadRepository<T> where T : Entity
	{
		JobUrl FindById(int id);
		IEnumerable<T> GetAll();
		IQueryable<Tag> GetAllTags();
	}
}