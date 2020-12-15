using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using ThetestingworldApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThetestingworldApp.Test;

namespace ThetestingworldApp.Test
{
    [TestClass]
    public class StudentAPITest : BaseTest
    { 

        [TestMethod]
        public void VerifyGetStudentdetailsAPI()
        {


            reportUtils.CreatetestCase("VerifyGetStudentdetailsAPI-Test");
            var id_input = 78612;
            var restResponse = requestFactory.GetAllStudent($"{endpointUrl}{studentGetAllResource}/{id_input}");
            reportUtils.AddLogs(Status.Info, $"Response Status Code: {restResponse.StatusCode}\n" + $"Content: {restResponse.Content}");
            var id = restResponse.Data.data.id;
            Assert.AreEqual(id, id_input);
            Console.WriteLine(id);
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);           
        }


        [TestMethod]
        public void VerifyGetStudentAPIwithQueryparam()
        {
            reportUtils.CreatetestCase("VerifyGetStudentIdwithQueryparam-Test");
            Dictionary<string, object> queryparam = new Dictionary<string, object>();
            int limit = 5;
            queryparam.Add("page", limit);

            IRestResponse restResponse = requestFactory.GetAllStudent($"{endpointUrl}{studentGetAllResource}", queryparam);
            reportUtils.AddLogs(Status.Info, $"Response Status Code: {restResponse.StatusCode}\n" + $"Content: {restResponse.Content}");
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

        }

        [TestMethod]

        public void VerifyCreateStudentWithStringRequestPayload()
        {
            string requestPayload = "{\r\n  \"id\": 1,\r\n  \"first_name\": \"Shruti\",\r\n  \"middle_name\": \"Mohan\",\r\n  \"last_name\": \"sample string 4\",\r\n  \"date_of_birth\": \"July-14\"\r\n}";
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Console.WriteLine(restResponse.Data.id);
        }


        [TestMethod]
        public void VerifyCreateStudentAPIwithDictionary()
        {
            Dictionary<string, object> requestPayload = new Dictionary<string, object>();
            requestPayload.Add("id",3);
            requestPayload.Add("first_name", "Shruti");
            requestPayload.Add("middle_name", "Mohan");
            requestPayload.Add("last_name", "Jha");
            requestPayload.Add("date_of_birth", "July-14");
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
           Console.WriteLine(restResponse.Data.id);
        }


        [TestMethod]
        public void VerifyCreateStudentAPIJSON()
        {
            string requestPayLoadJsonFile = $"{currentprojectDirectory}/TestData/Studentdetails.json";
            string requestPayload = File.ReadAllText(requestPayLoadJsonFile);
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Console.WriteLine(restResponse.Data.id);
        }

        [TestMethod]
        public void VerifyCreateStudentAPIwithDto()
        {
            RootPostStudentDto requestPayload = new RootPostStudentDto();
            requestPayload.id = 1234;
            requestPayload.first_name = "Shruti";
            requestPayload.last_name = "Mohan";
            requestPayload.middle_name = "jha";
            requestPayload.date_of_birth = "July-14";
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Console.WriteLine(restResponse.Data.id);
        }

        [TestMethod]
        public void VerifyUpdateAndDeleteStudentAPIwithDto()
        {
            RootPostStudentDto requestPayload = new RootPostStudentDto();
            requestPayload.id = 1234;
            requestPayload.first_name = "Shruti";
            requestPayload.last_name = "Mohan";
            requestPayload.middle_name = "jha";
            requestPayload.date_of_birth = "July-14";
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            var id = restResponse.Data.id;
            RootPostStudentDto requestPayloadFrUpdate = new RootPostStudentDto();
            requestPayloadFrUpdate.id = id;
            requestPayloadFrUpdate.first_name = "Shikha";
            requestPayloadFrUpdate.last_name = "Mohan";
            requestPayloadFrUpdate.middle_name = "Jha";
            requestPayloadFrUpdate.date_of_birth = "July-15";

            var restResponse1 = requestFactory.EditStudent($"{endpointUrl}{studentPOSTResource}/{id}", requestPayloadFrUpdate);
            Assert.AreEqual(HttpStatusCode.OK, restResponse1.StatusCode);
            Console.WriteLine(restResponse1.Data.msg);
            Console.WriteLine(restResponse1.Data.status);

            var restResponse2 = requestFactory.DeleteStudent($"{endpointUrl}{studentPOSTResource}/{id}");
            Assert.AreEqual(HttpStatusCode.OK, restResponse1.StatusCode);
      
            
            var restResponse3 = requestFactory.GetAllStudent($"{endpointUrl}{studentGetAllResource}/{id}");
            Assert.AreEqual(HttpStatusCode.OK, restResponse3.StatusCode);


        }

    }
}
