using SAonlineMart.Models;
namespace SAonlineMart.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<cartItems>> GetAll();
        bool Add(int Pid,string userid);
        bool PlusOne(int id);
        bool MinusOne(int id);
        public bool RemoveOne(int id);
        public bool RemoveALL(string userID);
        bool Delete(cartItems cartItems);
        bool update(cartItems cartItems);
        bool Save();
    }
}
