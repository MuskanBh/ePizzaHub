using ePizzaHub.Core;
using ePizzaHub.Core.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Implementations
{
    public class CartRepository : Repository<CartRepository>, ICartRepository
    {
        AppDbContext context { get { return _db as AppDbContext; } }
        public CartRepository(AppDbContext db) : base(db)
        {

        }
        public void Add(Cart entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = context.CartItems.Where(ci => ci.CartId == cartId && ci.Id == itemId).FirstOrDefault();
            if(item != null)
            {
                context.CartItems.Remove(item);
                return context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public Cart GetCart(Guid cartId)
        {
            return context.Carts.Include(c => c.CartItems).Where(p => p.Id == cartId && p.IsActive == true).FirstOrDefault();
        }

        public CartModel GetCartDetails(Guid cartId)
        {
            var model = (from cart in context.Carts
                         where
                         cart.Id == cartId && cart.IsActive == true
                         select new CartModel
                         {
                             Id = cart.Id,
                             UserId = cart.UserId,
                             CreatedDate = cart.CreatedDate,
                             Items = (from cartItem in context.CartItems
                                      join item in context.Items
                                      on cartItem.ItemId equals item.Id
                                      where cartItem.CartId == cartId
                                      select new ItemModel
                                      {
                                          Id = cartItem.Id,
                                          Quantity = cartItem.Quantity,
                                          UnitPrice = cartItem.UnitPrice,
                                          ItemId = item.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl
                                      }).ToList()
                         }).FirstOrDefault();
            return model;
        }

        public void Remove(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Cart entity)
        {
            throw new NotImplementedException();
        }

        public int UpdateCart(Guid cartId, int userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
            return context.SaveChanges();
        }

        public int UpdateQuantity(Guid cartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if(cart !=null)
            {
                var cartItems = cart.CartItems.ToList();
                for(int i=0; i< cart.CartItems.Count; i++)
                {
                    if (cartItems[i].Id = itemId)
                    {
                        flag= true;
                        cartItems[i].Quantity += Quantity;
                        break;
                    }
                }
                if (flag)
                {
                    cart.CartItems= cartItems;
                    return context.SaveChanges();
                }
            }
            return 0;
        }

        Cart IRepository<Cart>.Find(object id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Cart> IRepository<Cart>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
