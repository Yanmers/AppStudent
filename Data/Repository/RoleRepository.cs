
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<List<Role>> GetAllAsync()
        {
            return await _collegeDB.Roles.ToListAsync();
        }

        public async Task<Role> GetAsync(Expression<Func<Role, bool>> predicate)
        {
            return await _collegeDB.Roles.FirstOrDefaultAsync(predicate);
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _collegeDB.Roles.Where(n => n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Role> GetByNameAsync(string roleName)
        {
            return await _collegeDB.Roles.Where(n => n.RoleName == roleName).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(Role role)
        {
            _collegeDB.Update(role);
            await _collegeDB.SaveChangesAsync();
            return role.Id;
        }
    }
}
