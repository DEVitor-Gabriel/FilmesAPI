using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    public int Id { get; set; }

    [Required(ErrorMessage ="O titulo é obrigatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O genero é obrigatorio")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "A duração é obrigatorio")]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}
