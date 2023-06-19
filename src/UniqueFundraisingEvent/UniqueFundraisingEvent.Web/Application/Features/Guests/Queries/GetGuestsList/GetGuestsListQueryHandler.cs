using MediatR;
using UniqueFundraisingEvent.Web.Common.Application;
using UniqueFundraisingEvent.Web.Domain.Entities;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Queries.GetGuestsList
{
    public class GetGuestsListQueryHandler : IRequestHandler<GetGuestsListQuery, IEnumerable<GuestInList>>
    {
        private readonly IAsyncRepository<Guest> _guestRepository;

        public GetGuestsListQueryHandler(IAsyncRepository<Guest> guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<IEnumerable<GuestInList>> Handle(GetGuestsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _guestRepository.ReadListAsync();
            return result.Select(x => new GuestInList
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                Company = x.Company,
                CompanyPosition = x.CompanyPosition,
                State = x.State,
                DonationAmount = x.DonationAmount
            });
        }
    }
}