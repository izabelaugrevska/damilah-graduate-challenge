using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Author;
using ssis.Interfaces;
using ssis.Mappers;

namespace ssis.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;

        public AuthorService(IBookRepository bookRepo, IAuthorRepository authorRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
        }
        public async Task<AuthorDto> CreateAuthorAsync( CreateAuthorDto authorDto)
        {
            var authorModel = authorDto.ToAuthorFromCreate();
            await _authorRepo.CreateAsync(authorModel);

            return authorModel.ToAuthorDto();
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepo.GetAllAsync();
            return authors.Select(a => a.ToAuthorDto());
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
             var author = await _authorRepo.GetByIdAsync(id);
            return author?.ToAuthorDto();
        }
    }
}