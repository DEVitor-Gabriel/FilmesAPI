using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO.Cinema;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemasController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public CinemasController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(
                nameof(LerCinemaPorId),
                new { id = cinema.Id },
                cinema
            );
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> LerCinemas(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 50
        )
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult LerCinemaPorId(int id)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault((cinema) => cinema.Id == id);

        if (cinema == null) return NotFound();

        ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(
            cinema => cinema.Id == id
            );

        if (cinema == null) return NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveCinema(int id)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(
            cinema => cinema.Id == id
            );

        if (cinema == null) return NotFound();
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}
