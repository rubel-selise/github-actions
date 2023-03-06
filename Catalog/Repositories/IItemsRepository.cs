using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(Guid id);
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid id);
    }
}
