using OutTheGC.Interfaces;
using OutTheGC.Models;

namespace OutTheGC.Services;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryService(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

    public async Task<List<Category>> GetCategoriesAsync()
    {
		return await _categoryRepository.GetCategoriesAsync();
    }

    public async Task<Category> CreateCategoryAsync(Category newCategory)
	{
		return await _categoryRepository.CreateCategoryAsync(newCategory);

    }

    public async Task<Category> DeleteCategoryAsync(Guid categoryId)
	{
		return await _categoryRepository.DeleteCategoryAsync(categoryId);
    }
}

