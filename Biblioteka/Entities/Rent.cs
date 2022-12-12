using Biblioteka.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Entities
{
    public class Rent
    {
        public Guid Id { get; private set; }
        public Reader Reader { get; private set; }
        public Book Book { get; private set; }
        public RentDate RentDate { get; private set; }
        public bool Ended { get; private set; } = false;

        public Rent(Guid id, Reader reader, Book book, RentDate rentDate)
        {
            Id= id;
            Reader= reader;
            Book= book;
            RentDate = rentDate;
        }

        public void EndRent()
        {
            this.Ended = true;
        }
    }
}
