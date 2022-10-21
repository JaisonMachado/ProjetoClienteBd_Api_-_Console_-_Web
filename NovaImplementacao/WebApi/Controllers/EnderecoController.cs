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
    public class EnderecoController : ControllerBase
    {
        private readonly ClienteContext _context;

        public EnderecoController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/Contatos
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetTabelaEndereco()
        {
            return await _context.TabelaEnderecoCliente.ToListAsync();
        }

        // GET: api/Contatos/5
        [HttpGet("ObterEndereco/{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.TabelaEnderecoCliente.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        [HttpGet("ObterPorClienteId/{id}")]
        public async Task<ActionResult<Endereco>> GetEnderecoPorClienteId(int id)
        {           
            var endereco = await _context.TabelaEnderecoCliente.SingleOrDefaultAsync(x=>x.ClienteId==id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        [HttpGet("ObterNomeDoCliente/{nome}")]
        public async Task<ActionResult<Endereco>> GetEnderecoPorNomeDoCiente(string nome)
        {
            var clienteQuery =  _context.TabelaCliente.Where(x => x.ClienteNome.Contains(nome));
            Cliente cliente=new Cliente();
            if (cliente == null)
            {
                return NotFound();
            }
            
            foreach(var i in clienteQuery){cliente.EnderecoId=i.EnderecoId;}

            
            var endereco = await _context.TabelaEnderecoCliente.FindAsync(cliente.EnderecoId);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        // PUT: api/Contatos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Alterar")]
        public async Task<IActionResult> PutEndereco(Endereco endereco)
        {
           if (endereco == null)
            {
                return BadRequest();
            }
            
            _context.Entry(endereco).State = EntityState.Modified;
 
             try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(endereco.ClienteId))
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
        public async Task<ActionResult<Endereco>> PostEnereco(Endereco endereco)
        {
            if (endereco == null)
            {
                return BadRequest();
            }

            var verificaendereco = await _context.TabelaEnderecoCliente.SingleOrDefaultAsync(x=> x.ClienteId==endereco.ClienteId);
            if(verificaendereco!=null)
                return verificaendereco;

            _context.TabelaEnderecoCliente.Add(endereco);
            await _context.SaveChangesAsync();
            var retorno = CreatedAtAction("Getendereco", new { id = endereco.EnderecoId }, endereco);
            Cliente cliente = await _context.TabelaCliente.FindAsync(endereco.ClienteId);
            cliente.EnderecoId = endereco.EnderecoId;
            _context.Entry(cliente).State=EntityState.Modified;
            _context.SaveChanges();
            return retorno;
        }

        // DELETE: api/Contatos/5
        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _context.TabelaEnderecoCliente.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.TabelaEnderecoCliente.Remove(endereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoExists(int id)
        {
            return _context.TabelaEnderecoCliente.Any(e => e.EnderecoId == id);
        }
    }
}
