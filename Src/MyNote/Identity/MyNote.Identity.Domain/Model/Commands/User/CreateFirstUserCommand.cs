using MediatR;

namespace MyNote.Identity.Domain.Model.Commands.User
{
    public class CreateFirstUserCommand : IRequest<bool>
    {
        public RegisterUserCommand RegisterUserCommand { get; set; }
        public CreateOrganizationCommand CreateOrganizationCommand { get; set; }
        
    }
}