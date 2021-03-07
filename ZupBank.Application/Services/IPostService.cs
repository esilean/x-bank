using ZupBank.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZupBank.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}
