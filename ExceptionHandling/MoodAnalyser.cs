using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    public class MoodAnalyse
    {
        internal string Message;
        private string message;

        public MoodAnalyse()
        {
        }



        //creating constructor
        public MoodAnalyse(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            //try
            //{
               // if (this.message.Contains("Sad"))
               // {
               //     return "SAD";
               // }
              //  else
               // {
            //        return "HAPPY";
            //    }
            //}
            //catch
            //{
              //  return "HAPPY";
            //}

            //UC3
            try
            {
                if(this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustom(MoodAnalyserCustom.ExceptionType.EMPTY_MESSAGE, "Mood Should not be empty");
                }
                if (this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                 else
                {
                    return "HAPPY";
                 }

            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserCustom(MoodAnalyserCustom.ExceptionType.NULL_MESSAGE, "Mood Should not be Null");
            }
        }
    }
}
