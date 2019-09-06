using FeatureToggles.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FeatureToggles.WebApi.Config
{
    public class FeatureToggleOptions
    {
        private static JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            Converters = new[] { new StringEnumConverter() },
            Formatting = Formatting.None
        };

        public bool IsFirstFeatureEnabled { get; set; }
        public SecondFeatureVariant SecondFeatureVariant { get; set; }

        public string ToJson()
            => JsonConvert.SerializeObject(this, _serializerSettings);
    }
}
