using PackIT.Domain.Const;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies.Gender
{
    internal class MaleGenderPolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>()
            {
                new("Laptop",1),
                new("Book",(uint) Math.Ceiling(data.days/7m)),
                new("Creatine",1),
            };
        public bool IsApplicable(PolicyData data)
            => data.gender is Const.Gender.Male;   
    }
}
