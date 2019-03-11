using MunicipalitiesTax.Domain.Entities;

namespace MunicipalitiesTax.Domain.ViewModels
{
    public class MunicipalityViewModel
    {
        public string Name { get; set; }

        public decimal TaxValue { get; set; }

        public MunicipalityViewModel() { }

        public MunicipalityViewModel(decimal value, string municipalityName)
        {
            Name = municipalityName;
            TaxValue = value;
        }
    }
}
