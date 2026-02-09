namespace MathTestSystem.Infrasturcture
{
    using MathTestSystem.Domain.Entites;
    using MathTestSystem.Domain.Enums;

    public static class SeedData
    {
        public static List<User> GetUsers() => new List<User>
    {
        new User { Id= 123, Username="williamTeacher", Password="123", Role=UserRole.Teacher, ProfileId= 1 },
        new User { Id= 456, Username="anaStudent", Password="123", Role=UserRole.Student, ProfileId= 1 },
        new User { Id= 789, Username="johnStudent", Password="123", Role=UserRole.Student, ProfileId= 2 }
    };

        public static List<Student> GetStudents() => new List<Student>
    {
        new Student { Id=1, Name="Ana", LastName = "Swift", TeacherId = 1 },
        new Student { Id=2, Name="John", LastName = "Jolie", TeacherId = 1 }
    };

        public static List<Teacher> GetTeachers() => new List<Teacher>
    {
        new Teacher { Id=1, Name="William", LastName = "Gomez"}
    };
    }

}
