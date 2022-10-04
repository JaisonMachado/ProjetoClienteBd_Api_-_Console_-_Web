using ConsoleAppCliente.Models;
using ConsoleAppCliente.Repository;
using static System.Console;


int opc;
bool controle = true;
while (controle)
{
    Clear();
    Console.WriteLine("Escolha:");
    Console.WriteLine("< 1 > | Incluir cliente | < 2 > - Listar Clientes | < 3 > - Obter Cliente por ID |\n" +
        "  4 - Alterar Dados de Um Cliente | 5 - Exluir | Cliente 0 - Sair");
    opc = int.Parse(Console.ReadLine());
    switch (opc)
    {
        //Incluir cliente
        case 1:
            {
                Cliente cliente = new Cliente();
                
                WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                WriteLine("::::::::::::::::::::::::::   D A D O S   P E S S O A I S   ::::::::::::::::::::::::::");
                WriteLine("Nome: ");
                cliente.Nome = ReadLine().Trim();
                WriteLine("Cpf: ");
                cliente.Cpf = ReadLine().Trim();
                cliente.Ativo = true;
                await RepositoryCliente.AddCliente(cliente);

                WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                WriteLine(":::::::::::::::::::::::::: E N D E R E Ç O / C O N T A T O ::::::::::::::::::::::::::");
                ContatoCliente novoContatoCliente = new ContatoCliente();
                WriteLine("Digite o Telefone:");
                novoContatoCliente.Telefone = ReadLine().Trim();

                WriteLine("Digite o Email:");
                novoContatoCliente.Email = ReadLine().Trim();

                WriteLine("Digite o Logradouro:");
                novoContatoCliente.Logradouro = ReadLine().Trim();
                WriteLine("Digite o Bairro:");
                novoContatoCliente.Bairro = ReadLine().Trim();

                WriteLine("Digite o Cidade:");
                novoContatoCliente.Cidade = ReadLine().Trim();
                novoContatoCliente.Clientechave = await RepositoryCliente.GetultimoId();

                
                await RepositoryContatoCliente.AddContatoCliente(novoContatoCliente);
                

                break;
            }
        // Listar clientes
        case 2:
            {
                var listaDeClientes = RepositoryCliente.GetAll();

                foreach (var item in listaDeClientes.Result)
                {
                    Console.WriteLine(item.ToString());

                }
                WriteLine("Tecle algo para continuar.");
                ReadLine();
                break;
            }
        // Obter cliente por Id
        case 3:
            {
                WriteLine("Digite o Id: ");
                int idBusca = int.Parse(ReadLine());
                var clienteBd = await RepositoryCliente.GetByID(idBusca);
                WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                WriteLine("::::::::::::::::::::::::::   D A D O S   P E S S O A I S   ::::::::::::::::::::::::::");
                WriteLine(clienteBd.ToString());
                WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                WriteLine(":::::::::::::::::::::::::: E N D E R E Ç O / C O N T A T O ::::::::::::::::::::::::::");
                var clienteContatoBd = await RepositoryContatoCliente.GetByIDCliente(idBusca);
                WriteLine(clienteContatoBd.ToString());
                WriteLine("Tecle algo para continuar.");
                ReadLine();
                break;
            }
        // Alterar cliente
        case 4:
            {
                string cont = "";
                WriteLine("Digite o Id: ");
                int idBusca = int.Parse(ReadLine());
                Cliente clienteBd = await RepositoryCliente.GetByID(idBusca);
                WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                WriteLine("::::::::::::::::::::::::::   D A D O S   P E S S O A I S   ::::::::::::::::::::::::::");
                WriteLine($"Nome: {clienteBd.Nome}  - Deseja alterar o nome? s/n");
                cont = ReadLine();
                if (cont == "s")
                {
                    WriteLine("Digite o nome:");
                    clienteBd.Nome = ReadLine().Trim();
                }
                WriteLine($"CPF: {clienteBd.Cpf}  - Deseja alterar o CPF? s/n");
                cont = ReadLine();
                if (cont == "s")
                {
                    WriteLine("Digite o CPF:");
                    clienteBd.Cpf = ReadLine().Trim();
                }
                WriteLine($"Status: {clienteBd.Ativo}  - Deseja alterar o Status? s/n");
                cont = ReadLine();
                if (cont == "s")
                {
                    WriteLine("Digite o Status:");
                    clienteBd.Cpf = ReadLine().Trim();
                }
                WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                WriteLine(":::::::::::::::::::::::::: E N D E R E Ç O / C O N T A T O ::::::::::::::::::::::::::");
                var clienteContatoBd = await RepositoryContatoCliente.GetByIDCliente(idBusca);
                WriteLine($"Telefone: {clienteContatoBd.Telefone}  - Deseja alterar o Telefone? s/n");
                cont = ReadLine();
                if (cont == "s")
                {
                    WriteLine("Digite o Telefone:");
                    clienteContatoBd.Telefone = ReadLine().Trim();
                }
                WriteLine($"E-mail: {clienteContatoBd.Email}  - Deseja alterar o Email? s/n");
                cont = ReadLine();
                if (cont == "s")
                {
                    WriteLine("Digite o Email:");
                    clienteContatoBd.Email = ReadLine().Trim();
                }
                WriteLine($"Logradouro: {clienteContatoBd.Logradouro}  - Deseja alterar o Logradouro? s/n");
                cont = ReadLine();
                if (cont == "s")
                {
                    WriteLine("Digite o Logradouro:");
                    clienteContatoBd.Logradouro = ReadLine().Trim();
                }
                WriteLine($"Bairro: {clienteContatoBd.Bairro}  - Deseja alterar o Bairro? s/n");
                cont = ReadLine();
                if (cont == "s")
                {
                    WriteLine("Digite o Bairro:");
                    clienteContatoBd.Bairro = ReadLine().Trim();
                }
                WriteLine($"Cidade: {clienteContatoBd.Cidade}  - Deseja alterar Cidade? s/n");
                cont = ReadLine();
                if (cont == "s")
                {
                    WriteLine("Digite o Cidade:");
                    clienteContatoBd.Cidade = ReadLine().Trim();
                }

                WriteLine(clienteBd.ToString());
                WriteLine(clienteContatoBd.ToString());
                RepositoryCliente.UpdateCliente(clienteBd);
                RepositoryContatoCliente.UpdateContatoCliente(clienteContatoBd);

                break;
            }
            //Ecluir cliente
        case 5:
            {
                WriteLine("Digite o Id: ");
                int idBusca = int.Parse(ReadLine());
                var clienteBd = await RepositoryCliente.GetByID(idBusca);
                Console.WriteLine("Excluindo cliente!");
                await RepositoryCliente.DeleteCliente(clienteBd);
                
                break;
            }
        // Sair
        case 0:
            {
                controle = false;
                break;
            }
        default:
            {
                Console.WriteLine("Opção Inválida!");
                break;
            }
    }





}