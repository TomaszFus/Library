using Biblioteka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repositories.Abstract
{
    public interface IReaderRepository
    {
        void AddReader(Reader reader);
        Reader GetReaderByPesel(string pesel);
        void Update(Reader reader);
        void Delete(Reader reader);
        Reader GetReaderById(Guid id);
    }
}
