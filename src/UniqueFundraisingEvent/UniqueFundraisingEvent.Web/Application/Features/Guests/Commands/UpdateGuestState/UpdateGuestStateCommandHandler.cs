using MediatR;
using UniqueFundraisingEvent.Web.Common.Application;
using UniqueFundraisingEvent.Web.Domain.Entities;

namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.UpdateGuestState
{
    public class UpdateGuestStateCommandHandler : IRequestHandler<UpdateGuestStateCommand>
    {
        private readonly IAsyncRepository<Guest> _guestRepository;

        public UpdateGuestStateCommandHandler(IAsyncRepository<Guest> guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task Handle(UpdateGuestStateCommand request, CancellationToken cancellationToken)
        {
            var result = await _guestRepository.LookupEntityAsync(x => x.Id == request.Id);
            result.State = request.State;
            await _guestRepository.UpdateAsync(result);
        }
    }
}