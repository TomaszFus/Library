using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class BookNotAvailableException : CustomException
    {
        public BookNotAvailableException() : base("Book not available")
        {
        }
    }
}
