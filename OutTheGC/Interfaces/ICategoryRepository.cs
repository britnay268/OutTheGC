using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface ICategoryRepository
{
	Task<List<Category>> GetCategoriesAsync();

    Task<Category> CreateCategoryAsync(Category newCategory);

    Task<Category> DeleteCategoryAsync(Guid categoryId);
}

