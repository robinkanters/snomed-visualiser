namespace SnoMedVisualiser.Model
{
    using Interface;

    public class SnomedProperty : SnomedMember, ISnomedProperty
    {
        public ISnomedAnswer Answer { get; set; }
    }
}
