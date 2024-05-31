using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll() 
        {
            var subjects = _context.Subjects.ToList().Select(s => s.ToSubjectDto());
            
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var subject = _context.Subjects.Find(id);

            if(subject == null)
            {
                return NotFound();
            }

            return Ok(subject.ToSubjectDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSubjectRequestDto subjectDto)
        {
            var subjectModel = subjectDto.ToSubjectFromCreateDTO();
            _context.Subjects.Add(subjectModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = subjectModel.Id }, subjectModel.ToSubjectDto());
        }
    }
}