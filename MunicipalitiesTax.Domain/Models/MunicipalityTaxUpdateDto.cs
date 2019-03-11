using System;
using System.Collections.Generic;
using System.Text;
using MunicipalitiesTax.Domain.Enums;

namespace MunicipalitiesTax.Domain.Models
{
    public class MunicipalityTaxUpdateDto
    {
        public string Name { get; set; }

        public decimal TaxValue { get; set; }

        public DateTime StartDate { get; set; }

        public TaxType Type { get; set; }
    }
}
