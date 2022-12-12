using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class ReaderHaveBookException : CustomException
    {
        public ReaderHaveBookException() : base("Reader did not return book")
        {
        }
    }
}
