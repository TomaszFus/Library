using Biblioteka.Data;
using Biblioteka.Entities;
using Biblioteka.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repositories.Concrete
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext= libraryDbContext;
        }
        public void AddBook(Book book)
        {
            _libraryDbContext.Books.Add(book);
            _libraryDbContext.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _libraryDbContext.Books.Remove(book);
        }

        public Book GetBookById(Guid id)
        {
            return _libraryDbContext.Books.SingleOrDefault(x => x.Id == id);
        }

        public Book GetBookByTitleAndAuthor(string title, string author)
        {
            return _libraryDbContext.Books.SingleOrDefault(x => x.Title == title && x.Author == author);
        }

        public void Update(Book book)
        {
            _libraryDbContext.Books.Update(book);
            _libraryDbContext.SaveChanges();
        }
    }
}
