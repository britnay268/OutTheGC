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
    }
}

