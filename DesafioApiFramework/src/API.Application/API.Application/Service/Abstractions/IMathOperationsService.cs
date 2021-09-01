using API.Application.DTO;
using System.Threading.Tasks;

namespace API.Application.Service.Abstractions
{
    public interface IMathOperationsService
    {
        Task<OperationsResponseDTO> Get(int number);
    }
}
