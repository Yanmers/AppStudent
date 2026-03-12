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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> CreateRoleAsync(RoleDTO dto)
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

        [HttpGet]
        [Route("All", Name = "GetAllRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleDTO>> GetRoleAsync()
        {
            var roles = await _repository.GetAllAsync();

            return Ok(roles);
        }

    }

}

