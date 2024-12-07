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

	public async Task<Category> CreateCategoryAsync(Category newCategory)
	{
		Category addCategory = new Category
		{
			Name = newCategory.Name,
			Default = false
		};

		var categoryExists = dbContext.Categories.Any(c => c.Name.ToLower() == newCategory.Name.ToLower());

		if (categoryExists)
		{
			return null;
		}

		dbContext.Categories.Add(addCategory);
		await dbContext.SaveChangesAsync();
		return addCategory;
	}

    public async Task<Category> DeleteCategoryAsync(Guid categoryId)
	{
		var categoryExists = await dbContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId && c.Default == false);

		if (categoryExists == null)
		{
			return null;
		}

		dbContext.Categories.Remove(categoryExists);
		await dbContext.SaveChangesAsync();
		return categoryExists;
	}
}