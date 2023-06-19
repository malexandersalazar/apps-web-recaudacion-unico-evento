using MediatR;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Queries.GetGuestsList
{
    public sealed class GetGuestsListQuery : IRequest<IEnumerable<GuestInList>>
    {
    }
}
