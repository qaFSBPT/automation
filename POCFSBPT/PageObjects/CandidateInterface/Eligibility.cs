using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCFSBPT.PageObjects
{
    class Eligibility
    {
        private RemoteWebDriver driver;

        public Eligibility(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        // Page Elements
        #region PageElements

        private IWebElement educationLevel => driver.FindElementById("educationLevel");
        private SelectElement chooseEducationLevel
        {
            get
            {
                return new SelectElement(educationLevel);
            }
        }
        private IWebElement evaluationDate => driver.FindElementById("evaluationDate");
        private IWebElement credentialingAgency => driver.FindElementById("credentialingAgency");
        private SelectElement chooseCredentialingAgency
        {
            get
            {
                return new SelectElement(credentialingAgency);
            }
        }
        private IWebElement fileNumber => driver.FindElementById("FileNumber");
        private IWebElement toolName => driver.FindElementById("educationEquivalencePtToolVersion");
        private SelectElement chooseToolName
        {
            get
            {
                return new SelectElement(toolName);
            }
        }
        private IWebElement toolStatus => driver.FindElementById("educationEquivalenceToolStatus");
        private SelectElement chooseToolStatus
        {
            get
            {
                return new SelectElement(toolStatus);
            }
        }
        private IWebElement educationUploadButton => driver.FindElementById("education-equivalence-upload-file-button");
        private IWebElement toeflTaken => driver.FindElementById("ToeflTaken");
        private SelectElement chooseToeflTaken
        {
            get
            {
                return new SelectElement(toeflTaken);
            }
        }
        private IWebElement toeflDate => driver.FindElementById("toeflDate");
        private IWebElement nativeLanguage => driver.FindElementById("nativeLanguage");
        private SelectElement chooseNativeLanguage
        {
            get
            {
                return new SelectElement(nativeLanguage);
            }
        }
        private IWebElement otherNativeLanguage => driver.FindElementById("OtherNativeLanguage");
        private IWebElement readingScore => driver.FindElementById("ReadingScore");
        private IWebElement listeningScore => driver.FindElementById("ListeningScore");
        private IWebElement speakingScore => driver.FindElementById("SpeakingScore");
        private IWebElement writingScore => driver.FindElementById("WritingScore");
        private IWebElement toeflUploadButton => driver.FindElementById("toefl_upload-file-button");

        #endregion PageElements

        // Page Functions
        #region PageFunctions
        public void SelectEvaluationLevel(string level)
        {
            chooseEducationLevel.SelectByText(level);
        }
        public void TypeEvaluationDate(string date)
        {
            evaluationDate.SendKeys(date);
        }
        public void SelectCredentialingAgency(string agency)
        {
            chooseCredentialingAgency.SelectByText(agency);
        }
        public void TypeFileNumber(string number)
        {
            fileNumber.SendKeys(number);
        }
        public void SelectToolName(string name)
        {
            chooseToolName.SelectByText(name);
        }
        public void SelectToolStatus(string status)
        {
            chooseToolStatus.SelectByText(status);
        }
        public void ClickUploadEducation()
        {
            educationUploadButton.Click();
        }
        public void SelectToeflTaken(string choice)
        {
            chooseToeflTaken.SelectByText(choice);
        }
        public void TypeToeflDate(string date)
        {
            toeflDate.SendKeys(date);
        }
        public void SelectNativeLanguage(string language)
        {
            chooseNativeLanguage.SelectByText(language);
        }
        public void TypeOtherLanguage(string language)
        {
            otherNativeLanguage.SendKeys(language);
        }
        public void TypeReadingScore(string score)
        {
            readingScore.SendKeys(score);
        }
        public void TypeListeningScore(string score)
        {
            listeningScore.SendKeys(score);
        }
        public void TypeWritingScore(string score)
        {
            writingScore.SendKeys(score);
        }
        public void TypeSpeakingScore(string score)
        {
            speakingScore.SendKeys(score);
        }
        public void ClickUploadToefl()
        {
            toeflUploadButton.Click();
        }
        #endregion PageFunctions
    }
}
