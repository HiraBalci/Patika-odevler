using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetByIdBook
{
    public class GetByIdBookQuery
    {
        private readonly BookStoreDBContext _dbContext;
        public int bookId{get;set;}
        public GetByIdBookViewModel Model{get;set;}
        private readonly IMapper _mapper;

        public GetByIdBookQuery(BookStoreDBContext dbContext,IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper = mapper;
        }

        public GetByIdBookViewModel Handle()
        {
            var book= _dbContext.Books.Where(book=>book.Id==bookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");
            // GetByIdBookViewModel viewModel = new GetByIdBookViewModel();
            // viewModel.Title=book.Title;
            // viewModel.Genre=((GenreEnum)book.GenreId).ToString();
            // viewModel.PageCont=book.PageCount;
            // viewModel.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
            GetByIdBookViewModel viewModel = _mapper.Map<GetByIdBookViewModel>(book);
            return viewModel;  
        }
    }

    public class GetByIdBookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate{get;set;}
        public string Genre{get;set;}
    }
}