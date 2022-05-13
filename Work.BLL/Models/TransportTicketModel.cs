namespace Work.BLL.Models;

public class TransportTicketModel
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public TransportModel Transport { get; set; }

    public double Price { get; set; }
}