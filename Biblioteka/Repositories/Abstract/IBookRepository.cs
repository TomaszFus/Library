using Biblioteka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repositories.Abstract
{
    public interface IBookRepository
    {
        public void AddBook(Book book);
        public Book GetBookByTitleAndAuthor(string title, string author);
        public Book GetBookById(Guid id);
        public void DeleteBook(Book book);
        public void Update(Book book);
    }
}
