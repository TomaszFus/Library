using Biblioteka.Entities;
using Biblioteka.Exception;
using Biblioteka.ValueObjects;
using Shouldly;
using System.Reflection.PortableExecutable;

namespace LibraryTests
{
    public class ReaderTests
    {
        [Fact]
        public void given_valid_pesel_reader_should_be_created()
        {
            var validPesel = "98745632123";
                       
            var reader = new Reader(Guid.NewGuid(), "Jan", "Kowalski", validPesel, "student");

            reader.ShouldNotBeNull();
            reader.Pesel.Value.ShouldBe(validPesel);
        }

        [Fact]
        public void given_valid_role_reader_should_be_created()
        {
            var validRole = "student";

            var reader = new Reader(Guid.NewGuid(), "Jan", "Kowalski", "98745632123", validRole);

            reader.ShouldNotBeNull();
            reader.Role.Value.ShouldBe(validRole);
        }

        [Fact]
        public void given_invalidvalid_role_should_throw_exception()
        {
            var invalidRole = "boss";

            Exception exception = Record.Exception(()=> new Reader(Guid.NewGuid(), "Jan", "Kowalski", "98745632123", invalidRole));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidRoleException>();
        }

        [Fact]
        public void given_invalid_pesel_should_throw_exception()
        {
            var invalidPesel = "45645632";
            Exception exception = Record.Exception(() => new Reader(Guid.NewGuid(), "Jan", "Kowalski", invalidPesel, "employee"));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType <InvalidPeselException> ();
        }

        [Fact]
        public void employee_to_student_update_should_throw_exception()
        {
            var invalidRole = "student";
            var reader = new Reader(Guid.NewGuid(), "Jan", "Kowalski", "98745632123", "employee");


            Exception exception = Record.Exception(() => reader.UpdateRole(invalidRole));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<RoleCannotBeChangedException>();
        }

        [Fact]
        public void student_to_lecturer_update_should_be_updated()
        {
            var validRole = "lecturer";
            var reader = new Reader(Guid.NewGuid(), "Jan", "Kowalski", "98745632123", "student");


            reader.UpdateRole(validRole);

            reader.Role.Value.ShouldBe("lecturer");
        }
    }
}