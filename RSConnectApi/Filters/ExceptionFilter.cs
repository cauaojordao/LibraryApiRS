using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RSConnect.Communication.Responses;
using RSConnect.Exception;

namespace RSConnect.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is RSConnectException rsConnectException)
            {
                context.HttpContext.Response.StatusCode = (int)rsConnectException.GetStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessagesJson
                {
                    Errors = rsConnectException.GetErrorMessages()
                });
            } else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(new ResponseErrorMessagesJson
                {
                    Errors = ["Erro Desconhecido."]
                });
            }
        }
    }
}
