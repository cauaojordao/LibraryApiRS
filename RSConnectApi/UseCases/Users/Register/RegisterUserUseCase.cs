using FluentValidation.Results;
using RSConnect.Api.Domain.Entities;
using RSConnect.Api.Infraestructure.DataAccess;
using RSConnect.Api.Infraestructure.Security.Cryptography;
using RSConnect.Api.Infraestructure.Security.Tokens.Access;
using RSConnect.Communication.Requests;
using RSConnect.Communication.Responses;
using RSConnect.Exception;

namespace RSConnect.Api.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {

            var dbContext = new RSConnectDbContext();
            Validate(request, dbContext);
            
            var cryptography = new BCryptAlgorithm();
            var entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = cryptography.HashPassword(request.Password)
            };


            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name= entity.Name,
                AcessToken= tokenGenerator.Generate(entity)
            };
        }

        private void Validate(RequestUserJson request, RSConnectDbContext dbContext)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            var existUserWithEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email));
            if (existUserWithEmail)
                result.Errors.Add(new ValidationFailure("Email", "Email já registrado na plataforma"));

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }

}
