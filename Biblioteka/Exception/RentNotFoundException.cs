using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class RentNotFoundException : CustomException
    {
        public RentNotFoundException() : base("Rent not found")
        {
        }
    }
}
