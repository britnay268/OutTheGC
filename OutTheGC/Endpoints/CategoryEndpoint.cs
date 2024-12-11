using OutTheGC.Models;
using OutTheGC.Interfaces;
using OutTheGC.Services;

namespace OutTheGC.Endpoints;

public static class CategoryEndpoint
{
	public static void MapCategoryEndpoints(this IEndpointRouteBuilder routes)
	{
        var group = routes.MapGroup("").WithTags(nameof(Category));

        group.MapGet("/categories", async (ICategoryService categoryService) =>
        {
            return await categoryService.GetCategoriesAsync();
        })
        .WithOpenApi()
        .Produces<List<Category>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/category", async (ICategoryService categoryService, Category newCategory) =>
        {
            var categoryToAdd = await categoryService.CreateCategoryAsync(newCategory);

            if (categoryToAdd == null)
            {
                return Results.BadRequest(new
                {
                    error = "The category already exists."
                });
            }

            return Results.Created($"/category/{newCategory.Id}", newCategory);
        })
        .WithOpenApi()
        .Produces<Category>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/category/{categoryId}", async (ICategoryService categoryService, Guid categoryId) =>
        {
            var categortyToDelete = await categoryService.DeleteCategoryAsync(categoryId);

            if (categortyToDelete == null)
            {
                return Results.NotFound(new
                {
                    error = "The category does not exist or cannot be deleted."
                });
            }

            return Results.Ok(new { message = "Category has been deleted" });
        })
        .WithOpenApi()
        .Produces<Category>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/category/{categoryId}/activities", async (ICategoryService categoryService, Guid categoryId, Guid tripId) =>
        {
            var activitiesByCategory = await categoryService.GetActivitiesByCategoriesAsync(categoryId, tripId);

            if (!activitiesByCategory.Any())
            {
                return Results.NotFound(new
                {
                    message = "There are no activities in this category."
                });
            }

            return Results.Ok(activitiesByCategory.Select(ac => new
            {
                ac.Id,
                ac.Title,
                ac.Notes,
                ac.Location,
                ac.Date,
                ac.Duration,
                ac.Cost,
                ac.Category,
                ac.WebsiteUrl,
                User = new
                {
                    ac.User.FullName
                },
                ac.CreatedAt,
                ac.UpdatedAt,
                VoteCount = ac.Votes.Count()
            }));
        })
        .WithOpenApi()
        .Produces<List<Activity>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}

