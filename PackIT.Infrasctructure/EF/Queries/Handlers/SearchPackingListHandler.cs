using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;
using PackIT.Infrastructure.EF.Queries;
using PackIT.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Queries.Handlers
{
    internal sealed class SearchPackingListHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        private readonly DbSet<PackingListReadModel> _packingList;
        public SearchPackingListHandler(ReadDbContext context)
        {
            _packingList = context.PackingLists;
        }
        public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
        {
            var dbQuery = _packingList
                .Include(x => x.Items)
                .AsQueryable();

            if (query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(x =>                                    //ILike case insensitive
                    Microsoft.EntityFrameworkCore.EF.Functions.ILike(x.Name, $"%{query.SearchPhrase}%"));
            }

            return await dbQuery
                .Select(x => x.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
