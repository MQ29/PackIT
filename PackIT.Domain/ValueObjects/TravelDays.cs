﻿using PackIT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.ValueObjects
{
    public record TravelDays
    {
        public ushort Value { get; } //Value objects are immutable so no setter

        public TravelDays(ushort value)
        {
            if (value is 0 or > 100)
            {
                throw new InvalidTravelDaysException(value);
            }

            Value = value;
        }

        public static implicit operator ushort(TravelDays days)
            => days.Value;

        public static implicit operator TravelDays(ushort days)
           => new(days);
    }
}
