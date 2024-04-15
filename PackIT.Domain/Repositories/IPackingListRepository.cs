﻿using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Repositories
{
    internal interface IPackingListRepository
    {
        Task<PackingList> GetAsync(PackingListId Id);
        Task<PackingList> AddAsync(PackingList packingList);
        Task<PackingList> UpdateAsync(PackingList packingList);
        Task<PackingList> RemoveAsync(PackingList packingList);
    }
}
