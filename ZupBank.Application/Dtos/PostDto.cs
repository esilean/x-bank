using Newtonsoft.Json;

namespace ZupBank.Application.Dtos
{
    public class PostDto
    {
        [JsonProperty("codigo")]
        public int Id { get; set; }

        [JsonProperty("titulo")]
        public string Title { get; set; }
    }
}
