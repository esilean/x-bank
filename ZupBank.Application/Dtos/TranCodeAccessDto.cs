using Newtonsoft.Json;

namespace ZupBank.Application.Dtos
{
    public class TranCodeAccessDto
    {
        [JsonProperty("usuario")]
        public string User { get; set; }

        [JsonProperty("senha")]
        public string Pass { get; set; }

        [JsonProperty("dominio")]
        public string Domain { get; set; }
    }
}
