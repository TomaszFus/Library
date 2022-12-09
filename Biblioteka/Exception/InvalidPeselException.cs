using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class InvalidPeselException : CustomException
    {
        public string Pesel { get; }
        public InvalidPeselException(string pesel) : base($"Pesel {pesel} is invalid")
        {
            Pesel = pesel;
        }
    }
}
