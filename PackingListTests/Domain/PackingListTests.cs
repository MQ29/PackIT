using PackIT.Domain.Entities;
using PackIT.Domain.Exceptions;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;
using Shouldly;

namespace PackIT.UnitTests.Domain
{
    public class PackingListTests
    {
        [Fact]
        public void AddItem_Throws_PackingItemAlreadyExitsException_When_There_Is_Already_Item_With_The_Same_Name()
        {
            //ARRANGE
            var packingList = GetPackingList();
            packingList.AddItem(new PackingItem("Item 1", 1));

            //ACT
            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingItemAlreadyExitsException>();

        }


        #region ARRANGE

        private PackingList GetPackingList()
        {
            var packingList = _factory.Create(Guid.NewGuid(), "List", Localization.Create("Kraków, Poland"));
            packingList.ClearEvents();
            return packingList;
        }

        private readonly IPackingListFactory _factory;

        public PackingListTests()
        {
            _factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>()); //not caring about policies for now, need to create separate class for policy testing
        }

        #endregion


    }
}
