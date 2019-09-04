using FeatureToggles.Domain;

namespace FeatureToggles.WebApi.FeatureToggles
{
    public interface IFeatureToggleConfigurationReader
    {
        bool IsFirstFeatureEnabled { get; }
        SecondFeatureVariant SecondFeatureVariant { get; }
    }
}
