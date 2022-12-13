using Biblioteka.Entities;
using Biblioteka.Exception;
using Biblioteka.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTests
{
    public class PenaltyCalculatorTests
    {
        [Fact]
        public void given_valid_data_corect_calculate_penalty()
        {
            PenaltyService penaltyService=new PenaltyService();
            var reader = new Reader(Guid.NewGuid(), "Jan", "Kowalski", "45678912321", "student");
            var dueDate = new DateTime(2022,12,5);
            var deliveryDate = new DateTime(2022, 12, 9);

            var penalty = penaltyService.CalculatePenalty(reader, dueDate, deliveryDate);

            penalty.ShouldBe(4);
        }

        [Fact]
        public void given_invalid_date_should_throw_exception()
        {
            PenaltyService penaltyService = new PenaltyService();
            var reader = new Reader(Guid.NewGuid(), "Jan", "Kowalski", "45678912321", "student");
            var dueDate = new DateTime(2022, 12, 8);
            var deliveryDate = new DateTime(2022, 12, 5);

            Exception exception = Record.Exception(() => penaltyService.CalculatePenalty(reader, dueDate, deliveryDate));
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidDateException>();
        }
    }
}
