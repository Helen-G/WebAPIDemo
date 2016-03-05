using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using WebAPIDemo2.Controllers;


namespace WebAPIDemo2.Tests
{
    [TestFixture]
    public class MainTests
    {
        [Test]
        public void GET_Values_returns_200_code()
        {
            var serviceUrlString = ConfigurationManager.AppSettings["ServiceUrl"];

            //create an instance of Uri class to validate the service url string
            var serviceUrl = new Uri(serviceUrlString);
            var client = new WebClient();
            Assert.DoesNotThrow(() =>
            {
                // method to create and send GET request
                client.DownloadString(serviceUrl.ToString() + "api/values");
            });
        }

        [Test]
        public async Task GET_Values_returns_200_code_HttpClient()
        {
             var serviceUrlString = ConfigurationManager.AppSettings["ServiceUrl"];
            var serviceUrl = new Uri(serviceUrlString);
            var client = new HttpClient();
            var response = await client.GetAsync(serviceUrl.ToString() + "api/values");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content.ReadAsStringAsync().Result);
        }

        [Test]
        public async void GET_Values_returns_values()
        {
            var serviceUrlString = ConfigurationManager.AppSettings["ServiceUrl"];
            var serviceUrl = new Uri(serviceUrlString);
            var client = new HttpClient();

            // set up the format for the response
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            var response = await client.GetAsync(serviceUrl.ToString() + "api/values");

            // gets the content of http responce and converts it to a string
            var result = response.Content.ReadAsStringAsync().Result;

            var xmlDocument = XDocument.Parse(result);
            if (xmlDocument.Root != null)
            {
                var nodes = xmlDocument.Root.Descendants().Select(x => x.Value).ToList();

                Assert.AreEqual("value1", nodes[0]);
                Assert.AreEqual("value2", nodes[1]);
            }
        }

        [Test]
        public async Task Get_Flower_returns_flower()
        {
            var serviceUrlString = ConfigurationManager.AppSettings["ServiceUrl"];
            var serviceUrl = new Uri(serviceUrlString);
            var client = new HttpClient();

            // set up the format for the response
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            var response = await client.GetAsync(serviceUrl.ToString() + "api/values/flower");

            // gets the content of http responce and converts it to a string
            var result = response.Content.ReadAsStringAsync().Result;

            //way #1 to parse xml response
            var doc = new XmlDocument();
            doc.LoadXml(result);
            var flowerName = doc.GetElementsByTagName("Name")[0].InnerText;
            var flowerQuantity = doc.GetElementsByTagName("Quantity")[0].InnerText;
            var flowerSize = doc.GetElementsByTagName("Size")[0].InnerText;
            Assert.AreEqual(new Flower().Name, flowerName);
            Assert.AreEqual(new Flower().Quantity.ToString(), flowerQuantity);
            Assert.AreEqual(new Flower().Size, flowerSize);

            //way #2 to parse xml response
            var xmlDocument = XDocument.Parse(result);
            if (xmlDocument.Root != null)
            {
                var nodes = xmlDocument.Root.Descendants().Select(x => x.Value).ToList();
                Assert.AreEqual("Daizy", nodes[0]);
                Assert.AreEqual("2", nodes[1]);
                Assert.AreEqual("big", nodes[2]);
            }
        }
    }
}
