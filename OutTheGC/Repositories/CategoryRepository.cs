using OutTheGC.Models;
using OutTheGC.Interfaces;
using OutTheGC.Data;
using Microsoft.EntityFrameworkCore;

namespace OutTheGC.Repositories;

public class CategoryRepository : ICategoryRepository
{
	private readonly OutTheGCDbContext dbContext;

	public CategoryRepository(OutTheGCDbContext context)
	{
		dbContext = context;
	}

    public async Task<List<Category>> GetCategoriesAsync()
	{
		return await dbContext.Categories.ToListAsync();
    }
}

