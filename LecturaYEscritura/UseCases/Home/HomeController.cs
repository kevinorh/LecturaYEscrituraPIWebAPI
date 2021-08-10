using LecturaYEscritura.UseCases.Home;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LecturaYEscritura.UseCases
{
    public class HomeController : Controller
    {
        private static string baseUrl = "https://l-srvpivision/piwebapi/";
        private class PIWebAPIInput
        {
            public string Timestamp { get; set; }
            public double Value { get; set; }
            public string UnitsAbbreviation { get; set; } = "";
            public bool Good { get; set; } = true;
            public bool Questionable { get; set; } = true;
            public PIWebAPIInput()
            {
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetData()
        {
            dynamic response;
            var process = new List<string>();
            string userName = @"cmbsaa\l-usrpiadmin";
            string password = "Limaabril2021$";
            //string tagPath = tagTextBox.Text;
            string webId = "F1DP8mfxL4ZDU0K2ynkbula9xQBAIAAATC1TUlZQSURBXFBSVUVCQVdFQkFQSQ";
            PIWebApiClient piWebAPIClient = new PIWebApiClient(userName, password);
            try
            {
                //Resolve tag path
                string requestUrl = baseUrl + "/streams/" + webId + "/plot";
                string tget = await piWebAPIClient.GetAsync(requestUrl);
                process.Add("Processing...");
                response = new
                {
                    success = true,
                    process = JsonConvert.SerializeObject(process),
                    data = tget
                };
            }
            catch (HttpRequestException ex)
            {
                process.Add(ex.Message);
                response = new
                {
                    success = false,
                    process = JsonConvert.SerializeObject(process)
                };
            }
            catch (Exception ex)
            {
                process.Add(ex.Message); 
                response = new
                {
                    success = false,
                    process = JsonConvert.SerializeObject(process)
                };
            }
            finally
            {
                //We are closing the HttpClient after every write in this simple example. This is not necessary.
                piWebAPIClient.Dispose();
            }
            
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostData(string webId, string fecha,string hora,int valor)
        {
            dynamic response;
            var process = new List<string>();
            string userName = @"cmbsaa\l-usrpiadmin";
            string password = "Limaabril2021$";
            //string tagPath = tagTextBox.Text;
            webId = "F1DP8mfxL4ZDU0K2ynkbula9xQBAIAAATC1TUlZQSURBXFBSVUVCQVdFQkFQSQ";
            PIWebApiClient piWebAPIClient = new PIWebApiClient(userName, password);
            try
            {
                //Convert Date and Time to TimeSpan 2021-08-03T21:07:08Z
                DateTime toTimeSpan = DateTime.Now;
                string timeSpan;
                if(DateTime.TryParse(fecha + " " + hora, out toTimeSpan))
                {
                    //DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK")
                    timeSpan = toTimeSpan.ToString("yyyy-MM-ddTHH:mm:ssZ");
                }
                else
                {
                    timeSpan = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
                }
                var input = new PIWebAPIInput
                {
                    Timestamp = timeSpan,
                    Value = valor
                };
                //Resolve tag path
                string requestUrl = baseUrl + "/streams/" + webId + "/value";
                await piWebAPIClient.PostAsync(requestUrl,JsonConvert.SerializeObject(input));
                process.Add("Processing...");
                response = new
                {
                    success = true,
                    process = JsonConvert.SerializeObject(process)
                };
            }
            catch (HttpRequestException ex)
            {
                process.Add(ex.Message);
                response = new
                {
                    success = false,
                    process = JsonConvert.SerializeObject(process)
                };
            }
            catch (Exception ex)
            {
                process.Add(ex.Message); 
                response = new
                {
                    success = false,
                    process = JsonConvert.SerializeObject(process)
                };
            }
            finally
            {
                //We are closing the HttpClient after every write in this simple example. This is not necessary.
                piWebAPIClient.Dispose();
            }
            
            return Ok(response);
        }
        /*
        {
            "Timestamp": "2021-08-03T21:07:08Z",
            "Value": 10.0,
            "UnitsAbbreviation": "",
            "Good": true,
            "Questionable": false
        }
         */
    }
}
