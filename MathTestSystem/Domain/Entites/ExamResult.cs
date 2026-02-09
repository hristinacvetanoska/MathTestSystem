using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MathTestSystem.Domain.Entites
{
    public class ExamResult
    {
        [Key]
        public int Id { get; set; }
        public int TotalTasks { get; set; }
        public int CorrectTasks { get; set; }
        public int IncorrectTasks { get; set; }
        public double Score { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int ExamId { get; set; }
        public List<ExamTaskResult> ExamTasks { get; set; } = new List<ExamTaskResult>();

    }
}
