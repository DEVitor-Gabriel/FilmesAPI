using System.ComponentModel.DataAnnotations;
using FilmesAPI.Data.DTO.Sessao;

namespace FilmesAPI.Data.DTO.Filme
{
    public class ReadFilmeDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }

        public string? Genero { get; set; }

        public int Duracao { get; set; }

        public DateTime? HoraDaConsulta { get; set; } = DateTime.Now;

        public virtual ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}
