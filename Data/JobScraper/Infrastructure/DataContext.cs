using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
	public class DataContext : DbContext
	{
		public DataContext()
		{
			// Required for migrations
		}

		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<JobUrl> JobUrls { get; set; }

		public DbSet<Tag> Tags { get; set; }

		public DbSet<jobUrlTag> JobUrlTags { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				// Dublicate will need to resolve it later
				optionsBuilder.UseSqlServer("Server=LAPTOP-9RMR1NCR\\SQLEXPRESS; Database=JobData; Trusted_Connection=True; MultipleActiveResultSets=true");
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
				modelBuilder.Entity<jobUrlTag>()
			.HasOne(bc => bc.JobUrl)
			.WithMany(b => b.Tags)
			.HasForeignKey(bc => bc.TagId);

			modelBuilder.Entity<jobUrlTag>()
				.HasOne(bc => bc.Tag)
				.WithMany(c => c.JobUrls)
				.HasForeignKey(bc => bc.JobUrlId);
		}
	}
}
