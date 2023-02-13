using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Sessao
{
    public class CreateSessaoDto
    {
        [Required]
        public int FilmeId { get; set; }

    }
}
