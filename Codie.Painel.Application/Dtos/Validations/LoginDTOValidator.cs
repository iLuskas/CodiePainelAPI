using FluentValidation;

namespace Codie.Painel.Application.Dtos.Validations
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Login é obrigatório!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("A Senha é obrigatório!");
        }
    }
}
