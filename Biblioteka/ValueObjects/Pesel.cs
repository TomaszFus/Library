using Biblioteka.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.ValueObjects
{
    public sealed class Pesel
    {
        public string Value { get;}
        public Pesel(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidPeselException(value);
            }

            if (value.Length!=11)
            {
                throw new InvalidPeselException(value);
            }

            if (!value.All(char.IsDigit))
            {
                throw new InvalidPeselException(value);
            }

            

            Value = value;
        }

        public static implicit operator string(Pesel pesel)
        {
            return pesel?.Value;
        }

        public static implicit operator Pesel(string pesel)
        {
            return new(pesel);
        }
    }

}
