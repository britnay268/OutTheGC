using OutTheGC.Models;

namespace OutTheGC.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync();
}
