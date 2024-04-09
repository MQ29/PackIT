﻿using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Entities
{
    public class PackingList : AggregateRoot<Guid>
    {
        public PackingListId Id { get; private set; }

        private PackingListName _name;
        private Localization _localization;

        private readonly LinkedList<PackingItem> _items = new();

        internal PackingList(Guid id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }

        public void AddItem(PackingItem item)
        {
            var alreadyExists = _items.Any(x => x.Name == item.Name);

            if (alreadyExists)
            {
                throw new PackingItemAlreadyExitsException(_name,item.Name);
            }

            _items.AddLast(item);
            AddEvent(new PackingItemAdded(this,item));
        }
    }
}
