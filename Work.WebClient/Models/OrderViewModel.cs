namespace Work.WebClient.Models;

public class OrderViewModel
{
    public int Id { get; set; }

    public int TourId { get; set; }

    public int UserId { get; set; }

    public int HotelTicketId { get; set; }

    public int TransportTicketId { get; set; }

    public double FinalPrice { get; set; }
}