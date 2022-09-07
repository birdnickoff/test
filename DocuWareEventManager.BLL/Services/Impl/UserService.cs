using DocuWareEventManager.BLL.Enums;
using DocuWareEventManager.BLL.Models;
using DocuWareEventManager.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DocuWareEventManager.BLL.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<RegisterUserResponseDto> RegisterUser(string email, string password)
        {
            if(await _repository.CheckUser(email))
            {
                return new RegisterUserResponseDto { Result = RegisterUserResult.AlreadyExists };
            }

            try
            {
                var passwordHash = EncryptPassword(password);
                var userId = await _repository.AddUser(email, passwordHash);
                return new RegisterUserResponseDto { UserId = userId, Result = RegisterUserResult.Added };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during register user");
                return new RegisterUserResponseDto { Result = RegisterUserResult.Failed };
            }
            
        }

        public Task<int?> GetUserId(string email, string password)
        {
            var passwordHash = EncryptPassword(password);
            return _repository.GetUserId(email, passwordHash);
        }

        private string EncryptPassword(string password)
        {
            // TODO: using salt, etc
            using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
