using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogueCloud.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> FreeProductsOfTheWeek { get; }
        Product GetProductById(int coueseId);
    }
}
