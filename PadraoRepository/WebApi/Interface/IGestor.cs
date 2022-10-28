using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Interface
{
    public interface IGestor
    {
        //-------------------   CLIENTE ------------------
        Task<Cliente> GetById(int id);
        Task<List<Cliente>> GetByName(string name);
        Task<List<Cliente>> GetAll();
        Task<Cliente> AddCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task DeleteCliente(int id);
        Task<bool> ClienteExists(int id);

        //--------------------  CONTATO ----------------------

        Task<Contato> GetContato(int id);
        Task<Contato> GetContatoByClienteId(int idCliente);
        Task DeleteContatoById(int id);
        Task<Contato> AddContato(Contato contato);
        Task<Contato> UpdateContato(Contato contato);
        Task<List<Contato>> GetContatoList();
        Task<bool> ContatoExists(int id);
        Task<Contato> GetContatoByClienteName (string name);


        //-----------------     ENDERECO    ---------------------

        Task<Endereco> AddEndereco(Endereco endereco);
        Task<Endereco> UpdateEndereco(Endereco endereco);
        Task DeleteEndereco(int id);
        Task<Endereco> GetEndereco(int id);
        Task<Endereco> GetEnderecoByClienteId(int idCliente);
        Task<List<Endereco>> GetEnderecoList();
        Task<bool> EnderecoExists(int id);
        Task<Endereco> GetEnderecoByClienteName (string name);

    }
}
