namespace MathTestSystem.Infrasturcture.Data
{
    using MathTestSystem.Domain.Entites;
    using MathTestSystem.Domain.Enums;
    using Microsoft.EntityFrameworkCore;

    public class AppDBContext : DbContext
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

        public DbSet<User> Users { get; set; }
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

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "williamTeacher", Password = "123", Role = UserRole.Teacher, ProfileId = 1 },
                new User { Id = 2, Username = "anaStudent", Password = "123", Role = UserRole.Student, ProfileId = 1 },
                new User { Id = 3, Username = "johnStudent", Password = "123", Role = UserRole.Student, ProfileId = 2 }
            );
        }
    }
}