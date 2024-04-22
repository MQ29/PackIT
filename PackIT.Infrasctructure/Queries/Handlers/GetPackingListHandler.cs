using PackIT.Application.DTO;
using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Infrastructure.EF.Models;
using PackIT.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Queries.Handlers
{
    internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        private readonly IPackingListRepository _repository;
        public GetPackingListHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task<PackingListDto> HandleAsync(GetPackingList query)
        {
            var packingList = await _repository.GetAsync(query.Id);

            if (packingList is null)
            {
                throw new PackingListDoesntExistException(query.Id);
            }

            return packingList?.AsDto();
        }
    }
}
