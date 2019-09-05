using System.Net;
using FeatureToggles.Domain;
using FeatureToggles.WebApi.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FeatureToggles.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ResourceController : ControllerBase
    {
        private readonly FeatureToggleOptions _featureToggles;
        private readonly SecondFeatureBusinessLogicClass _secondFeatureBusinessLogicClass;

        public ResourceController(
            IOptionsSnapshot<FeatureToggleOptions> featureToggles,
            SecondFeatureBusinessLogicClass secondFeatureBusinessLogicOptions
        )
        {
            _featureToggles = featureToggles.Value;
            _secondFeatureBusinessLogicClass = secondFeatureBusinessLogicOptions;
        }

        [HttpGet]
        public ActionResult FirstFeature()
            => _featureToggles.IsFirstFeatureEnabled
                   ? Ok()
                   : StatusCode((int) HttpStatusCode.MethodNotAllowed);


        [HttpGet]
        public ActionResult SecondFeature()
            => Ok(
                _secondFeatureBusinessLogicClass
                   .SomeSecondFeatureAction(_featureToggles.SecondFeatureVariant)
            );
    }
}
