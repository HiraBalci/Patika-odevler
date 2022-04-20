using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDBContext _dbcontext;
        public int bookId{get;set;}
        public DeleteBookCommand(BookStoreDBContext dbContext)
        {
            _dbcontext=dbContext;
        }
        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x=>x.Id==bookId);
            if(book is null){
                throw new InvalidOperationException("Silinecek Kitap Bulunamadı");
            }
            _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
        }
    }
}