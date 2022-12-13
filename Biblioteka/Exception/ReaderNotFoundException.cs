using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public sealed class ReaderNotFoundException : CustomException
    {
        public Guid Id { get; }
        public ReaderNotFoundException(Guid id) : base($"Reader {id} not found")
        {
            Id = id;
        }

        public ReaderNotFoundException() : base("Reader not found")
        {

        }
    }
}
