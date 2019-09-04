using System;
using FeatureToggles.Domain;

namespace FeatureToggles.WebApi.FeatureToggles
{
    public class FeatureToggleEnvironmentVariablesReader : IFeatureToggleConfigurationReader
    {
        public bool IsFirstFeatureEnabled
        {
            get
            {
                var environmentVariableValue = Environment.GetEnvironmentVariable("FEATURE_TOGGLES_FIRST_FEATURE_IS_ENABLED");
                var parsed = Boolean.TryParse(environmentVariableValue, out var isEnabled);
                return parsed && isEnabled;
            }
        }

        public SecondFeatureVariant SecondFeatureVariant
        {
            get
            {
                var environmentVariableValue = Environment.GetEnvironmentVariable("FEATURE_TOGGLES_SECOND_FEATURE_VARIANT");
                Enum.TryParse(environmentVariableValue, out SecondFeatureVariant secondFeatureVariant);
                return secondFeatureVariant;
            }
        }
    }
}
