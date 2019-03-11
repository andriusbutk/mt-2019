using MunicipalitiesTax.Domain.Entities;
using MunicipalitiesTax.Domain.Enums;
using MunicipalitiesTax.Domain.Helpers;
using MunicipalitiesTax.Domain.Models;
using MunicipalitiesTax.Domain.Repositories;
using MunicipalitiesTax.Domain.Services;
using MunicipalitiesTax.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalitiesTax.ServiceImpementation.Services
{
    public class MunicipalitiesService : IMunicipalitiesService
    {
        private readonly IMunicipalitiesTaxRepository _municipalitiesTaxRepository;
        private readonly IMunicipalitiesRepository _municipalitiesRepository;

        public MunicipalitiesService(IMunicipalitiesTaxRepository municipalitiesTaxRepository, IMunicipalitiesRepository municipalitiesRepository)
        {
            _municipalitiesTaxRepository = municipalitiesTaxRepository;
            _municipalitiesRepository = municipalitiesRepository;
        }

        public async Task<MunicipalityViewModel> AddMunicipalityTax(MunicipalityTaxAddDto model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new Exception("Wrong name submitted. ");

            if (model.TaxValue < 0)
                throw new Exception("Wrong tax's value submitted. ");

            if (!Enum.IsDefined(typeof(TaxType), model.Type))
                throw new Exception("Wrong tax's type submitted. ");

            if (model.StartDate == null)
                throw new Exception("Wrong tax's date submitted. ");

            var municipality = await _municipalitiesRepository.GetByNameAsync(model.Name);

            if (municipality != null)
                throw new Exception($"{model.Name} - municipality's name already exists. ");

            var tax = await _municipalitiesTaxRepository.AddAsync(new MunicipalityTax(model));

            return new MunicipalityViewModel(tax.Value, municipality.Name);
        }

        public MunicipalityViewModel GetMunicipalityTax(GetTaxDto model)
        {
            var tax = _municipalitiesTaxRepository.GetByMunicipality(model.Municipality)
                .Where(x => (x.TaxType == TaxType.Yearly && x.StartDate < model.Date && x.StartDate.AddYears(1) > model.Date)
                            || (x.TaxType == TaxType.Monthly && x.StartDate < model.Date && x.StartDate.AddMonths(1) > model.Date)
                            || (x.TaxType == TaxType.Weekly && DatesAreInTheSameWeek(x.StartDate, model.Date))
                            || (x.TaxType == TaxType.Daily && x.StartDate.Date == model.Date))
                .OrderByDescending(x => x.TaxType)
                .FirstOrDefault();

            if (tax == null)
                throw new Exception("No data were found. ");

            return new MunicipalityViewModel(tax.Value, model.Municipality);
        }

        public async Task ImportTaxesJson(byte[] streamContent)
        {
            var taxes = ByteToJson.FromByteArray<IEnumerable<MunicipalityTaxAddDto>>(streamContent);

            await _municipalitiesTaxRepository.AddRange(taxes.Select(x => new MunicipalityTax(x)));
        }

        public async Task<MunicipalityViewModel> UpdateMunicipalityTax(MunicipalityTaxUpdateDto model, int id)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new Exception("Wrong name submitted. ");

            if (model.TaxValue < 0)
                throw new Exception("Wrong tax's value submitted. ");

            if (!Enum.IsDefined(typeof(TaxType), model.Type))
                throw new Exception("Wrong tax's type submitted. ");

            if (model.StartDate == null)
                throw new Exception("Wrong tax's date submitted. ");

            var tax = await _municipalitiesTaxRepository.GetByIdAsync(id);

            tax.UpdateProperties(model);

            await _municipalitiesTaxRepository.UpdateAsync(tax);

            return new MunicipalityViewModel(tax.Value, model.Name);
        }

        private bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;

            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return d1 == d2;
        }
    }
}
