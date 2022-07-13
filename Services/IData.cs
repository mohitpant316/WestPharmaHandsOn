using ProductCatalog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IData
    {
        Task<List<Product>> GetProductData();
    }
}