using AppStudent.Data;
using AppStudent.Data.Repository;
using AppStudent.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _repository;


        public RoleController(IRoleRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> CreateRoleAsync(RoleDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest();
                }

                Role role = new Role
                {
                    Id = dto.Id,
                    RoleName = dto.RoleName,
                    Description = dto.Description,
                    IsActive = dto.IsActive
                };

                role.IsDelete = false;
                role.CreateDate = DateTime.Now;
                role.ModifiedDate = DateTime.Now;

                await _repository.CreateAsync(role);

                return Ok(role);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("All", Name = "GetAllRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> GetRolesAsync()
        {
            try
            {
                var roles = await _repository.GetAllAsync();

                return Ok(roles);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetRoleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetRoleById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest($"Please validate{id}, is not correct");
                }
                var role = await _repository.GetAsync(role => role.Id == id);

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
        [Route("{name:alpha}", Name = "GetRoleByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest($"Please validate{name}, is not correct");
                }
                var role = await _repository.GetAsync(role => role.RoleName == name);

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
        [Route("Update", Name = "UpdateAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> UpdateRoleAsync([FromBody] RoleDTO dto)
        {
            try
            {
                if (dto == null || dto.Id <= 0)
                {
                    return BadRequest();
                }

                //var role = await _repository.GetAsync(role => role.Id == dto.Id);
                var role = await _repository.GetByIdAsync(dto.Id);

                if (role == null)
                {
                    return BadRequest($"Role not found with id {dto.Id} to update");
                }

                //var newRole = new Role
                //{
                //    RoleName = dto.RoleName,
                //    Description = dto.Description,
                //    IsActive = dto.IsActive
                //};
                //newRole.IsDelete = false;
                //newRole.ModifiedDate = DateTime.Now;

                role.RoleName = dto.RoleName;
                role.Description = dto.Description;
                role.IsActive = dto.IsActive;
                role.IsDelete = false;
                role.ModifiedDate = DateTime.Now;

                await _repository.UpdateAsync(role);

                return Ok(role);
            }
            catch (Exception ex)
            {

                return NotFound($"{ex}");
            }
        }

        [HttpDelete]
        [Route("Delete/{id}", Name = "DeleteRoleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> DeleteRoleAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest($"The id: {id} is not valid");
                }

                var deleteRole = await _repository.GetByIdAsync(id);

                if (deleteRole == null)
                {
                    return NotFound();
                }

                await _repository.DeleteAsync(deleteRole);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex}");

            }
        }
    }

}

