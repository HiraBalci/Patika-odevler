using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {

        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper = mapper;
        }

        public List<BookViewModel> Handle()
        {
            var bookList= _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            // List<BookViewModel> vmBooks =new List<BookViewModel>();
            // foreach (var book in bookList)
            // {
            //     vmBooks.Add(new BookViewModel(){
            //         Title=book.Title,
            //         PageCont=book.PageCount,
            //         Genre=((GenreEnum)book.GenreId).ToString(),
            //         PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy")
            //     });
            // }
            List<BookViewModel> vmBooks=_mapper.Map<List<BookViewModel>>(bookList);
            return vmBooks;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate{get;set;}
        public string Genre{get;set;}
    }
}