using System.Threading.Tasks;

namespace DocuWareEventManager.DAL.Repositories
{
    public interface IUserRepository
    {
        public Task<int?> GetUserId(string email, string password);

        public Task<bool> CheckUser(string email);

        public Task<int> AddUser(string email, string password);
    }
}
