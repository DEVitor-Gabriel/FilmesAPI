﻿using AutoMapper;
using FilmesAPI.Data.DTO.Endereco;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
