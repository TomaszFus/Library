using Biblioteka.Exception;
using Biblioteka.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public Availability Availability { get; private set; }

        public Book(Guid id, string author, string title, int quantity) 
        {
            Id = id;
            Author = author;
            Title = title;
            Availability = quantity;
        }

        public void Update(string author, string title, int availability)
        {
            this.Author = author;
            this.Title= title;
            this.Availability = availability;
        }

        public void IncreaseAvailability()
        {
            this.Availability += 1;
        }
        public void DecreaseAvailability()
        {
            if (this.Availability==0)
            {
                throw new InvalidAvailabilityException();
            }
            this.Availability -= 1;
        }

        public int AddAvailability(int quantity)
        {
            return this.Availability += quantity;
        }

    }
}
