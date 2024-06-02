using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ssis.Dtos.Author;
using ssis.Interfaces;

namespace ssis.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public AuthorController( IBookService bookService, IAuthorService authorService )
        {
            _bookService = bookService;
            _authorService = authorService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if(author == null)
            {
                return NotFound();
            }
            
            return Ok(author);

        }

        [HttpPost]
        public async Task<IActionResult> Create( CreateAuthorDto authorDto)
        {
            try
            {
                var createdAuthor = await _authorService.CreateAuthorAsync( authorDto);
                return CreatedAtAction(nameof(GetById), new { id = createdAuthor.Id }, createdAuthor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}