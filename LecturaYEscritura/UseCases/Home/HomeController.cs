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
        private static string baseUrl = "https://svsrfpivision.mineria.breca/piwebapi/";
        private static string userName = @"mineria\admin.pi";
        private static string password = @"Q=i5G3uPt$";

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
            WritableTagsList.Add(new WritableTag { Name = "TagManual1", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwHgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMQ", Path = "\\\\SVSRFPIARCHIVE\\TagManual1" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual2", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwHwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMg", Path = "\\\\SVSRFPIARCHIVE\\TagManual2" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual3", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMw", Path = "\\\\SVSRFPIARCHIVE\\TagManual3" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual4", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNA", Path = "\\\\SVSRFPIARCHIVE\\TagManual4" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual5", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNQ", Path = "\\\\SVSRFPIARCHIVE\\TagManual5" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual6", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNg", Path = "\\\\SVSRFPIARCHIVE\\TagManual6" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual7", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNw", Path = "\\\\SVSRFPIARCHIVE\\TagManual7" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual8", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMOA", Path = "\\\\SVSRFPIARCHIVE\\TagManual8" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual9", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMOQ", Path = "\\\\SVSRFPIARCHIVE\\TagManual9" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual10", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTA", Path = "\\\\SVSRFPIARCHIVE\\TagManua10" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual11", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTE", Path = "\\\\SVSRFPIARCHIVE\\TagManua11" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual12", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTI", Path = "\\\\SVSRFPIARCHIVE\\TagManua12" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual13", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTM", Path = "\\\\SVSRFPIARCHIVE\\TagManua13" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual14", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTQ", Path = "\\\\SVSRFPIARCHIVE\\TagManua14" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual15", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTU", Path = "\\\\SVSRFPIARCHIVE\\TagManua15" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual16", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTY", Path = "\\\\SVSRFPIARCHIVE\\TagManua16" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual17", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTc", Path = "\\\\SVSRFPIARCHIVE\\TagManua17" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual18", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTg", Path = "\\\\SVSRFPIARCHIVE\\TagManua18" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual19", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMTk", Path = "\\\\SVSRFPIARCHIVE\\TagManua19" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual20", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjA", Path = "\\\\SVSRFPIARCHIVE\\TagManua20" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual21", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjE", Path = "\\\\SVSRFPIARCHIVE\\TagManua21" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual22", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjI", Path = "\\\\SVSRFPIARCHIVE\\TagManua22" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual23", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjM", Path = "\\\\SVSRFPIARCHIVE\\TagManua23" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual24", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjQ", Path = "\\\\SVSRFPIARCHIVE\\TagManua24" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual25", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjU", Path = "\\\\SVSRFPIARCHIVE\\TagManua25" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual26", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjY", Path = "\\\\SVSRFPIARCHIVE\\TagManua26" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual27", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjc", Path = "\\\\SVSRFPIARCHIVE\\TagManua27" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual28", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjg", Path = "\\\\SVSRFPIARCHIVE\\TagManua28" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual29", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMjk", Path = "\\\\SVSRFPIARCHIVE\\TagManua29" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual30", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzA", Path = "\\\\SVSRFPIARCHIVE\\TagManua30" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual31", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzE", Path = "\\\\SVSRFPIARCHIVE\\TagManua31" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual32", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzI", Path = "\\\\SVSRFPIARCHIVE\\TagManua32" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual33", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzM", Path = "\\\\SVSRFPIARCHIVE\\TagManua33" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual34", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzQ", Path = "\\\\SVSRFPIARCHIVE\\TagManua34" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual35", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzU", Path = "\\\\SVSRFPIARCHIVE\\TagManua35" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual36", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzY", Path = "\\\\SVSRFPIARCHIVE\\TagManua36" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual37", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzc", Path = "\\\\SVSRFPIARCHIVE\\TagManua37" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual38", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzg", Path = "\\\\SVSRFPIARCHIVE\\TagManua38" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual39", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzk", Path = "\\\\SVSRFPIARCHIVE\\TagManua39" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual40", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDA", Path = "\\\\SVSRFPIARCHIVE\\TagManua40" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual41", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDE", Path = "\\\\SVSRFPIARCHIVE\\TagManua41" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual42", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDI", Path = "\\\\SVSRFPIARCHIVE\\TagManua42" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual43", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwSAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDM", Path = "\\\\SVSRFPIARCHIVE\\TagManua43" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual44", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwSQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDQ", Path = "\\\\SVSRFPIARCHIVE\\TagManua44" });
            WritableTagsList.Add(new WritableTag { Name = "TagManual45", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwSgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDU", Path = "\\\\SVSRFPIARCHIVE\\TagManua45" });

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
