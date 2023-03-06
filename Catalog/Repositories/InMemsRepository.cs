using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class InMemsRepository : IItemsRepository
    {
        private readonly List<Item> Items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 29, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 19, CreatedDate = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(Items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var items  = Items.Where(item => item.Id == id).FirstOrDefault();
            return await Task.FromResult(items);
        }

        public async Task CreateItemAsync(Item item)
        {
            Items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = Items.FindIndex(existingItem => existingItem.Id == item.Id);
            Items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = Items.FindIndex(existingItem => existingItem.Id == id);
            Items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
