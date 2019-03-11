using System;
using System.Collections.Generic;
using System.Text;

namespace MunicipalitiesTax.Domain.Models
{
    public class GetTaxDto
    {
        public string Municipality { get; set; }

        public DateTime Date { get; set; }
    }
}
