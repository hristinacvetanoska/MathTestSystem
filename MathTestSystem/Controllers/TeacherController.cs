using MathTestSystem.Application.Interfaces;
using MathTestSystem.DTOs;
using MathTestSystem.Infrasturcture.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MathTestSystem.Controllers
{
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
            var dtoResults = result.Values.Select(er => new ExamResultDto
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
    }
}
