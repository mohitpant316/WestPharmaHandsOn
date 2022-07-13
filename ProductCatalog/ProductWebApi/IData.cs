using ProductCatalog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductWebApi
{
    public interface IData
    {
        Task<List<Product>> GetProductData();
    }
}