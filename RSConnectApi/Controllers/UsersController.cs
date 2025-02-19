using Microsoft.AspNetCore.Mvc;
using RSConnect.Api.UseCases.Users.Register;
using RSConnect.Communication.Requests;
using RSConnect.Communication.Responses;
using RSConnect.Exception;

namespace RSConnect.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Create(RequestUserJson request)
        {
           var useCase = new RegisterUserUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
