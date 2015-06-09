namespace SnoMedVisualiser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Interface;
    using Model;

    public sealed class SnomedParser
    {
        public static ISnomedAnswer ParseSnoMedString(string snomedString)
        {
            var split = snomedString.Split(':');
            var answer = new SnomedAnswer(SctId.FromString(split[0]));

            if (split.Length > 1)
                answer.Properties = ParseSnomedProperties(split[1]);

            return answer;
        }

        private static IList<ISnomedProperty> ParseSnomedProperties(string s)
        {
            var properties = Regex.Split(s, ",(?=(?:[^']*'[^']*')*[^']*$)").ToList();
            var result = new List<ISnomedProperty>();

            properties.ForEach(e =>
            {
                var split = e.Split('=');

                result.Add(new SnomedProperty
                {
                    SctId = SctId.FromString(split[0]),
                    Answer = new SnomedAnswer(SctId.FromString(split[1]))
                });
            });

            return result;
        }
    }
}
