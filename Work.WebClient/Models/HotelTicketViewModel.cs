namespace Work.WebClient.Models;

public class HotelTicketViewModel
{
    public int Id { get; set; }

    public int NumberOfDays { get; set; }

    public int HotelId { get; set; }

    public double SummaryPrice { get; set; }
}