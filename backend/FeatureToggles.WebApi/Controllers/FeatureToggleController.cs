using System.Net;
using FeatureToggles.WebApi.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FeatureToggles.WebApi.Controllers
{
    [Route("api/FeatureToggles")]
    public class FeatureToggleController : Controller
    {
        private readonly FeatureToggleOptions _featureToggles;

        public FeatureToggleController(
            IOptionsSnapshot<FeatureToggleOptions> featureToggles)
        {
            this._featureToggles = featureToggles.Value;
        }

        [HttpGet]
        public ActionResult<FeatureToggleOptions> Get()
            => _featureToggles;
    }
}
