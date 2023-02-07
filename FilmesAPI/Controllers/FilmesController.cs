using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmesController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
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
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult LerFilmePorId(int id)
    {
        Filme? filme =  _context.Filmes.FirstOrDefault((filme) => filme.Id == id);

        if (filme == null) return NotFound();
        return Ok(filme);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id
            );

        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }
}
