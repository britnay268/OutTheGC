using System;
using OutTheGC.Models;
namespace OutTheGC.Data;

public class CategoryData
{
	public static List<Category> Categories = new()
	{
		new()
		{
			Id = new Guid("a143452f-7b59-4082-8bfa-44faa0d963ed"),
			Name = "Entertainment"
		},
        new()
        {
            Id = new Guid("48876876-6725-4225-9ae4-0279e87ce888"),
            Name = "Food & Drinks"
        },
        new()
        {
            Id = new Guid("a0254d5f-f540-44df-908b-d33d7c0da285"),
            Name = "Tours"
        },
        new()
        {
            Id = new Guid("27b9d332-04d0-4c7e-8196-ef38fb4779cc"),
            Name = "Adventure"
        },
        new()
        {
            Id = new Guid("72ff3052-5d20-4996-afec-a837d4df2904"),
            Name = "Relaxation & Wellness"
        },
        new()
        {
            Id = new Guid("973d6c63-ad42-475d-97bd-4197f484ad2a"),
            Name = "Other"
        }
    };
}

