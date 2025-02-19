using RSConnect.Api.Infraestructure.DataAccess;
using RSConnect.Api.Infraestructure.Security.Cryptography;
using RSConnect.Api.Infraestructure.Security.Tokens.Access;
using RSConnect.Communication.Requests;
using RSConnect.Communication.Responses;
using RSConnect.Exception;

namespace RSConnect.Api.UseCases.Login.DoLogin
{
    public class DoLoginUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {
            var dbContext = new RSConnectDbContext();

            var entity = dbContext.Users.FirstOrDefault(user => user.Email.Equals(request.Email));
            if (entity == null)
                throw new InvalidLoginException(); 
            

            var cryptography = new BCryptAlgorithm();
            var passwordIsValid = cryptography.Verify(request.Password, entity);
            if (passwordIsValid == false)
                throw new InvalidLoginException();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
                AcessToken = tokenGenerator.Generate(entity)
            };
        }
    }
}
