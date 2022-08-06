using Walks.API.Models.Domains;

namespace Walks.API.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuntenticateAsync(string Username,string Password);
    }
}
