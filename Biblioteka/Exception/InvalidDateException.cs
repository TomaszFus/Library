using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class InvalidDateException : CustomException
    {
        public DateTime Date { get; }
        public InvalidDateException(DateTime date) : base($"Date {date} is from future")
        {
            Date = date;
        }

        public InvalidDateException() : base($"Invalid date")
        {           
        }
    }
}
