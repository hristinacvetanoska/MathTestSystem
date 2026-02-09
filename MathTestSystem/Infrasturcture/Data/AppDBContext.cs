namespace MathTestSystem.Infrasturcture.Data
{
    using MathTestSystem.Domain.Entites;
    using MathTestSystem.Domain.Entities;
    using MathTestSystem.Domain.Enums;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=MathTestSystem.db");
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<ExamTaskResult> ExamTaskResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExamTaskResult>()
                .HasOne(t => t.ExamResult)         
                .WithMany(r => r.ExamTasks)        
                .HasForeignKey(t => t.ExamResultId) 
                .OnDelete(DeleteBehavior.Cascade);  
                                                    
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "William", LastName = "Smith" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Ana", LastName = "Swift", TeacherId = 1 },
                new Student { Id = 2, Name = "John", LastName = "Jolie", TeacherId = 1 }
            );
        }
    }
}