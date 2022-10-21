using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ContatosController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/Contatos
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Contato>>> GetTabelaContato()
        {
            return await _context.TabelaContatoCliente.ToListAsync();
        }

        // GET: api/Contatos/5
        [HttpGet("ObterContato/{id}")]
        public async Task<ActionResult<Contato>> GetContato(int id)
        {
            var contato = await _context.TabelaContatoCliente.FindAsync(id);

            if (contato == null)
            {
                return NotFound();
            }

            return contato;
        }

        [HttpGet("ObterPorClienteId/{id}")]
        public async Task<ActionResult<Contato>> GetContatoPorCienteId(int id)
        {
            var contato = await _context.TabelaContatoCliente.SingleOrDefaultAsync(x=> x.ClienteId==id);

            if (contato == null)
            {
                return NotFound();
            }

            return contato;
        }

        [HttpGet("ObterNomeDoCliente/{nome}")]
        public async Task<ActionResult<Contato>> GetContatoPorNomeDoCiente(string nome)
        {
            
            var clienteQuery =  _context.TabelaCliente.Where(x => x.ClienteNome.Contains(nome));
            Cliente cliente=new Cliente();
            if (cliente == null)
            {
                return NotFound();
            }
            foreach(var i in clienteQuery){ cliente.ContatoId=i.ContatoId;}
            var contato = await _context.TabelaContatoCliente.FindAsync(cliente.ContatoId);

            if (contato == null)
            {
                return NotFound();
            }

            return contato;
        }

        // PUT: api/Contatos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Alterar")]
        public async Task<IActionResult> PutContato(Contato contato)
        {
            if (contato == null)
            {
                return BadRequest();
            }

           
            _context.Entry(contato).State = EntityState.Modified;
  
                     
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(contato.ClienteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contatos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Adicionar")]
        public async Task<ActionResult<Contato>> PostContato(Contato contato)
        {
            Contato verificaContato = new Contato();
            if (contato == null)
            {
                return BadRequest();
            }

            
            verificaContato = await _context.TabelaContatoCliente.SingleOrDefaultAsync(x=> x.ClienteId==contato.ClienteId);
            if(verificaContato!=null)
                return verificaContato;

            _context.TabelaContatoCliente.Add(contato);
            await _context.SaveChangesAsync();
            var retorno = CreatedAtAction("GetContato", new { id = contato.ContatoId }, contato);
            Cliente cliente =await _context.TabelaCliente.FindAsync(contato.ClienteId);
            cliente.ContatoId=contato.ContatoId;
            
             _context.Entry(cliente).State=EntityState.Modified;
            _context.SaveChanges();
            return retorno;
        }

        // DELETE: api/Contatos/5
        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> DeleteContato(int id)
        {
            var contato = await _context.TabelaContatoCliente.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }

            _context.TabelaContatoCliente.Remove(contato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContatoExists(int id)
        {
            return _context.TabelaContatoCliente.Any(e => e.ContatoId == id);
        }
    }
}
