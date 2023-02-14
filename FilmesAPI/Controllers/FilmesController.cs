using FilmesAPI.Data.DTO.Filme;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{
    private IFilmeService _filmeService;
    public FilmesController(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _filmeService.InserirFilme(filmeDto);
        return CreatedAtAction(
                nameof(LerFilmePorId),
                new { id = filme.Id },
                filme
            );
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> LerFilmes(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 50,
            [FromQuery] string? nomeCinema = null
        )
    {
        return _filmeService.BuscarTodosFilmes();

        // if (nomeCinema == null)
        // {
        //     return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList());
        // }
        // return _mapper.Map<List<ReadFilmeDto>>(
        //     _context
        //     .Filmes
        //     .Skip(skip)
        //     .Take(take)
        //     .Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome == nomeCinema))
        //     .ToList()
        // );
    }

    [HttpGet("{id}")]
    public IActionResult LerFilmePorId(int id)
    {
        
        ReadFilmeDto? filmeDto = _filmeService.BuscarFilmePorId(id);

        if (filmeDto == null) return NotFound();
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeUpdateDto)
    {
        ReadFilmeDto? filmeDto = _filmeService.BuscarFilmePorId(id);
        if (filmeDto == null) return NotFound();

        _filmeService.AlterarFilme(id, filmeUpdateDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveFilme(int id)
    {
        ReadFilmeDto? filmeDto = _filmeService.BuscarFilmePorId(id);
        if (filmeDto == null) return NotFound();

        _filmeService.ExcluirFilme(id);
        return NoContent();
    }

}
