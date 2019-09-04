using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace FeatureToggles.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ResourceController : ControllerBase
    {
        [HttpPost]
        public ActionResult FirstFeature() => Ok();

        [HttpPost]
        public ActionResult SecondFeature() => Ok();

        [HttpPost]
        public ActionResult ThirdFeature() => StatusCode((int) HttpStatusCode.NotImplemented);
    }
}
