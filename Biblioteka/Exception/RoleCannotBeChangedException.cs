using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class RoleCannotBeChangedException : CustomException
    {
        public string Role { get; }
        public RoleCannotBeChangedException(string role) : base($"Role {role} cannot be changed")
        {
            Role = role;
        }
    }
}
