using Account.ApplicationCore.DTOs.Request.Account;
using Account.ApplicationCore.DTOs.Response;
using Account.ApplicationCore.DTOs.Response.Account;
using Account.ApplicationCore.Interfaces;
using Account.ApplicationCore.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService) =>
            _accountService = accountService;

        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AccountResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> Find()
        {
            var account = await _accountService.Find();
            return Ok(account.ToAccountResponse());
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> FindById([FromRoute] Guid id)
        {
            var account = await _accountService.FindById(id);
            return Ok(account.ToAccountResponse());
        }

        [HttpPost("Debit/{id}")]
        [MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> Debit([FromRoute] Guid id, [FromBody] DebitRequest request)
        {
            await _accountService.Debit(request.ToTransaction(id));
            return Ok();
        }

        [HttpPost("Credit/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> Credit([FromRoute] Guid id, [FromBody] CreditRequest request)
        {
            await _accountService.Credit(request.ToTransaction(id));
            return Ok();
        }
    }
}