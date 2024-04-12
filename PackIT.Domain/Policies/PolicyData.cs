using PackIT.Domain.Const;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies
{
    public record PolicyData(TravelDays days, Gender gender, Temperature temperature, Localization localization);
}
