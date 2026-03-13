
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppStudent.Data.Repository
{
    public class RolePrivilegeRepository : IRolePrivilegeRepository
    {
        private readonly CollegeDBContext _collegeDBContext;
        public RolePrivilegeRepository(CollegeDBContext collegeDBContext)
        {
            _collegeDBContext = collegeDBContext;
        }
        public async Task<int> CreateAsync(RolePrivilege rolePrivilege)
        {
            _collegeDBContext.RolePrivileges.Add(rolePrivilege);
            _collegeDBContext.SaveChanges();
            return rolePrivilege.Id;
        }

        public async Task<bool> DeleteAsync(RolePrivilege rolePrivilege)
        {
            _collegeDBContext.RolePrivileges.Remove(rolePrivilege);
            await _collegeDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<RolePrivilege>> GetAllAsync()
        {
            return await _collegeDBContext.RolePrivileges.ToListAsync();
        }

        public async Task<RolePrivilege> GetAsync(Expression<Func<RolePrivilege, bool>> predicate)
        {
            return await _collegeDBContext.RolePrivileges.FirstOrDefaultAsync(predicate);
        }

        public async Task<RolePrivilege> GetByIdAsync(int id)
        {
            return await _collegeDBContext.RolePrivileges.Where(n => n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<RolePrivilege> GetByroleNameAsync(string rolePrivilegeName)
        {
            return await _collegeDBContext.RolePrivileges.Where(n => n.RolePrivilegeName == rolePrivilegeName).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(RolePrivilege rolePrivilege)
        {
            _collegeDBContext.RolePrivileges.Add(rolePrivilege);
            await _collegeDBContext.SaveChangesAsync();
            return rolePrivilege.Id;
        }
    }
}
