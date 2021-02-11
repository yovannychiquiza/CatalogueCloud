using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogueCloud.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext appDBContext;

        public EFCategoryRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IEnumerable<Category> AllCategories => appDBContext.Categories;
    }
}
