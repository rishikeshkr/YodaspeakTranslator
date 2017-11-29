using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Net;
using API.YodaSpeak;

namespace UnitTest.YodaSpeak
{
    [TestFixture]
    public class YodaSpeakTestCase
    {
        /*This method used for finding the length of input text box and enalbe/disable the "Translate" button accordingly*/
        [TestCase]
        public void TranslateBtnEnableDisable(string inputString) 
        {
            CheckInputText(inputString);
        }

        public bool CheckInputText(string inputString)
        {
            if (inputString.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*This method used to return true for Application start*/
        [TestCase]
        public void StartApplication()
        {
            checkSysteamCapability();
        }

        /*This method used to return Translate your text after enable the Translate Button*/
        [TestCase("I am very lazy person.")]
        public void TranslateInputText(string inputString)
        {
            CheckAsserts(inputString);
        }       

        public string CheckAsserts(string value)
        {
            string result = string.Empty;
            if (CheckInputText(value))
            {
                result = YodaTranslator.YodaSpeak(value.ToString());
                if (result != "")
                    return result;
                else
                    return result = "";
            }
            return result;
            
        }        

        public bool checkSysteamCapability()
        {
            if (Environment.Is64BitOperatingSystem)
                return true;
            else
                return false;
        }
    }
}
