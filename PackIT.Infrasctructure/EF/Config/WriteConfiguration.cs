using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingItem>, IEntityTypeConfiguration<PackingList>
    {
        public void Configure(EntityTypeBuilder<PackingList> builder)
        {
            builder.HasKey(x => x.Id);

            var localizationConverter = new ValueConverter<Localization, string>(x => x.ToString(),
               x => Localization.Create(x));

            var packingListName = new ValueConverter<PackingListName, string>(x => x.Value, x => new PackingListName(x));

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PackingListId(x));

        }

        public void Configure(EntityTypeBuilder<PackingItem> builder)
        {
        }
    }
}
