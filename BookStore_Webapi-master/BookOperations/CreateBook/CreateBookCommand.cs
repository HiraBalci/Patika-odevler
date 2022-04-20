using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Webapi.Common;
using Webapi.DbOperations;

namespace Webapi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public BookCreateModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(b => b.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut");

            Book newBook = _mapper.Map<Book>(Model);
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }
    }

    public class BookCreateModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}