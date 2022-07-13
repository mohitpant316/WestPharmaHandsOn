using ProductCatalog.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProductCatalog.Services
{
    class ProductService : IDataStore<Product>
    {
        private List<Product> productList;
        public async Task<bool> AddItemAsync(Product item)
        {
            var id = productList.Max(x => x.id);
            item.id = id + 1;
            productList.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = productList.Where(x => x.id == id).FirstOrDefault();
            productList.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Product> GetItemAsync(int id)
        {
            return await Task.FromResult(productList.FirstOrDefault(s => s.id == id));
        }

        public async Task<IEnumerable<Product>> GetItemsAsync()
        {
            if (productList != null)
                return productList;
            productList = await DataManagerFactory.Instance.RepositoryType.GetProductData();
            return productList;
        }

        public Task<bool> UpdateItemAsync(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
