using BankTizimlari.Servise.DTOs.ApiUsersDTOs;
using BankTizimlari.Servise.DTOs.BankDTOs;
using BankTizimlari.Servise.IServices;
using BankTIzimlati.Data.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankTizimlari.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        IBankService service;

        public BankController(IBankService service)
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
        public async Task<IActionResult> Add(BankAddDto dto)
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
        public async Task<IActionResult> UpdateBank(Guid Id, BankAddDto bank)
        {
            try
            {
                await service.UpdateBank(Id, bank);
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
