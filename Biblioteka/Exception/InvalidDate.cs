using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class InvalidDate : CustomException
    {
        public DateTime Date { get; }
        public InvalidDate(DateTime date) : base($"Date {date} is from future")
        {
            Date = date;
        }

        public InvalidDate() : base($"Invalid date")
        {           
        }
    }
}
