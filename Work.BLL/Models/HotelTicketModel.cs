namespace Work.BLL.Models;

public class HotelTicketModel
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int NumberOfDays { get; set; }

    public int HotelId { get; set; }

    public HotelModel Hotel { get; set; }

    public double SummaryPrice { get; set; }
}