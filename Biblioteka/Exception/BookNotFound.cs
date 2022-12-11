using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class BookNotFound : CustomException
    {
        public BookNotFound() : base("Book not found")
        {
        }
    }
}
