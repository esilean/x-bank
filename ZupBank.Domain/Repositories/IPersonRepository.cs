using ZupBank.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZupBank.Domain.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Person>> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Person> Get(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task Add(Person person);
    }
}
