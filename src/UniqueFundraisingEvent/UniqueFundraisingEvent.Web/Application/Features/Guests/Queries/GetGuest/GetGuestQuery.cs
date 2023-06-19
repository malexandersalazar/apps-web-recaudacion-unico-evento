using MediatR;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Queries.GetGuest
{
    public sealed class GetGuestQuery : IRequest<GuestDetail>
    {
        public int Id { get; set; }

        public GetGuestQuery(int id)
        {
            Id = id;
        }
    }
}