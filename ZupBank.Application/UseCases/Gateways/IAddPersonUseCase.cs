using ZupBank.Application.Dtos;
using System.Threading.Tasks;

namespace ZupBank.Application.UseCases.Gateways
{
    public interface IAddPersonUseCase
    {
        Task Add(PersonDto personDto);
    }
}
