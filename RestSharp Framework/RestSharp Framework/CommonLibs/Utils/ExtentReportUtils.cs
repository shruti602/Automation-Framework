using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.Utils
{
    public class ExtentReportUtils
    {
        private ExtentReports extentReports;
        private ExtentHtmlReporter htmlReporter;
        private ExtentTest extentTest;
        public ExtentReportUtils(string htmlReportFile)
        {
            extentReports = new ExtentReports();
            htmlReportFile = htmlReportFile.Trim();
            htmlReporter = new ExtentHtmlReporter(htmlReportFile);
            extentReports.AttachReporter(htmlReporter);
        }

        public void CreatetestCase(string TestcaseName, string TestCaseDescription)
        {
            extentTest = extentReports.CreateTest(TestcaseName, TestCaseDescription);
        }

        public void CreatetestCase(string TestcaseName)
        {
            extentTest = extentReports.CreateTest(TestcaseName);
        }


        public void AddLogs(Status status, string logMessage)
        {
            extentTest.Log(status, logMessage);
        }


        public void DisposeExtentReport()
        {
            extentReports.Flush();
        }
    }
}
