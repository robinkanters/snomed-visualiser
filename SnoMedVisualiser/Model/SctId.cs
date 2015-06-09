namespace SnoMedVisualiser.Model
{
    using Interface;

    public class SctId : ISctId
    {
        public string Id { get; set; }

        public static ISctId FromString(string id)
        {
            return new SctId {Id = id};
        }
    }
}
