using ExceptionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoodAnalyzerMSTestWithCore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sad()
        {
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);

            string mood = moodAnalyse.AnalyseMood();
            Assert.AreEqual(expected, mood);
        }

        [TestMethod]
        [DataRow("I am in Happy Mood")]
        [DataRow(null)]
        public void GivenSadMoodShouldReturnHappy(string message)
        {
            string expected = "HAPPY";
            //string message = "I am in Happy Mood";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);

            string mood = moodAnalyse.AnalyseMood();
            Assert.AreEqual(expected, mood);
        }

        //UC3
        [TestMethod]

        public void Given_Empty_Mood_Should_throw_MoodAnalyserCustom_Indicating_EmptyMood()
        {
            try
            {
                string message = "Empty";
                MoodAnalyse moodAnalyse = new MoodAnalyse(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch(MoodAnalyserCustom e)
            {
                Assert.AreEqual("Mood Should not be Empty", e.Message);
            }
        }
        [TestMethod]

        public void Given_Null_Mood_Should_throw_MoodAnalyserCustom()
        {
            try
            {
                string message = null;
                MoodAnalyse moodAnalyse = new MoodAnalyse(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserCustom e)
            {
                Assert.AreEqual("Mood Should not be Null", e.Message);
            }
        }

        //UC4
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyse();
            object obj = MoodAnalyseFactory.CreateMoodAnalyse("MoodAnalyserApp.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        //UC5
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_usingParameeterizedConstructor()
        {
            object expected = new MoodAnalyse("HAPPY");
            object obj = MoodAnalyseFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserApp.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);

        }
        //UC6
        [TestMethod]

        public void Given_HAPPYMessage_WithReflector_Should_ReturnhAPPY()
        {
            string result = MoodAnalyseFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }
    }
}

