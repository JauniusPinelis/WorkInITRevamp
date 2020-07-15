using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
	public class DataContext : DbContext
	{
		public DbSet<JobUrl> JobUrls { get; set; }
	}
}
