using System.Collections;
using Work.DAL.Entities;

namespace Work.Tests.ServicesTests.TestsData;

public class AddTourTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Tour
            {
                Id = 1,
                TourMovementType = "Walking",
                TourName = "Fenway Park",
                TourDateTime = new DateTime(2022, 5, 30),
                TourDurationInDays = 1,
                TourRegion = "USA",
                TourType = "Individual Tour",
                TourPrice = 100
            },
            new Tour
            {
                Id = 1,
                TourMovementType = "Walking",
                TourName = "Fenway Park",
                TourDateTime = new DateTime(2022, 5, 30),
                TourDurationInDays = 1,
                TourRegion = "USA",
                TourType = "Individual Tour",
                TourPrice = 100
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditTourTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Tour
            {
                Id = 1,
                TourMovementType = "Walking",
                TourName = "Fenway Park",
                TourDateTime = new DateTime(2022, 5, 30),
                TourDurationInDays = 1,
                TourRegion = "USA",
                TourType = "Individual Tour",
                TourPrice = 100
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteTourTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Tour
            {
                Id = 1,
                TourMovementType = "Walking",
                TourName = "Fenway Park",
                TourDateTime = new DateTime(2022, 5, 30),
                TourDurationInDays = 1,
                TourRegion = "USA",
                TourType = "Individual Tour",
                TourPrice = 100
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetTourByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new Tour
            {
                Id = 1,
                TourMovementType = "Walking",
                TourName = "Fenway Park",
                TourDateTime = new DateTime(2022, 5, 30),
                TourDurationInDays = 1,
                TourRegion = "USA",
                TourType = "Individual Tour",
                TourPrice = 100
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}