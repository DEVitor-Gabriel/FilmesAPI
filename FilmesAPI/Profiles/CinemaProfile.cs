using AutoMapper;
using FilmesAPI.Data.DTO.Cinema;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cinemaDto => cinemaDto.Endereco,
                opt => opt.MapFrom(cinema => cinema.Endereco));
                
            CreateMap<UpdateCinemaDto, Cinema>();
            CreateMap<CreateCinemaDto, Cinema>();
        }
    }
}
