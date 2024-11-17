using System;
using OutTheGC.Models;
namespace OutTheGC.Data;

public class TripData
{
	public static List<Trip> Trips = new()
	{
		new(){
            Id = new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"),
            Title = "Summer Getaway",
            Notes = "A relaxing trip to the beach to unwind and explore new places.",
            Destination = "Maldives",
            StartDate = new DateTime(6, 15, 2024),
            EndDate = new DateTime(6, 22, 2024),
            Status = "Planned",
            Budget = 3500.00M,
            ImageUrl = "https =//example.com/images/maldives.jpg",
            UserId = new Guid("0eaed767-eecd-4d19-a853-9da895e78057"),
            CreatedAt = new DateTime(1, 15, 2024),
            UpdatedAt = new DateTime(2, 22, 2024)
        },
        new(){
            Id = new Guid("0eb66928-c2b0-4eea-9e4a-f7363fc98778"),
            Title = "Adventure in the Alps",
            Notes = "An action-packed trip to the Swiss Alps for skiing and hiking.",
            Destination = "Switzerland",
            StartDate = new DateTime(2024, 3, 10),
            EndDate = new DateTime(2024, 3, 17),
            Status = "Confirmed",
            Budget = 4000.00M,
            ImageUrl = "https://example.com/images/alps.jpg",
            UserId = new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"),
            CreatedAt = new DateTime(2023, 12, 1),
            UpdatedAt = new DateTime(2023, 12, 5)
        },
        new(){
            Id = new Guid("4da6ceb3-2c4d-475f-9afd-3eecd34d1523"),
            Title = "Road Trip USA",
            Notes = "A long road trip across the United States visiting national parks.",
            Destination = "USA",
            StartDate = new DateTime(2024, 7, 1),
            EndDate = new DateTime(2024, 7, 15),
            Status = "Planned",
            Budget = 2500.00M,
            ImageUrl = "https://example.com/images/roadtrip.jpg",
            UserId = new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85"),
            CreatedAt = new DateTime(2024, 2, 10),
            UpdatedAt = new DateTime(2024, 2, 12)
        },
        new(){
            Id = new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"),
            Title = "Cultural Escape",
            Notes = "A trip to explore the rich history and culture of Italy.",
            Destination = "Italy",
            StartDate = new DateTime(2024, 9, 1),
            EndDate = new DateTime(2024, 9, 10),
            Status = "Confirmed",
            Budget = 3200.00M,
            ImageUrl = "https://example.com/images/italy.jpg",
            UserId = new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"),
            CreatedAt = new DateTime(2024, 1, 10),
            UpdatedAt = new DateTime(2024, 1, 12)
        },
        new(){
            Id = new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"),
            Title = "Tropical Retreat",
            Notes = "Escape to a private island in the Caribbean for rest and relaxation.",
            Destination = "Bahamas",
            StartDate = new DateTime(2024, 11, 1),
            EndDate = new DateTime(2024, 11, 7),
            Status = "Planned",
            Budget = 5000.00M,
            ImageUrl = "https://example.com/images/bahamas.jpg",
            UserId = new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5"),
            CreatedAt = new DateTime(2024, 3, 15),
            UpdatedAt = new DateTime(2024, 3, 20)
        }
    };
}

