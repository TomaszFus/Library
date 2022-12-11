using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class InvalidAvailabilityException : CustomException
    {
        public InvalidAvailabilityException() : base("Value cannot be less than zero")
        {
        }
    }
}
