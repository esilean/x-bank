using ZupBank.Application.Services;
using ZupBank.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZupBank.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;

        public PostService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(nameof(PostService));
        }
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var responseMessage = await _httpClient.GetAsync("/typicode/demo/posts");
            var content = await responseMessage.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(content);

            return posts;
        }
    }
}
