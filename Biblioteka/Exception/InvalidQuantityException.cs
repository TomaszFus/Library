using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class InvalidQuantityException : CustomException
    {
        public InvalidQuantityException() : base("Quantity must be greater than zero")
        {
        }
    }
}
