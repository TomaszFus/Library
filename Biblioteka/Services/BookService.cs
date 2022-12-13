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
        private readonly IRentRepository _rentRepository;
        public BookService(IBookRepository bookRepository, IRentRepository rentRepository)
        {
            _bookRepository = bookRepository;
            _rentRepository = rentRepository;
        }
        /// <summary>
        /// Dodaje nową książkę do biblioteki. Jeśli książka o podanym tytule i autorze istnieje, zwiększa jej dostępną ilość
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="InvalidQuantityException"></exception>
        public Book AddBook(string title, string author, int quantity = 1)
        {
            if (quantity<=0)
            {
                throw new InvalidQuantityException();
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
        /// <summary>
        /// Modyfikuje informacje o książce
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="InvalidQuantityException"></exception>
        /// <exception cref="BookNotFoundException"></exception>
        public Book Update(Guid id, string title, string author, int quantity)
        {
            if (quantity < 0)
            {
                throw new InvalidQuantityException();
            }
            var book = _bookRepository.GetBookById(id);
            if (book is null)
            {
                throw new BookNotFoundException();
            }
            book.Update(author, title, quantity);
            _bookRepository.Update(book);
            return book;
        }
        /// <summary>
        /// Usuwa wybraną książkę, jeśli żaden z egzemplarzy nie jest wypożyczony
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <exception cref="BookNotFoundException"></exception>
        /// <exception cref="BookIsRentedException"></exception>
        public void DeleteBook(string title, string author)
        {
            var book = _bookRepository.GetBookByTitleAndAuthor(title, author);
            if (book is null)
            {
                throw new BookNotFoundException();
            }

            var rents = _rentRepository.GetRentsByBook(title, author);

            var bookIsRented = rents.Any(x => x.Ended == false);

            if (bookIsRented)
            {
                throw new BookIsRentedException();
            }

            _bookRepository.DeleteBook(book);


        }


    }
}
