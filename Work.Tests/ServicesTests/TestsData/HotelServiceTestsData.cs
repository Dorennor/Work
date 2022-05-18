using System.Collections;
using Work.DAL.Entities;

namespace Work.Tests.ServicesTests.TestsData;

public class AddHotelTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Hotel
            {
                Id = 3,
                HotelName = "Montage Kapalua Bay",
                HotelStars = 5,
                HotelPrice = 90
            },
            new Hotel
            {
                Id = 3,
                HotelName = "Montage Kapalua Bay",
                HotelStars = 5,
                HotelPrice = 90
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditHotelTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Hotel
            {
                Id = 3,
                HotelName = "Montage Kapalua Bay",
                HotelStars = 5,
                HotelPrice = 90
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteHotelTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Hotel
            {
                Id = 3,
                HotelName = "Montage Kapalua Bay",
                HotelStars = 5,
                HotelPrice = 90
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetHotelByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new Hotel
            {
                Id = 3,
                HotelName = "Montage Kapalua Bay",
                HotelStars = 5,
                HotelPrice = 90
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}