using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository.Interfaces
{
    interface ISessaoRepository: ICommand<Sessao>, IQuery<Sessao>
    {
        
    }
}