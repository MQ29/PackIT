using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies.Universal
{
    internal class BasicPolicy : IPackingItemsPolicy
    {
        private const uint MaximumQuantityOfClothes = 7;
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>()
            {
                new("Pants", Math.Min(data.days, MaximumQuantityOfClothes)),
                new("Socks", Math.Min(data.days, MaximumQuantityOfClothes)),
                new("T-Shirt", Math.Min(data.days, MaximumQuantityOfClothes)),
                new("Trousers", data.days < 7 ? 1u : 2u),
                new("Shampoo", 1),
                new("Toothbrush", 1),
                new("Toothpaste", 1),
                new("Towel", 1),
                new("Bag pack", 1),
                new("Passport", 1),
                new("Phone Charger", 1)
            };
        public bool IsApplicable(PolicyData _) //parameter not used in the method's body
            => true;
    }
}
