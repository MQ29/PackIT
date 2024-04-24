using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infrastructure.Queries.Handlers
{
    internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;
        public GetPackingListHandler(ReadDbContext context)
        {
            _packingLists = context.PackingLists;
        }

        public Task<PackingListDto> HandleAsync(GetPackingList query)
            => _packingLists
            .Include(x => x.Items)
            .Where(x => x.Id == query.Id)
            .Select(x => x.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
}
