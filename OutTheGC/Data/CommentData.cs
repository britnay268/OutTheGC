using System;
using OutTheGC.Models;
namespace OutTheGC.Data;

public class CommentData
{
	public static List<Comment> Comments = new()
	{
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("0eaed767-eecd-4d19-a853-9da895e78057"),
            ActivityId = new Guid("175a8012-6200-4180-915b-f3e4d604923d"),
            Content = "The beach day sounds so relaxing! Can’t wait to enjoy the sun and sea breeze.",
            CreatedAt = new DateTime(2024, 2, 2)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("0eaed767-eecd-4d19-a853-9da895e78057"),
            ActivityId = new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"),
            Content = "The underwater adventure is a must-try! The reefs look amazing.",
            CreatedAt = new DateTime(2024, 2, 14),
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("0eaed767-eecd-4d19-a853-9da895e78057"),
            ActivityId = new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"),
            Content = "Island hopping will be such a fun way to explore the Maldives!",
            CreatedAt = new DateTime(2024, 2, 18),
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"),
            ActivityId = new Guid("d7e309b1-dde9-48f5-99b5-7d3c6f153032"),
            Content = "Skiing in the Alps is a dream come true! Can’t wait for this adventure.",
            CreatedAt = new DateTime(2023, 12, 8)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"),
            ActivityId = new Guid("a3c9c52c-038f-4b3e-a9bc-26496fcbfa0b"),
            Content = "I’m excited for the hiking trip. The views are going to be breathtaking!",
            CreatedAt = new DateTime(2024, 1, 2)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"),
            ActivityId = new Guid("b8d3c7d2-8a8e-45d0-8b1a-cbc32bc3b53d"),
            Content = "Alpine dining sounds so cozy. Can’t wait to try the Swiss specialties.",
            CreatedAt = new DateTime(2023, 12, 15)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85"),
            ActivityId = new Guid("ff8f6c32-8e22-4a3c-8d8a-2f1e5b557477"),
            Content = "The national park tour will be such a scenic experience. Looking forward to it!",
            CreatedAt = new DateTime(2024, 3, 1)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85"),
            ActivityId = new Guid("bfa47491-e758-4330-bc10-2e60d9a3479d"),
            Content = "A sunset drive along the coast sounds like the perfect way to relax.",
            CreatedAt = new DateTime(2024, 2, 20)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85"),
            ActivityId = new Guid("d7f9d8ed-4f65-4859-a837-d4a512bf7a6b"),
            Content = "Looking forward to the classic diner experience on Route 66!",
            CreatedAt = new DateTime(2024, 2, 18)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"),
            ActivityId = new Guid("f2d85352-0c93-4f58-9739-4e0d63ca90d1"),
            Content = "I’ve always wanted to visit this museum. The history here is so rich!",
            CreatedAt = new DateTime(2024, 2, 10)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"),
            ActivityId = new Guid("343f58ed-97d1-4324-b231-71e7a3d577e5"),
            Content = "The cultural dance show will be such a treat. I love traditional performances.",
            CreatedAt = new DateTime(2024, 2, 11)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"),
            ActivityId = new Guid("da699d06-56b7-4fbd-89b1-b24fdf9b7ab2"),
            Content = "Exploring the old town will be such a charming experience. Can’t wait!",
            CreatedAt = new DateTime(2024, 1, 30)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5"),
            ActivityId = new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"),
            Content = "Beach day with blue waters and sun? Yes, please!",
            CreatedAt = new DateTime(2024, 2, 10)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5"),
            ActivityId = new Guid("9b0ecf93-c42d-4c45-9ecb-85b8fe7e2d7c"),
            Content = "Tasting tropical drinks will be a refreshing break. Can’t wait!",
            CreatedAt = new DateTime(2024, 2, 15)
        },
        new Comment
        {
            Id = Guid.NewGuid(),
            UserId = new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5"),
            ActivityId = new Guid("92d62312-4397-4c9d-9172-2c8a53e8c6a4"),
            Content = "Snorkeling at Coral Reef Bay will be a highlight of the trip for sure!",
            CreatedAt = new DateTime(2024, 2, 17)
        }
    };
}

