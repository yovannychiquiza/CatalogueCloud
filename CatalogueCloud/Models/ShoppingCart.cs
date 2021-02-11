using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogueCloud.Models
{
    public class ShoppingCart
    {
        private readonly AppDBContext appDBContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services
                                .GetRequiredService<IHttpContextAccessor>()
                                .HttpContext.Session;

            string ShoppingcartId = session.GetString("ShoppingCartId") ??
                                    Guid.NewGuid().ToString();

            session.SetString("ShoppingCartId", ShoppingcartId);
            var context = services.GetService<AppDBContext>();
            return new ShoppingCart(context) { ShoppingCartId = ShoppingcartId };
        }

        public void AddItemToCart(Course course, decimal amount)
        {
            var ShoppingCartItem = appDBContext.ShoppingCartItems.SingleOrDefault(
                s => s.Course.CourseId == course.CourseId
                &&
                s.ShoppingCartId == this.ShoppingCartId
                );
            if(ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = this.ShoppingCartId,
                    Course = course,
                    Amount = amount
                };
                appDBContext.ShoppingCartItems.Add(ShoppingCartItem);
            }
            appDBContext.SaveChanges();
        }

        public void RemoveItemFromCart(Course course)
        {
            var ShoppingCartItem = appDBContext.ShoppingCartItems.SingleOrDefault(
                s => s.Course.CourseId == course.CourseId
                &&
                s.ShoppingCartId == this.ShoppingCartId
                );
            if (ShoppingCartItem != null)
            {
                appDBContext.ShoppingCartItems.Remove(ShoppingCartItem);
            }
            appDBContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            this.ShoppingCartItems = appDBContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == this.ShoppingCartId
                ).Include(cart => cart.Course).ToList();
            return this.ShoppingCartItems;
        }

        public decimal GetShoppingCartTotal()
        {
            return appDBContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == this.ShoppingCartId
                ).Select(cart => cart.Amount).Sum();
        }

        public void ClearShoppingCart()
        {
            var ShoppingCartItems = appDBContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == this.ShoppingCartId
                );
            appDBContext.ShoppingCartItems.RemoveRange(ShoppingCartItems);
            appDBContext.SaveChanges();
        }


    }
}
