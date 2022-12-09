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
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
        public ReaderRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public void AddReader(Reader reader)
        {
            _libraryDbContext.Readers.Add(reader);
            _libraryDbContext.SaveChanges();
        }

        public void Delete(Reader reader)
        {
            _libraryDbContext.Readers.Remove(reader);
        }

        public Reader GetReaderById(Guid id)
        {
            return _libraryDbContext.Readers.SingleOrDefault(x=>x.Id == id);
        }

        public Reader GetReaderByPesel(string pesel)
        {
            return _libraryDbContext.Readers.SingleOrDefault(x => x.Pesel == pesel);
        }

        public void Update(Reader reader)
        {
            _libraryDbContext.Readers.Update(reader);
            _libraryDbContext.SaveChanges();
        }
    }
}
