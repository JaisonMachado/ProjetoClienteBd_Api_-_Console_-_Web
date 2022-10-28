using ConsoleAppGestor.conexao;
using ConsoleAppGestor.Models;
using ConsoleAppGestor.Repository;
using static System.Console;

Conecta conecta = new Conecta();
WriteLine("Bem vindo ao Gestor de clientes.");
int op = 10;
while(op!=0)
{
    op = Conecta.Menu();
    switch(op)
    {
        case 1:
        {
            conecta.CadastrarCliente();
            break;
        }
        case 2:
            {
                conecta.ListarClientes();
                break;
            }
        case 3:
            {
                int id = 99;
                
                bool obter=false;
                while(!obter)
                {
                    WriteLine("Digite o ID do cliente:");
                    obter = int.TryParse(ReadLine().Trim(), out id);                    
                }                

                conecta.ObterCliente(id);
                break;
            }
        case 4:
            {
                int id = 99;
                
                bool obter = false;
                while (!obter)
                {
                    WriteLine("Digite o ID do cliente:");
                    obter = int.TryParse(ReadLine().Trim(), out id);
                }

                conecta.UpdateCliente(id);
                break;
            }
        case 5:
            {
                int id = 99;

                bool obter = false;
                while (!obter)
                {
                    WriteLine("Digite o ID do cliente:");
                    obter = int.TryParse(ReadLine().Trim(), out id);
                }

                conecta.ExcluirCliente(id);
                break;
            }
        case 6:
            {
                WriteLine("Digite o nome inteiro ou parte dele: ");
                var nome = ReadLine().Trim().ToLower();
                conecta.GetByName(nome);
                break;
            }
        case 0: break;
    }
    
        
    
}


