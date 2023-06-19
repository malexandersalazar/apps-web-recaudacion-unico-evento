using MediatR;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.UpdateGuestDonation
{
    public sealed class UpdateGuestDonationCommand : IRequest
    {
        public int Id { get; set; }
        public decimal DonationAmount { get; set; }

        public UpdateGuestDonationCommand(int id, decimal donationAmount)
        {
            Id = id;
            DonationAmount = donationAmount;
        }
    }
}
