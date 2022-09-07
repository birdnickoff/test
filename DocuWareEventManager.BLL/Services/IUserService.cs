using DocuWareEventManager.BLL.Models;
using System.Threading.Tasks;

namespace DocuWareEventManager.BLL.Services
{
    public interface IUserService
    {
        public Task<int?> GetUserId(string email, string password);

        Task<RegisterUserResponseDto> RegisterUser(string email, string password);
    }
}
