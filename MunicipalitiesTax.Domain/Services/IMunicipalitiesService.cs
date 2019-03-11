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

        /// <summary>
        /// Add a new tax
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MunicipalityViewModel> AddMunicipalityTax(MunicipalityTaxAddDto model);

        /// <summary>
        /// Update a tax
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MunicipalityViewModel> UpdateMunicipalityTax(MunicipalityTaxUpdateDto model, int id);

        /// <summary>
        /// Add taxes ranges from json byte array
        /// </summary>
        /// <param name="streamContent"></param>
        /// <returns></returns>
        Task ImportTaxesJson(byte[] streamContent);
    }
}
