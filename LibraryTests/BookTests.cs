using Biblioteka.Entities;
using Biblioteka.Exception;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTests
{
    public class BookTests
    {
        [Fact]
        public void given_valid_data_book_should_be_created()
        {
            var book = new Book(Guid.NewGuid(), "Henryk Sienkiewicz", "Potop", 4);

            book.ShouldNotBeNull();
            book.Author.ShouldBe("Henryk Sienkiewicz");
            book.Title.ShouldBe("Potop");
            book.Availability.Value.ShouldBe(4);
        }

        [Fact]
        public void add_availability_should_be_updated()
        {
            var book = new Book(Guid.NewGuid(), "Henryk Sienkiewicz", "Potop", 4);
            book.AddAvailability(5);

            book.Availability.Value.ShouldBe(9);
        }

        [Fact]
        public void decrease_availability_should_throw_exception()
        {
            var book = new Book(Guid.NewGuid(), "Henryk Sienkiewicz", "Potop", 0);
            
            Exception exception = Record.Exception(() => book.DecreaseAvailability());

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidAvailabilityException>();
        }
    }
}
