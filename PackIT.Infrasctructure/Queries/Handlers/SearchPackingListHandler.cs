using PackIT.Application.DTO;
using PackIT.Infrastructure.EF.Models;
using PackIT.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Queries.Handlers
{
    public class SearchPackingListHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        public Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
        {
        }
    }
}
