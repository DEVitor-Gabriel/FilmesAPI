using FilmesAPI.Data.DTO.Endereco;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Cinema
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ReadEnderecoDto ReadEnderecoDto { get; set; }
    }
}
