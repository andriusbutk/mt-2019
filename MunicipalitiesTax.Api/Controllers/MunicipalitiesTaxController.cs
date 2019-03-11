using Microsoft.AspNetCore.Mvc;
using MunicipalitiesTax.Domain.Models;
using MunicipalitiesTax.Domain.Repositories;
using MunicipalitiesTax.Domain.Services;
using System.IO;
using System.Threading.Tasks;

namespace MunicipalitiesTax.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalitiesTaxController : ControllerBase
    {
        private readonly IMunicipalitiesService _municipalityService;
        private readonly IMunicipalitiesTaxRepository _municipalitiesTaxRepository;

        public MunicipalitiesTaxController(IMunicipalitiesService municipalityService, IMunicipalitiesTaxRepository municipalitiesTaxRepository)
        {
            _municipalityService = municipalityService;
            _municipalitiesTaxRepository = municipalitiesTaxRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]MunicipalityTaxAddDto addMunicipality) => Ok(await _municipalityService.AddMunicipalityTax(addMunicipality));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]MunicipalityTaxUpdateDto updateMunicipality, int id) => Ok(await _municipalityService.UpdateMunicipalityTax(updateMunicipality, id));

        [HttpGet("import/json")]
        public async Task<IActionResult> ImportJson()
        {
            byte[] streamContent = null;
            var destination = new MemoryStream();
            var buffer = new byte[2048];

            await Request.Body.CopyToAsync(destination);

            using (destination)
                streamContent =  destination.ToArray();

            await _municipalityService.ImportTaxesJson(streamContent);

            return Ok();
        }

        [HttpPost("getTax")]
        public IActionResult GetTax([FromBody]GetTaxDto taxGetDto) => Ok(_municipalityService.GetMunicipalityTax(taxGetDto));
    }
}