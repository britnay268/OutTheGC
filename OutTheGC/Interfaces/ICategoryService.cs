using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync();

    Task<Category> CreateCategoryAsync(Category newCategory);

    Task<Category> DeleteCategoryAsync(Guid categoryId);
}
