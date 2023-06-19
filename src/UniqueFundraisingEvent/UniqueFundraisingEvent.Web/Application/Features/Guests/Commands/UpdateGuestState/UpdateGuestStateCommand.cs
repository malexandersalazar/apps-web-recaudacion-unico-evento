using MediatR;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.UpdateGuestState
{
    public sealed class UpdateGuestStateCommand : IRequest
    {
        public int Id { get; set; }
        public string State { get; set; }

        public UpdateGuestStateCommand(int id, string state)
        {
            Id = id;
            State = state;
        }
    }
}