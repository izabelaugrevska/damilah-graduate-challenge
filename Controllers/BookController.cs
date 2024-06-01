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
        private readonly IBookService _bookService;
        private readonly ISubjectService _subjectService;

        public BookController( IBookService bookService, ISubjectService subjectService )
        {
            _bookService = bookService;
            _subjectService = subjectService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            
            return Ok(book);

        }

        [HttpPost("{subjectId}")]
        public async Task<IActionResult> Create([FromRoute] int subjectId, CreateBookDto bookDto)
        {
            try
            {
                var createdBook = await _bookService.CreateBookAsync(subjectId, bookDto);
                return CreatedAtAction(nameof(GetById), new { id = createdBook.BookId }, createdBook);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}