using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PexelStore.Models.Domain;
using PexelStore.Models.DTO;
using PexelStore.Repository;

namespace PexelStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GamesController(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _gameRepository.GetAllAsync();
            return Ok(result);

        }

        [HttpGet]
        [Route("{Id:guid}")]

        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var game = await _gameRepository.GetByIdAsync(Id);
            if (game is null)
            {
                return BadRequest($"Not Found Game With Id :{Id}");
            }

            return Ok(game);

        }

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> CreateAsync([FromForm]AddGameDTO addGameDTO) 
        {
            var datastream = new MemoryStream();
            await addGameDTO.Poster.CopyToAsync(datastream);
            var GameDomainModel = _mapper.Map<Games>(addGameDTO);
            GameDomainModel.Poster = datastream.ToArray();
            GameDomainModel = await _gameRepository.CreateAsync(GameDomainModel);
            
            
            return Ok(GameDomainModel);
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateAsync(Guid Id , [FromForm]UpdateGameDTO? updateGameDTO) 
        {
            var datastream = new MemoryStream();
            await updateGameDTO.Poster.CopyToAsync(datastream);
            var gameDomainModel = _mapper.Map<Games>(updateGameDTO);
            gameDomainModel.Poster = datastream.ToArray();
            gameDomainModel = await _gameRepository.UpdateAsync(Id, gameDomainModel);
            if (gameDomainModel is null)
            {
                BadRequest($"No Genre Found With this Id:{Id}");
            }

            return Ok(gameDomainModel);

        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id) 
        {

            var result = await _gameRepository.DeleteAsync(Id);
            if (result is null) 
            {
                return BadRequest($"Not Found Game With id: {Id}");
            }

            return Ok(result);
        }
    }
}












