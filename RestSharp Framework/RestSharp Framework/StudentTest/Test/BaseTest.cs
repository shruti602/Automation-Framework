using AventStack.ExtentReports;
using CommonLibs.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThetestingworldApp.Request;
using System.Configuration;

namespace ThetestingworldApp.Test
{
    [TestClass]
    public class BaseTest
    {
        public RequestFactory requestFactory;
        public string endpointUrl;
        public string studentGetAllResource;
        public string studentPOSTResource;
        public static string currentSolutionDirectory;
        public static string currentprojectDirectory;
        public string Configuration;
        //static Iconfiguration Configuration;
        public static ExtentReportUtils reportUtils;

        [AssemblyInitialize]
        public static void PreSetup(TestContext context)
        {
            
            Console.WriteLine("PreSetup");
            string currentworkingDirectory = Environment.CurrentDirectory;
            currentprojectDirectory = Directory.GetParent(currentworkingDirectory).Parent.FullName.Replace("\\\\","\\");
            Console.WriteLine(currentprojectDirectory);
            currentSolutionDirectory = Directory.GetParent(currentworkingDirectory).Parent.Parent.Parent.FullName;
            //Configuration = new ConfigurationBuilder().AddJsonFile(currentProjectDirectory+ "/appSettings.Json").Build;
            string reportFilename = $"{currentprojectDirectory}/Reports/restSharp-report.html"; 
            reportUtils = new ExtentReportUtils(reportFilename);
        }



        [TestInitialize]
        public void Setup()
        {

            reportUtils.CreatetestCase("Pre-Requisite");
            requestFactory = new RequestFactory();
            // string server = Configuration["environment:server"];
            // int portNumber = int.parse(Configuration["environment:portNumber"]);
            //endpointUrl = $"http{server}:{portNumber}";
            //reportUtils.AddLogs(Status.Info, $"Executing test case at environment on server :{server}and port number:{portNumber}");

            endpointUrl = "http://thetestingworldapi.com";
            studentGetAllResource = "/api/studentsDetails";
            studentPOSTResource = "/api/studentsDetails";
            Console.WriteLine("Setup");    

        }

        [TestCleanup]

      public void Cleanup()
        {
            Console.WriteLine("Cleanup");
        }

        [AssemblyCleanup ]
        public static void PostCleanup()
        {
            Console.WriteLine("Post-Cleanup");
        }
    }
}
