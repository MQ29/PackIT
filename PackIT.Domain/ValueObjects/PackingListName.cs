using PackIT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.ValueObjects
{
    public record PackingListName //Value objects implement IEquatable
    {
        public string Value { get; } //Value objects are immutable so no setter

        public PackingListName(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyPackingListNameException();
            }

            Value = value;
        }

        public static implicit operator string(PackingListName name)
            => name.Value;

        public static implicit operator string(string name)
           => new(name);
    }
}
