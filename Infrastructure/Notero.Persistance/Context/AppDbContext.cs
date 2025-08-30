using Microsoft.EntityFrameworkCore;
using Notero.Domain.Entities;

namespace Notero.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Social> Socials { get; set; }
    }
}

