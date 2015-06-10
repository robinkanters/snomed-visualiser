namespace SnoMedVisualiser.Model
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Interface;
    using Newtonsoft.Json.Linq;

    public class SnomedAnswer : SnomedMember, ISnomedAnswer
    {
        public SnomedAnswer(ISctId sctId)
        {
            SctId = sctId;
        }

        public IList<ISnomedProperty> Properties { get; set; }

        public string DefaultTerm { get; set; }

        public static SnomedAnswer FromJson(string jsonString)
        {
            var o = JObject.Parse(jsonString);

            return new SnomedAnswer(Model.SctId.FromString(o["conceptId"].ToString()))
            {
                DefaultTerm = o["defaultTerm"].ToString()
            };
        }
    }
}
