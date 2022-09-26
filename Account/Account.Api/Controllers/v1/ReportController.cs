using Account.ApplicationCore.DTOs.Response;
using Account.ApplicationCore.DTOs.Response.Report;
using Account.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IAppLogger<ReportController> _logger;
        private readonly IAccountService _accountService;

        public ReportController(IAppLogger<ReportController> logger, IAccountService accountService) =>
            (_logger, _accountService) = (logger, accountService);

        [HttpGet("Balance")]
        [MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BalanceResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> Balance()
        {
            var balance = await _accountService.Balance();
            return Ok(balance);
        }
    }
}