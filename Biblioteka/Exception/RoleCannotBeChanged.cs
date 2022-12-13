using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public class RoleCannotBeChanged : CustomException
    {
        public string Role { get; }
        public RoleCannotBeChanged(string role) : base($"Role {role} cannot be changed")
        {
            Role = role;
        }
    }
}
