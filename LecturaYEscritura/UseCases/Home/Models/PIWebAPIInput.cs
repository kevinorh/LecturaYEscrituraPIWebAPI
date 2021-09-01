using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturaYEscritura.UseCases.Home.Models
{
    public class PIWebAPIInput
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
}
