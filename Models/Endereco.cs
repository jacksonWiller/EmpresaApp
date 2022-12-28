using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmpresaApp.Models
{
    public class Endereco
    {
        [JsonProperty(PropertyName = "cep")]
        public string Cep { get; set; }
        [JsonProperty(PropertyName = "logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty(PropertyName = "complemento")]
        public string Complemento { get; set; }
        [JsonProperty(PropertyName = "bairro")]
        public string Bairro { get; set; }
        [JsonProperty(PropertyName = "localidade")]
        public string Localidade { get; set; }
        [JsonProperty(PropertyName = "uf")]
        public string Uf { get; set; }
        [JsonProperty(PropertyName = "ibge")]
        public string Ibge { get; set; }
        [JsonProperty(PropertyName = "gia")]
        public string Gia { get; set; }
        [JsonProperty(PropertyName = "ddd")]
        public string Ddd { get; set; }
        [JsonProperty(PropertyName = "siafi")]
        public string Siafi { get; set; }

        public bool Vericacao = false;

    }

}