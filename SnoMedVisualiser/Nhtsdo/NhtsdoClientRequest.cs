namespace SnoMedVisualiser.Nhtsdo
{
    using System;
    using System.Net;
    using Interface;

    public class NhtsdoClientRequest : INhtsdoClientRequest
    {
        public WebRequest WebRequest { get; set; }

        public Uri Uri { get; set; }
    }
}
