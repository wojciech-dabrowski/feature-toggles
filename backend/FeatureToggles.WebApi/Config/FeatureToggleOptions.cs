using FeatureToggles.Domain;

namespace FeatureToggles.WebApi.Config
{
    public class FeatureToggleOptions
    {
        public bool IsFirstFeatureEnabled { get; set; }
        public SecondFeatureVariant SecondFeatureVariant { get; set; }
    }
}
