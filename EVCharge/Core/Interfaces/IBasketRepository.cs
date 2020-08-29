using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<ShoppingBasket> GetBasketAsync(string basketId);
        Task<ShoppingBasket> UpdateBasketAsync(ShoppingBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
