using Microsoft.EntityFrameworkCore;
using PexelStore.Data;
using PexelStore.Models.Domain;

namespace PexelStore.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GameRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Games> CreateAsync(Games game)
        {
            await _dbContext.AddAsync(game);
            await _dbContext.SaveChangesAsync();
            return game;
        }

        public async Task<Games?> DeleteAsync(Guid? Id)
        {
            var result = await _dbContext.games.Include("genres").FirstOrDefaultAsync(x=> x.Id == Id);
            if (result == null) 
            {
                return null;
            }
            _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<List<Games>> GetAllAsync()
        {
            return await _dbContext.games.Include("genres").ToListAsync();
            
        }

        public async Task<Games?> GetByIdAsync(Guid? Id)
        {
            var game = await _dbContext.games.Include("genres").FirstOrDefaultAsync(x => x.Id == Id);
            if (game is null) 
            {
            return null;
            }

            return game;
        }

        public async Task<Games?> UpdateAsync(Guid Id, Games games)
        {
            var result = await _dbContext.games.FirstOrDefaultAsync(x => x.Id == Id);
            if (result is null) 
            {
                return null;
            }
            result.Title = games.Title;
            result.Price = games.Price;
            result.Story = games.Story;
            result.Poster = games.Poster;
            result.GenreId = games.GenreId;
            result.Platform = games.Platform;
            await _dbContext.SaveChangesAsync();
            return result;
            
           }

        

    }
}
