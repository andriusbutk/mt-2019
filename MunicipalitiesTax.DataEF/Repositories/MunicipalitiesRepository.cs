using Microsoft.EntityFrameworkCore;
using MunicipalitiesTax.DataEF.Context;
using MunicipalitiesTax.Domain.Entities;
using MunicipalitiesTax.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MunicipalitiesTax.DataEF.Repositories
{
    public class MunicipalitiesRepository : IMunicipalitiesRepository
    {
        private readonly MunicipalityContext _context;

        public MunicipalitiesRepository(MunicipalityContext context)
        {
            _context = context;
        }

        public void Dispose() => _context.Dispose();

        public async Task<Municipality> GetByNameAsync(string name, CancellationToken ct = default(CancellationToken)) => await _context.Municipalities.FirstOrDefaultAsync(x => x.Name == name);
    }
}
