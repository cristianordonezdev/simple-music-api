using AutoMapper;
using music.Models;
using music.Models.Dtos;

namespace music.Mappings
{
    public class MainMapping : Profile
    {
        // origin - destination

        public MainMapping()
        {
            CreateMap<AddSong, Song>().ReverseMap();
            CreateMap<AddGenre, Genre>().ReverseMap();
        }
    }
}
