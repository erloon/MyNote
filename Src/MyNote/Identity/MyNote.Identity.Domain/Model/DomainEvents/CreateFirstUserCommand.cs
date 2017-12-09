using MediatR;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Identity.Domain.Model.Commands.User;

namespace MyNote.Identity.Domain.Model.DomainEvents
{
    public class CreateFirstUserCommand : IRequest<bool>
    {
        public RegisterUserCommand RegisterUserCommand { get; set; }
        public CreateOrganizationCommand CreateOrganizationCommand { get; set; }
        
    }
}