using Biblioteka.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.ValueObjects
{
    public sealed class RentDate
    {
        public DateTime Value { get; }
        public RentDate(DateTime value)
        {
            if (value > DateTime.Today)
            {
                throw new InvalidDateException(value);
            }
            if (value == DateTime.MinValue)
            {
                throw new InvalidDateException();
            }
            Value = value;
        }

        public static implicit operator DateTime(RentDate rentDate) 
        {
            return rentDate.Value;
        }
        public static implicit operator RentDate(DateTime rentDate)
        {
            return new(rentDate);
        }
    }
}
