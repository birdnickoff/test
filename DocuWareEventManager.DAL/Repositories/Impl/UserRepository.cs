using DocuWareEventManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace DocuWareEventManager.DAL.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly DocuWareEventManagerContext _context;

        public UserRepository(DocuWareEventManagerContext context)
        {
            _context = context;
        }


        public async Task<int> AddUser(string email, string password)
        {
            var newUser = new User
            {
                Email = email,
                Password = password,
                CreateDate = System.DateTime.UtcNow,
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser.Id;
        }

        public async Task<int?> GetUserId(string email, string password)
        {
            return (await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password))?.Id;
        }

        public async Task<bool> CheckUser(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
