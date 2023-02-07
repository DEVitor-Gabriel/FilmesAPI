using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O Nome é obrigatorio")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
    }
}
