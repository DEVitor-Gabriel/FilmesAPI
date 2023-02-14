using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository.Interfaces
{
    interface IEnderecoRepository : ICommand<Endereco>, IQuery<Endereco>
    {
        
    }
}