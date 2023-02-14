using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository.Interfaces
{
    interface ICinemaRepository : ICommand<Cinema>, IQuery<Cinema>
    {
        
    }
}