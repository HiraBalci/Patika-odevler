using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetByIdBook;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.AddControllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // private static List<Book> BookList = new List<Book>(){
        //     new Book(){
        //         Id=1,
        //         Title="Lean Startup",
        //         GenreId=1,//Personal Growth
        //         PageCount=200,
        //         PublishDate=new DateTime(2001,06,12)
        //     },
        //     new Book(){
        //         Id=2,
        //         Title="Herland",
        //         GenreId=2,//Science Finction
        //         PageCount=250,
        //         PublishDate=new DateTime(2010,05,23)
        //     },
        //     new Book(){
        //         Id=3,
        //         Title="Dune",
        //         GenreId=2,//Science Finction
        //         PageCount=540,
        //         PublishDate=new DateTime(2001,12,21)
        //     }
        // };


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        // [HttpGet("{id}")]
        // public IActionResult GetById(int id)
        // {
        //     GetByIdBookQuery query= new GetByIdBookQuery(_context,_mapper);
        //     GetByIdBookQueryValidator validator = new GetByIdBookQueryValidator();  
        //     GetByIdBookViewModel result;
        //     try
        //     {
        //         query.bookId=id;
        //         validator.ValidateAndThrow(query);
        //         result = query.Handle();
        //     }
        //     catch (Exception ex)
        //     {

        //         return BadRequest(ex.Message);
        //     }
        //     return Ok(result);
        // }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdBookQuery query = new GetByIdBookQuery(_context, _mapper);
            GetByIdBookQueryValidator validator = new GetByIdBookQueryValidator();
            GetByIdBookViewModel result;

            query.bookId = id;
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }


        // [HttpGet]
        // public Book? Get([FromQuery] string id){
        //     var book = BookList.Where(book=>book.Id==Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        // [HttpPost]
        // public IActionResult AddBook([FromBody] CreateBookModel newBook)
        // {
        //     CreateBookCommand command = new CreateBookCommand(_context,_mapper);
        //     try
        //     {
        //         command.Model = newBook;
        //         CreateBookCommandValidator validator = new CreateBookCommandValidator();
        //         // ValidationResult result =validator.Validate(command);
        //         // if(!result.IsValid){
        //         //     foreach (var item in result.Errors)
        //         //     {
        //         //         Console.WriteLine("Özellik: "+item.PropertyName+" - Hata Mesajı: "+item.ErrorMessage);
        //         //     }
        //         // }else{
        //         //     command.Handle();
        //         // }
        //         validator.ValidateAndThrow(command);
        //         command.Handle();

        //     }
        //     catch(Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        //     return Ok();
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();

            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        // [HttpPut("{id}")]
        // public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        // {
        //     UpdateBookCommand command = new UpdateBookCommand(_context);
        //     UpdateBookCommandValidator validator = new UpdateBookCommandValidator();

        //     try
        //     {
        //         command.BookId = id;
        //         command.Model = updatedBook;
        //         validator.ValidateAndThrow(command);
        //         command.Handle();
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        //     return Ok();
        // }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();

            command.BookId = id;
            command.Model = updatedBook;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        // [HttpDelete("{id}")]
        // public IActionResult DeleteBook(int id)
        // {
        //     DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
        //     DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        //     try
        //     {
        //         deleteBookCommand.bookId = id;
        //         validator.ValidateAndThrow(deleteBookCommand);
        //         deleteBookCommand.Handle();
        //     }
        //     catch (Exception ex)
        //     {

        //         return BadRequest(ex.Message);
        //     }

        //     return Ok();
        // }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();

            deleteBookCommand.bookId = id;
            validator.ValidateAndThrow(deleteBookCommand);
            deleteBookCommand.Handle();

            return Ok();
        }

    }
}