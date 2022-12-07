using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{

    public static List<Filme> filmes = new();
    public static int id = 0;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(
                nameof(LerFilmePorId),
                new { id = filme.Id },
                filme
            );
    }

    [HttpGet]
    public IEnumerable<Filme> LerFilmes(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 50
        )
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult LerFilmePorId(int id)
    {
        Filme? filme =  filmes.FirstOrDefault((filme) => filme.Id == id);

        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
