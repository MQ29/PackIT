using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class InvalidTemperatureException : PackItException
    {
        public double Temp { get; }

        public InvalidTemperatureException(double temp) : base($"Value: '{temp}' is invalid temperature.")
            =>Temp = temp;
        

    }
}
