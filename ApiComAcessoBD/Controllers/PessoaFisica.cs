using ApiComAcessoBD.Data;
using ApiComAcessoBD.Dtos;
using ApiComAcessoBD.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiComAcessoBD.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public PessoaFisicaController(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarPessoa([FromBody] PessoaDto pessoaDto)
        {
            //Aqui estou fazendo o mapeamento de um objeto do tipo DTO (Data Transfer Object), que nada mais é
            //que um objeto com as propriedades básicas para que seja possível cadastrar uma nova pessoa no sistema.
            Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);

            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(PesquisarPessoaPorId), new { id = pessoa.Id }, pessoa);
        }

        [HttpGet]
        public IActionResult PesquisarPessoas()
        {
            IEnumerable<Pessoa> pessoas = _context.Pessoa.Where(x => x.IdTipoPessoa == 1)
                                                         .Include(x => x.PessoaFisica)
                                                         .Include(x => x.PessoaTelefones)
                                                         .Include(x => x.PessoaEnderecos)
                                                         .ToList();

            if(!pessoas.Any())
                return NotFound();

            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult PesquisarPessoaPorId(int id)
        {
            Pessoa? pessoa = _context.Pessoa.Include(x => x.PessoaFisica)
                                            .Include(x => x.PessoaTelefones)
                                            .Include(x => x.PessoaEnderecos)
                                            .FirstOrDefault(x => x.Id == id && x.IdTipoPessoa == 1);

            if(pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        [HttpGet(), Route("PesquisarPorNome")]
        public IActionResult PesquisarPessoaPorNome(string nome)
        {
            List<Pessoa>? pessoa = _context.Pessoa.Where(x => x.PessoaFisica.Nome.Contains(nome) && x.IdTipoPessoa == 1)
                                                  .Include(x => x.PessoaFisica)
                                                  .Include(x => x.PessoaTelefones)
                                                  .Include(x => x.PessoaEnderecos)
                                                  .ToList();

            if (!pessoa.Any())
                return NotFound();

            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPessoa(int id, [FromBody] PessoaDto pessoaDto)
        {
            Pessoa? pessoa = _context.Pessoa.Include(x => x.PessoaFisica)
                                            .Include(x => x.PessoaTelefones)
                                            .Include(x => x.PessoaEnderecos)
                                            .FirstOrDefault(x => x.Id == id && x.IdTipoPessoa == 1);

            if (pessoa == null)
                return NotFound();

            _mapper.Map(pessoaDto, pessoa);
            _context.SaveChanges();

            return NoContent();
        }
    }
}