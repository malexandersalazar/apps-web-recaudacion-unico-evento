using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.UpdateGuestDonation;
using UniqueFundraisingEvent.Web.Application.Features.Guests.Queries.GetGuest;

namespace UniqueFundraisingEvent.Web.Pages.Guests
{
    [Authorize(Roles = "Administrador,Recolector")]
    public class EditDonationsModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditDonationsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public GuestDetail GuestDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var guestDetail = await _mediator.Send(new GetGuestQuery(id.Value));
            if (guestDetail is null)
                return NotFound();

            GuestDetail = guestDetail;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var vs = ModelState["GuestDetail.DonationAmount"].ValidationState;

            if (vs == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                return Page();

            await _mediator.Send(new UpdateGuestDonationCommand(GuestDetail.Id, GuestDetail.DonationAmount));

            return RedirectToPage("./Index");
        }
    }
}