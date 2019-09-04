using System.Net;
using FeatureToggles.Domain;
using FeatureToggles.WebApi.FeatureToggles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FeatureToggles.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ResourceController : ControllerBase
    {
        private readonly IFeatureToggleConfigurationReader _featureToggleConfigurationReader;
        private readonly SecondFeatureBusinessLogicClass _secondFeatureBusinessLogicClass;

        public ResourceController(IFeatureToggleConfigurationReader featureToggleConfigurationReader, SecondFeatureBusinessLogicClass secondFeatureBusinessLogicOptions)
        {
            _featureToggleConfigurationReader = featureToggleConfigurationReader;
            _secondFeatureBusinessLogicClass = secondFeatureBusinessLogicOptions;
        }

        [HttpPost]
        public ActionResult FirstFeature()
            => _featureToggleConfigurationReader.IsFirstFeatureEnabled
                   ? Ok()
                   : StatusCode((int) HttpStatusCode.MethodNotAllowed);


        [HttpPost]
        public ActionResult SecondFeature()
            => Ok(
                _secondFeatureBusinessLogicClass
                   .SomeSecondFeatureAction(_featureToggleConfigurationReader.SecondFeatureVariant)
            );
    }
}
