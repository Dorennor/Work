using Microsoft.AspNetCore.Identity;

namespace Work.BLL.Models;

public class OrderModel
{
    public int Id { get; set; }

    public int TourId { get; set; }

    public TourModel Tour { get; set; }

    public IdentityUser<int> User { get; set; }

    public HotelTicketModel? HotelReservationTicket { get; set; }

    public TransportTicketModel? TransportReservationTicket { get; set; }

    public double FinalPrice { get; set; }
}