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

        public Rent AddRent(string pesel, string bookTitle, string bookAuthor, DateTime rentDate)
        {
            var reader = _readerRepository.GetReaderByPesel(pesel);
            if (reader is null)
            {
                throw new ReaderNotFound();
            }
            var book = _bookRepository.GetBookByTitleAndAuthor(bookTitle, bookAuthor);
            if (book is null)
            {
                throw new BookNotFound();
            }
            if (book.Availability == 0)
            {
                throw new BookNotAvailableException();
            }
            if (rentDate.Date > DateTime.Today)
            {
                throw new InvalidDate(rentDate);
            }
            book.DecreaseAvailability();
            _bookRepository.Update(book);

            Rent rent = new Rent(Guid.NewGuid(), reader, book, rentDate);
            _rentRepository.AddRent(rent);
            return rent;
        }

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
                throw new BookNotFound();
            }
            book.IncreaseAvailability();
            rent.EndRent();

            _bookRepository.Update(book);
            _rentRepository.UpdateRent(rent);
        }
    }
}
