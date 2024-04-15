using PackIT.Domain.Const;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies
{
    public record PolicyData(TravelDays days, Const.Gender gender, ValueObjects.Temperature temperature, Localization localization);
}
