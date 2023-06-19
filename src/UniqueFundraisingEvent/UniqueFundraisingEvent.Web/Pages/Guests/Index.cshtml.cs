using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using UniqueFundraisingEvent.Web.Application.Contracts.Persistence;
using UniqueFundraisingEvent.Web.Application.Features.Guests.Commands.RegisterGuest;
using UniqueFundraisingEvent.Web.Application.Features.Guests.Queries.GetGuestsList;

namespace UniqueFundraisingEvent.Web.Pages.Guests
{
    public class GuestsModel : PageModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;

        [BindProperty]
        public IFormFile ImportUpload { get; set; } = default!;

        public IEnumerable<GuestInList> Guests { get; set; } = new List<GuestInList>();

        public GuestsModel(IServiceProvider serviceProvider, IMediator mediator)
        {
            _serviceProvider = serviceProvider;
            _mediator = mediator;
        }

        public async Task OnGet()
        {
            Guests = await _mediator.Send(new GetGuestsListQuery());
        }

        public async Task<IActionResult> OnPostImport()
        {
            using var memoryStream = new MemoryStream();
            await ImportUpload.CopyToAsync(memoryStream);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };

            using var reader = new StreamReader(memoryStream);
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<RegisterGuestCommand>();

            var unitOfWork = _serviceProvider.GetRequiredService<UnitOfWork>();
            foreach (var record in records)
                await _mediator.Send(record);
            await unitOfWork.CommitAsync();

            return RedirectToPage("./Index");
        }
    }
}