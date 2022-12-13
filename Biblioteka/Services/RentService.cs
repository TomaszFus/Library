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
    public sealed class RentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IBookRepository _bookRepository;
        public RentService(IRentRepository rentRepository, IReaderRepository readerRepository, IBookRepository bookRepository)
        {
            _rentRepository = rentRepository;
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
        }
        /// <summary>
        /// Wypożycza książkę, jeśli jest dostępna
        /// </summary>
        /// <param name="pesel"></param>
        /// <param name="bookTitle"></param>
        /// <param name="bookAuthor"></param>
        /// <param name="rentDate"></param>
        /// <returns></returns>
        /// <exception cref="ReaderNotFoundException"></exception>
        /// <exception cref="BookNotFoundException"></exception>
        /// <exception cref="BookNotAvailableException"></exception>
        /// <exception cref="InvalidDateException"></exception>
        public Rent AddRent(string pesel, string bookTitle, string bookAuthor, DateTime rentDate)
        {
            var reader = _readerRepository.GetReaderByPesel(pesel);
            if (reader is null)
            {
                throw new ReaderNotFoundException();
            }
            var book = _bookRepository.GetBookByTitleAndAuthor(bookTitle, bookAuthor);
            if (book is null)
            {
                throw new BookNotFoundException();
            }
            if (book.Availability == 0)
            {
                throw new BookNotAvailableException();
            }
            if (rentDate.Date > DateTime.Today)
            {
                throw new InvalidDateException(rentDate);
            }
            book.DecreaseAvailability();
            _bookRepository.Update(book);

            Rent rent = new Rent(Guid.NewGuid(), reader, book, rentDate);
            _rentRepository.AddRent(rent);
            return rent;
        }
        /// <summary>
        /// Kończy wypożyczenie, zwraca wypożyczoną książkę
        /// </summary>
        /// <param name="pesel"></param>
        /// <param name="bookTitle"></param>
        /// <param name="bookAuthor"></param>
        /// <exception cref="RentNotFoundException"></exception>
        /// <exception cref="BookNotFoundException"></exception>
        public void EndRent(string pesel, string bookTitle, string bookAuthor)
        {
            var rent = _rentRepository.GetRentByPeselAndBook(pesel, bookTitle, bookAuthor);
            if (rent is null)
            {
                throw new RentNotFoundException();
            }
            var book = _bookRepository.GetBookByTitleAndAuthor(bookTitle, bookAuthor);
            if (book is null)
            {
                throw new BookNotFoundException();
            }
            book.IncreaseAvailability();
            rent.EndRent();

            _bookRepository.Update(book);
            _rentRepository.UpdateRent(rent);
        }
    }
}
