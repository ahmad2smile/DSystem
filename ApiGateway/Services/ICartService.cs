using System.Threading.Tasks;
using Cart;

namespace ApiGateway.Services
{
    public interface ICartService
    {
        Task<int> GetTotal(string cartId);
        Task<AddItemReply> AddItem(AddItemRequest request);
        Task<RemoveItemReply> RemoveItem(RemoveItemRequest request);
    }
}
