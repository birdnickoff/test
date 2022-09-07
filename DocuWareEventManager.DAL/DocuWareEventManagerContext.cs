using DocuWareEventManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocuWareEventManager.DAL
{
    public class DocuWareEventManagerContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventRegistration> EventRegistrations { get; set; }

        public DocuWareEventManagerContext(DbContextOptions<DocuWareEventManagerContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
