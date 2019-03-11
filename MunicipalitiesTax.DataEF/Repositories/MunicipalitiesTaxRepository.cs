using Microsoft.EntityFrameworkCore;
using MunicipalitiesTax.DataEF.Context;
using MunicipalitiesTax.Domain.Entities;
using MunicipalitiesTax.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MunicipalitiesTax.Domain.Enums;

namespace MunicipalitiesTax.DataEF.Repositories
{
    public class MunicipalitiesTaxRepository : IMunicipalitiesTaxRepository
    {
        private readonly MunicipalityContext _context;

        public MunicipalitiesTaxRepository(MunicipalityContext context)
        {
            _context = context;
        }

        public void Dispose() => _context.Dispose();

        public async Task<MunicipalityTax> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken)) => await _context.MuniciaplitiesTaxes.FindAsync(id);

        public async Task<MunicipalityTax> AddAsync(MunicipalityTax tax, CancellationToken ct = default(CancellationToken))
        {
            _context.MuniciaplitiesTaxes.Add(tax);
            await SavechangesAsync(ct);

            return tax;
        }

        public async Task<bool> UpdateAsync(MunicipalityTax municipalityTax, CancellationToken ct = default(CancellationToken))
        {
            _context.MuniciaplitiesTaxes.Update(municipalityTax);

            return await SavechangesAsync(ct);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var toRemove = _context.MuniciaplitiesTaxes.Find(id);
            _context.MuniciaplitiesTaxes.Remove(toRemove);

            return await SavechangesAsync(ct);
        }

        public async Task<bool> AddRange(IEnumerable<MunicipalityTax> taxes, CancellationToken ct = default(CancellationToken))
        {
            await _context.MuniciaplitiesTaxes.AddRangeAsync(taxes);

            return await SavechangesAsync(ct);
        }

        public IQueryable<MunicipalityTax> GetByMunicipality(string municipality, CancellationToken ct = default(CancellationToken))
        {
            return from item in _context.MuniciaplitiesTaxes
                join t in _context.Municipalities on item.MunicipalityId equals t.Id
                select item;
        }

        private async Task<bool> SavechangesAsync(CancellationToken ct = default(CancellationToken)) => await _context.SaveChangesAsync(ct) != 0;
    }
}
