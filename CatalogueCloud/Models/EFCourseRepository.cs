using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogueCloud.Models
{
    public class EFProductRepository: IProductRepository
    {
        private readonly AppDBContext appDBContext;
        public EFProductRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return appDBContext.Products.Include(c => c.Category);
            }
        }

        public IEnumerable<Product> FreeProductsOfTheWeek => throw new NotImplementedException();

        public Product GetProductById(int coueseId)
        {
            return appDBContext.Products.Include(c => c.Category).FirstOrDefault(c => c.ProductId == coueseId);   
        }
    }
}
