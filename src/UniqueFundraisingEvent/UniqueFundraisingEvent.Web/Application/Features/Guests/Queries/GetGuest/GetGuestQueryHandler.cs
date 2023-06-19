using MediatR;
using UniqueFundraisingEvent.Web.Common.Application;
using UniqueFundraisingEvent.Web.Domain.Entities;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Queries.GetGuest
{
    public class GetGuestQueryHandler : IRequestHandler<GetGuestQuery, GuestDetail>
    {
        private readonly IAsyncRepository<Guest> _guestRepository;

        public GetGuestQueryHandler(IAsyncRepository<Guest> guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<GuestDetail> Handle(GetGuestQuery request, CancellationToken cancellationToken)
        {
            var result = await _guestRepository.ReadEntryAsync(x => x.Id == request.Id);
            return new GuestDetail
            {
                Id = result.Id,
                Name = result.Name,
                LastName = result.LastName,
                Email = result.Email,
                Company = result.Company,
                CompanyPosition = result.CompanyPosition,
                State = result.State,
                DonationAmount = result.DonationAmount
            };
        }
    }
}