using Credit.ApplicationCore.DTOs.Request.Account;
using Credit.ApplicationCore.DTOs.Response;
using Credit.ApplicationCore.Interfaces;
using Credit.ApplicationCore.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Credit.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CreditController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public CreditController(IAccountService accountService) =>
            _accountService = accountService;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> Credit([FromBody] CreditRequest request)
        {
            await _accountService.Credit(request.Agency, request.AccountNumber, request.CurrentAccountDigit, request.ToTransaction());
            return Ok();
        }
    }
}