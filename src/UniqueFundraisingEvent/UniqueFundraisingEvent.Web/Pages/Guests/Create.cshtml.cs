using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.RegisterGuest;

namespace UniqueFundraisingEvent.Web.Pages.Guests
{
    public class CreateModel : PageModel
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

        [BindProperty]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "El campo Apellido es requerido")]
        public string LastName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "El campo Correo es requerido")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "El campo Empresa es requerido")]
        public string Company { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "El campo Cargo es requerido")]
        public string CompanyPosition { get; set; } = string.Empty;

        private readonly IMediator mediator;

        public CreateModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await mediator.Send(new RegisterGuestCommand(Name, LastName, Email, Company, CompanyPosition));

            return RedirectToPage("./Index");
        }
    }
}