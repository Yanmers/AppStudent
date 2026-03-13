using AppStudent.Data;
using AppStudent.Data.Repository;
using AppStudent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace AppStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePrivilegeController : ControllerBase
    {
        private readonly IRolePrivilegeRepository _rolePrivilege;
        public RolePrivilegeController(IRolePrivilegeRepository rolePrivilege)
        {
            _rolePrivilege = rolePrivilege;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RolePrivilegeDTO>> CreateRolePrivilegeAsync(RolePrivilegeDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest();
                }

                RolePrivilege rolePrivilege = new RolePrivilege
                {
                    RoleId = dto.RoleId,
                    RolePrivilegeName = dto.RolePrivilegeName,
                    Description = dto.Description,
                    IsActive = dto.IsActive
                };


                rolePrivilege.CreateDate = DateTime.Now;
                rolePrivilege.ModifiedDate = DateTime.Now;

                await _rolePrivilege.CreateAsync(rolePrivilege);

                return Ok(rolePrivilege);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
