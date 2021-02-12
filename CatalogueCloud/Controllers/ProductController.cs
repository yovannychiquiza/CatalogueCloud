using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogueCloud.Models;
using CatalogueCloud.ViewModels;

namespace CatalogueCloud.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductController(IProductRepository productRepository,
            ICategoryRepository categoryRepository
            )
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }
        public ViewResult List()
        {
            ProductListVM productListVM = new ProductListVM()
            {
                Products = productRepository.AllProducts,
                SelectedCategoryName = categoryRepository.AllCategories.ToList()[0].Name
            };

            return View(productListVM);
        }


        public ViewResult Details(int id)
        {
            var product = productRepository.GetProductById(id);
            return View(product);
        }

    }
}
