using System;
using System.Collections.Generic;
using System.Text;
using MunicipalitiesTax.Domain.Enums;

namespace MunicipalitiesTax.Domain.Models
{
    public class MunicipalityTaxAddDto
    {
        public string Name { get; set; }

        public decimal TaxValue { get; set; }

        public TaxType Type { get; set; }

        public DateTime StartDate { get; set; }

        public int MunicipalityId { get; set; }
    }
}
