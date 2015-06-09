namespace SnoMedVisualiser.UnitTest
{
    using Interface;
    using Model;
    using NUnit.Framework;

    public class SnoMedParserTest
    {

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [TestCase("410609009")]
        [TestCase("39801007")]
        [TestCase("41796003")]
        public void ParseSnoMedCode(string code)
        {
            var answer = SnomedParser.ParseSnoMedString(code); 

            Assert.That(answer, Is.Not.Null);
            Assert.That(answer.SctId.Id, Is.EqualTo(code));
        }

        [Test]
        [TestCase("76505004:272741003=7771000")]
        public void ParseMultipartSnoMedCode(string code)
        {
            var answer = SnomedParser.ParseSnoMedString(code);

            Assert.That(answer, Is.Not.Null);
            Assert.That(answer.Properties.Count, Is.GreaterThanOrEqualTo(1));
        }
    }
}
