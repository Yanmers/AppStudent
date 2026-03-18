
namespace AppStudent.Data.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly CollegeDBContext _collegeDBContext;
        public UserRepository(CollegeDBContext CollegeDBContext)
        {
            _collegeDBContext = CollegeDBContext;
        }
        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user, int id)
        {
            throw new NotImplementedException();
        }
    }
}
