namespace SnoMedVisualiser.Model
{
    using Interface;

    public abstract class SnomedMember : ISnomedMember
    {
        public ISctId SctId { get; set; }
    }
}