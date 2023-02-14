// using AutoMapper;
// using FilmesAPI.Data;
// using FilmesAPI.Data.DTO.Sessao;
// using FilmesAPI.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace FilmesAPI.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class SessaoController : ControllerBase
// {

//     private FilmeContext _context;
//     private IMapper _mapper;

//     public SessaoController(FilmeContext context, IMapper mapper)
//     {
//         _context = context;
//         _mapper = mapper;
//     }

//     [HttpPost]
//     public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
//     {
//         Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

//         _context.Sessoes.Add(sessao);
//         _context.SaveChanges();
//         return CreatedAtAction(
//                 nameof(LerSessaoPorId),
//                 new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId },
//                 sessao
//             );
//     }

//     [HttpGet]
//     public IEnumerable<ReadSessaoDto> LerSessoes(
//             [FromQuery] int skip = 0,
//             [FromQuery] int take = 50
//         )
//     {
//         return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.Skip(skip).Take(take).ToList());
//     }

//     [HttpGet("{filmeId}/{cinemaId}")]
//     public IActionResult LerSessaoPorId(int filmeId, int cinemaId)
//     {
//         Sessao? sessao = _context.Sessoes.FirstOrDefault((sessao) => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);

//         if (sessao == null) return NotFound();

//         ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
//         return Ok(sessaoDto);
//     }

//     //[HttpPut("{id}")]
//     //public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
//     //{
//     //    Sessao? sessao = _context.Sessaos.FirstOrDefault(
//     //        sessao => sessao.Id == id
//     //        );

//     //    if (sessao == null) return NotFound();
//     //    _mapper.Map(sessaoDto, sessao);
//     //    _context.SaveChanges();
//     //    return NoContent();
//     //}

//     [HttpDelete("{filmeId}/{cinemaId}")]
//     public IActionResult RemoveSessao(int filmeId, int cinemaId)
//     {
//         Sessao? sessao = _context.Sessoes.FirstOrDefault(
//             sessao => sessao.FilmeId == filmeId &&
//                     sessao.CinemaId == cinemaId
//             );

//         if (sessao == null) return NotFound();
//         _context.Remove(sessao);
//         _context.SaveChanges();
//         return NoContent();
//     }

// }
