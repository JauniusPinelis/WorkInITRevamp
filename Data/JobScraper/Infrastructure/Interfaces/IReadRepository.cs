using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
	public interface IReadRepository<T> where T : Entity
	{
		T FindById(int id);
		IEnumerable<T> GetAll();
	}
}