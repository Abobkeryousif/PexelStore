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
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenre() 
        {
        var genres = await _repository.GetAllGenreAsync();
            return Ok(genres);
        
        }
        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GetByIdAsync(Guid Id) 
        {
        var result = await _repository.GetByIdAsync(Id);
            if (result is null)
            {
                return BadRequest("Genre Not Found");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync(AddGenreDTO addGenre) 
        {
        var GenreDomainModel = _mapper.Map<Genre>(addGenre);
        GenreDomainModel = await _repository.CreateGenreAsync(GenreDomainModel);
        var GenreDTO = _mapper.Map<GenreDTO>(GenreDomainModel);
            return Ok(GenreDTO);
        
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteAsync(Guid Id) 
        {
        var result = await _repository.DeleteAsync(Id);
            if (result is null)
            {
                BadRequest("Not Found Genre With your ID!");
            }

            return Ok(result);
        
        }
    }
}








