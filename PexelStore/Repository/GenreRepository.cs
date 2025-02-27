using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PexelStore.Data;
using PexelStore.Models.Domain;

namespace PexelStore.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GenreRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
         
            await _dbContext.AddAsync(genre);
            await _dbContext.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre?> DeleteAsync(Guid? Id)
        {
            var genre = await _dbContext.genres.FindAsync(Id);
            if (genre == null) 
            {
                return null;
            }
            _dbContext.genres.Remove(genre);
            await _dbContext.SaveChangesAsync();
            return genre;
        }

        public async Task<List<Genre>> GetAllGenreAsync()
        {
            return await _dbContext.genres.ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(Guid? Id)
        {
            return await _dbContext.genres.FirstOrDefaultAsync(x=> x.Id == Id);
        }

        public async Task<Genre?> UpdateAsync(Guid? Id, Genre? genre)
        {
            var result = await _dbContext.genres.FirstOrDefaultAsync(x=> x.Id == Id);
            if (result is null) 
            {
                return null;
            }

            result.Name = genre.Name;
            result.GameId = genre.GameId;
            await _dbContext.SaveChangesAsync();
            return result;

        }
    }
}
