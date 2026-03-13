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
        [Route("CreateRolePrivilege")]
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


        [HttpGet]
        [Route("All", Name = "GetAllRolesPrivilege")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RolePrivilegeDTO>> GetRolePrivilegesAsync()
        {
            try
            {
                var roles = await _rolePrivilege.GetAllAsync();

                return Ok(roles);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("{id:int}", Name = "GetRolePrivilegeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetRolePrivilegeById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest($"Please validate{id}, is not correct");
                }
                var role = await _rolePrivilege.GetAsync(role => role.Id == id);

                if (role == null)
                {
                    return NotFound($"The Role not found with id: {id}");
                }
                return Ok(role);
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex}");
            }
        }

        [HttpGet]
        [Route("{name:alpha}", Name = "GetRolePrivilegeByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetRolePrivilegeByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest($"Please validate{name}, is not correct");
                }
                var role = await _rolePrivilege.GetAsync(role => role.RolePrivilegeName == name);

                if (role == null)
                {
                    return NotFound($"The Role not found with id: {name}");
                }
                return Ok(role);
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex}");
            }
        }

        [HttpPut]
        [Route("Update", Name = "UpdateRolePrivilegeAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RolePrivilegeDTO>> UpdateRolePrivilegeAsync([FromBody] RolePrivilegeDTO dto)
        {
            try
            {
                if (dto == null || dto.Id <= 0)
                {
                    return BadRequest();
                }

                //var role = await _rolePrivilege.GetAsync(role => role.Id == dto.Id);
                var role = await _rolePrivilege.GetByIdAsync(dto.Id);

                if (role == null)
                {
                    return BadRequest($"Role not found with id {dto.Id} to update");
                }

                role.RolePrivilegeName = dto.RolePrivilegeName;
                role.Description = dto.Description;
                role.IsActive = dto.IsActive;
                role.IsDelete = false;
                role.ModifiedDate = DateTime.Now;

                await _rolePrivilege.UpdateAsync(role);

                return Ok(role);
            }
            catch (Exception ex)
            {

                return NotFound($"{ex}");
            }
        }



    }
}
