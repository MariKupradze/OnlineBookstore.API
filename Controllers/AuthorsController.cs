using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.API.Interfaces;
using OnlineBookstore.API.Models;
using System;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _authorRepository.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthorById(int authorId)
        {
            var author = _authorRepository.GetAuthorById(authorId);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _authorRepository.AddAuthor(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(GetAuthorById), new { authorId = author.AuthorID }, author);
        }

        [HttpPut("{authorId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateAuthor(int authorId, Author author)
        {
            if (authorId != author.AuthorID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _authorRepository.UpdateAuthor(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{authorId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAuthor(int authorId)
        {
            try
            {
                _authorRepository.DeleteAuthor(authorId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
