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
    public class ClientesController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ClientesController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetTabelaCliente()
        {
            return await _context.TabelaCliente.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("Obter/{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.TabelaCliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }


         [HttpGet("ObterPorNome/{nome}")]
        public async Task<ActionResult<Cliente>> GetClienteByName(string nome)
        {

            var clienteQuery =   _context.TabelaCliente.Where(x => x.ClienteNome.Contains(nome));
            Cliente cliente=new Cliente();
            if (cliente == null)
            {
                return NotFound();
            }
            foreach(var i in clienteQuery)
            { 
                cliente.ContatoId=i.ContatoId;
                cliente.ClienteAtivo=i.ClienteAtivo;
                cliente.ClienteId=i.ClienteId;
                cliente.ClienteNome=i.ClienteNome;
                cliente.Cpf=i.Cpf;
                cliente.EnderecoId=i.EnderecoId;                

            }            
            
            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Alterar")]
        public async Task<IActionResult> PutCliente(Cliente cliente)
        {
            if(cliente==null)
                return BadRequest();
            
            _context.Entry(cliente).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.ClienteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cliente);
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Incluir")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            if(cliente==null) return BadRequest();

            _context.TabelaCliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            
            var cliente = await _context.TabelaCliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            
            if(cliente.ContatoId!=0)
            {
                var contato = await _context.TabelaContatoCliente.FindAsync(cliente.ContatoId);
                if(contato!=null)
                _context.TabelaContatoCliente.Remove(contato);
            }
            
            if(cliente.EnderecoId!=0)
            {
                var endereco = await _context.TabelaEnderecoCliente.FindAsync(cliente.EnderecoId);
                if(endereco!=null)
                _context.TabelaEnderecoCliente.Remove(endereco);
            }
            

            _context.TabelaCliente.Remove(cliente);

            
                        
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.TabelaCliente.Any(e => e.ClienteId == id);
        }
    }
}
