using Work.DAL.Entities;

namespace Work.BLL.Models;

public class OrderModel
{
    public int Id { get; set; }

    public TourModel Tour { get; set; }

    public User User { get; set; }

    public HotelTicketModel? HotelReservationTicket { get; set; }

    public TransportTicketModel? TransportReservationTicket { get; set; }

    public double FinalPrice { get; set; }
}