namespace SnoMedVisualiser.Model
{
    using Interface;

    public abstract class SnomedMember : ISnomedMember
    {
        public virtual ISctId SctId { get; set; }
    }
}