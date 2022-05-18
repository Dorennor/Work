using System.Collections;
using Work.DAL.Entities;

namespace Work.Tests.ServicesTests.TestsData;

public class AddHotelTicketTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new HotelTicket
            {
                Id = 3,
                HotelId = 1,
                NumberOfDays = 5,
                SummaryPrice = 100
            },
            new HotelTicket
            {
                Id = 3,
                HotelId = 1,
                NumberOfDays = 5,
                SummaryPrice = 100
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditHotelTicketTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new HotelTicket
            {
                Id = 3,
                HotelId = 1,
                NumberOfDays = 5,
                SummaryPrice = 100
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteHotelTicketTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new HotelTicket
            {
                Id = 3,
                HotelId = 1,
                NumberOfDays = 5,
                SummaryPrice = 100
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetHotelTicketByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new HotelTicket
            {
                Id = 3,
                HotelId = 1,
                NumberOfDays = 5,
                SummaryPrice = 100
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}