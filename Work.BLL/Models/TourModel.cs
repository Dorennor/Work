namespace Work.BLL.Models;

public class TourModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public string Region { get; set; }

    public string MovementType { get; set; }

    public DateOnly TourDate { get; set; }

    public double Price { get; set; }

    public int TourDuration { get; set; }
}