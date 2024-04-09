using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class PackingItemAlreadyExitsException : PackItException
    {
        public string ListName { get; } //properties for future
        public string ItemName { get; }

        public PackingItemAlreadyExitsException(string listName, string itemName) 
            : base($"Packing List: '{listName}' already defined item '{itemName}'.")
        {
            ListName = listName;
            ItemName = itemName;
        }

    }
}
