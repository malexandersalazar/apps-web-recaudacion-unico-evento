using MediatR;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.RegisterGuest
{
    public sealed class RegisterGuestCommand : IRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string CompanyPosition { get; set; }

        public RegisterGuestCommand(string name, string lastName, string email, string company, string companyPosition)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Company = company;
            CompanyPosition = companyPosition;
        }
    }
}