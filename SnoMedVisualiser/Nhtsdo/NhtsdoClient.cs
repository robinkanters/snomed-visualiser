namespace SnoMedVisualiser.Nhtsdo
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Interface;
    using Model;

    public class NhtsdoClient
    {
        public static ISnomedAnswer LookupAnswer(ISctId sctId)
        {
            var request = BuildApiRequest(sctId);
            var apiResult = MakeApiCall(request);
            return ParseApiResult(apiResult);
        }

        public static async Task<ISnomedAnswer> LookupAnswerAsync(ISctId sctId)
        {
            var request = BuildApiRequest(sctId);
            var apiResult = await MakeApiCallAsync(request);
            return ParseApiResult(apiResult);
        }

        private static INhtsdoClientRequest BuildApiRequest(ISctId sctId)
        {
            var url = string.Format("http://multibrowser.ihtsdotools.org/api/snomed/nl-edition/v20150331/concepts/{0}", sctId.Id);
            var webRequest = WebRequest.CreateHttp(url);

            return new NhtsdoClientRequest
            {
                WebRequest = webRequest,
                Uri = new Uri(url)
            };
        }

        private static INhtsdoClientResponse MakeApiCall(INhtsdoClientRequest request)
        {
            var response = request.WebRequest.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());

            var responseString = reader.ReadToEnd();

            reader.Close();
            reader.Dispose();
            response.Close();
            response.Dispose();

            return new NhtsdoClientResponse
            {
                Response = responseString
            };
        }

        private static async Task<INhtsdoClientResponse> MakeApiCallAsync(INhtsdoClientRequest request)
        {
            var response = await request.WebRequest.GetResponseAsync();
            var reader = new StreamReader(response.GetResponseStream());

            var responseString = reader.ReadToEnd();

            reader.Close();
            reader.Dispose();
            response.Close();
            response.Dispose();

            return new NhtsdoClientResponse
            {
                Response = responseString
            };
        }

        private static ISnomedAnswer ParseApiResult(INhtsdoClientResponse apiResponse)
        {
            return SnomedAnswer.FromJson(apiResponse.Response);
        }
    }
}
