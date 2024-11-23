using OutTheGC.Interfaces;
using OutTheGC.Data;
using OutTheGC.Models;

namespace OutTheGC.Services;

public class CategoryService
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
}

