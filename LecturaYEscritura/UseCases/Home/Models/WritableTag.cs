using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturaYEscritura.UseCases.Home.Models
{
    public class WritableTag
    {
        public string Name { get; set; }
        public string WebId { get; set; }
        public string Path { get; set; }
        public string Unit { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string Type { get; set; }
        public Area Area { get; set; }
    }
}
