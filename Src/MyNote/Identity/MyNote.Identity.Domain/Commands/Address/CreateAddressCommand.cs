using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Address
{
    public class CreateAddressCommand : BaseCommand
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}