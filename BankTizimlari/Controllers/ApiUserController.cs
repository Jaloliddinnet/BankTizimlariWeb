using BankTizimlari.Servise.DTOs.ApiUsersDTOs;
using BankTizimlari.Servise.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankTizimlari.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        IApiUserService service;
        public ApiUserController(IApiUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(ApiUserAddDto dto)
        {
            try
            {
                await service.Add(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await service.Delete(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApiUser(Guid Id,ApiUserAddDto apiUser)
        {
            try
            {
                await service.UpdateApiUser(Id, apiUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                return Ok(await service.GetById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
