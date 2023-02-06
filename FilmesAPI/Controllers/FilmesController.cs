﻿using FilmesAPI.Data;
using FilmesAPI.Data.DTO;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{

    private FilmeContext _context;

    public FilmesController(FilmeContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
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
}
