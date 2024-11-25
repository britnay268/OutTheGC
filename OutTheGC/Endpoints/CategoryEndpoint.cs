using OutTheGC.Models;
using OutTheGC.Interfaces;

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
    }
}

