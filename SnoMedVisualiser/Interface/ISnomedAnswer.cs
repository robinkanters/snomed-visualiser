namespace SnoMedVisualiser.Interface
{
    using System.Collections.Generic;

    public interface ISnomedAnswer : ISnomedMember
    {
        IList<ISnomedProperty> Properties { get; }
        ISctId SctId { get; set; }
        string DefaultTerm { get; set; }
    }
}
