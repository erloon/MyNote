using MediatR;
using MyNote.Identity.Domain.Commands.Organization;

namespace MyNote.Identity.Domain.Commands.User
{
    public class CreateFirstUserCommand : IRequest<bool>
    {
        public RegisterUserCommand RegisterUserCommand { get; set; }
        public CreateOrganizationCommand CreateOrganizationCommand { get; set; }
        
    }
}