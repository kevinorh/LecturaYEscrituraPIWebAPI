using LecturaYEscritura.UseCases.Home;
using LecturaYEscritura.UseCases.Home.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LecturaYEscritura.UseCases
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private static readonly string baseUrl = "https://svsrfpivision.mineria.breca/piwebapi/";
        private static readonly string userName = @"mineria\admin.pi";
        private static readonly string password = @"Q=i5G3uPt$";

        private static readonly List<WritableTag> WritableTagsList = new List<WritableTag>();
        private static readonly List<Area> AreasList = new List<Area> { 
            new Area { Id = 1,Descripcion= "Control de mallas y densidades" },
            new Area { Id = 2, Descripcion = "Leyes de estaño" } 
        };
        private static readonly List<SubArea> SubAreasList = new List<SubArea> { 
            new SubArea { Id = 1,Descripcion= "REMOLIENDA DE CONCENTRADOS" },
            new SubArea { Id = 2, Descripcion = "MOLIENDA PRIMARIA" } ,
            new SubArea { Id = 3, Descripcion = "GRAVIMETRÍA GRUESA" } ,
            new SubArea { Id = 4, Descripcion = "GRAVIMETRIA MEDIA" } ,
            new SubArea { Id = 5, Descripcion = "GRAVIMETRIA FINA" } ,
            new SubArea { Id = 6, Descripcion = "FLOTACION CASITERITA" } ,
            new SubArea { Id = 7, Descripcion = "DESPACHO DE CONCENTRADOS" } ,
            new SubArea { Id = 8, Descripcion = "GRAVIMETRIA ULTRAFINA" } ,
            new SubArea { Id = 9, Descripcion = "DESLAMADO" }
        };
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
        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetTagListValues()
        {
            WritableTagsList.Clear();
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"4231_ML_01_ALM.BOLAS", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwHgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9BTE0uQk9MQVM", Path = @"\\SVSRFPIARCHIVE\4231_ML_01_ALM.BOLAS", Unit = "Kg", MinValue = 0, MaxValue = 2000, Type = "int", Descriptor = "A: Alimento de bolas de acero al molino de bolas" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"4122_TN_DES.M325", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwHwEAAAU1ZTUkZQSUFSQ0hJVkVcNDEyMl9UTl9ERVMuTTMyNQ", Path = @"\\SVSRFPIARCHIVE\4122_TN_DES.M325", Unit = "%", MinValue = 32, MaxValue = 82, Type = "float",Descriptor = "A: % Pasante Malla325 en la descarga de los tanques de repulpado" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"4222_ML_01_DES.M325", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMl9NTF8wMV9ERVMuTTMyNQ", Path = @"\\SVSRFPIARCHIVE\4222_ML_01_DES.M325", Unit = "%", MinValue = 65, MaxValue = 139, Type = "float", Descriptor = "A: % Pasante Malla325 en la descarga del molino del Isamill" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"4231_ML_01_ALM.M200", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9BTE0uTTIwMA", Path = @"\\SVSRFPIARCHIVE\4231_ML_01_ALM.M200", Unit = "%", MinValue = 10, MaxValue = 29, Type = "int", Descriptor = "A: % Pasante Malla200 en el alimento al molino de bolas" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"4231_ML_01_DES.M200", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9ERVMuTTIwMA", Path = @"\\SVSRFPIARCHIVE\4231_ML_01_DES.M200", Unit = "%", MinValue = 48, MaxValue = 106, Type = "float", Descriptor = "A: % Pasante Malla200 en la descarga del molino de bolas" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"4231_ML_01_DES.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9ERVMuREVOUw", Path = @"\\SVSRFPIARCHIVE\4231_ML_01_DES.Dens", Unit = "g/l", MinValue = 1400, MaxValue = 3100, Type = "float", Descriptor = "A: Densidad en la descarga del molino de bolas" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"4231_SR_01_DES.US.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9TUl8wMV9ERVMuVVMuREVOUw", Path = @"\\SVSRFPIARCHIVE\4231_SR_01_DES.US.Dens", Unit = "g/l", MinValue = 1200, MaxValue = 2700, Type = "int", Descriptor = "A: Densidad en el undersize de la zaranda stack sizer" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"4221_CI_01_OF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMV9DSV8wMV9PRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4221_CI_01_OF.Dens", Unit = "g/l", MinValue = 1100, MaxValue = 2400, Type = "int",Descriptor = "A: Densidad en el overflow  del nido de hidrociclones de gruesos" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"4222_CI_01_OF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMl9DSV8wMV9PRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4222_CI_01_OF.Dens", Unit = "g/l", MinValue = 1050, MaxValue = 2300, Type = "int",Descriptor = "A: Densidad en el overflow del nido de hidrociclones de molienda" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), Name = @"4221_CI_02_OF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMV9DSV8wMl9PRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4221_CI_02_OF.Dens", Unit = "g/l", MinValue = 1000, MaxValue = 2300, Type = "int",Descriptor = "A: Densidad en el overflow del nido de hidrociclones de media" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), Name = @"4213_CI_01_OF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19DSV8wMV9PRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4213_CI_01_OF.Dens", Unit = "g/l", MinValue = 1050, MaxValue = 2300, Type = "int",Descriptor = "A: Densidad en el underflow del nido de hidrociclones desaguado de mesas" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"4223_CI_01_UF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyM19DSV8wMV9VRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4223_CI_01_UF.Dens", Unit = "g/l", MinValue = 1200, MaxValue = 2800, Type = "int",Descriptor = "A: Densidad en el underflow del nido de hidrociclones deslamado 1" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), Name = @"4223_CI_02_UF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyM19DSV8wMl9VRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4223_CI_02_UF.Dens", Unit = "g/l", MinValue = 1050, MaxValue = 2350, Type = "int", Descriptor = "A: Densidad en el underflow del nido de hidrociclones deslamado 2" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"4211_CE_Ro_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMV9DRV9ST19BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4211_CE_Ro_ALM.Dens", Unit = "g/l", MinValue = 1200, MaxValue = 2800, Type = "int",Descriptor = "A: Densidad en el alimento al banco de espirales rougher" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"4211_CE_Cl_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMV9DRV9DTF9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4211_CE_Cl_ALM.Dens", Unit = "g/l", MinValue = 1200, MaxValue = 2700, Type = "int",Descriptor = "A: Densidad en el alimento al banco de espirales cleaner" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), Name = @"4212_CC_Ro_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMl9DQ19ST19BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4212_CC_Ro_ALM.Dens", Unit = "g/l", MinValue = 1250, MaxValue = 2750, Type = "int",Descriptor = "A: Densidad en el alimento a Falcon C2000 rougher" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), Name = @"4212_CC_Cl_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMl9DQ19DTF9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4212_CC_Cl_ALM.Dens", Unit = "g/l", MinValue = 1200, MaxValue = 2700, Type = "int", Descriptor = "A: Densidad en el alimento a Falcon C1000 cleaner" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), Name = @"4213_TA_LADOA_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19UQV9MQURPQV9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4213_TA_LADOA_ALM.Dens", Unit = "g/l", MinValue = 1220, MaxValue = 2620, Type = "int",Descriptor = "A: Densidad en el alimento a las mesas concentradoras Lado A" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), Name = @"4213_TA_LADOB_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19UQV9MQURPQl9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4213_TA_LADOB_ALM.Dens", Unit = "g/l", MinValue = 1220, MaxValue = 2620, Type = "int", Descriptor = "A: Densidad en el alimento a las mesas concentradoras Lado B" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), Name = @"4213_TA_ALM.Ton", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19UQV9BTE0uVE9O", Path = @"\\SVSRFPIARCHIVE\4213_TA_ALM.Ton", Unit = "TMS/h", MinValue = 1.0, MaxValue = 3.00, Type = "float", Descriptor = "A: Tonelaje de alimentación a las mesas concentradoras" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(7)), Name = @"4253_CH_DESPACHO_Conc.prod", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI1M19DSF9ERVNQQUNIT19DT05DLlBST0Q", Path = @"\\SVSRFPIARCHIVE\4253_CH_DESPACHO_Conc.prod", Unit = "TMH", MinValue = 0, MaxValue = 30, Type = "float", Descriptor = "A: Tonelaje producido por planta de procesos" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), Name = @"4222_ML_01_ALM.BOLAS", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMl9NTF8wMV9BTE0uQk9MQVM", Path = @"\\SVSRFPIARCHIVE\4222_ML_01_ALM.BOLAS", Unit = "T", MinValue = 0, MaxValue = 5000, Type = "float", Descriptor = "A: Alimento de bolas cerámicas al molino isamill" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(6)), Name = @"4243_FC_01_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNAEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GQ18wMV9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4243_FC_01_ALM.Dens", Unit = "g/l", MinValue = 1220, MaxValue = 2620, Type = "int", Descriptor = "A: Densidad de alimento a flotación rougher" });
                                                                                          
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"4122_TN_DES.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNQEAAAU1ZTUkZQSUFSQ0hJVkVcNDEyMl9UTl9ERVMuJVNO", Path = @"\\SVSRFPIARCHIVE\4122_TN_DES.%Sn", Unit = "%", MinValue = 0.76, MaxValue = 1.8, Type = "float", Descriptor = "A: Ley de estaño en la descarga de los tanques de repulpado, alimento fresco" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(6)), Name = @"4243_FLOT_CLEANERII_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GTE9UX0NMRUFORVJJSV9DT05DLiVTTg", Path = @"\\SVSRFPIARCHIVE\4243_FLOT_CLEANERII_CONC.%Sn", Unit = "%", MinValue = 7, MaxValue = 25, Type = "float", Descriptor = "A: Ley de estaño en el concentrado de flotación cleaner II" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), Name = @"4213_GRAV_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19HUkFWX0NPTkMuJVNO", Path = @"\\SVSRFPIARCHIVE\4213_GRAV_CONC.%Sn", Unit = "%", MinValue = 30, MaxValue = 70, Type = "float", Descriptor = "A: Ley de estaño en el concentrado final gravimétrico de mesas y mgs" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(8)), Name = @"4214_FALCONUF_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxNF9GQUxDT05VRl9DT05DLiVTTg", Path = @"\\SVSRFPIARCHIVE\4214_FALCONUF_CONC.%Sn", Unit = "%", MinValue = 23, MaxValue = 53, Type = "float", Descriptor = "A: Ley de estaño en el concentrador final de los Falcon UF" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(8)), Name = @"4243_CELLCOLUMN_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOQEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19DRUxMQ09MVU1OX0NPTkMuJVNO", Path = @"\\SVSRFPIARCHIVE\4243_CELLCOLUMN_CONC.%Sn", Unit = "%", MinValue = 20, MaxValue = 50, Type = "float", Descriptor = "A: Ley de estaño en el concentrador final de la celda columna" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(6)), Name = @"4243_FLOT_SCV_REL.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GTE9UX1NDVl9SRUwuJVNO", Path = @"\\SVSRFPIARCHIVE\4243_FLOT_SCV_REL.%Sn", Unit = "%", MinValue = 0, MaxValue = 0.2, Type = "float", Descriptor = "A: Ley de estaño en el relave de las celdas de flotación scavenger" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(9)), Name = @"4262_LAMAS_%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOwEAAAU1ZTUkZQSUFSQ0hJVkVcNDI2Ml9MQU1BU18lU04", Path = @"\\SVSRFPIARCHIVE\4262_LAMAS_%Sn", Unit = "%", MinValue = 0, MaxValue = 1.2, Type = "float", Descriptor = "A: Ley de estaño en el overflow de deslamado 2" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), Name = @"4211_CE_ESPIRALES_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMV9DRV9FU1BJUkFMRVNfQ09OQy4lU04", Path = @"\\SVSRFPIARCHIVE\4211_CE_ESPIRALES_CONC.%Sn", Unit = "%", MinValue = 0.8, MaxValue = 3.8, Type = "float", Descriptor = "A: Ley de estaño en el pre-concentrado de espirales" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), Name = @"4212_CC_FALCONC1000_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMl9DQ19GQUxDT05DMTAwMF9DT05DLiVTTg", Path = @"\\SVSRFPIARCHIVE\4212_CC_FALCONC1000_CONC.%Sn", Unit = "%", MinValue = 0.8, MaxValue = 3.8, Type = "float", Descriptor = "A: Ley de estaño en el pre-concentrado de falcon C1000" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(6)), Name = @"4243_FLOT_ROUGHER_ALIM.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GTE9UX1JPVUdIRVJfQUxJTS4lU04", Path = @"\\SVSRFPIARCHIVE\4243_FLOT_ROUGHER_ALIM.%Sn", Unit = "%", MinValue = 0.5, MaxValue = 1.4, Type = "float", Descriptor = "A: Ley de estaño en el alimento a las celdas de flotación rougher" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(7)), Name = @"4253_FD_CONCENTRADO_FINAL.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPwEAAAU1ZTUkZQSUFSQ0hJVkVcNDI1M19GRF9DT05DRU5UUkFET19GSU5BTC4lU04", Path = @"\\SVSRFPIARCHIVE\4253_FD_CONCENTRADO_FINAL.%Sn", Unit = "%", MinValue = 28, MaxValue = 63, Type = "float", Descriptor = "A: Ley de estaño en el concentrado final de despacho" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(8)), Name = @"4243_CELLCOLUMN_CONC.%Sn_rev", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQAEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19DRUxMQ09MVU1OX0NPTkMuJVNOX1JFVg", Path = @"\\SVSRFPIARCHIVE\4243_CELLCOLUMN_CONC.%Sn_rev", Unit = "%", MinValue = 0, MaxValue = 9, Type = "float", Descriptor = "A: Ley de estaño en el relave de la celda columna" });

            //WritableTagsList.Add(new WritableTag { Name = "TagManual37", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzc", Path = "\\\\SVSRFPIARCHIVE\\TagManua37", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float"});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual38", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzg", Path = "\\\\SVSRFPIARCHIVE\\TagManua38", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float"});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual39", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzk", Path = "\\\\SVSRFPIARCHIVE\\TagManua39", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float"});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual40", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDA", Path = "\\\\SVSRFPIARCHIVE\\TagManua40", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float"});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual41", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDE", Path = "\\\\SVSRFPIARCHIVE\\TagManua41", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float"});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual42", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDI", Path = "\\\\SVSRFPIARCHIVE\\TagManua42", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float"});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual43", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwSAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDM", Path = "\\\\SVSRFPIARCHIVE\\TagManua43", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float"});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual44", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwSQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDQ", Path = "\\\\SVSRFPIARCHIVE\\TagManua44", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float"});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual45", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwSgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDU", Path = "\\\\SVSRFPIARCHIVE\\TagManua45", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float"});

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
                        case 1: area = "CMD"; break;
                        case 2: area = "LE"; break;
                    }
                    switch (writeableTag.SubArea.Id)
                    {
                        case 1: subarea = "RDC"; break;
                        case 2: subarea = "MP"; break;
                        case 3: subarea = "GG"; break;
                        case 4: subarea = "GM"; break;
                        case 5: subarea = "GF"; break;
                        case 6: subarea = "FC"; break;
                        case 7: subarea = "DDC"; break;
                        case 8: subarea = "GU"; break;
                        case 9: subarea = "D"; break;
                    }
                    /*
                     new SubArea { Id = 1,Descripcion= "REMOLIENDA DE CONCENTRADOS" },
            new SubArea { Id = 2, Descripcion = "MOLIENDA PRIMARIA" } ,
            new SubArea { Id = 3, Descripcion = "GRAVIMETRÍA GRUESA" } ,
            new SubArea { Id = 4, Descripcion = "GRAVIMETRIA MEDIA" } ,
            new SubArea { Id = 5, Descripcion = "GRAVIMETRIA FINA" } ,
            new SubArea { Id = 6, Descripcion = "FLOTACION CASITERITA" } ,
            new SubArea { Id = 7, Descripcion = "DESPACHO DE CONCENTRADOS" } ,
            new SubArea { Id = 8, Descripcion = "GRAVIMETRIA ULTRAFINA" } ,
            new SubArea { Id = 9, Descripcion = "DESLAMADO" } ,
                     */
                    results.Add(new TagListResponse {
                        WebId = writeableTag.WebId , 
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
        public async Task<IActionResult> GetTagsInfo() {
            WritableTagsList.Clear();
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwHgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9BTE0uQk9MQVM"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwHwEAAAU1ZTUkZQSUFSQ0hJVkVcNDEyMl9UTl9ERVMuTTMyNQ" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMl9NTF8wMV9ERVMuTTMyNQ"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9BTE0uTTIwMA"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9ERVMuTTIwMA"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9ERVMuREVOUw"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9TUl8wMV9ERVMuVVMuREVOUw"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMV9DSV8wMV9PRi5ERU5T"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMl9DSV8wMV9PRi5ERU5T"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMV9DSV8wMl9PRi5ERU5T" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19DSV8wMV9PRi5ERU5T" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyM19DSV8wMV9VRi5ERU5T"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(1)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyM19DSV8wMl9VRi5ERU5T"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMV9DRV9ST19BTE0uREVOUw"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMV9DRV9DTF9BTE0uREVOUw"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMl9DQ19ST19BTE0uREVOUw"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMl9DQ19DTF9BTE0uREVOUw"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19UQV9MQURPQV9BTE0uREVOUw"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19UQV9MQURPQl9BTE0uREVOUw"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19UQV9BTE0uVE9O"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(7)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI1M19DSF9ERVNQQUNIT19DT05DLlBST0Q" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(2)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMl9NTF8wMV9BTE0uQk9MQVM" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(1)), SubArea = SubAreasList.Find(x => x.Id.Equals(6)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNAEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GQ18wMV9BTE0uREVOUw" });
                                                                                          
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNQEAAAU1ZTUkZQSUFSQ0hJVkVcNDEyMl9UTl9ERVMuJVNO" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(6)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GTE9UX0NMRUFORVJJSV9DT05DLiVTTg" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(5)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19HUkFWX0NPTkMuJVNO"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(8)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxNF9GQUxDT05VRl9DT05DLiVTTg" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(8)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOQEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19DRUxMQ09MVU1OX0NPTkMuJVNO"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(6)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GTE9UX1NDVl9SRUwuJVNO"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(9)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOwEAAAU1ZTUkZQSUFSQ0hJVkVcNDI2Ml9MQU1BU18lU04" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(3)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMV9DRV9FU1BJUkFMRVNfQ09OQy4lU04"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(4)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMl9DQ19GQUxDT05DMTAwMF9DT05DLiVTTg"});
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(6)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GTE9UX1JPVUdIRVJfQUxJTS4lU04" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(7)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPwEAAAU1ZTUkZQSUFSQ0hJVkVcNDI1M19GRF9DT05DRU5UUkFET19GSU5BTC4lU04" });
            WritableTagsList.Add(new WritableTag { Area = AreasList.Find(x => x.Id.Equals(2)), SubArea = SubAreasList.Find(x => x.Id.Equals(8)), WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQAEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19DRUxMQ09MVU1OX0NPTkMuJVNOX1JFVg" });
            
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
                    string requestUrl = baseUrl + "/points/"+writeableTag.WebId;
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
                    .Select(x=> {
                        x.Name = tagItem.Name;
                        x.Descriptor = tagItem.Descriptor;
                        x.Path = tagItem.Path;
                        x.Unit = tagItem.EngineeringUnits;
                        x.MinValue = tagItem.Zero;
                        x.MaxValue = tagItem.Zero + tagItem.Span;
                        x.Type = tagItem.PointType;
                        return x; })
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
                        case 1: area = "CMD"; break;
                        case 2: area = "LE"; break;
                    }
                    switch (writeableTag.SubArea.Id)
                    {
                        case 1: subarea = "RDC"; break;
                        case 2: subarea = "MP"; break;
                        case 3: subarea = "GG"; break;
                        case 4: subarea = "GM"; break;
                        case 5: subarea = "GF"; break;
                        case 6: subarea = "FC"; break;
                        case 7: subarea = "DDC"; break;
                        case 8: subarea = "GU"; break;
                        case 9: subarea = "D"; break;
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
                results= new TagListResponse { WebId = webId, Result = tget};
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
        public async Task<IActionResult> PostData(string webId, string fecha,string hora,float valor)
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
    }
}
