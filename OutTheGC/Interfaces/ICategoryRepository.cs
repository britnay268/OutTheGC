using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface ICategoryRepository
{
	Task<List<Category>> GetCategoriesAsync();
}

