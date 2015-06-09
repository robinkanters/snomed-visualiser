namespace SnoMedVisualiser.Interface
{
    using System.Collections.Generic;

    public interface ISnomedAnswer
    {
        IList<ISnomedProperty> Properties { get; }
        ISctId SctId { get; set; }
    }
}
