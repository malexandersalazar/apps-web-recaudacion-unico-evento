using MediatR;
using UniqueFundraisingEvent.Web.Common.Application;
using UniqueFundraisingEvent.Web.Domain.Entities;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.RegisterGuest
{
    public class RegisterGuestCommandHandler : IRequestHandler<RegisterGuestCommand>
    {
        private readonly IAsyncRepository<Guest> _guestRepository;

        public RegisterGuestCommandHandler(IAsyncRepository<Guest> guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task Handle(RegisterGuestCommand request, CancellationToken cancellationToken)
        {
            await _guestRepository.CreateAsync(new Guest
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Company = request.Company,
                CompanyPosition = request.CompanyPosition,
                State = "Reservado",
                DonationAmount = 0,
                FechaCreacion = DateTime.UtcNow
            });
        }
    }
}