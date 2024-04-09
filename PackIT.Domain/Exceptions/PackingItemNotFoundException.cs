using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class PackingItemNotFoundException : PackItException
    {
        public string ItemName { get; }
        public PackingItemNotFoundException(string itemName) : base($"Item with name: {itemName} was not found.")
           =>  ItemName = itemName;

    }
}
