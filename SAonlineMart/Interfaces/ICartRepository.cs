using SAonlineMart.Models;
namespace SAonlineMart.Interfaces
{
    public interface ICartRepository//interface for repository
    {
        Task<IEnumerable<cartItems>> GetAll(string userID);
        bool Add(int Pid,string userid);
        bool PlusOne(int id);
        bool MinusOne(int id);
        public bool RemoveOne(int id);
        public bool RemoveALL(IEnumerable<cartItems> i);
        public bool CompleteCheckout(Order o);
        bool Delete(cartItems cartItems);
        bool update(cartItems cartItems);
        bool Save();
    }
}
