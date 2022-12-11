using Biblioteka.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.ValueObjects
{
    public sealed class Availability
    {
        public int Value { get; }
        public Availability(int value)
        {
            if (value<0)
            {
                throw new InvalidAvailabilityException();
            }
            Value = value;
        }

        public static implicit operator int(Availability availability)
        { 
            return availability.Value;
        }

        public static implicit operator Availability(int availability)
        {
            return new(availability);
        }
    }
}
