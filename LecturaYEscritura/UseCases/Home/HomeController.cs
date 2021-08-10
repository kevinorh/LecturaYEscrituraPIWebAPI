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
        private static string userName = @"cmbsaa\l-usrpiadmin";
        private static string password = "Limaabril2021$";

        private static List<WritableTag> WritableTagsList = new List<WritableTag>();        

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
        private class WritableTag
        {
            public string Name { get; set; } 
            public string WebId { get; set; } 
            public string Path { get; set; }
        }
        private class TagListResponse
        {
            public string Name { get; set; } 
            public string WebId { get; set; } 
            public string Result { get; set; }
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetTagListValues()
        {
            WritableTagsList.Clear();
            WritableTagsList.Add(new WritableTag { Name = "pruebaWEBAPI", WebId = "F1DP8mfxL4ZDU0K2ynkbula9xQBAIAAATC1TUlZQSURBXFBSVUVCQVdFQkFQSQ", Path = "\\\\l-srvpida\\pruebaWEBAPI" });
            WritableTagsList.Add(new WritableTag { Name = "pruebaWEBAPI1", WebId = "F1DP8mfxL4ZDU0K2ynkbula9xQBQIAAATC1TUlZQSURBXFBSVUVCQVdFQkFQSTE", Path = "\\\\l-srvpida\\pruebaWEBAPI1" });
            WritableTagsList.Add(new WritableTag { Name = "pruebaWEBAPI2", WebId = "F1DP8mfxL4ZDU0K2ynkbula9xQBgIAAATC1TUlZQSURBXFBSVUVCQVdFQkFQSTI", Path = "\\\\l-srvpida\\pruebaWEBAPI2" });
            WritableTagsList.Add(new WritableTag { Name = "pruebaWEBAPI3", WebId = "F1DP8mfxL4ZDU0K2ynkbula9xQBwIAAATC1TUlZQSURBXFBSVUVCQVdFQkFQSTM", Path = "\\\\l-srvpida\\pruebaWEBAPI3" });
            WritableTagsList.Add(new WritableTag { Name = "pruebaWEBAPI4", WebId = "F1DP8mfxL4ZDU0K2ynkbula9xQCAIAAATC1TUlZQSURBXFBSVUVCQVdFQkFQSTQ", Path = "\\\\l-srvpida\\pruebaWEBAPI4" });
            WritableTagsList.Add(new WritableTag { Name = "pruebaWEBAPI5", WebId = "F1DP8mfxL4ZDU0K2ynkbula9xQCQIAAATC1TUlZQSURBXFBSVUVCQVdFQkFQSTU", Path = "\\\\l-srvpida\\pruebaWEBAPI5" });

            dynamic response;
            bool success = true;
            var process = new List<string>(); 
            var results = new List<TagListResponse>(); 
            PIWebApiClient piWebAPIClient = new PIWebApiClient(userName, password);
            foreach (var writeableTag in WritableTagsList)
            {
                try
                {
                    //Resolve tag path
                    string requestUrl = baseUrl + "/streams/" + writeableTag.WebId + "/plot";
                    string tget = await piWebAPIClient.GetAsync(requestUrl);
                    process.Add("--------------------------------");
                    process.Add("Asking for values of " + writeableTag.Name);
                    process.Add("WebID " + writeableTag.WebId);
                    process.Add("Processing...");
                    results.Add(new TagListResponse { WebId = writeableTag.WebId , Name = writeableTag.Name, Result = tget}); 
                    process.Add("Exito...");
                }
                catch (HttpRequestException ex)
                {
                    process.Add("Error...");
                    process.Add(ex.Message); 
                    success = false;
                }
                catch (Exception ex)
                {
                    process.Add("Error...");
                    process.Add(ex.Message);
                    success = false;
                }
            }
            piWebAPIClient.Dispose();
            response = new
            {
                success = success,
                process = JsonConvert.SerializeObject(process),
                data = JsonConvert.SerializeObject(results)
            };
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> GetData()
        {
            dynamic response;
            var process = new List<string>();
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
                piWebAPIClient.Dispose();
            }
            
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostData(string webId, string fecha,string hora,int valor)
        {
            dynamic response;
            var process = new List<string>();            
            PIWebApiClient piWebAPIClient = new PIWebApiClient(userName, password);
            try
            {
                //Convert Date and Time to TimeSpan 2021-08-03T21:07:08Z
                DateTime toTimeSpan = DateTime.Now;
                string timeSpan;
                if(DateTime.TryParse(fecha + " " + hora, out toTimeSpan))
                {
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
                piWebAPIClient.Dispose();
            }
            
            return Ok(response);
        }
    }
}
