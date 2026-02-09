using MathTestSystem.Application.Interfaces;
using MathTestSystem.DTOs;
using MathTestSystem.Infrasturcture.Services;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("UploadXMLDocument")]
        public async Task<IActionResult> UploadExam([FromBody] XMLContent xmlContent)
        {
            var result = await this.examService.ReadXMLContent(xmlContent.XMLContentValue);
            return Ok(result);
        }
    }
}
