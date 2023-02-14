using FilmesAPI.Data.DTO.Filme;
using FilmesAPI.Models;

namespace FilmesAPI.Services  
{
    public interface IFilmeService
    {
        Filme InserirFilme(CreateFilmeDto filmeDto);
        void AlterarFilme(int id, UpdateFilmeDto filmeDto);

        void ExcluirFilme(int id);

        ICollection<ReadFilmeDto> BuscarTodosFilmes();
        ReadFilmeDto? BuscarFilmePorId(int id);
    }
}