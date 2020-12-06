using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
	public interface IRepository<T> : IReadRepository<T> where T : JobUrl
	{
		void Insert(T entity);
		void InsertRange(IEnumerable<T> entities);
		void UpdateHtml(int id, string html);
		void UpdateSalary(int id, int? min, int? max);
		void UpdateTags(int id, IEnumerable<Tag> tags);

		void UpdateCompany(int id, int companyId);
	}
}