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

            private readonly ILogger<BookController> _logger;


        public BookController( IBookService bookService, ISubjectService subjectService, ILogger<BookController> logger )
        {
            _bookService = bookService;
            _subjectService = subjectService;
            _logger = logger;

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

        // [HttpPost("{subjectId}")]
        // public async Task<IActionResult> Create([FromRoute] int subjectId, CreateBookDto bookDto)
        // {
        //     try
        //     {
        //         var createdBook = await _bookService.CreateBookAsync(subjectId, bookDto);
        //         return CreatedAtAction(nameof(GetById), new { id = createdBook.BookId }, createdBook);
        //     }
        //     catch (ArgumentException ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }

        // }

        [HttpPost]
        public async Task<IActionResult> CreateBookWithInfo([FromBody] CreateBookDto request)
        {
            var book = await _bookService.CreateBookWithInfoAsync(request.BookName, request.SubjectId);
            return Ok(book);
        }

        [HttpGet("info/{title}")]
        public async Task<IActionResult> GetBookInfo([FromRoute] string title)
        {
            // var bookInfo = await _bookService.GetBookInfoAsync(title);
            // return Ok(bookInfo);
            Console.WriteLine($"title from console: {title}");
            _logger.LogInformation($"Received request to get book info for title: {title}");

            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("Title is required");
            }

            var bookInfo = await _bookService.GetBookInfoAsync(title);

            if (bookInfo == null)
            {
                return NotFound("Book not found");
            }

            return Ok(bookInfo);
        }
    }
}