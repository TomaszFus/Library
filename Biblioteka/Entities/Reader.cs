using Biblioteka.Exception;
using Biblioteka.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Entities
{
    public class Reader
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Pesel Pesel { get; private set; }
        public Role Role { get; private set; }


        public Reader(Guid id, string firstName, string lastName, Pesel pesel, Role role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Role = role;
        }

        public void Update(string firstName, string lastName, string pesel)
        {
            this.FirstName = firstName;
            this.LastName= lastName;
            this.Pesel= pesel;
        }
        
        public void UpdateRole(Role newRole)
        {
            if (this.Role =="employee")
            {
                throw new RoleCannotBeChanged(this.Role);
            }
            Role = newRole;
        }

    }
}