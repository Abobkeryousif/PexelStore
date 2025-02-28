using PexelStore.Models.Domain;

namespace PexelStore.Repository
{
    public interface IGameRepository
    {
        Task<List<Games>> GetAllAsync();
        Task<Games?> GetByIdAsync(Guid? Id);  

        Task<Games> CreateAsync(Games game);

        Task<Games?> DeleteAsync(Guid? Id);

        Task<Games?> UpdateAsync(Guid Id , Games games);
    }
}
