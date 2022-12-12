using Biblioteka.Entities;
using Biblioteka.Exception;
using Biblioteka.Repositories.Abstract;
using Biblioteka.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Services
{
    public sealed class ReaderService
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IRentRepository _rentRepository;
        public ReaderService(IReaderRepository readerRepository, IRentRepository rentRepository)
        {
            _readerRepository = readerRepository;
            _rentRepository = rentRepository;
        }

        public Reader CreateReader(string firstName, string lastName, string pesel, string role)
        {
            var readerExist = _readerRepository.GetReaderByPesel(pesel);
            if (readerExist != null)
            {
                throw new GivenPeselAlreadyExist(pesel);
            }
            Reader reader = new Reader(Guid.NewGuid(), firstName, lastName, pesel, role);
            _readerRepository.AddReader(reader);

            return reader;
        }

        public Reader ChangeRole(Reader reader, string newRole)
        {
            if (reader.Role == "lecturer" && newRole == "student")
            {
                throw new RoleCannotBeChanged(reader.Role);
            }

            if (reader.Role == "employee")
            {
                throw new RoleCannotBeChanged(reader.Role);
            }

            reader.UpdateRole(newRole);
            _readerRepository.Update(reader);
            return reader;
        }

        public void Delete(string pesel)
        {
            var readerToDelete = _readerRepository.GetReaderByPesel(pesel);
            if (readerToDelete is null)
            {
                throw new ReaderNotFound();
            }

            var rents = _rentRepository.GetRentsByReader(pesel);
            var readerHaveRent = rents.Any(x=>x.Ended == false);
            if (readerHaveRent)
            {
                throw new ReaderHaveBookException();
            }
            _readerRepository.Delete(readerToDelete);
        }

        public Reader Updade(Guid id, string firstName, string lastName, string pesel)
        {
            var readerToUpdate = _readerRepository.GetReaderById(id);
            if (readerToUpdate is null)
            {
                throw new ReaderNotFound(id);
            }
            readerToUpdate.Update(firstName, lastName, pesel);
            _readerRepository.Update(readerToUpdate);
            return readerToUpdate;
        }
    }
}
