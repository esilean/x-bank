using Newtonsoft.Json;
using System.Collections.Generic;
using ZupBank.Domain.Enums;

namespace ZupBank.Application.Dtos
{
    public class PersonDto
    {
        [JsonProperty("codigo")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("genero")]
        public Gender Gender { get; set; }

        [JsonProperty("mesAniversario")]
        public BirthdayMonth BirthdayMonth { get; set; }

        [JsonProperty("acesso")]
        public TranCodeAccessDto TranCodeAccess { get; set; }

        [JsonProperty("publicacoes")]
        public IEnumerable<PostDto> Posts { get; set; }
    }
}
