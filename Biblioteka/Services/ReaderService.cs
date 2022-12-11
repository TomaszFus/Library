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
        public ReaderService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
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

        public void Delete(Guid id)
        {
            //sprawdzic czy nie ma aktywnych wypozyczen
            var readerToDelete = _readerRepository.GetReaderById(id);
            if (readerToDelete != null)
            {
                _readerRepository.Delete(readerToDelete);
            }
            throw new ReaderNotFound(id);
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
