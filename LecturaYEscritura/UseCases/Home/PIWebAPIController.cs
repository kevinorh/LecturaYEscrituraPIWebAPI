using LecturaYEscritura.UseCases.Home.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LecturaYEscritura.UseCases.Home
{
    public class PIWebAPIController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private static readonly string baseUrl = "https://172.20.0.122/piwebapi/";
        private static readonly string userName = @"mineria\serv.pmanual.puc";
        private static readonly string password = @"M#}tey~UE5&3n4f-";

        private static readonly List<WritableTag> WritableTagsList = new List<WritableTag>();
        private static readonly List<Area> AreasList = new List<Area> {
            new Area { Id = 1,Descripcion= "PUCAMARCA" }
        };
        private static readonly List<SubArea> SubAreasList = new List<SubArea> {
            new SubArea { Id = 1,Descripcion= "CHANCADO" },
            new SubArea { Id = 2, Descripcion = "LIXIVIACIÓN" } ,
            new SubArea { Id = 3, Descripcion = "ADR" },
            new SubArea { Id = 4, Descripcion = "AZUFRE" }
        };
        public PIWebAPIController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        private class TagListResponse
        {
            public string Name { get; set; }
            public string WebId { get; set; }
            public string Unit { get; set; }
            public double MinValue { get; set; }
            public double MaxValue { get; set; }
            public string Type { get; set; }
            public string Descriptor { get; set; }
            public string Area { get; set; }
            public string SubArea { get; set; }
            public string Result { get; set; }
        }
        public class PiPointsResponse
        {
            public string WebId { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Path { get; set; }
            public string Descriptor { get; set; }
            public string PointClass { get; set; }
            public string PointType { get; set; }
            public string DigitalSetName { get; set; }
            public string EngineeringUnits { get; set; }
            public float Span { get; set; }
            public float Zero { get; set; }
            public bool Step { get; set; }
            public bool Future { get; set; }
            public float DisplayDigits { get; set; }
            //public Links Links { get; set; }
        }
        public class Links
        {

            public string Self { get; set; }
            public string DataServer { get; set; }
            public string Attributes { get; set; }
            public string InterpolatedData { get; set; }
            public string RecordedData { get; set; }
            public string PlotData { get; set; }
            public string SummaryData { get; set; }
            public string Value { get; set; }
            public string EndValue { get; set; }
        }
        [HttpPost]
        public async Task<IActionResult> GetTagListValues()
        {
            WritableTagsList.Clear();
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"Chancado.Horas_Produccion.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFgglgAAAAU1ZQVUNQSUFSQ0hJVkVcQ0hBTkNBRE8uSE9SQVNfUFJPRFVDQ0lPTi5JTQ", Path = @"\\SVPUCPIARCHIVE\Chancado.Horas_Produccion.IM", Unit = "h", MinValue = 0, MaxValue = 2000, Type = "float", Descriptor = "Horas de Producción" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"Chancado.P80.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFgglwAAAAU1ZQVUNQSUFSQ0hJVkVcQ0hBTkNBRE8uUDgwLklN", Path = @"\\SVPUCPIARCHIVE\Chancado.P80.IM", Unit = "in", MinValue = 32, MaxValue = 82, Type = "float", Descriptor = "P80" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"Chancado.Ratio_Cal.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggmAAAAAU1ZQVUNQSUFSQ0hJVkVcQ0hBTkNBRE8uUkFUSU9fQ0FMLklN", Path = @"\\SVPUCPIARCHIVE\Chancado.Ratio_Cal.IM", Unit = "kg cal/TM", MinValue = 65, MaxValue = 139, Type = "float", Descriptor = "Ratio de cal" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"Lixiviacion.Area_Celdas.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggmQAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uQVJFQV9DRUxEQVMuSU0", Path = @"\\SVPUCPIARCHIVE\Lixiviacion.Area_Celdas.IM", Unit = "m2", MinValue = 10, MaxValue = 29, Type = "float", Descriptor = "Área de celdas" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"Lixiviacion.Tonelaje_Celdas.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggmgAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uVE9ORUxBSkVfQ0VMREFTLklN", Path = @"\\SVPUCPIARCHIVE\Lixiviacion.Tonelaje_Celdas.IM", Unit = "TM", MinValue = 48, MaxValue = 106, Type = "float", Descriptor = "Tonelaje de celdas" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"Lixiviacion.Altura_Celdas.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggmwAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uQUxUVVJBX0NFTERBUy5JTQ", Path = @"\\SVPUCPIARCHIVE\Lixiviacion.Altura_Celdas.IM", Unit = "m", MinValue = 1400, MaxValue = 3100, Type = "float", Descriptor = "Altura de celdas" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"Lixiviacion.Onzas_Celdas.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggnAAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uT05aQVNfQ0VMREFTLklN", Path = @"\\SVPUCPIARCHIVE\Lixiviacion.Onzas_Celdas.IM", Unit = "Oz", MinValue = 1200, MaxValue = 2700, Type = "float", Descriptor = "Onzas puestas en celdas" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"Lixiviacion.Onzas_Recuperables.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggnQAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uT05aQVNfUkVDVVBFUkFCTEVTLklN", Path = @"\\SVPUCPIARCHIVE\Lixiviacion.Onzas_Recuperables.IM", Unit = "Oz", MinValue = 1100, MaxValue = 2400, Type = "float", Descriptor = "Onzas recuperables " });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"Lixiviacion.Inicio_Riego.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggngAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uSU5JQ0lPX1JJRUdPLklN", Path = @"\\SVPUCPIARCHIVE\Lixiviacion.Inicio_Riego.IM", Unit = "", MinValue = 1050, MaxValue = 2300, Type = "float", Descriptor = "Inicio de riego (días de riego)" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"Lixiviacion.Porcentaje_Extraccion.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggnwAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uUE9SQ0VOVEFKRV9FWFRSQUNDSU9OLklN", Path = @"\\SVPUCPIARCHIVE\Lixiviacion.Porcentaje_Extraccion.IM", Unit = "%", MinValue = 1000, MaxValue = 2300, Type = "float", Descriptor = "Porcentaje de extracción" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"Lixiviacion.Nivel_Freatico_Dinamico.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggFgEAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uTklWRUxfRlJFQVRJQ09fRElOQU1JQ08uSU0", Path = @"\\SVPUCPIARCHIVE\Lixiviacion.Nivel_Freatico_Dinamico.IM", Unit = "m", MinValue = 1000, MaxValue = 2300, Type = "float", Descriptor = "Nivel Freático Dinámico" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"Lixiviacion.Nivel_Freatico_Estatico.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggFwEAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uTklWRUxfRlJFQVRJQ09fRVNUQVRJQ08uSU0", Path = @"\\SVPUCPIARCHIVE\Lixiviacion.Nivel_Freatico_Estatico.IM", Unit = "m", MinValue = 1000, MaxValue = 2300, Type = "float", Descriptor = "Nivel Freático Estático" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"ADR.pH_M2.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggowAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLlBIX00yLklN", Path = @"\\SVPUCPIARCHIVE\ADR.pH_M2.IM", Unit = "PH", MinValue = 1050, MaxValue = 2300, Type = "float", Descriptor = "pH (M2)" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"ADR.Fuerza_CN_M2.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggoQAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkZVRVJaQV9DTl9NMi5JTQ", Path = @"\\SVPUCPIARCHIVE\ADR.Fuerza_CN_M2.IM", Unit = "ppm", MinValue = 1200, MaxValue = 2800, Type = "float", Descriptor = "Fuerza de CN (M2)" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"ADR.pH_M3.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggoAAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLlBIX00zLklN", Path = @"\\SVPUCPIARCHIVE\ADR.pH_M3.IM", Unit = "PH", MinValue = 1050, MaxValue = 2350, Type = "float", Descriptor = "pH (M3)" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"ADR.Fuerza_CN_M3.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggogAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkZVRVJaQV9DTl9NMy5JTQ", Path = @"\\SVPUCPIARCHIVE\ADR.Fuerza_CN_M3.IM", Unit = "ppm", MinValue = 1200, MaxValue = 2800, Type = "float", Descriptor = "Fuerza de CN (M3)" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"ADR.Columna_Descarga.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggpAAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkNPTFVNTkFfREVTQ0FSR0EuSU0", Path = @"\\SVPUCPIARCHIVE\ADR.Columna_Descarga.IM", Unit = "", MinValue = 1200, MaxValue = 2700, Type = "float", Descriptor = "Columna de descarga" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"ADR.Hora_Estado_A.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggpQAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkhPUkFfRVNUQURPX0EuSU0", Path = @"\\SVPUCPIARCHIVE\ADR.Hora_Estado_A.IM", Unit = "h", MinValue = 1250, MaxValue = 2750, Type = "float", Descriptor = "Hora estado A" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"ADR.Hora_Estado_B.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggpgAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkhPUkFfRVNUQURPX0IuSU0", Path = @"\\SVPUCPIARCHIVE\ADR.Hora_Estado_B.IM", Unit = "h", MinValue = 1200, MaxValue = 2700, Type = "float", Descriptor = "Hora estado B" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"ADR.Consumo_Reactivos.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggpwAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkNPTlNVTU9fUkVBQ1RJVk9TLklN", Path = @"\\SVPUCPIARCHIVE\ADR.Consumo_Reactivos.IM", Unit = "Kg", MinValue = 1220, MaxValue = 2620, Type = "float", Descriptor = "Consumo de reactivos" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), Name = @"Azufre.Nivel_Silo_Cal.IM", WebId = "F1DPExBopmzHp0eIcrpvCeJFggqAAAAAU1ZQVUNQSUFSQ0hJVkVcQVpVRlJFLk5JVkVMX1NJTE9fQ0FMLklN", Path = @"\\SVPUCPIARCHIVE\Azufre.Nivel_Silo_Cal.IM", Unit = "m", MinValue = 1220, MaxValue = 2620, Type = "float", Descriptor = "Nivel Silo de Cal" });

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

                    string area = "";
                    string subarea = "";
                    switch (writeableTag.Area.Id)
                    {
                        case 1: area = "PUCAMARCA"; break;
                    }
                    switch (writeableTag.SubArea.Id)
                    {
                        case 1: subarea = "chanc"; break;
                        case 2: subarea = "lix"; break;
                        case 3: subarea = "adr"; break;
                        case 4: subarea = "azu"; break;
                    }
                    results.Add(new TagListResponse
                    {
                        WebId = writeableTag.WebId,
                        Name = writeableTag.Name,
                        Result = tget,
                        MinValue = writeableTag.MinValue,
                        MaxValue = writeableTag.MaxValue,
                        Type = writeableTag.Type,
                        Unit = writeableTag.Unit,
                        Area = area,
                        SubArea = subarea,
                        Descriptor = writeableTag.Descriptor
                    });

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
        public async Task<ActionResult> GetTagsInfo()
        {
            WritableTagsList.Clear();
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DPExBopmzHp0eIcrpvCeJFgglgAAAAU1ZQVUNQSUFSQ0hJVkVcQ0hBTkNBRE8uSE9SQVNfUFJPRFVDQ0lPTi5JTQ" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DPExBopmzHp0eIcrpvCeJFgglwAAAAU1ZQVUNQSUFSQ0hJVkVcQ0hBTkNBRE8uUDgwLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggmAAAAAU1ZQVUNQSUFSQ0hJVkVcQ0hBTkNBRE8uUkFUSU9fQ0FMLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggmQAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uQVJFQV9DRUxEQVMuSU0" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggmgAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uVE9ORUxBSkVfQ0VMREFTLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggmwAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uQUxUVVJBX0NFTERBUy5JTQ" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggnAAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uT05aQVNfQ0VMREFTLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggnQAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uT05aQVNfUkVDVVBFUkFCTEVTLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggngAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uSU5JQ0lPX1JJRUdPLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggnwAAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uUE9SQ0VOVEFKRV9FWFRSQUNDSU9OLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggFgEAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uTklWRUxfRlJFQVRJQ09fRElOQU1JQ08uSU0" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggFwEAAAU1ZQVUNQSUFSQ0hJVkVcTElYSVZJQUNJT04uTklWRUxfRlJFQVRJQ09fRVNUQVRJQ08uSU0" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggowAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLlBIX00yLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggoQAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkZVRVJaQV9DTl9NMi5JTQ" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggoAAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLlBIX00zLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggogAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkZVRVJaQV9DTl9NMy5JTQ" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggpAAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkNPTFVNTkFfREVTQ0FSR0EuSU0" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggpQAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkhPUkFfRVNUQURPX0EuSU0" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggpgAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkhPUkFfRVNUQURPX0IuSU0" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggpwAAAAU1ZQVUNQSUFSQ0hJVkVcQURSLkNPTlNVTU9fUkVBQ1RJVk9TLklN" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), WebId = "F1DPExBopmzHp0eIcrpvCeJFggqAAAAAU1ZQVUNQSUFSQ0hJVkVcQVpVRlJFLk5JVkVMX1NJTE9fQ0FMLklN" });

            dynamic response;
            bool success = true;
            var process = new List<string>();
            var results = new List<TagListResponse>();
            PIWebApiClient piWebAPIClient = new PIWebApiClient(userName, password);
            var tagsList = new List<object>();
            //Ask for Tags info
            foreach (var writeableTag in WritableTagsList)
            {
                try
                {
                    //Resolve tag path
                    string requestUrl = baseUrl + "/points/" + writeableTag.WebId;
                    process.Add("--------------------------------");
                    process.Add("TGET");
                    string tget = await piWebAPIClient.GetAsync(requestUrl);
                    var prop = JsonConvert.DeserializeObject(tget);
                    tagsList.Add(prop);
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
            //Update Tags info (Descriptor, Path, Unit, Min, Max and Type)
            string json = JsonConvert.SerializeObject(tagsList);
            foreach (var item in tagsList)
            {
                var tagItem = JsonConvert.DeserializeObject<PiPointsResponse>((string)item);
                WritableTagsList
                    .Where(x => x.WebId.Equals(tagItem.WebId))
                    .Select(x => {
                        x.Name = tagItem.Name;
                        x.Descriptor = tagItem.Descriptor;
                        x.Path = tagItem.Path;
                        x.Unit = tagItem.EngineeringUnits;
                        x.MinValue = tagItem.Zero;
                        x.MaxValue = tagItem.Zero + tagItem.Span;
                        x.Type = tagItem.PointType;
                        return x;
                    })
                    .ToList();
            }
            //Ask for values of Tags
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

                    string area = "";
                    string subarea = "";
                    switch (writeableTag.Area.Id)
                    {
                        case 1: area = "PUCAMARCA"; break;
                    }
                    switch (writeableTag.SubArea.Id)
                    {
                        case 1: subarea = "chanc"; break;
                        case 2: subarea = "lix"; break;
                        case 3: subarea = "adr"; break;
                        case 4: subarea = "azu"; break;
                    }
                    results.Add(new TagListResponse
                    {
                        WebId = writeableTag.WebId,
                        Name = writeableTag.Name,
                        Result = tget,
                        MinValue = writeableTag.MinValue,
                        MaxValue = writeableTag.MaxValue,
                        Type = writeableTag.Type,
                        Unit = writeableTag.Unit,
                        Area = area,
                        SubArea = subarea,
                        Descriptor = writeableTag.Descriptor
                    });

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
        public async Task<IActionResult> GetTagData(string webId)
        {
            dynamic response;
            bool success = true;
            var process = new List<string>();
            var results = new TagListResponse();
            PIWebApiClient piWebAPIClient = new PIWebApiClient(userName, password);
            try
            {
                //Resolve tag path
                string requestUrl = baseUrl + "/streams/" + webId + "/plot";
                string tget = await piWebAPIClient.GetAsync(requestUrl);
                process.Add("--------------------------------");
                process.Add("WebID " + webId);
                process.Add("Processing...");
                results = new TagListResponse { WebId = webId, Result = tget };
                process.Add("Exito...");

                response = new
                {
                    success = true,
                    process = JsonConvert.SerializeObject(process),
                    data = tget
                };

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
        public async Task<IActionResult> PostData(string webId, string fecha, string hora, float valor)
        {
            dynamic response;
            var process = new List<string>();
            PIWebApiClient piWebAPIClient = new PIWebApiClient(userName, password);
            try
            {
                //Convert Date and Time to TimeSpan 2021-08-03T21:07:08Z
                DateTime toTimeSpan = DateTime.Now;
                string timeSpan;
                if (DateTime.TryParse(fecha + " " + hora, out toTimeSpan))
                {
                    timeSpan = toTimeSpan.AddHours(5).ToString("yyyy-MM-ddTHH:mm:ssZ");
                    //timeSpan = toTimeSpan.ToString("yyyy-MM-ddTHH:mm:ssZ");
                    //timeSpan = timeSpan.
                }
                else
                {
                    timeSpan = DateTime.Now.AddHours(5).ToString("yyyy-MM-ddTHH:mm:ssZ");
                }
                var input = new PIWebAPIInput
                {
                    Timestamp = timeSpan,
                    Value = valor
                };
                //Resolve tag path
                string requestUrl = baseUrl + "/streams/" + webId + "/value";
                await piWebAPIClient.PostAsync(requestUrl, JsonConvert.SerializeObject(input));
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
