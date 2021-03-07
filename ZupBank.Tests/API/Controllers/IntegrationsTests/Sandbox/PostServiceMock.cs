using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ZupBank.Application.Dtos;
using ZupBank.Application.Mappers;
using ZupBank.Application.Services;
using ZupBank.Domain.Entities;

namespace ZupBank.Tests.API.Controllers.IntegrationsTests.Sandbok
{
    /// <summary>
    /// 
    /// </summary>
    public class PostServiceMock : IPostService
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var postsJson = File.ReadAllText(@$"API\Controllers\IntegrationsTests\Sandbox\Data\postsDto.json");

            var postsDto = JsonConvert.DeserializeObject<IEnumerable<PostDto>>(postsJson);

            return await Task.FromResult(PostMapper.ToDomainList(postsDto));
        }
    }
}
