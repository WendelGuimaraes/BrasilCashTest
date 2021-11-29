using Newtonsoft.Json;
using System;

namespace BrasilCashTest.Domain.Entities
{
    public class Addres
    {
        public Addres () {} // rest sharp para carregar o endereço da API, tem que ter um construtor vazio

        public Addres(string street, string district, string city, string state) 
        {
            Logradouro = street;
            Bairro = district;
            Localidade = city;
            UF = state;
        }
   
        public Guid Id { get; private set; }

        [JsonProperty("street")]
        public string Logradouro { get; private set; }

        [JsonProperty("district")]
        public string Bairro { get; private set; }

        [JsonProperty("city")]
        public string Localidade { get; private set; }

        [JsonProperty("state")]
        public string UF { get; private set; }
    }
}
