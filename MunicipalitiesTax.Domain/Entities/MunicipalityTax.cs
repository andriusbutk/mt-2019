using MunicipalitiesTax.Domain.Enums;
using System;
using MunicipalitiesTax.Domain.Models;

namespace MunicipalitiesTax.Domain.Entities
{
    public class MunicipalityTax
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public DateTime StartDate { get; set; }

        public TaxType TaxType { get; set; }

        public int MunicipalityId { get; set; }

        public Municipality Municipality { get; set; }

        public MunicipalityTax() { }

        public MunicipalityTax(MunicipalityTaxAddDto model)
        {
            Value = model.TaxValue;
            StartDate = model.StartDate;
            TaxType = model.Type;
            MunicipalityId = model.MunicipalityId;
        }

        public void UpdateProperties(MunicipalityTaxUpdateDto model)
        {
            Value = model.TaxValue;
            StartDate = model.StartDate;
            TaxType = model.Type;
        }
    }
}
