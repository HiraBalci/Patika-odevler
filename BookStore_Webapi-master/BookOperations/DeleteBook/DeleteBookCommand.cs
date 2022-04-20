using System.Linq;
using Webapi.DbOperations;
using System;

namespace Webapi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int BookId { get; set; }
        private BookStoreDbContext _context;

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}