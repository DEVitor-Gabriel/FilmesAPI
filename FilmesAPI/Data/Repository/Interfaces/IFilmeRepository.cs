using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository.Interfaces
{
    interface IFilmeRepository : ICommand<Filme>, IQuery<Filme>
    {
        
    }
}