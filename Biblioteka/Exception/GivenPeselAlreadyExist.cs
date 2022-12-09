using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    internal class GivenPeselAlreadyExist : CustomException
    {
        public string Pesel { get; }
        public GivenPeselAlreadyExist(string pesel) : base($"User with given pesel {pesel} already exist")
        {
            Pesel = pesel;
        }
    }
}
