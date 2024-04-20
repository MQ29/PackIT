using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Repositories
{
    public interface IPackingListRepository
    {
        Task<PackingList> GetAsync(PackingListId Id);
        Task<PackingList> AddAsync(PackingList packingList);
        Task<PackingList> UpdateAsync(PackingList packingList);
        Task<PackingList> DeleteAsync(PackingList packingList);
    }
}
