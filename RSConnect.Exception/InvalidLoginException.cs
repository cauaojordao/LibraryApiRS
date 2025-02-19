using System.Net;

namespace RSConnect.Exception
{
    public class InvalidLoginException : RSConnectException
    {
        public override List<string> GetErrorMessages() => ["Email e/ou senha inválidos."];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
        
    }
}
