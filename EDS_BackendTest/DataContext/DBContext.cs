using EDS_BackendTest.Model;
using Microsoft.EntityFrameworkCore;

namespace EDS_BackendTest.DataContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Columns> Columns { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<DataRecepient> DataRecepients { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobLog> JobLogs { get; set; }
        public DbSet<Lookups> Lookup { get; set; }
        public DbSet<NotificationRecepient> notificationRecepients { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationLevel> OrganizationLevels { get; set; }
        public DbSet<Sublevel> Sublevels { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateColumns> TemplateColumns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Lookup)
                .WithMany()
                .HasForeignKey(j => j.LookupID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Template)
                .WithMany()
                .HasForeignKey(j => j.TemplateID)
                .OnDelete(DeleteBehavior.NoAction); // Specify the appropriate option


            // Other configurations and relationships here...
            modelBuilder.Entity<Template>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Templates)
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<TemplateColumns>()
                .HasKey(tc => new { tc.TemplateID, tc.ColumnId });

            modelBuilder.Entity<TemplateColumns>()
                .HasOne(tc => tc.Template)
                .WithMany(t => t.TemplateColumns)
                .HasForeignKey(tc => tc.TemplateID);

            modelBuilder.Entity<TemplateColumns>()
                .HasOne(tc => tc.Column)
                .WithMany(c => c.TemplateColumns)
                .HasForeignKey(tc => tc.ColumnId);

            // Define relationships for OrganizationLevel
            modelBuilder.Entity<OrganizationLevel>()
                .HasOne(ol => ol.Organization)
                .WithMany(o => o.Levels)
                .HasForeignKey(ol => ol.OrganizationId);

            modelBuilder.Entity<OrganizationLevel>()
                .HasMany(ol => ol.Sublevels)
                .WithOne(sl => sl.OrganizationLevel)
                .HasForeignKey(sl => sl.OrganizationLevelId);

            // Define relationships for Sublevel
            modelBuilder.Entity<Sublevel>()
                .HasOne(sl => sl.OrganizationLevel)
                .WithMany(ol => ol.Sublevels)
                .HasForeignKey(sl => sl.OrganizationLevelId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
