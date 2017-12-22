using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Organization
{
    public class UpdateOrganizationCommand : Command, IRequest<Model.Organization>
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}