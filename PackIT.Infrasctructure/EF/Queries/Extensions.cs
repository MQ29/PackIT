using PackIT.Application.DTO;
using PackIT.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static PackingListDto AsDto(this PackingListReadModel readModel)
            => new()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Localization = new LocalizationDto
                {
                    City = readModel.Localization?.City,
                    Country = readModel.Localization?.Country,
                },
                Items = readModel?.Items.Select(x => new PackingItemDto
                {
                    Name = x.Name,
                    Quantity = x.Quantity,
                    IsPacked = x.IsPacked
                })
            };

    }
}
