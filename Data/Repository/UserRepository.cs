
using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly CollegeDBContext _collegeDBContext;
        public UserRepository(CollegeDBContext CollegeDBContext)
        {
            _collegeDBContext = CollegeDBContext;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            _collegeDBContext.Remove(id);
            await _collegeDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _collegeDBContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _collegeDBContext.Users.FindAsync(id);
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _collegeDBContext.Users.Where(n => n.UserName == name).FirstOrDefaultAsync();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _collegeDBContext.Users.Add(user);
            await _collegeDBContext.SaveChangesAsync();
            return user;
        }
    }
}
