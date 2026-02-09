namespace MathTestSystem.Controllers
{
    using MathTestSystem.Application.Interfaces;
    using MathTestSystem.DTOs;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IExamService examService;

        public TeacherController(IExamService examService) 
        {
            this.examService = examService;
        }

        [HttpPost("upload-xml-document")]
        public async Task<IActionResult> UploadExam([FromBody] XMLContentDTO xmlContent)
        {
            var result = await this.examService.ReadXMLContent(xmlContent.XMLContent);
            var dtoResults = result.Values.Select(er => new ExamResultDTO
            {
                StudentId = er.StudentId,
                TeacherId = er.TeacherId,
                Score = er.Score,
                ExamTasks = er.ExamTasks.Select(t => new ExamTaskResultDto
                {
                    TaskId = t.TaskId,
                    IsCorrect = t.IsCorrect
                }).ToList()
            }).ToList();

            return Ok(dtoResults);
        }

        [HttpGet("students")]
        public async Task<List<StudentWithResultsDTO>> GetStudents()
        {
            return await this.examService.GetExamResultsForAllStudents();
        }

    }
}
