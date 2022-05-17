namespace Work.BLL.Models;

public class TransportTicketModel
{
    public int Id { get; set; }

    public int NumberOfUsing { get; set; }

    public int TransportId { get; set; }

    public double TransportPrice { get; set; }
}