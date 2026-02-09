using MathTestSystem.Application.Interfaces;
using MathTestSystem.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MathTestSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IExamService examService;
        public StudentController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpGet("exam-results/{studentId}")]
        public async Task<ActionResult<List<ExamResultDTO>>> GetExamResultsByStudentId(int studentId)
        {
            var result = await this.examService.GetExamResultByStudent(studentId);
            if (result == null || !result.Any()) 
            {
                return NotFound("There is no exam results for this student.");
            }
            return Ok(result);
        }
    }
}
