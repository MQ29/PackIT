using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class AddPackingItemHandler: ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository;

        public AddPackingItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(AddPackingItem command)
        {
            var (id, name, quantity) = command;

            var packingList = await _repository.GetAsync(id);

            if (packingList is null)
            {
                throw new PackingListDoesntExistException(id);
            }

            var packingItem = new PackingItem(name, quantity);
            packingList.AddItem(packingItem);

            await _repository.UpdateAsync(packingList);
        }
    }
}
