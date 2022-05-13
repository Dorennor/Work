namespace Work.BLL.Models;

public class TransportTicketModel
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int NumberOfUsing { get; set; }

    public TransportModel Transport { get; set; }

    public double TransportPrice { get; set; }
}