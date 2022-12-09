using Biblioteka.Entities;
using Biblioteka.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.ValueObjects
{
    public sealed class Role
    {
        public static IEnumerable<string> Roles { get; } = new[] { "student", "employee", "lecturer" };

        public string Value { get; }

        public Role(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidRoleException(value);
            }

            if (!Roles.Contains(value))
            {
                throw new InvalidRoleException(value);
            }

            Value = value;
        }

        public static implicit operator Role(string value)
        {
            return new Role(value);
        }
        public static implicit operator string(Role role)
        {
            return role?.Value;
        }

                
    }
}
