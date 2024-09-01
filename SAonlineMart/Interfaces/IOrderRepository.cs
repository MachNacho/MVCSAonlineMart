using SAonlineMart.Models;
namespace SAonlineMart.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll(string userID);
        Task<Order> GetByIdAsync(int ORDERid);
    }
}