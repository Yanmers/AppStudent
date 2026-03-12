
using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CollegeDBContext _collegeDB;
        public RoleRepository(CollegeDBContext collegeDB)
        {
            _collegeDB = collegeDB;
        }


        public async Task<int> CreateAsync(Role role)
        {
            _collegeDB.Roles.Add(role);
            await _collegeDB.SaveChangesAsync();
            return role.Id;

        }

        public Task<bool> DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
