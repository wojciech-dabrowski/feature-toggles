using FeatureToggles.Domain;
using FeatureToggles.WebApi.Config;
using Microsoft.Extensions.Options;

namespace FeatureToggles.WebApi.FeatureToggles
{
    public class FeatureToggleConfigFileReader : IFeatureToggleConfigurationReader
    {
        private readonly FeatureTogglesConfigurationSection _featureTogglesConfiguration;

        public FeatureToggleConfigFileReader(IOptions<FeatureTogglesConfigurationSection> featureTogglesConfigurationOptions)
        {
            _featureTogglesConfiguration = featureTogglesConfigurationOptions.Value;
        }

        public bool IsFirstFeatureEnabled => _featureTogglesConfiguration.FirstFeatureIsEnabled;
        public SecondFeatureVariant SecondFeatureVariant => _featureTogglesConfiguration.SecondFeatureVariant;
    }
}
