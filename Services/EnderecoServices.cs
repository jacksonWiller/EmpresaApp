using EmpresaApp.Models;
using Newtonsoft.Json;

namespace EmpresaApp.Services
{
    public class EnderecoServices
    {
        
        public async Task<dynamic> Integracao(string cep)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            Console.WriteLine(response);
            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            Console.WriteLine("jsonObject!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(jsonObject);
            if(jsonObject != null)
            {
                return jsonObject;
            }
            else
            {
                return new Endereco
                {
                    Vericacao = true
                };
            }
        }

    }
}