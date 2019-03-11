using MunicipalitiesTax.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MunicipalitiesTax.Domain.Repositories
{
    public interface IMunicipalitiesTaxRepository
    {
        Task<MunicipalityTax> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<MunicipalityTax> AddAsync(MunicipalityTax tax, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(MunicipalityTax municipalityTax, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<bool> AddRange(IEnumerable<MunicipalityTax> taxes, CancellationToken ct = default(CancellationToken));
        IQueryable<MunicipalityTax> GetByMunicipality(string municipality, CancellationToken ct = default(CancellationToken));

        void Dispose();
    }
}
