using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<JobUrl> JobUrls { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
