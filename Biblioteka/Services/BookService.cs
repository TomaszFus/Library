using Biblioteka.Entities;
using Biblioteka.Exception;
using Biblioteka.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Services
{
    public sealed class BookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository= bookRepository;
        }

        public Book AddBook(string title, string author, int quantity = 1)
        {
            if (quantity<=0)
            {
                throw new InvalidQuantity();
            }
            var book = _bookRepository.GetBookByTitleAndAuthor(title, author);
            if (book is null)
            {
                book = new Book(Guid.NewGuid(), author, title, quantity);
                _bookRepository.AddBook(book);
            }
            else
            {
                quantity = book.AddAvailability(quantity);
                book.Update(author, title, quantity);
                _bookRepository.Update(book);
            }
            
            return book;
        }

        public Book Update(Guid id, string title, string author, int quantity)
        {
            if (quantity < 0)
            {
                throw new InvalidQuantity();
            }
            var book = _bookRepository.GetBookById(id);
            if (book is null)
            {
                throw new BookNotFound();
            }
            book.Update(author, title, quantity);
            _bookRepository.Update(book);
            return book;
        }
    }
}
