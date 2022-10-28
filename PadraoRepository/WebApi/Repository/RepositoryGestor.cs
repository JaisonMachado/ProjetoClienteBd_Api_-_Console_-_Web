using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Repository
{
    
    public class RepositoryGestor : IGestor
    {
        private readonly ClienteContext _context;

        public RepositoryGestor(ClienteContext context)
        {
            _context = context;
        }



        //----------------------    CLIENTE  ----------------------------

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            var newCliente = await _context.TabelaCliente.AddAsync(cliente);
            Cliente clienteCriado = newCliente.Entity;
            _context.SaveChangesAsync();
            return clienteCriado;
        }

        public async Task DeleteCliente(int id)
        {
            var cliente = await _context.TabelaCliente.FindAsync(id);
            Contato contato = new Contato();
            Endereco endereco = new Endereco();

            if(cliente.ContatoId!=0){
                contato = await _context.TabelaContatoCliente.FindAsync(cliente.ContatoId);
                _context.TabelaContatoCliente.Remove(contato);
            }
            if(cliente.EnderecoId!=0){
                endereco = await _context.TabelaEnderecoCliente.FindAsync(cliente.EnderecoId);
                _context.TabelaEnderecoCliente.Remove(endereco);
            }
            _context.TabelaCliente.Remove(cliente);            
            
            //_context.Entry(cliente).State=EntityState.Deleted;
            _context.SaveChanges();
        }

        public async Task<Cliente> GetById(int id)
        {
            Cliente cliente = await _context.TabelaCliente.FindAsync(id);            
            return cliente;
        }

        public async Task<List<Cliente>> GetByName(string name)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            var clientes =  _context.TabelaCliente.Where(x => x.ClienteNome.ToLower().Contains(name.ToLower()));
            foreach(var item in clientes)
            {
                listaClientes.Add(item);
            }
            return listaClientes;
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            Cliente clienteBd = await _context.TabelaCliente.FindAsync(cliente.ClienteId);
            clienteBd.ClienteNome = cliente.ClienteNome;
            clienteBd.Cpf=cliente.Cpf;
            clienteBd.ClienteAtivo = cliente.ClienteAtivo;
            clienteBd.ContatoId=cliente.ContatoId;
            clienteBd.EnderecoId=cliente.EnderecoId;

            _context.Entry(clienteBd).State = EntityState.Modified;
            _context.SaveChanges();
            return clienteBd;


        }

        
        public async Task<List<Cliente>> GetAll()
        {
            var listaCliente = await _context.TabelaCliente.ToListAsync<Cliente>();
            
            return listaCliente;
        
        }

        public async Task<bool> ClienteExists(int id)
        {
            return await _context.TabelaCliente.AnyAsync(e => e.ClienteId == id);
        }



        //-------------------     CONTATO     ---------------------------------

        public async Task<Contato> GetContato(int id)
        {
            Contato contato = await _context.TabelaContatoCliente.FindAsync(id);
            return contato;
        }

        public async Task<Contato> GetContatoByClienteId(int idCliente)
        {
            Cliente cliente = await _context.TabelaCliente.FindAsync(idCliente);
            Contato contato = await _context.TabelaContatoCliente.FindAsync(cliente.ContatoId);
            return contato;
        }

        public async Task DeleteContatoById(int id)
        {
            Contato contato = await _context.TabelaContatoCliente.FindAsync(id);
            _context.TabelaContatoCliente.Remove(contato);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Contato> AddContato(Contato contato)
        {
            var newContato = await _context.TabelaContatoCliente.AddAsync(contato);
            Contato contatoCriado = newContato.Entity;
            _context.SaveChanges();
            return contatoCriado;
        }

        public async Task<Contato> UpdateContato(Contato contato)
        {
            Contato contatoBd = await _context.TabelaContatoCliente.FindAsync(contato.ContatoId);
            contatoBd.Email=contato.Email;
            contatoBd.ContatoAtivo=contato.ContatoAtivo;
            contatoBd.Telefone=contato.Telefone;
            contatoBd.ClienteId=contato.ClienteId;

            _context.Entry(contatoBd).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contatoBd;
        }

        public async Task<List<Contato>> GetContatoList()
        {
            List<Contato> listaContatos = await _context.TabelaContatoCliente.ToListAsync();
            return listaContatos;
        }

        public async Task<Contato> GetContatoByClienteName(string name)
        {
            Cliente cliente = await _context.TabelaCliente.SingleOrDefaultAsync(x => x.ClienteNome == name);
            Contato contato = await _context.TabelaContatoCliente.FindAsync(cliente.ContatoId);
            return contato;
        }

        public async Task<bool> ContatoExists(int id)
        {
            return await _context.TabelaContatoCliente.AnyAsync(e => e.ContatoId == id);
        }


        //--------------------------        ENDERECO        -----------------------------

        public async Task<Endereco> AddEndereco(Endereco endereco)
        {
            var newEndereco = await _context.TabelaEnderecoCliente.AddAsync(endereco);
            _context.SaveChanges();
            Endereco enderecoCriado = newEndereco.Entity;
            return enderecoCriado;
        }

        public async Task<Endereco> UpdateEndereco(Endereco endereco)
        {
            Endereco enderecoBd = await _context.TabelaEnderecoCliente.FindAsync(endereco.EnderecoId);
            enderecoBd.Logradouro=endereco.Logradouro;
            enderecoBd.EnderecoAtivo=endereco.EnderecoAtivo;
            enderecoBd.Cidade=endereco.Cidade;
            enderecoBd.Bairro=endereco.Bairro;
            enderecoBd.ClienteId=endereco.ClienteId;

            _context.Entry(enderecoBd).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return enderecoBd;
        
    }

        public async Task DeleteEndereco(int id)
        {
            Endereco endereco = await _context.TabelaEnderecoCliente.FindAsync(id);
            _context.TabelaEnderecoCliente.Remove(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task<Endereco> GetEndereco(int id)
        {
            Endereco endereco = await _context.TabelaEnderecoCliente.FindAsync(id);
            return endereco;
        }

        public async Task<Endereco> GetEnderecoByClienteId(int idCliente)
        {
            Cliente cliente = await _context.TabelaCliente.FindAsync(idCliente);
            Endereco endereco = await _context.TabelaEnderecoCliente.FindAsync(cliente.EnderecoId);
            return endereco;
        }

        public async Task<List<Endereco>> GetEnderecoList()
        {
            List<Endereco> enderecoList = await _context.TabelaEnderecoCliente.ToListAsync();
            return enderecoList;
        }

        public async Task<Endereco> GetEnderecoByClienteName(string name)
        {
            Cliente cliente = await _context.TabelaCliente.SingleOrDefaultAsync(x=>x.ClienteNome == name);
            Endereco endereco = await _context.TabelaEnderecoCliente.FindAsync(cliente.EnderecoId);
            return endereco;
        }

        public async Task<bool> EnderecoExists(int id)
        {
            return await _context.TabelaEnderecoCliente.AnyAsync(e => e.EnderecoId==id);
        }

        
    }
}
