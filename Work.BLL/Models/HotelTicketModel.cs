using Work.DAL.Entities;

namespace Work.BLL.Models;

public class HotelTicketModel
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public HotelModel Hotel { get; set; }

    public double Price { get; set; }
}