using PackIT.Application.DTO;
using PackIT.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Queries
{
    public class GetPackingList : IQuery<PackingListDto>
    {
        public Guid Id { get; set; }
    }
}
