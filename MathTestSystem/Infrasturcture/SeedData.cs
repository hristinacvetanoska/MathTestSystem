namespace MathTestSystem.Infrasturcture
{
    using MathTestSystem.Domain.Entites;
    using MathTestSystem.Domain.Enums;

    public static class SeedData
    {
        public static List<User> GetUsers() => new List<User>
    {
        new User { Id= new Guid(), Username="williamTeacher", Password="123", Role=UserRole.Teacher, ReferenceId= 1 },
        new User { Id= new Guid(), Username="anaStudent", Password="123", Role=UserRole.Student, ReferenceId= 1 },
        new User { Id=new Guid(), Username="johnStudent", Password="123", Role=UserRole.Student, ReferenceId= 2 }
    };

        public static List<Student> GetStudents() => new List<Student>
    {
        new Student { Id=1, Name="Ana" },
        new Student { Id=2, Name="John" }
    };

        public static List<Teacher> GetTeachers() => new List<Teacher>
    {
        new Teacher { Id=1, Name="William" }
    };
    }
}
