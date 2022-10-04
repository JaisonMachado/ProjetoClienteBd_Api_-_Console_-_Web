using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClientes.Context;
using ApiClientes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase

    {
        private readonly ClienteContext _context;

        public ClienteController (ClienteContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetTabelaClientes()
        {
            return await _context.TabelaClientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("ObterPor{id}")]
        public async Task<ActionResult<Cliente>> GetById (int id)
        {
            var cliente = await _context.TabelaClientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Esta ID não existe");
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Alterar{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
           
            var clienteBd = await _context.TabelaClientes.FindAsync(id);
            clienteBd.Nome=cliente.Nome;
            clienteBd.Cpf=cliente.Cpf;
            clienteBd.Ativo=cliente.Ativo;
            _context.Entry(clienteBd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Incluir")]
        public async Task<ActionResult<Cliente>> AddCliente (Cliente cliente)
        {
            _context.TabelaClientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        [HttpGet("UltimoId")]
        public async Task<ActionResult<int>> GetUltimoId()
        {
            var clientesLista= _context.TabelaClientes.ToListAsync().Result;
            int ultimoId=0;
            foreach(var item in clientesLista)
            {
                ultimoId=item.ClienteId;
            }
            return ultimoId;
        }

        // DELETE: api/Clientes/5
        

        private bool ClienteExists(int id)
        {
            return _context.TabelaClientes.Any(e => e.ClienteId == id);
        }
    }
    
}