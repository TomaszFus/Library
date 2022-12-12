using Biblioteka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repositories.Abstract
{
    public interface IRentRepository
    {
        public void AddRent(Rent borrowing);
        public void UpdateRent(Rent borrowing);
        public Rent GetRentByPeselAndBook(string pesel, string bookTitle, string bookAuthor);
        public IEnumerable<Rent> GetRentsByBook(string bookTitle, string bookAuthor);
        public IEnumerable<Rent> GetRentsByReader(string pesel);
    }
}
