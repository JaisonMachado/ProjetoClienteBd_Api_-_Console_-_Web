﻿

using System.Text;

using System;
using ConsoleAppGestor.Models;
using Newtonsoft.Json;

namespace ConsoleAppGestor.Repository
{
    public static class GestaoRepository 
    {
        
        private static readonly string _uriApi = "http://localhost:5011/";
        // ------------------------         CLIENTE     -------------------------------

        public static Cliente AddCliente(Cliente cliente)
        {
            Cliente clienteCriado = new Cliente();
            HttpClient http = new HttpClient();
            try
            {
                string objJson = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(objJson, Encoding.UTF8, "application/json");
                var resposta = http.PostAsync(_uriApi + "api/V1/Clientes/Incluir", content);
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                clienteCriado = JsonConvert.DeserializeObject<Cliente>(retorno.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }
            return clienteCriado;
        }

       

        public static List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            HttpClient http = new HttpClient();
            try
            {
                var resposta = http.GetStringAsync(_uriApi + "api/V1/Clientes/Listar");
                resposta.Wait();
                
                lista = JsonConvert.DeserializeObject<Cliente[]>(resposta.Result).ToList();
            }catch(Exception ex)
            {
                throw new Exception("Erro: "+ex.Message.ToString());
            }
            
            return lista;

        }

        public static Cliente ObterPorId(int id)
        {
            Cliente cliente =   new Cliente();
            HttpClient http = new HttpClient();
            try
            {
                var resposta = http.GetStringAsync(_uriApi + "api/V1/Clientes/Obter/" + id);
                resposta.Wait();
                cliente = JsonConvert.DeserializeObject<Cliente>(resposta.Result);
            }catch(Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }
            return cliente;
        }

        public static Cliente ObterPorNome (string nome)
        {
            Cliente cliente = new Cliente();
            HttpClient http = new HttpClient();
            try
            {
                var resposta = http.GetStringAsync(_uriApi + "api/V1/Clientes/ObterPorNome/" + nome.ToString());
                resposta.Wait();
                cliente = JsonConvert.DeserializeObject<Cliente>(resposta.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }
            return cliente;
        }


        public static Cliente UpdateCliente (Cliente cliente)
        {
            Cliente clienteBd = new Cliente();
           
            try
            {
                HttpClient http = new HttpClient();
                string objetoJson = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(objetoJson, Encoding.UTF8, "application/json");
                var resposta = http.PutAsync(_uriApi+"api/V1/Clientes/Alterar", content);
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                clienteBd = JsonConvert.DeserializeObject<Cliente>(retorno.Result);
            }catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }


            return clienteBd;
        }

        public static async void RemoveCliente(int id)
        {
            HttpClient http = new HttpClient();
            
            try
            {
                 await http.DeleteAsync(_uriApi+ "api/V1/Clientes/Remover/" + id.ToString());
                
            }catch (Exception ex)
            {
                throw new Exception("Erro: "+ex.Message.ToString());
            }
            
        }



        //----------------------        CONTATO     -------------------------------------


        public static Contato AddContato(Contato contato)
        {
            Contato contatoCriado = new Contato();
            HttpClient http = new HttpClient();
            try
            {
                string objJson = JsonConvert.SerializeObject(contato);
                var content = new StringContent(objJson, Encoding.UTF8, "application/json");
                var resposta = http.PostAsync(_uriApi + "api/V1/Contatos/Adicionar", content);
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                contatoCriado = JsonConvert.DeserializeObject<Contato>(retorno.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }
            return contatoCriado;
        }

        public static Contato ObterPorIdCliente(int id)
        {
            Contato contato  = new Contato();
            
            HttpClient http = new HttpClient();
            try
            {
                var resposta = http.GetStringAsync(_uriApi + "api/V1/Contatos/ObterPorClienteId/" + id);
                resposta.Wait();
                contato = JsonConvert.DeserializeObject<Contato>(resposta.Result);
            }
            catch (Exception ex)
            {
                
                    contato.ContatoAtivo=false;
                    contato.ContatoId=0;
                    contato.ClienteId=0;
                    contato.Telefone="sem registro";
                    contato.Email="sem registro";                
                    
                //throw new Exception("Erro: " + ex.Message.ToString());
            }
            return contato;
        }

        public static List<Contato> ListarContato()
        {
            List<Contato> lista = new List<Contato>();
            HttpClient http = new HttpClient();
            try
            {
                var resposta = http.GetStringAsync(_uriApi + "api/V1/Contatos/Listar");
                resposta.Wait();
                lista = JsonConvert.DeserializeObject<Contato[]>(resposta.Result).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }

            return lista;
        }

        public static Contato ObterContatoPorId(int id)
        {
            Contato contato = new Contato();
            HttpClient http = new HttpClient();
            try
            {
                var resposta = http.GetStringAsync(_uriApi + "api/V1/Contatos/ObterContato/" + id);
                resposta.Wait();
                contato = JsonConvert.DeserializeObject<Contato>(resposta.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }
            return contato;            

        }


        public static Contato UpdateContato (Contato contato)
        {
            Contato contatoBd = new Contato();
            

            try
            {
                HttpClient http = new HttpClient();
                string objetoJson = JsonConvert.SerializeObject(contatoBd);
                var content = new StringContent(objetoJson, Encoding.UTF8, "application/json");
                var resposta = http.PutAsync(_uriApi + "api/V1/Contatos/Alterar", content);
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                contatoBd = JsonConvert.DeserializeObject<Contato>(retorno.Result);               


            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }


            return contatoBd;
        }

        public static void RemoveContato (int id)
        {
            HttpClient http = new HttpClient();
           
            try
            {
                http.DeleteAsync(_uriApi+"api/v1/Contatos/Remover/"+id.ToString());
            }catch(Exception ex)
            {
                throw new Exception("Erro: "+ex.Message.ToString());
            }
        }



        //---------------------         ENDERECO            ---------------------------------

        public static Endereco AddEndereco(Endereco endereco)
        {
            Endereco enderecoCriado = new Endereco();
            HttpClient http = new HttpClient();
            try
            {
                string objJson = JsonConvert.SerializeObject(endereco);
                var content = new StringContent(objJson, Encoding.UTF8, "application/json");
                var resposta = http.PostAsync(_uriApi + "api/V1/Endereco/Adicionar", content);
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                enderecoCriado = JsonConvert.DeserializeObject<Endereco>(retorno.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }
            return enderecoCriado;
        }

        public static List<Endereco> ListarEndereco()
        {
            List<Endereco> lista = new List<Endereco>();
            HttpClient http = new HttpClient();
            try
            {
                var resposta = http.GetStringAsync(_uriApi + "api/V1/Endereco/Listar");
                resposta.Wait();
                lista = JsonConvert.DeserializeObject<Endereco[]>(resposta.Result).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }

            return lista;
        }

        public static Endereco ObterEnderecoPorId(int id)
        {
            Endereco endereco = new Endereco();
            HttpClient http = new HttpClient();
            try
            {
                var resposta = http.GetStringAsync(_uriApi + "api/V1/Endereco/ObterEndereco/" + id);
                resposta.Wait();
                endereco = JsonConvert.DeserializeObject<Endereco>(resposta.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }
            return endereco;
        }

        public static Endereco ObterEnderecoPorIdCliente(int id)
        {
            Endereco endereco = new Endereco();
            HttpClient http = new HttpClient();
            try
            {
                var resposta = http.GetStringAsync(_uriApi + "api/V1/Endereco/ObterPorClienteId/" + id);
                resposta.Wait();
                endereco = JsonConvert.DeserializeObject<Endereco>(resposta.Result);
            }
            catch (Exception ex)
            {
                endereco.EnderecoId=0;
                endereco.EnderecoAtivo=false;
                endereco.ClienteId=0;
                endereco.Cidade="sem registro";
                endereco.Logradouro="sem registro";
                endereco.Bairro="sem registro";
            }
            return endereco;
        }

        public static Endereco UpdateEndereco(Endereco endereco)
        {
            Endereco enderecoBd = new Endereco();
            HttpClient http = new HttpClient();
           
            try
            {
                string objetoJson = JsonConvert.SerializeObject(enderecoBd);
                var content = new StringContent(objetoJson, Encoding.UTF8, "application/json");
                var resposta = http.PutAsync(_uriApi + "api/V1/Endereco/Alterar", content);
                resposta.Wait();
                var retorno = resposta.Result.Content.ReadAsStringAsync();
                enderecoBd = JsonConvert.DeserializeObject<Endereco>(retorno.Result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }


            return enderecoBd;
        }

        public static void RemoveEndereco(int id)
        {
            HttpClient http = new HttpClient();
            //string objetoJson = JsonConvert.SerializeObject(id);
            //var content = new StringContent(objetoJson, Encoding.UTF8, "application/json");
            try
            {
                http.DeleteAsync(_uriApi+"api/V1/Endereco/Remover/"+id.ToString());
            }catch(Exception ex)
            {
                throw new Exception("Erro: "+ex.Message.ToString());
            }
        }

       
    }
}