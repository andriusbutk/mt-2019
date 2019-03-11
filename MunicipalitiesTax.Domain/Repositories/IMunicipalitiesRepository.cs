using MunicipalitiesTax.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MunicipalitiesTax.Domain.Repositories
{
    public interface IMunicipalitiesRepository
    {
        Task<Municipality> GetByNameAsync(string name, CancellationToken ct = default(CancellationToken));
        void Dispose();
    }
}
