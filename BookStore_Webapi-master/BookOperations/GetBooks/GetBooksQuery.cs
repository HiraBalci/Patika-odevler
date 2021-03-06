using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Webapi.Common;
using Webapi.DbOperations;

namespace Webapi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var books = _context.Books.ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(books);
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}