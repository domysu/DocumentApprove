using DokumentuTvirtinimoSistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DokumentuTvirtinimoSistema
{
    public partial class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DocumentReview> DocumentReviews { get; set; }
        public DbSet<ValidationLog> ValidationLogs { get; set; }
        public DbSet<DocumentCorrection> DocumentCorrections { get; set; }
        public DbSet<WorkflowStatus> WorkflowStatus { get; set; }
        public DbSet<DocumentRequest> DocumentRequests { get; set; }
        public DbSet<DocumentData> DocumentData { get; set; }
        public DbSet<AuditLogs> AuditLogs { get; set; }
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

            modelBuilder.Entity<DocumentData>()
                .HasOne(dd => dd.DocumentRequest)
                .WithMany(dr => dr.DocumentData)
                .HasForeignKey(dd => dd.RequestId);

            modelBuilder.Entity<DocumentCorrection>()
                .HasKey(dc => dc.DataId);

            modelBuilder.Entity<DocumentRequest>()
                .HasKey(dr => dr.RequestId);

            modelBuilder.Entity<DocumentRequest>()
                .HasMany(dr => dr.DocumentData)
                .WithOne(dd => dd.DocumentRequest)
                .HasForeignKey(dd => dd.RequestId);

            modelBuilder.Entity<DocumentReview>()
                .HasOne<DocumentRequest>()
                .WithMany()
                .HasForeignKey(dr => dr.DocumentId);
        }
    }
}
