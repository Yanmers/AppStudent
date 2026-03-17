using Octokit;

namespace AppStudent.Services
{
    public class UserServices : IUserServices
    {

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user, int id)
        {
            throw new NotImplementedException();
        }
    }
}
