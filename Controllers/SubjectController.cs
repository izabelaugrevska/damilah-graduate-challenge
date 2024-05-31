using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ssis.Data;
using ssis.Dtos.Subject;
using ssis.Mappers;

namespace ssis.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public SubjectController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAll() 
        {
            var subjects = await _context.Subjects.ToListAsync();
            
            var subjectDto = subjects.Select(s => s.ToSubjectDto());
            
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if(subject == null)
            {
                return NotFound();
            }

            return Ok(subject.ToSubjectDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubjectRequestDto subjectDto)
        {
            var subjectModel = subjectDto.ToSubjectFromCreateDTO();
            await _context.Subjects.AddAsync(subjectModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = subjectModel.Id }, subjectModel.ToSubjectDto());
        }
    }
}