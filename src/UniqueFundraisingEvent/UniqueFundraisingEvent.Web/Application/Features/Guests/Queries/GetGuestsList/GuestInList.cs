namespace UniqueFundraisingEvent.Web.Application.Features.Guests.Queries.GetGuestsList
{
    public class GuestInList
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string CompanyPosition { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public decimal DonationAmount { get; set; }
    }
}