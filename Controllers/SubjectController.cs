using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ssis.Data;
using ssis.Dtos.Subject;
using ssis.Interfaces;
using ssis.Mappers;

namespace ssis.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController( ISubjectService subjectService )
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAll() 
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);

            if(subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubjectRequestDto subjectDto)
        {
             var createdSubject = await _subjectService.CreateSubjectAsync(subjectDto);

            return CreatedAtAction(nameof(GetById), new { id = createdSubject.Id }, createdSubject);
        }
    }
}