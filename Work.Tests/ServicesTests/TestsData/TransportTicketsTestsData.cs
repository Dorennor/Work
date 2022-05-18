using System.Collections;
using Work.DAL.Entities;

namespace Work.Tests.ServicesTests.TestsData;

public class AddTransportTicketTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new TransportTicket
            {
                Id = 3,
                NumberOfUsing = 3,
                TransportId = 2,
                TransportPrice = 30
            },
            new TransportTicket
            {
                Id = 3,
                NumberOfUsing = 3,
                TransportId = 2,
                TransportPrice = 30
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditTransportTicketTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new TransportTicket
            {
                Id = 3,
                NumberOfUsing = 3,
                TransportId = 2,
                TransportPrice = 30
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteTransportTicketTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new TransportTicket
            {
                Id = 3,
                NumberOfUsing = 3,
                TransportId = 2,
                TransportPrice = 30
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetTransportTicketByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new TransportTicket
            {
                Id = 3,
                NumberOfUsing = 3,
                TransportId = 2,
                TransportPrice = 30
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}