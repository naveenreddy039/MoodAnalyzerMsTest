using ExceptionDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void msgSadMood()
        {
            string msg = "I am in sad mood";
            string expected = "SAD";

            MoodAnalyser mood = new MoodAnalyser(msg);

            string actual = mood.AnalyseMood();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void msgHaapyMood()
        {
            string msg = "I am in Any mood";
            string expected = "HAPPY";

            MoodAnalyser mood = new MoodAnalyser(msg);

            string actual = mood.AnalyseMood();

            Assert.AreEqual(expected, actual);
        }

    }
}
