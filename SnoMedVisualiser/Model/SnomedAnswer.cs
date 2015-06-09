namespace SnoMedVisualiser.Model
{
    using System.Collections.Generic;
    using Interface;

    public class SnomedAnswer : SnomedMember, ISnomedAnswer
    {
        public SnomedAnswer(ISctId sctId)
        {
            SctId = sctId;
        }

        public IList<ISnomedProperty> Properties { get; set; }
    }
}
