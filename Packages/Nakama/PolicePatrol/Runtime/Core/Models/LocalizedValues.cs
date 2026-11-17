using System;

namespace PolicePatrol.Sdk
{
    public static class LocalizedValues
    {
        public static string Pick(LocalizedValue[] values, string languageId)
        {
            if (values == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(languageId))
            {
                foreach (var value in values)
                {
                    if (value != null && string.Equals(value.LanguageId, languageId, StringComparison.Ordinal) && !string.IsNullOrWhiteSpace(value.Value))
                    {
                        return value.Value;
                    }
                }
            }

            foreach (var value in values)
            {
                if (value != null && !string.IsNullOrWhiteSpace(value.Value))
                {
                    return value.Value;
                }
            }

            return null;
        }
    }
}
