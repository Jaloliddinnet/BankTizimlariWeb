using BankTizimlari.Servise.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankTizimlari.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserOperationController : ControllerBase
    {
        IBankService bankService;
        public UserOperationController(IBankService bankService)
        {
            this.bankService = bankService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserBank(Guid IdUser,Guid IdBank)
        {
            try
            {
                await bankService.AddUserBank(IdUser, IdBank);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
