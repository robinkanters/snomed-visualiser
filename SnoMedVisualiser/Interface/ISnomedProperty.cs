namespace SnoMedVisualiser.Interface
{
    public interface ISnomedProperty : ISnomedMember
    {
        ISnomedAnswer Answer { get; }
    }
}
