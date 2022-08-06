using Walks.API.Models.Domains;

namespace Walks.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> usermodel = new List<User> {
        new User{ FirstName="Readonly", EmailAddress="Readonly@gmail.com",LastName="Read", Password="Read@2022", Roles=new List<string>{"Read"}, UserName="Read", Id=new Guid() },
        new User{ FirstName="ReadWrite", EmailAddress="ReadWrite@gmail.com",LastName="Readwrite", Password="ReadWrite@2022", Roles=new List<string>{"Read","Write"}, UserName="ReadWrite", Id=new Guid() }
        };
        public async Task<User> AuntenticateAsync(string Username, string Password)
        {
            User result = usermodel.Find(x => x.UserName == Username && x.Password == Password);
            return result;
        }
    }
}
