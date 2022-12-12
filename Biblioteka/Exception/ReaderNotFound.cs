using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class ReaderNotFound : CustomException
    {
        public Guid Id { get; }
        public ReaderNotFound(Guid id) : base($"Reader {id} not found")
        {
            Id = id;
        }

        public ReaderNotFound() : base("Reader not found")
        {

        }
    }
}
