using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<JobUrl> JobUrls { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<jobUrlTag> JobUrlTags { get; set; }

        public DbSet<Company> Companies { get; set; }
    }
}
