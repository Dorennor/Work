using System.Collections;
using Work.DAL.Entities;

namespace Work.Tests.ServicesTests.TestsData;

public class AddTransportTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Transport
            {
                Id = 1,
                Name = "Liner",
                TransportPrice = 82.60
            },
            new Transport
            {
                Id = 1,
                Name = "Liner",
                TransportPrice = 82.60
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditTransportTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Transport
            {
                Id = 1,
                Name = "Liner",
                TransportPrice = 82.60
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteTransportTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Transport
            {
                Id = 1,
                Name = "Liner",
                TransportPrice = 82.60
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetTransportByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new Transport
            {
                Id = 1,
                Name = "Liner",
                TransportPrice = 82.60
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}