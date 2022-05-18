using System.Collections;
using Work.DAL.Entities;

namespace Work.Tests.ServicesTests.TestsData;

public class AddOrderTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Order
            {
                Id = 1,
                FinalPrice = 500,
                HotelTicketId = 1,
                TransportTicketId = 1,
                TourId = 1,
                UserId = 3
            },
            new Order
            {
                Id = 1,
                FinalPrice = 500,
                HotelTicketId = 1,
                TransportTicketId = 1,
                TourId = 1,
                UserId = 3
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditOrderTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Order
            {
                Id = 1,
                FinalPrice = 500,
                HotelTicketId = 1,
                TransportTicketId = 1,
                TourId = 1,
                UserId = 3
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteOrderTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Order
            {
                Id = 1,
                FinalPrice = 500,
                HotelTicketId = 1,
                TransportTicketId = 1,
                TourId = 1,
                UserId = 3
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetOrderByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new Order
            {
                Id = 1,
                FinalPrice = 500,
                HotelTicketId = 1,
                TransportTicketId = 1,
                TourId = 1,
                UserId = 3
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}