namespace Work.BLL.Models;

public class TourModel
{
    public int Id { get; set; }

    public string TourName { get; set; }

    public string TourType { get; set; }

    public string TourRegion { get; set; }

    public string TourMovementType { get; set; }

    public DateTime TourDateTime { get; set; }

    public int TourDurationInDays { get; set; }

    public double TourPrice { get; set; }
}