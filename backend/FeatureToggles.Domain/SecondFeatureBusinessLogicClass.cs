using System;

namespace FeatureToggles.Domain
{
    public class SecondFeatureBusinessLogicClass
    {
        private const string FirstVariantResult = "I am the first variant result.";
        private const string SecondVariantResult = "I am the second variant result.";

        public string SomeSecondFeatureAction(SecondFeatureVariant secondFeatureVariant)
        {
            switch (secondFeatureVariant)
            {
                case SecondFeatureVariant.First:
                    return FirstVariantResult;
                case SecondFeatureVariant.Second:
                    return SecondVariantResult;
                default:
                    throw new ArgumentOutOfRangeException(nameof(secondFeatureVariant), secondFeatureVariant, null);
            }
        }
    }
}
