using AppStudent.Data;
using AppStudent.Data.Repository;
using AppStudent.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit.Internal;
using Refit;
using System.Threading.Tasks;

namespace AppStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //private readonly IMapper _mapper;
        private readonly IRoleRepository _repository;


        public RoleController(IRoleRepository repository)
        {
            //_mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        [Route("Create")]
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

            var result = await _repository.CreateAsync(role);

            return Ok(result);
        }

    }

}

