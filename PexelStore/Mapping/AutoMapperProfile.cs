using AutoMapper;
using PexelStore.Models.Domain;
using PexelStore.Models.DTO;

namespace PexelStore.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Genre,GenreDTO>().ReverseMap();
            CreateMap<Genre, AddGenreDTO>().ReverseMap();
            CreateMap<Genre, UpdateGenreDTO>().ReverseMap();
            CreateMap<Games , AddGameDTO>().ReverseMap().ForMember(o => o.Poster, x => x.Ignore());
            CreateMap<Games, UpdateGameDTO>().ReverseMap().ForMember(o => o.Poster, x => x.Ignore());
        }
    }
}
