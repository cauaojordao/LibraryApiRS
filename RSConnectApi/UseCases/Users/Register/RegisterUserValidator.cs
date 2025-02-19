using FluentValidation;
using RSConnect.Communication.Requests;

namespace RSConnect.Api.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O nome não pode ser vazio.");
            RuleFor(request => request.Email).EmailAddress().WithMessage("O email não é válido.");
            RuleFor(request => request.Password).NotEmpty().WithMessage("A senha é obrigatória");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(5).WithMessage("A senha deve ter, pelo menos, 6 digitos.");
            });
        }
    }
}
