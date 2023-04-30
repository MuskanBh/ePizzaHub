using ePizzaHub.Core.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Implementations
{
    public class CartService : Service<Cart>, ICartService
    {
        ICartRepository _cartRepo;
        IRepository<CartItem> _cartItem;
        public CartService(ICartRepository cartRepo, IRepository<Cart> cartItem) : base(cartRepo) 
        {
            _cartRepo = cartRepo;
            _cartItem = cartItem;
        }

        public Cart AddItem(int UserId, Guid CartId, int ItemId, decimal UnitPrice, int Quantity)
        {
            try
            {
                Cart cart = _cartRepo.GetCart(CartId);
                if(cart== null)
                {
                    cart = new Cart();
                    CartItem item = new CartItem {ItemId= ItemId, Quantity= Quantity, UnitPrice= UnitPrice };
                    cart.Id = CartId;
                    cart.UserId= UserId;
                    cart.CreatedDate= DateTime.Now;
                    cart.IsActive= true;
                    item.CartId=cart.Id;
                    cart.CartItems.Add(item);

                    _cartRepo.Add(cart);
                    _cartRepo.SaveChanges();
                }
                else
                {
                    CartItem item = cart.CartItems.Where(p=>p.ItemId==ItemId).FirstOrDefault(); 
                    if(item!=null) 
                    { 
                        item.Quantity +=Quantity;
                        _cartItem.Update(item);
                        _cartItem.SaveChanges();
                    }
                    else
                    {
                        item = new CartItem { ItemId = ItemId, Quantity = Quantity, UnitPrice = UnitPrice };
                        item.CartId = cart.Id;
                        cart.CartItems.Add(item);

                        _cartItem.Update(item);
                        _cartItem.SaveChanges();
                    }
                }
                return cart;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            throw new NotImplementedException();
        }

        public int GetCartCount(Guid cartId)
        {
            throw new NotImplementedException();
        }

        public CartModel GetCartDetails(Guid cartId)
        {
            throw new NotImplementedException();
        }

        public int UpdateCart(Guid cartId, int userId)
        {
            throw new NotImplementedException();
        }

        public int UpdateQuantity(Guid cartId, int itemId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
