using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.UpdateGuestState;
using UniqueFundraisingEvent.Web.Application.Features.Guests.Queries.GetGuest;

namespace UniqueFundraisingEvent.Web.Pages.Guests
{
    [Authorize(Roles = "Administrador,Recepcionista")]
    public class EditStatusModel : PageModel
    {
        public List<SelectListItem> States = new List<SelectListItem>
        {
            new SelectListItem
            {
                Text = "Reservado",
                Value = "Reservado"
            },
            new SelectListItem
            {
                Text = "Ingresó",
                Value = "Ingresó"
            },
            new SelectListItem
            {
                Text = "Se retiró",
                Value = "Se retiró"
            }
        };

        [BindProperty]
        [Required(ErrorMessage = "El campo Estado es requerido")]
        public string State { get; set; } = "Reservado";

        private readonly IMediator _mediator;

        public EditStatusModel(IMediator mediator)
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
            State = guestDetail.State;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _mediator.Send(new UpdateGuestStateCommand(GuestDetail.Id, State));

            return RedirectToPage("./Index");
        }
    }
}