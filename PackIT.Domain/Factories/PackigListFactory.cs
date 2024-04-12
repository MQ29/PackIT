using PackIT.Domain.Const;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Factories
{
    public class PackigListFactory : IPackingListFactory
    {
        public PackingItem Create(PackingListId id, PackingListName name, Localization localization)
        {
            throw new NotImplementedException();
        }

        public PackingItem CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender, Temperature temperature, Localization localization)
        {
            throw new NotImplementedException();
        }
    }
}
