using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ssis.Dtos.Book;
using ssis.Interfaces;
using ssis.Mappers;

namespace ssis.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;
        private readonly ISubjectRepository _subjectRepo;

        public BookController(IBookRepository bookRepo, ISubjectRepository subjectRepo)
        {
            _bookRepo = bookRepo;
            _subjectRepo = subjectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepo.GetAllAsync();

            var bookDto = books.Select(b => b.ToBookDto());

            return Ok(bookDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            
            return Ok(book.ToBookDto());

        }

        [HttpPost("{subjectId}")]
        public async Task<IActionResult> Create([FromRoute] int subjectId, CreateBookDto bookDto)
        {
            if(!await _subjectRepo.SubjectExists(subjectId))
            {
                return BadRequest("Subject does not exist");
            }
            var bookModel = bookDto.ToBookFromCreate(subjectId);
            await _bookRepo.CreateAsync(bookModel);

            return CreatedAtAction(nameof(GetById), new { id = bookModel}, bookModel.ToBookDto());

        }
    }
}