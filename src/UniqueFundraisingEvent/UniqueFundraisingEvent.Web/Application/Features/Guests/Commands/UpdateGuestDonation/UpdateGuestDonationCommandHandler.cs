using MediatR;
using UniqueFundraisingEvent.Web.Common.Application;
using UniqueFundraisingEvent.Web.Domain.Entities;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.UpdateGuestDonation
{
    public class UpdateGuestDonationCommandHandler : IRequestHandler<UpdateGuestDonationCommand>
    {
        private readonly IAsyncRepository<Guest> _guestRepository;

        public UpdateGuestDonationCommandHandler(IAsyncRepository<Guest> guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task Handle(UpdateGuestDonationCommand request, CancellationToken cancellationToken)
        {
            var result = await _guestRepository.LookupEntityAsync(x => x.Id == request.Id);
            result.DonationAmount = request.DonationAmount;
            await _guestRepository.UpdateAsync(result);
        }
    }
}