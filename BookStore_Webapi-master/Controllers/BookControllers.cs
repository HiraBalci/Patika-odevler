using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webapi.BookOperations.CreateBook;
using Webapi.BookOperations.DeleteBook;
using Webapi.BookOperations.GetBookById;
using Webapi.BookOperations.GetBooks;
using Webapi.BookOperations.UpdateBook;
using Webapi.DbOperations;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookCreateModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            BookViewModel result;
            try
            {
                GetBookByIdQuery query = new GetBookByIdQuery(_context, _mapper);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute] int id, [FromBody] UpdateBookModel bookModel)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Model = bookModel;
                command.Handle();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Handle();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
            return NoContent();
        }
    }
}