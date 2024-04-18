using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class PackingListDoesntExistException : PackItException
    {
        public Guid Id { get; }

        public PackingListDoesntExistException(Guid id) : base($"Packing list with id: {id} doesn't exist.")
        {
            Id = id;
        }
    }
}
