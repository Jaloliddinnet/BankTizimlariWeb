using AutoMapper;
using BankTizimlari.Domain.DTOs.AuthDTOs;
using BankTizimlari.Domain.DTOs.Identity;
using BankTizimlari.Domain.Entities.Products;
using BankTizimlari.Servises.Identity;
using BankTIzimlati.Data.BankDBContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TexnikaBuyurtma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _unitOfWork;
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;


        public AccountController(UserManager<ApiUser> userManager,
            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager, AppDbContext unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LodinDto userDto)
        {
            _logger.LogInformation($"Login attempt for {userDto.Username}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _authManager.ValidateUser(userDto))
            {
                return Unauthorized();
            }

            return await GetUserWithToken(userDto.Username);
        }
        private async Task<IActionResult> GetUserWithToken(string username, bool hasToken = true)
        {
            var user = await _userManager.FindByNameAsync(username);

            var roles = (await _userManager.GetRolesAsync(user)).ToArray();

            if (roles is null)
                return NotFound();

            dynamic userWithToken = MapUserWithToken(user, roles);

            userWithToken.Roles = roles;

            if (hasToken)
                userWithToken.Token = await _authManager.CreateToken();

            return Accepted(userWithToken);
        }

        private dynamic MapUserWithToken(ApiUser user, string[] role)
        {
            dynamic userWithToken = _mapper.Map<UserDto>(user);

            return userWithToken;
        }
    }
}
