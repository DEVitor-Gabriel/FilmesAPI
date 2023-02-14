using FilmesAPI.Data.EfCore;
using FilmesAPI.Data.Repository.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository.EfCore
{
    class FilmeRepository : IFilmeRepository
    {
        private AppDbContext _context;
        public FilmeRepository(AppDbContext context)
        {
            _context = context;
        }
        void ICommand<Filme>.Alterar(int id, Filme obj)
        {
            Filme? filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id
            );

            if (filme != null)
            {
                filme.Titulo = obj.Titulo;
                filme.Genero = obj.Genero;
                filme.Duracao = obj.Duracao;
                _context.SaveChanges();
            }
        }

        Filme IQuery<Filme>.BuscarPorId(int id)
        {
            return _context.Filmes.First((filme) => filme.Id == id);
        }

        ICollection<Filme> IQuery<Filme>.BuscarTodos()
        {
            return _context
            .Filmes
            // .Skip(skip)
            // .Take(take)
            // .Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome == nomeCinema))
            .ToList();
        }

        void ICommand<Filme>.Excluir(int id)
        {
            Filme? filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id
            );

            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();

            }

        }

        void ICommand<Filme>.Inserir(Filme obj)
        {
            _context.Filmes.Add(obj);
            _context.SaveChanges();
        }
    }
}