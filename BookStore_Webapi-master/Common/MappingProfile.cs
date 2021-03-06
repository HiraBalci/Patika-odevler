using AutoMapper;
using Webapi.BookOperations.CreateBook;
using Webapi.BookOperations.GetBookById;
using Webapi.BookOperations.GetBooks;

namespace Webapi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookCreateModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}