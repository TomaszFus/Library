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
        /// <summary>
        /// Dodaje nowego czytelnika do biblioteki
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="pesel"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        /// <exception cref="GivenPeselAlreadyExistException"></exception>
        public Reader CreateReader(string firstName, string lastName, string pesel, string role)
        {
            var readerExist = _readerRepository.GetReaderByPesel(pesel);
            if (readerExist != null)
            {
                throw new GivenPeselAlreadyExistException(pesel);
            }
            Reader reader = new Reader(Guid.NewGuid(), firstName, lastName, pesel, role);
            _readerRepository.AddReader(reader);

            return reader;
        }
        /// <summary>
        /// Zmienia rolę czytelnika
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="newRole"></param>
        /// <returns></returns>
        public Reader ChangeRole(Reader reader, string newRole)
        {
            reader.UpdateRole(newRole);
            _readerRepository.Update(reader);
            return reader;
        }
        /// <summary>
        /// Usuwa czytelnika pod warunkiem, że nie posiada on wypożyczonych książek 
        /// </summary>
        /// <param name="pesel"></param>
        /// <exception cref="ReaderNotFoundException"></exception>
        /// <exception cref="ReaderHaveBookException"></exception>
        public void Delete(string pesel)
        {
            var readerToDelete = _readerRepository.GetReaderByPesel(pesel);
            if (readerToDelete is null)
            {
                throw new ReaderNotFoundException();
            }

            var rents = _rentRepository.GetRentsByReader(pesel);
            var readerHaveRent = rents.Any(x=>x.Ended == false);
            if (readerHaveRent)
            {
                throw new ReaderHaveBookException();
            }
            _readerRepository.Delete(readerToDelete);
        }
        /// <summary>
        /// Modyfikuje dane użytkownica
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="pesel"></param>
        /// <returns></returns>
        /// <exception cref="ReaderNotFoundException"></exception>
        public Reader Updade(Guid id, string firstName, string lastName, string pesel)
        {
            var readerToUpdate = _readerRepository.GetReaderById(id);
            if (readerToUpdate is null)
            {
                throw new ReaderNotFoundException(id);
            }
            readerToUpdate.Update(firstName, lastName, pesel);
            _readerRepository.Update(readerToUpdate);
            return readerToUpdate;
        }
    }
}
