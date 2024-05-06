using PackIT.Shared.Abstractions.Commands;
using PackIT.Domain.Repositories;
using PackIT.Domain.Factories;
using PackIT.Application.Services;
using PackIT.Application.Exceptions;
using PackIT.Domain.ValueObjects;

namespace PackIT.Application.Commands.Handlers
{
    public sealed class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListFactory _factory;
        private readonly IPackingListReadService _readService;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory factory, IPackingListReadService readService, IWeatherService weatheService)
        {
            _repository = repository;
            _factory = factory;
            _readService = readService;
            _weatherService = weatheService;
        }

        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            var (id, name, days, gender, localizationWriteModel) = command; //deconstruction

            if (await _readService.ExistsByNameAsync(name)) //providing idempotency
            {
                throw new PackingListAlreadyExistsException(name);
            }

            var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(localization);

            if (weather is null)
            {
                throw new MissingLocalizationWeatherException(localization);
            }

            var packingList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature, localization);

            await _repository.AddAsync(packingList);

        }
    }
}
