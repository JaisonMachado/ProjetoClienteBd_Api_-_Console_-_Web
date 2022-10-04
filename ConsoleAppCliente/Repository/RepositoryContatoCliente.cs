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
    public class RepositoryContatoCliente
    {
        public static string minhaUri = "https://localhost:7281/api/Contatos/";
        public static async Task<ContatoCliente> GetByIDCliente(int id)
        {
            using (var clientApi = new HttpClient())
            {
                HttpResponseMessage response = await clientApi.GetAsync($"{minhaUri}ObterPorCliente" + id);
                if (response.IsSuccessStatusCode)
                {
                    var clienteJsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ContatoCliente>(clienteJsonString);
                }
                else
                {
                    throw new Exception("Falha ao obter os dados de contato do cliente! " + response.StatusCode.ToString());
                }

            }
        }

        public static async Task UpdateContatoCliente(ContatoCliente contatoCliente)
        {
            using (var clientApi = new HttpClient())
            {
                int id = contatoCliente.Id;


                //var clienteJson = JsonConvert.SerializeObject(cliente);
                //var content = new StringContent(clienteJson, Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await clientApi.PutAsJsonAsync($"{minhaUri}Alterar" + id, contatoCliente);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }
                

            }
        }

        public static async Task AddContatoCliente(ContatoCliente contatoCliente)
        {
            
            
            HttpClient clienteapi = new HttpClient();
            var clienteJson = JsonConvert.SerializeObject(contatoCliente);
            var content = new StringContent(clienteJson, Encoding.UTF8, "application/json");
            try
            {
                await clienteapi.PostAsync($"{minhaUri}Incluir", content);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
    }
}
