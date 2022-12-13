using Biblioteka.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTests
{
    public class RentTest
    {
        [Fact]
        public void given_valid_data_rent_should_be_created()
        {
            var reader = new Reader(Guid.NewGuid(), "Jan", "Kowalski", "95621547854", "student");
            var book = new Book(Guid.NewGuid(), "Henryk Sienkiewicz", "Potop", 4);
            var date = new DateTime(2022, 10, 15);
            var rent = new Rent(Guid.NewGuid(), reader, book, date);


            rent.ShouldNotBeNull();
            rent.RentDate.Value.ShouldBe(date);
            rent.Ended.ShouldBe(false);
            rent.Reader.FirstName.ShouldBe("Jan");
        }

        [Fact]
        public void end_rent_should_be_ended()
        {
            var reader = new Reader(Guid.NewGuid(), "Jan", "Kowalski", "95621547854", "student");
            var book = new Book(Guid.NewGuid(), "Henryk Sienkiewicz", "Potop", 4);
            var date = new DateTime(2022, 10, 15);
            var rent = new Rent(Guid.NewGuid(), reader, book, date);
            rent.EndRent();

            rent.ShouldNotBeNull();
            rent.RentDate.Value.ShouldBe(date);
            rent.Ended.ShouldBe(true);
        }
    }
}
