using ConsoleAppCliente.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCliente.Repository
{

    public class RepositoryCliente
    {
        public static string minhaUri = "https://localhost:7281/api/Cliente/";


        //metodo para listar os clientes
        public static async Task<List<Cliente>> GetAll()
        {

            using (var clientApi = new HttpClient())
            {

                using (var response = await clientApi.GetAsync($"{minhaUri}Listar"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var dados = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Cliente>>(dados);
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o usuário!\n" + response.StatusCode.ToString());
                    }
                }
            }
        }

        public static async Task<Cliente> GetByID(int id)
        {
            using (var clientApi = new HttpClient())
            {
                HttpResponseMessage response = await clientApi.GetAsync($"{minhaUri}ObterPor" + id);
                if (response.IsSuccessStatusCode)
                {
                    var clienteJsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Cliente>(clienteJsonString);
                }
                else
                {
                    throw new Exception("Falha ao obter o cliente! " + response.StatusCode.ToString());
                }

            }
        }

        public static async Task UpdateCliente(Cliente cliente)
        {
            using (var clientApi = new HttpClient())
            {
                int id = cliente.ClienteId;


                //var clienteJson = JsonConvert.SerializeObject(cliente);
                //var content = new StringContent(clienteJson, Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await clientApi.PutAsJsonAsync($"{minhaUri}Alterar" + id, cliente);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }

            }
        }

        public static async Task<Cliente> AddCliente(Cliente novocliente)
        {

            HttpClient clienteapi = new HttpClient();
            var clienteJson = JsonConvert.SerializeObject(novocliente);
            var content = new StringContent(clienteJson, Encoding.UTF8, "application/json");
            Cliente novoCliente = new Cliente();
            try
            {
                var resposta= clienteapi.PostAsync($"{minhaUri}Incluir", content);
                resposta.Wait();
                
                if(resposta.Result.IsSuccessStatusCode)
                {
                    var retorno = resposta.Result.Content.ReadAsStringAsync();
                    novoCliente = JsonConvert.DeserializeObject<Cliente>(retorno.Result);
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            
            return novoCliente;

        }
        public static async Task<int> GetultimoId()
        {
            HttpClient clienteapi = new HttpClient();
            var resposta = clienteapi.GetAsync($"{minhaUri}UltimoId");
            resposta.Wait();
            var retorno=resposta.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(retorno.Result);
        }
        public static async Task DeleteCliente(Cliente cliente)
        {
            using (var clientApi = new HttpClient())
            {
                int id = cliente.ClienteId;
                cliente.Ativo = false;
                
                //var clienteJson = JsonConvert.SerializeObject(cliente);
                //var content = new StringContent(clienteJson, Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await clientApi.PutAsJsonAsync($"{minhaUri}Alterar" + id, cliente);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }

            }
        }
        
    }
}
