namespace SnoMedVisualiser.UnitTest.Nhtsdo
{
    using Interface;
    using Interface.Fakes;
    using Model;
    using NUnit.Framework;
    using SnoMedVisualiser.Nhtsdo;

    public class NhtsdoClientTest
    {
        [Test]
        public void NhtsdoClient_DoApiRequest_Success()
        {
            var id = SctId.FromString("41796003");
            var answer = NhtsdoClient.LookupAnswer(id);

            Assert.That(answer, Is.Not.Null);
            Assert.That(answer.SctId.Id, Is.EqualTo(id.Id));
            Assert.That(answer.DefaultTerm, Is.Not.Null.And.Not.Empty);
        }
    }
}
