using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ExceptionHandling
{
    //UC4
    public class MoodAnalyseFactory
    {
        public static object CreateMoodAnalyse(string className,string ConstructorName)
        {
            string pattern = @"," + ConstructorName + "$";
            Match results = Regex.Match(className, pattern);

            if(results.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch(ArgumentNullException)
                {
                    throw new MoodAnalyserCustom(MoodAnalyserCustom.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustom(MoodAnalyserCustom.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");

            }
        }
        //UC5
        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string ConstructorName, string message)
        {
            Type type = typeof(MoodAnalyse);
            if(type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if(type.Name.Equals(ConstructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object insatance = ctor.Invoke(new object[] { message });
                    return insatance;
                }
                else
                {
                    throw new MoodAnalyserCustom(MoodAnalyserCustom.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");

                }
            }
            else
            {
                throw new MoodAnalyserCustom(MoodAnalyserCustom.ExceptionType.NO_SUCH_CLASS, "Class not found");

            }
        }
        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="ExceptionHandling.MoodAnalyserCustom">message should  not be null</exception>
        public static string SetField(string Message,string fieldName)
        {
            try
            {
                MoodAnalyse moodAnalyse = new MoodAnalyse();
                Type type = typeof(MoodAnalyse);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if(Message==null)
                {
                    throw new MoodAnalyserCustom(MoodAnalyserCustom.ExceptionType.NO_SUCH_FIELD, "message should  not be null");

                }
                field.SetValue(moodAnalyse, Message);
                return moodAnalyse.Message;
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserCustom(MoodAnalyserCustom.ExceptionType.NO_SUCH_FIELD, "Field is not found");

            }
        }
    }
}
