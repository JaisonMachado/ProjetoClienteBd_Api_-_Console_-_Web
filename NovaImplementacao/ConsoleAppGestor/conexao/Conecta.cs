using ConsoleAppGestor.Interface;
using ConsoleAppGestor.Models;
using ConsoleAppGestor.Repository;
using System;
using System.ComponentModel.Design;
using System.Linq;
using static System.Console;

namespace ConsoleAppGestor.conexao
{
    public class Conecta
    {

        
        public static int Menu()
        {
            int opc = 0;
            bool sucesso = false;
            while (!sucesso)
            {
                WriteLine("Escolha:");
                WriteLine("< 1 > | Incluir cliente | < 2 > - Listar Clientes | < 3 > - Obter Detalhes do Cliente |\n" +
                "  4 - Alterar Dados de Um Cliente | 5 - Exluir  Cliente | 6 - Buscar por nome | 0 - Sair");

                sucesso = int.TryParse(Console.ReadLine().Trim(), out opc);
                if (!sucesso)
                {
                    WriteLine("Entrada inválida, escolha um número entre 1 e 6, ou 0 para sair!");
                }
            }
            return opc;

        }

        public void CadastrarCliente()
        {


            Cliente nocoCliente = new Cliente();
            Contato contato = new Contato();
            Endereco endereco = new Endereco();
            WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            WriteLine("::::::::::::::::::::::::::   D A D O S   P E S S O A I S   ::::::::::::::::::::::::::");
            WriteLine("Nome: ");
            nocoCliente.ClienteNome = ReadLine().Trim();
            WriteLine("Cpf: ");
            nocoCliente.Cpf = ReadLine().Trim();
            nocoCliente.ClienteAtivo = true;
            var novoCliente = GestaoRepository.AddCliente(nocoCliente);
            WriteLine(novoCliente.ToString());
            AddContato(novoCliente.ClienteId);
            AddEndereco(novoCliente.ClienteId);
        }

        public void AddContato(int idCliente)
        {
            
            Contato contato = new Contato();
            Contato retorno = new Contato();
            WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            WriteLine(":::::::::::::::::::::::::: E N D E R E Ç O / C O N T A T O ::::::::::::::::::::::::::");


            WriteLine("Digite o Telefone:");
            contato.Telefone = ReadLine().Trim();

            WriteLine("Digite o Email:");
            contato.Email = ReadLine().Trim();


            contato.ClienteId = idCliente;
            contato.ContatoAtivo = true;

            retorno = GestaoRepository.AddContato(contato);
            WriteLine(retorno.ToString());
        }

        public void AddEndereco(int idCliente)
        {
            Endereco endereco = new Endereco();
            WriteLine("Digite o Logradouro:");
            endereco.Logradouro = ReadLine().Trim();

            WriteLine("Digite o Bairro:");
            endereco.Bairro = ReadLine().Trim();

            WriteLine("Digite o Cidade:");
            endereco.Cidade = ReadLine().Trim();
            endereco.EnderecoAtivo = true;
            endereco.ClienteId = idCliente;

            var retorno = GestaoRepository.AddEndereco(endereco);
            WriteLine(retorno.ToString);
        }
            
        public void ListarClientes()
        {
            List<Cliente> listaDeClientes = GestaoRepository.Listar();

            foreach (var item in listaDeClientes)
            {
                WriteLine(item.ToString());

            }
            
        }

        public void ObterCliente(int idCliente)
        {
            
            var clienteBd = GestaoRepository.ObterPorId(idCliente);
            WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            WriteLine("::::::::::::::::::::::::::   D A D O S   P E S S O A I S   ::::::::::::::::::::::::::");
            WriteLine(clienteBd.ToString());
            WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            WriteLine(":::::::::::::::::::::::::: E N D E R E Ç O / C O N T A T O ::::::::::::::::::::::::::");
            Contato contatoBd = new Contato();
            try
            {
                contatoBd = GestaoRepository.ObterPorIdCliente(idCliente);
            }
            catch (Exception ex)
            {
                WriteLine("Err: " + ex.Message.ToString());
            }
            Endereco enderecoBd = new Endereco();
            try
            {
                enderecoBd = GestaoRepository.ObterEnderecoPorId(clienteBd.EnderecoId);
            }
            catch (Exception ex)
            {
                WriteLine("Err: " + ex.Message.ToString());
            }
            WriteLine(contatoBd.ToString());
            WriteLine(enderecoBd.ToString());
        }

        public void UpdateCliente(int idCliente)
        {
            string cont = "";
            
            
            Cliente clienteBd = GestaoRepository.ObterPorId(idCliente);
            WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            WriteLine("::::::::::::::::::::::::::   D A D O S   P E S S O A I S   ::::::::::::::::::::::::::");
            WriteLine($"Nome: {clienteBd.ClienteNome}  - Deseja alterar o nome? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                WriteLine("Digite o nome:");
                clienteBd.ClienteNome = ReadLine().Trim().ToLower();
            }
            WriteLine($"CPF: {clienteBd.Cpf}  - Deseja alterar o CPF? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                WriteLine("Digite o CPF:");
                clienteBd.Cpf = ReadLine().Trim();
            }
            WriteLine($"Status: {clienteBd.ClienteAtivo}  - Deseja alterar o Status? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                var newControle = false;
                int opc = 0;
                while (!newControle)
                {

                    WriteLine("Digite o Status: 0 - inativo / 1 - ativo");
                    newControle = int.TryParse(Console.ReadLine().Trim(), out opc);
                    if (!newControle)
                    {
                        WriteLine("Entrada inválida, escolha 1 para ativo ou 0 para inativo!");
                    };
                }
                if (opc == 1)
                    clienteBd.ClienteAtivo = true;

                else 
                    clienteBd.ClienteAtivo = false;
                
            }
            WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            WriteLine(":::::::::::::::::::::::::: E N D E R E Ç O / C O N T A T O ::::::::::::::::::::::::::");
            var contatoBd = GestaoRepository.ObterContatoPorId(clienteBd.ContatoId);
            WriteLine($"Telefone: {contatoBd.Telefone}  - Deseja alterar o Telefone? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                WriteLine("Digite o Telefone:");
                contatoBd.Telefone = ReadLine().Trim();
            }
            WriteLine($"E-mail: {contatoBd.Email}  - Deseja alterar o Email? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                WriteLine("Digite o Email:");
                contatoBd.Email = ReadLine().Trim();
            }

            WriteLine($"Contato ativo: {contatoBd.ContatoAtivo}  - Deseja alterar o status? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                var newControle = false;
                int opc = 0;
                while (!newControle)
                {

                    WriteLine("Digite o Status: 0 - inativo / 1 - ativo");
                    newControle = int.TryParse(Console.ReadLine().Trim(), out opc);
                    if (!newControle)
                    {
                        WriteLine("Entrada inválida, escolha 1 para ativo ou 0 para inativo!");
                    };
                }
                if (opc == 1)                
                    contatoBd.ContatoAtivo= true;
                    
                else 
                    contatoBd.ContatoAtivo = false;
                
            }
            var enderecoBd = GestaoRepository.ObterEnderecoPorId(clienteBd.EnderecoId);

            WriteLine($"Logradouro: {enderecoBd.Logradouro}  - Deseja alterar o Logradouro? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                WriteLine("Digite o Logradouro:");
                enderecoBd.Logradouro = ReadLine().Trim().ToLower();
            }
            WriteLine($"Bairro: {enderecoBd.Bairro}  - Deseja alterar o Bairro? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                WriteLine("Digite o Bairro:");
                enderecoBd.Bairro = ReadLine().Trim().ToLower();
            }
            WriteLine($"Cidade: {enderecoBd.Cidade}  - Deseja alterar Cidade? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                WriteLine("Digite o Cidade:");
                enderecoBd.Cidade = ReadLine().Trim().ToLower();
            }


            WriteLine($"Endereço ativo: {enderecoBd.EnderecoAtivo}  - Deseja alterar o status? s/n");
            cont = ReadLine().Trim().ToLower();
            if (cont == "s")
            {
                var newControle = false;
                int opc = 0;
                while (!newControle)
                {

                    WriteLine("Digite o Status: 0 - inativo / 1 - ativo");
                    newControle = int.TryParse(Console.ReadLine().Trim(), out opc);
                    if (!newControle)
                    {
                        WriteLine("Entrada inválida, escolha 1 para ativo ou 0 para inativo!");
                    };
                }
                if (opc == 1)
                    enderecoBd.EnderecoAtivo = true;

                else
                    enderecoBd.EnderecoAtivo = false;

            }

            GestaoRepository.UpdateCliente(clienteBd);
            GestaoRepository.UpdateContato(contatoBd);
            GestaoRepository.UpdateEndereco(enderecoBd);
            WriteLine(clienteBd.ToString());
            WriteLine(contatoBd.ToString());
            WriteLine(enderecoBd.ToString());
            
            WriteLine();
            WriteLine("Alterações concluídas!");
        }

        public void ExcluirCliente(int idCliente)
        {
            var clienteBd = GestaoRepository.ObterPorId(idCliente);
            WriteLine(clienteBd.ToString());
            WriteLine();
            WriteLine("Confirma a exclusão? s - sim / n - cancela.");
            var novoControle = ReadLine().Trim().ToLower();
            if (novoControle == "s")
            {
                Console.WriteLine("Excluindo cliente!");
                GestaoRepository.RemoveCliente(idCliente);
            }
            WriteLine("Clinete excluído!");
        }

        public void GetByName(string nome)
        {
            
            Cliente cliente = GestaoRepository.ObterPorNome(nome);
            if (cliente == null) WriteLine($"{nome} não encontrao!");
            else WriteLine(cliente.ToString());
        }
             
       
    }
}
    
