namespace SnoMedVisualiser.Interface
{
    using System;
    using System.Net;

    public interface INhtsdoClientRequest
    {
        WebRequest WebRequest { get; }
        Uri Uri { get; }
    }
}