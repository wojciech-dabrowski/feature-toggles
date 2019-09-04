using FeatureToggles.Domain;

namespace FeatureToggles.WebApi.Config
{
    public class FeatureTogglesConfigurationSection
    {
        public bool FirstFeatureIsEnabled { get; set; }
        public SecondFeatureVariant SecondFeatureVariant { get; set; }
    }
}
