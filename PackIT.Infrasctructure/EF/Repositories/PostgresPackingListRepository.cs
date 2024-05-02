using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.EF.Contexts;

namespace PackIT.Infrastructure.EF.Repositories
{
    internal sealed class PostgresPackingListRepository : IPackingListRepository
    {

        private readonly DbSet<PackingList> _packingLists;
        private readonly WriteDbContext _writeDbContext;

        public PostgresPackingListRepository(WriteDbContext writeDbContext)
        {
            _packingLists = writeDbContext.PackingLists;
            _writeDbContext = writeDbContext;
        }

        public Task<PackingList> AddAsync(PackingList packingList)
        {
            throw new NotImplementedException();
        }

        public Task<PackingList> DeleteAsync(PackingList packingList)
        {
            throw new NotImplementedException();
        }

        public Task<PackingList> GetAsync(PackingListId Id)
            => _packingLists.Include("_items").SingleOrDefaultAsync(x => x.Id == Id);

        public Task<PackingList> UpdateAsync(PackingList packingList)
        {
            throw new NotImplementedException();
        }
    }
}
