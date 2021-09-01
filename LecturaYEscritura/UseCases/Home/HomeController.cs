using LecturaYEscritura.UseCases.Home;
using LecturaYEscritura.UseCases.Home.Models;
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
        private static readonly List<Area> AreasList = new List<Area> { 
            new Area { Id = 1,Descripcion= "Control de mallas y densidades" },
            new Area { Id = 2, Descripcion = "Leyes de estaño" } 
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
            WritableTagsList.Add(new WritableTag { Name = @"4231_ML_01_ALM.BOLAS", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwHgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9BTE0uQk9MQVM", Path = @"\\SVSRFPIARCHIVE\4231_ML_01_ALM.BOLAS", Unit = "Kg", MinValue = 0, MaxValue = 5000, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Alimento de bolas de acero al molino de bolas" });
            WritableTagsList.Add(new WritableTag { Name = @"4122_TN_DES.M325", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwHwEAAAU1ZTUkZQSUFSQ0hJVkVcNDEyMl9UTl9ERVMuTTMyNQ", Path = @"\\SVSRFPIARCHIVE\4122_TN_DES.M325", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: % Pasante Malla325 en la descarga de los tanques de repulpado" });
            WritableTagsList.Add(new WritableTag { Name = @"4222_ML_01_DES.M325", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMl9NTF8wMV9ERVMuTTMyNQ", Path = @"\\SVSRFPIARCHIVE\4222_ML_01_DES.M325", Unit = "%", MinValue = 65, MaxValue = 139, Type = "float", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: % Pasante Malla325 en la descarga del molino del Isamill" });
            WritableTagsList.Add(new WritableTag { Name = @"4231_ML_01_ALM.M200", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9BTE0uTTIwMA", Path = @"\\SVSRFPIARCHIVE\4231_ML_01_ALM.M200", Unit = "%", MinValue = 13, MaxValue = 28, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: % Pasante Malla200 en el alimento al molino de bolas" });
            WritableTagsList.Add(new WritableTag { Name = @"4231_ML_01_DES.M200", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9ERVMuTTIwMA", Path = @"\\SVSRFPIARCHIVE\4231_ML_01_DES.M200", Unit = "%", MinValue = 48, MaxValue = 100, Type = "float", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: % Pasante Malla200 en la descarga del molino de bolas" });
            WritableTagsList.Add(new WritableTag { Name = @"4231_ML_01_DES.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwIwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9NTF8wMV9ERVMuREVOUw", Path = @"\\SVSRFPIARCHIVE\4231_ML_01_DES.Dens", Unit = "g/l", MinValue = 1500, MaxValue = 3100, Type = "float", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Densidad en la descarga del molino de bolas" });
            WritableTagsList.Add(new WritableTag { Name = @"4231_SR_01_DES.US.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIzMV9TUl8wMV9ERVMuVVMuREVOUw", Path = @"\\SVSRFPIARCHIVE\4231_SR_01_DES.US.Dens", Unit = "g/l", MinValue = 1300, MaxValue = 2660, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Densidad en el undersize de la zaranda stack sizer" });
            WritableTagsList.Add(new WritableTag { Name = @"4221_CI_01_OF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMV9DSV8wMV9PRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4221_CI_01_OF.Dens", Unit = "g/l", MinValue = 1200, MaxValue = 2450, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: Densidad en el overflow  del nido de hidrociclones de gruesos" });
            WritableTagsList.Add(new WritableTag { Name = @"4222_CI_01_OF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMl9DSV8wMV9PRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4222_CI_01_OF.Dens", Unit = "g/l", MinValue = 1080, MaxValue = 2180, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: Densidad en el overflow del nido de hidrociclones de molienda" });
            WritableTagsList.Add(new WritableTag { Name = @"4221_CI_02_OF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwJwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMV9DSV8wMl9PRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4221_CI_02_OF.Dens", Unit = "g/l", MinValue = 1080, MaxValue = 2180, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: Densidad en el overflow del nido de hidrociclones de media" });
            WritableTagsList.Add(new WritableTag { Name = @"4213_CI_01_OF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19DSV8wMV9PRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4213_CI_01_OF.Dens", Unit = "g/l", MinValue = 1080, MaxValue = 2180, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: Densidad en el underflow del nido de hidrociclones desaguado de mesas" });
            WritableTagsList.Add(new WritableTag { Name = @"4223_CI_01_UF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyM19DSV8wMV9VRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4223_CI_01_UF.Dens", Unit = "g/l", MinValue = 1300, MaxValue = 2800, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: Densidad en el underflow del nido de hidrociclones deslamado 1" });
            WritableTagsList.Add(new WritableTag { Name = @"4223_CI_02_UF.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyM19DSV8wMl9VRi5ERU5T", Path = @"\\SVSRFPIARCHIVE\4223_CI_02_UF.Dens", Unit = "g/l", MinValue = 1050, MaxValue = 2150, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Densidad en el underflow del nido de hidrociclones deslamado 2" });
            WritableTagsList.Add(new WritableTag { Name = @"4211_CE_Ro_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwKwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMV9DRV9ST19BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4211_CE_Ro_ALM.Dens", Unit = "g/l", MinValue = 1350, MaxValue = 2900, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: Densidad en el alimento al banco de espirales rougher" });
            WritableTagsList.Add(new WritableTag { Name = @"4211_CE_Cl_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMV9DRV9DTF9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4211_CE_Cl_ALM.Dens", Unit = "g/l", MinValue = 1350, MaxValue = 2830, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: Densidad en el alimento al banco de espirales cleaner" });
            WritableTagsList.Add(new WritableTag { Name = @"4212_CC_Ro_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMl9DQ19ST19BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4212_CC_Ro_ALM.Dens", Unit = "g/l", MinValue = 1300, MaxValue = 2700, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: Densidad en el alimento a Falcon C2000 rougher" });
            WritableTagsList.Add(new WritableTag { Name = @"4212_CC_Cl_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLgEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMl9DQ19DTF9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4212_CC_Cl_ALM.Dens", Unit = "g/l", MinValue = 1230, MaxValue = 2530, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Densidad en el alimento a Falcon C1000 cleaner" });
            WritableTagsList.Add(new WritableTag { Name = @"4213_TA_LADOA_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwLwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19UQV9MQURPQV9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4213_TA_LADOA_ALM.Dens", Unit = "g/l", MinValue = 1270, MaxValue = 2590, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)),Descriptor = "A: Densidad en el alimento a las mesas concentradoras Lado A" });
            WritableTagsList.Add(new WritableTag { Name = @"4213_TA_LADOB_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19UQV9MQURPQl9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4213_TA_LADOB_ALM.Dens", Unit = "g/l", MinValue = 1270, MaxValue = 2590, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Densidad en el alimento a las mesas concentradoras Lado B" });
            WritableTagsList.Add(new WritableTag { Name = @"4213_TA_ALM.Ton", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19UQV9BTE0uVE9O", Path = @"\\SVSRFPIARCHIVE\4213_TA_ALM.Ton", Unit = "TMS", MinValue = 1.2, MaxValue = 2.65, Type = "float", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Tonelaje de alimentación a las mesas concentradoras" });
            WritableTagsList.Add(new WritableTag { Name = @"4253_CH_DESPACHO_Conc.prod", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI1M19DSF9ERVNQQUNIT19DT05DLlBST0Q", Path = @"\\SVSRFPIARCHIVE\4253_CH_DESPACHO_Conc.prod", Unit = "TMS", MinValue = 4, MaxValue = 11, Type = "float", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Tonelaje producido por planta de procesos" });
            WritableTagsList.Add(new WritableTag { Name = @"4222_ML_01_ALM.BOLAS", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwMwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIyMl9NTF8wMV9BTE0uQk9MQVM", Path = @"\\SVSRFPIARCHIVE\4222_ML_01_ALM.BOLAS", Unit = "T", MinValue = 1, MaxValue = 2, Type = "float", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Alimento de bolas cerámicas al molino isamill" });
            WritableTagsList.Add(new WritableTag { Name = @"4243_FC_01_ALM.Dens", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNAEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GQ18wMV9BTE0uREVOUw", Path = @"\\SVSRFPIARCHIVE\4243_FC_01_ALM.Dens", Unit = "g/l", MinValue = 1270, MaxValue = 2570, Type = "int", Area = AreasList.Find(x => x.Id.Equals(1)), Descriptor = "A: Densidad de alimento a flotación rougher" });

            WritableTagsList.Add(new WritableTag { Name = @"4122_TN_DES.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNQEAAAU1ZTUkZQSUFSQ0hJVkVcNDEyMl9UTl9ERVMuJVNO", Path = @"\\SVSRFPIARCHIVE\4122_TN_DES.%Sn", Unit = "%", MinValue = 0.83, MaxValue = 1.68, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en la descarga de los tanques de repulpado, alimento fresco" });
            WritableTagsList.Add(new WritableTag { Name = @"4243_FLOT_CLEANERII_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GTE9UX0NMRUFORVJJSV9DT05DLiVTTg", Path = @"\\SVSRFPIARCHIVE\4243_FLOT_CLEANERII_CONC.%Sn", Unit = "%", MinValue = 9.5, MaxValue = 22.5, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el concentrado de flotación cleaner II" });
            WritableTagsList.Add(new WritableTag { Name = @"4213_GRAV_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwNwEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxM19HUkFWX0NPTkMuJVNO", Path = @"\\SVSRFPIARCHIVE\4213_GRAV_CONC.%Sn", Unit = "%", MinValue = 32, MaxValue = 72, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el concentrado final gravimétrico de mesas y mgs" });
            WritableTagsList.Add(new WritableTag { Name = @"4214_FALCONUF_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxNF9GQUxDT05VRl9DT05DLiVTTg", Path = @"\\SVSRFPIARCHIVE\4214_FALCONUF_CONC.%Sn", Unit = "%", MinValue = 25, MaxValue = 53, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el concentrador final de los Falcon UF" });
            WritableTagsList.Add(new WritableTag { Name = @"4243_CELLCOLUMN_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOQEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19DRUxMQ09MVU1OX0NPTkMuJVNO", Path = @"\\SVSRFPIARCHIVE\4243_CELLCOLUMN_CONC.%Sn", Unit = "%", MinValue = 24, MaxValue = 51, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el concentrador final de la celda columna" });
            WritableTagsList.Add(new WritableTag { Name = @"4243_FLOT_SCV_REL.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GTE9UX1NDVl9SRUwuJVNO", Path = @"\\SVSRFPIARCHIVE\4243_FLOT_SCV_REL.%Sn", Unit = "%", MinValue = 0, MaxValue = 0.2, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el relave de las celdas de flotación scavenger" });
            WritableTagsList.Add(new WritableTag { Name = @"4262_LAMAS_%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwOwEAAAU1ZTUkZQSUFSQ0hJVkVcNDI2Ml9MQU1BU18lU04", Path = @"\\SVSRFPIARCHIVE\4262_LAMAS_%Sn", Unit = "%", MinValue = 0, MaxValue = 0.8, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el overflow de deslamado 2" });
            WritableTagsList.Add(new WritableTag { Name = @"4211_CE_ESPIRALES_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPAEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMV9DRV9FU1BJUkFMRVNfQ09OQy4lU04", Path = @"\\SVSRFPIARCHIVE\4211_CE_ESPIRALES_CONC.%Sn", Unit = "%", MinValue = 1.1, MaxValue = 3.5, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el pre-concentrado de espirales" });
            WritableTagsList.Add(new WritableTag { Name = @"4212_CC_FALCONC1000_CONC.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPQEAAAU1ZTUkZQSUFSQ0hJVkVcNDIxMl9DQ19GQUxDT05DMTAwMF9DT05DLiVTTg", Path = @"\\SVSRFPIARCHIVE\4212_CC_FALCONC1000_CONC.%Sn", Unit = "%", MinValue = 1.1, MaxValue = 3.5, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el pre-concentrado de falcon C1000" });
            WritableTagsList.Add(new WritableTag { Name = @"4243_FLOT_ROUGHER_ALIM.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPgEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19GTE9UX1JPVUdIRVJfQUxJTS4lU04", Path = @"\\SVSRFPIARCHIVE\4243_FLOT_ROUGHER_ALIM.%Sn", Unit = "%", MinValue = 0.5, MaxValue = 1.4, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el alimento a las celdas de flotación rougher" });
            WritableTagsList.Add(new WritableTag { Name = @"4253_FD_CONCENTRADO_FINAL.%Sn", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwPwEAAAU1ZTUkZQSUFSQ0hJVkVcNDI1M19GRF9DT05DRU5UUkFET19GSU5BTC4lU04", Path = @"\\SVSRFPIARCHIVE\4253_FD_CONCENTRADO_FINAL.%Sn", Unit = "%", MinValue = 31.9, MaxValue = 64, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el concentrado final de despacho" });
            WritableTagsList.Add(new WritableTag { Name = @"4243_CELLCOLUMN_CONC.%Sn_rev", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQAEAAAU1ZTUkZQSUFSQ0hJVkVcNDI0M19DRUxMQ09MVU1OX0NPTkMuJVNOX1JFVg", Path = @"\\SVSRFPIARCHIVE\4243_CELLCOLUMN_CONC.%Sn_rev", Unit = "%", MinValue = 2, MaxValue = 8, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2)), Descriptor = "A: Ley de estaño en el relave de la celda columna" });

            //WritableTagsList.Add(new WritableTag { Name = "TagManual37", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzc", Path = "\\\\SVSRFPIARCHIVE\\TagManua37", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2))});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual38", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwQwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzg", Path = "\\\\SVSRFPIARCHIVE\\TagManua38", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2))});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual39", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMMzk", Path = "\\\\SVSRFPIARCHIVE\\TagManua39", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2))});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual40", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDA", Path = "\\\\SVSRFPIARCHIVE\\TagManua40", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2))});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual41", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDE", Path = "\\\\SVSRFPIARCHIVE\\TagManua41", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2))});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual42", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwRwEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDI", Path = "\\\\SVSRFPIARCHIVE\\TagManua42", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2))});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual43", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwSAEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDM", Path = "\\\\SVSRFPIARCHIVE\\TagManua43", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2))});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual44", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwSQEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDQ", Path = "\\\\SVSRFPIARCHIVE\\TagManua44", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2))});
            //WritableTagsList.Add(new WritableTag { Name = "TagManual45", WebId = "F1DP1NYTaEQugEWVxMlNxGu3zwSgEAAAU1ZTUkZQSUFSQ0hJVkVcVEFHTUFOVUFMNDU", Path = "\\\\SVSRFPIARCHIVE\\TagManua45", Unit = "%", MinValue = 38, MaxValue = 81, Type = "float", Area = AreasList.Find(x => x.Id.Equals(2))});

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
                    switch (writeableTag.Area.Id)
                    {
                        case 1: area = "CMD"; break;
                        case 2: area = "LE"; break;
                    }

                    results.Add(new TagListResponse {
                        WebId = writeableTag.WebId , 
                        Name = writeableTag.Name, 
                        Result = tget,
                        MinValue = writeableTag.MinValue, 
                        MaxValue = writeableTag.MaxValue, 
                        Type = writeableTag.Type, 
                        Unit = writeableTag.Unit, 
                        Area = area,
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
    }
}
