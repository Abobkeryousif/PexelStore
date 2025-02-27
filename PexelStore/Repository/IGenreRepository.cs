using PexelStore.Models.Domain;

namespace PexelStore.Repository
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenreAsync();
        Task<Genre> CreateGenreAsync(Genre genre);
        Task<Genre?> GetByIdAsync(Guid? Id);
        Task<Genre?> DeleteAsync(Guid? Id);

        Task<Genre?> UpdateAsync(Guid? Id , Genre? genre);

    }
}
