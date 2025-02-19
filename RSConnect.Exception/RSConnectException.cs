using System.Net;

namespace RSConnect.Exception
{
    public abstract class RSConnectException : System.Exception
    {
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();
    }
}
