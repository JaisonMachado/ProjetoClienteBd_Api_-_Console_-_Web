using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Repositories;
using WebApi.Context;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IGestor _context;

        public ClientesController(IGestor context)
        {
            _context = context;
        }

        //------------------        CLIENTE     -------------------------------------
        // POST: api/Clientes

        [HttpPost("IncluirCliente")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            if (cliente == null) return BadRequest();

            var clienteInserido = await _context.AddCliente(cliente);
            return clienteInserido;
            

           // return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        // GET: api/Clientes/
        [HttpGet("ObterCliente/{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.GetById(id);
            if(cliente==null)
                return NotFound();
            return cliente;
        }

        // GET: api/Clientes
        [HttpGet("ListarClientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetTabelaCliente()
        {
            var listaClientes = await _context.GetAll();
            if (listaClientes == null) return NotFound();
            return listaClientes;
                
        }

        [HttpGet("ObterClientePorNome/{nome}")]
        public async Task<ActionResult<List<Cliente>>> GetClienteByName(string nome)
        {

            List<Cliente> cliente = await _context.GetByName(nome);
            
            if (cliente == null)
            {
                return NotFound();
            }           

            return cliente;
        }

        // PUT: api/Clientes/5
        [HttpPut("AlterarCliente")]
        public async Task<IActionResult> PutCliente(Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();
            if (!(await _context.ClienteExists(cliente.ClienteId)))
            {
                return NotFound();
            }
            var clienteBd = await _context.UpdateCliente(cliente);         
            return Ok(clienteBd);
        }


        // DELETE: api/Clientes/5
        [HttpDelete("RemoverCliente/{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {   

            if(!await _context.ClienteExists(id))
                return BadRequest();

            await _context.DeleteCliente(id);

            return NoContent();
        }



        //------------------------          CONTATO         -----------------------

        // POST: api/Contato

        [HttpPost("IncluirContato")]
        public async Task<ActionResult<Contato>> PostContato (Contato contato)
        {
            if (contato == null) return BadRequest();

            var contatoInserido = await _context.AddContato(contato);
            return contatoInserido;


            //return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        // GET: api/Contato
        [HttpGet("ObterContato/{id}")]
        public async Task<ActionResult<Contato>> GetContato (int id)
        {
            var contato = await _context.GetContato(id);
            if (contato == null)
                return NotFound();
            return contato;
        }

        // GET: api/Contato
        [HttpGet("ListarContatos")]
        public async Task<ActionResult<IEnumerable<Contato>>> GetTabeleContato()
        {
            var listaContatos = await _context.GetContatoList();
            if (listaContatos == null) return NotFound();
            return listaContatos;

        }

        [HttpGet("ObterContatoPorNomeDoCliente/{nome}")]
        public async Task<ActionResult<Contato>> GetByNameCliente (string name)
        {

            var contato = await _context.GetContatoByClienteName(name);

            if (contato == null)
            {
                return NotFound();
            }

            return contato;
        }

        [HttpGet("ObterContatoPorClienteId/{id}")]
        public async Task<ActionResult<Contato>> GetByClienteId(int id)
        {

            var contato = await _context.GetContatoByClienteId(id);

            if (contato == null)
            {
                return NotFound();
            }

            return contato;
        }

        // PUT: api/Contato
        [HttpPut("AlterarContato")]
        public async Task<IActionResult> PutContato (Contato contato)
        {
            if (contato == null)
                return BadRequest();
            if (!(await _context.ContatoExists(contato.ContatoId)))
            {
                return NotFound();
            }
            var contatoBd = await _context.UpdateContato(contato);
            return Ok(contatoBd);
        }


        // DELETE: api/Contato
        [HttpDelete("RemoverContato/{id}")]
        public async Task<IActionResult> DeleteContato (int id)
        {

            if (!await _context.ContatoExists(id))
                return BadRequest();

            await _context.DeleteContatoById(id);

            return NoContent();
        }



        //---------------------         ENDERECO        ----------------------------

        // POST: api/Endereco

        [HttpPost("IncluirEndereco")]
        public async Task<ActionResult<Endereco>> PostEndereco (Endereco endereco)
        {
            if (endereco == null) return BadRequest();

            var enderecoInserido = await _context.AddEndereco(endereco);
            return enderecoInserido;


            //return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        // GET: api/Endereco
        [HttpGet("ObterEnderecoPorClienteId/{id}")]
        public async Task<ActionResult<Endereco>> GetEnderecoByClienteId (int id)
        {
            var endereco = await _context.GetEnderecoByClienteId(id);
            if (endereco == null)
                return NotFound();
            return endereco;
        }


        // GET: api/Endereco
        [HttpGet("ObterEndereco/{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco (int id)
        {
            var endereco = await _context.GetEndereco(id);
            if (endereco == null)
                return NotFound();
            return endereco;
        }

        [HttpGet("ObterEnderecoPorNomeDoCliente/{nome}")]
        public async Task<ActionResult<Endereco>> GetEnderecoByNameCliente(string name)
        {

            var endereco = await _context.GetEnderecoByClienteName(name);

            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }


        // GET: api/Endereco
        [HttpGet("ListarEnderecos")]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetTabelaEndereco ()
        {
            var listaEndereco = await _context.GetEnderecoList();
            if (listaEndereco== null) return NotFound();
            return listaEndereco;

        }

       

        // PUT: api/Endereco
        [HttpPut("AlterarEndereco")]
        public async Task<IActionResult> Putendereco (Endereco endereco)
        {
            if (endereco == null)
                return BadRequest();
            if (!(await _context.EnderecoExists(endereco.EnderecoId)))
            {
                return NotFound();
            }
            var enderecoBd = await _context.UpdateEndereco(endereco);
            return Ok(enderecoBd);
        }


        // DELETE: api/Endereco
        [HttpDelete("RemoverEndereco/{id}")]
        public async Task<IActionResult> DeleteEndereco (int id)
        {

            if (!await _context.EnderecoExists(id))
                return BadRequest();

            await _context.DeleteEndereco(id);

            return NoContent();
        }


    }
}
