using System.Collections.Generic;

namespace MunicipalitiesTax.Domain.Entities
{
    public class Municipality
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<MunicipalityTax> Taxes { get; set; }

        public Municipality() => Taxes = new List<MunicipalityTax>();
    }
}
