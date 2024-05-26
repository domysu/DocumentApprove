using DokumentuTvirtinimoSistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DokumentuTvirtinimoSistema
{
    public partial class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        // Constructor for dependency injection
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Ensure to use fallback if not configured through dependency injection
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<UserRoles> Roles { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<DocumentReview> DocumentReviews { get; set; }
        public DbSet<ValidationLog> ValidationLogs { get; set; }
        //public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<DocumentCorrection> DocumentCorrections { get; set; }
        public DbSet<WorkflowStatus> WorkflowStatus { get; set; }
        public DbSet<DocumentRequest> DocumentRequests { get; set; }
        public DbSet<DocumentData> DocumentData { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentReview>()
                .HasKey(dr => dr.Id);

            modelBuilder.Entity<DocumentReview>()
                .HasMany(dr => dr.ValidationLogs)
                .WithOne(vl => vl.DocumentReview)
                .HasForeignKey(vl => vl.DocumentReviewId);

            modelBuilder.Entity<ValidationLog>()
                .HasKey(vl => vl.Id);

     
           
            modelBuilder.Entity<DocumentData>()
            .HasKey(dd => dd.DataId);
            modelBuilder.Entity<DocumentRequest>()
            .HasKey(dd => dd.RequestId);


            modelBuilder.Entity<User>()
               .HasMany(u => u.Roles)
               .WithOne()
               .HasForeignKey(u => u.Id);


            modelBuilder.Entity<DocumentData>()
         .HasKey(dd => dd.DataId);  // Define the primary key

            modelBuilder.Entity<DocumentData>()
                .HasOne(dd => dd.DocumentRequest)
                .WithMany(dr => dr.DocumentData)
                .HasForeignKey(dd => dd.RequestId);

            modelBuilder.Entity<DocumentReview>()
          .HasKey(dr => dr.Id);  // Define the primary key
        }
    }
}
