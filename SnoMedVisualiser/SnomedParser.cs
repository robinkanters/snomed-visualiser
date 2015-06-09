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
            var split = Regex.Split(snomedString, ",(?=(?:[^']*'[^']*')*[^']*$)");
            var answer = new SnomedAnswer(SctId.FromString(split[0]))
            {
                Properties = split.Length > 1 ? ParseSnomedProperties(split[1]) : new List<ISnomedProperty>()
            };

#if DEBUG
            Console.WriteLine("Answer: {0}", answer.SctId.Id);
            answer.Properties.ToList().ForEach(e =>
            {
                Console.WriteLine("Property: {0} = {1}", e.SctId.Id, e.Answer.SctId.Id);
            });
#endif
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
