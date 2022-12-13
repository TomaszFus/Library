using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public class GivenPeselAlreadyExistException : CustomException
    {
        public string Pesel { get; }
        public GivenPeselAlreadyExistException(string pesel) : base($"User with given pesel {pesel} already exist")
        {
            Pesel = pesel;
        }
    }
}
