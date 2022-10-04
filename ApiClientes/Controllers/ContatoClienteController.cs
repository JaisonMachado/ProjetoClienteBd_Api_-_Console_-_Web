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
    public class ContatosController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ContatosController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/Contats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoCliente>>> GetTabelaContatos()
        {
            return await _context.TabelaContatos.ToListAsync();
        }

        // GET: api/Contats/5
        [HttpGet("ObterPorCliente{id}")]

       // public ContatoCliente GetByIdCliente(int id) => _context.TabelaContatos.SingleOrDefault(c => c.Clientechave == id);
        
        public ActionResult<ContatoCliente> GetContato(int id)
        {
            //var tarefa = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));

            //Contato contato =await _context.TabelaContatos.FindAsync(id);
            /*var resultado = from cli in _context.TabelaContatos
                            where cli.Clientechave == id
                            select cli;

            int idBd=0;
            foreach(var x in resultado)
            {
                    idBd = x.Id;
            }
           var contato = await _context.TabelaContatos.FindAsync(idBd);
            */
            ContatoCliente contato = _context.TabelaContatos.SingleOrDefault(c => c.Clientechave == id);


            if (contato == null)
            {
                return NotFound();
            }

            return contato;
        }
         

        // PUT: api/Contats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("Alterar{id}")]
        public async Task<IActionResult> PutContato(int id, ContatoCliente contato)
        {
            if (id != contato.Id)
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
                if (!ContatoExists(id))
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

        // POST: api/Contats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost("Incluir")]
        public async Task<ActionResult> PostContato(ContatoCliente contato)
        {
            
            try
            {
                _context.TabelaContatos.Add(contato);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetContato", new { id = contato.Id }, contato);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao gravar no BD:" + ex.Message.ToString());
            }

        }
            

        private bool ContatoExists(int id)
        {
            return _context.TabelaContatos.Any(e => e.Id == id);
        }
    
    }
}