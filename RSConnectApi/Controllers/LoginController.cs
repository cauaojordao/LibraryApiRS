using Microsoft.AspNetCore.Mvc;
using RSConnect.Api.UseCases.Login.DoLogin;
using RSConnect.Communication.Requests;
using RSConnect.Communication.Responses;

namespace RSConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status401Unauthorized)]
        public IActionResult DoLogin(RequestLoginJson request)
        {
            var useCase = new DoLoginUseCase();

            var response = useCase.Execute(request);

            return Ok(response);
        }
    }
}
