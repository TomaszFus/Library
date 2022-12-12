using Biblioteka.Data;
using Biblioteka.Entities;
using Biblioteka.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repositories.Concrete
{
    public class RentRepository : IRentRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
        public RentRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext= libraryDbContext;
        }

        public void AddRent(Rent rent)
        {
            _libraryDbContext.Rents.Add(rent);
            _libraryDbContext.SaveChanges();
        }
        
        public Rent GetRentByPeselAndBook(string pesel, string bookTitle, string bookAuthor)
        {
            return _libraryDbContext.Rents.Include(x=>x.Reader).Include(x=>x.Book).FirstOrDefault(x => x.Reader.Pesel == pesel && x.Book.Author == bookAuthor && x.Book.Title == bookTitle && x.Ended==false);
        }

        public IEnumerable<Rent> GetRentsByBook(string bookTitle, string bookAuthor)
        {
            return _libraryDbContext.Rents.Where(x => x.Book.Title == bookTitle && x.Book.Author == bookAuthor).ToList();
        }

        public IEnumerable<Rent> GetRentsByReader(string pesel)
        {
            return _libraryDbContext.Rents.Where(x => x.Reader.Pesel == pesel).ToList();
        }

        public void UpdateRent(Rent rent)
        {
            _libraryDbContext.Rents.Update(rent);
            _libraryDbContext.SaveChanges();
        }
    }
}
