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

		public DbSet<Company> Companies { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				// Dublicate will need to resolve it later
				optionsBuilder.UseSqlServer("Server=LAPTOP-9RMR1NCR\\SQLEXPRESS; Database=JobDb; Trusted_Connection=True; MultipleActiveResultSets=true");
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

			modelBuilder.Entity<Company>()
				.HasMany(c => c.Jobs)
				.WithOne(j => j.Company)
				.HasForeignKey(j => j.CompanyId);
				

			SeedData(modelBuilder);
		}

		private void SeedData(ModelBuilder builder)
		{
			builder.Entity<Tag>().HasData(
				new Tag { Id = 1, Name = ".NET" },
				new Tag { Id = 2, Name = "c#" },
				new Tag { Id = 3, Name = "React" },
				new Tag { Id = 4, Name = "Angular" },
				new Tag { Id = 5, Name = "Vue" },
				new Tag { Id = 6, Name = "Typescript" },
				new Tag { Id = 7, Name = "Php" },
				new Tag { Id = 8, Name = "Java" }
				);
		}
	}
}
