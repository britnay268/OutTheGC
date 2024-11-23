using OutTheGC.Models;
using OutTheGC.Interfaces;
using OutTheGC.Data;

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
        throw new NotImplementedException();
    }
}

