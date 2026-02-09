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
    }
}
