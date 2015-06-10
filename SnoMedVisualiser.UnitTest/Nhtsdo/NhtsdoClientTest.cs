namespace SnoMedVisualiser.UnitTest.Nhtsdo
{
    using System.Diagnostics;
    using Interface;
    using Interface.Fakes;
    using Model;
    using NUnit.Framework;
    using SnoMedVisualiser.Nhtsdo;

    public class NhtsdoClientTest
    {
        [Test]
        [TestCase("41796003")]
        public void NhtsdoClient_DoApiRequest_Success(string sctId)
        {
            var id = SctId.FromString(sctId);
            var answer = NhtsdoClient.LookupAnswer(id);

            Debug.WriteLine(answer.DefaultTerm);

            Assert.That(answer, Is.Not.Null);
            Assert.That(answer.SctId.Id, Is.EqualTo(id.Id));
            Assert.That(answer.DefaultTerm, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        [TestCase("41796003")]
        public async void NhtsdoClient_DoApiRequestAsync_Success(string sctId)
        {
            var id = SctId.FromString(sctId);
            var answerTask = NhtsdoClient.LookupAnswerAsync(id);

            var answer = await answerTask;

            Debug.WriteLine(answer.DefaultTerm);

            Assert.That(answer, Is.Not.Null);
            Assert.That(answer.SctId.Id, Is.EqualTo(id.Id));
            Assert.That(answer.DefaultTerm, Is.Not.Null.And.Not.Empty);
        }
    }
}
