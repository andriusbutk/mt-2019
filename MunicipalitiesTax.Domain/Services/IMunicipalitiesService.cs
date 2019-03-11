using MunicipalitiesTax.Domain.Models;
using MunicipalitiesTax.Domain.ViewModels;
using System.Threading.Tasks;

namespace MunicipalitiesTax.Domain.Services
{
    public interface IMunicipalitiesService
    {
        /// <summary>
        /// Gets a tax by name and date time
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MunicipalityViewModel GetMunicipalityTax(GetTaxDto model);
        Task<MunicipalityViewModel> AddMunicipalityTax(MunicipalityTaxAddDto model);
        Task<MunicipalityViewModel> UpdateMunicipalityTax(MunicipalityTaxUpdateDto model, int id);
        Task ImportTaxesJson(byte[] streamContent);
    }
}
