using PackIT.Domain.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands
{
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Gender Gender, LocalizationWriteModel Localization
        ) : ICommand;

    public record LocalizationWriteModel(string City, string Country);
}
