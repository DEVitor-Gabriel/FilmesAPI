using AutoMapper;
using FilmesAPI.Data.DTO.Filme;
using FilmesAPI.Data.Repository.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Services.Handlers
{
    class FilmeService : IFilmeService
    {
        private IFilmeRepository _filmeRepository;
        private IMapper _mapper;

        public FilmeService(IFilmeRepository filmeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _filmeRepository = filmeRepository;
        }

        void IFilmeService.AlterarFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filmeOld = _mapper.Map<Filme>(filmeDto);
            _filmeRepository.Alterar(id, filmeOld);
        }

        ReadFilmeDto? IFilmeService.BuscarFilmePorId(int id)
        {
            Filme? filme = _filmeRepository.BuscarPorId(id);
            if (filme == null) return null;

            ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return filmeDto;
        }

        ICollection<ReadFilmeDto> IFilmeService.BuscarTodosFilmes()
        {
            return _mapper.Map<List<ReadFilmeDto>>(_filmeRepository.BuscarTodos());
        }

        void IFilmeService.ExcluirFilme(int id)
        {
            _filmeRepository.Excluir(id);
        }

        Filme IFilmeService.InserirFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _filmeRepository.Inserir(filme);
            return filme;
        }
    }
}