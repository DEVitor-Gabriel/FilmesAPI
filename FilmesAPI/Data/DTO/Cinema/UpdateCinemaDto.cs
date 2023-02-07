using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O Nome é obrigatorio")]
        public string Nome { get; set; }
    }
}
