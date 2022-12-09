using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public abstract class CustomException : global::System.Exception
    {
        protected CustomException(string message) : base(message)
        { }
    }
}
