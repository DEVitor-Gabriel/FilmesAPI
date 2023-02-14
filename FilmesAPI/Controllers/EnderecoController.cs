// using AutoMapper;
// using FilmesAPI.Data;
// using FilmesAPI.Data.DTO.Endereco;
// using FilmesAPI.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace FilmesAPI.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class EnderecosController : ControllerBase
// {

//     private FilmeContext _context;
//     private IMapper _mapper;

//     public EnderecosController(FilmeContext context, IMapper mapper)
//     {
//         _context = context;
//         _mapper = mapper;
//     }

//     [HttpPost]
//     public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
//     {
//         Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

//         _context.Enderecos.Add(endereco);
//         _context.SaveChanges();
//         return CreatedAtAction(
//                 nameof(LerEnderecoPorId),
//                 new { id = endereco.Id },
//                 endereco
//             );
//     }

//     [HttpGet]
//     public IEnumerable<ReadEnderecoDto> LerEnderecos(
//             [FromQuery] int skip = 0,
//             [FromQuery] int take = 50
//         )
//     {
//         return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take).ToList());
//     }

//     [HttpGet("{id}")]
//     public IActionResult LerEnderecoPorId(int id)
//     {
//         Endereco? endereco = _context.Enderecos.FirstOrDefault((endereco) => endereco.Id == id);

//         if (endereco == null) return NotFound();

//         ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
//         return Ok(enderecoDto);
//     }

//     [HttpPut("{id}")]
//     public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
//     {
//         Endereco? endereco = _context.Enderecos.FirstOrDefault(
//             endereco => endereco.Id == id
//             );

//         if (endereco == null) return NotFound();
//         _mapper.Map(enderecoDto, endereco);
//         _context.SaveChanges();
//         return NoContent();
//     }

//     [HttpDelete("{id}")]
//     public IActionResult RemoveEndereco(int id)
//     {
//         Endereco? endereco = _context.Enderecos.FirstOrDefault(
//             endereco => endereco.Id == id
//             );

//         if (endereco == null) return NotFound();
//         _context.Remove(endereco);
//         _context.SaveChanges();
//         return NoContent();
//     }

// }
