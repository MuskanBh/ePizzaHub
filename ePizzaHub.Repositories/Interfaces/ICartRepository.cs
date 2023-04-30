using ePizzaHub.Core.Entities;
using ePizzaHub.Models;

namespace ePizzaHub.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCart(Guid cartId);
        CartModel GetCartDetails(Guid cartId);

        int DeleteItem(Guid cartId, int itemId);

        int UpdateQuantity(Guid cartId, int itemId, int quantity);

        int UpdateCart(Guid cartId, int userId);

    }
}
