using ZupBank.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZupBank.Application.UseCases.Gateways
{
    public interface IGetPersonUseCase
    {
        Task<PersonDto> Get(int id);

        Task<IEnumerable<PersonDto>> GetAll();
    }
}
