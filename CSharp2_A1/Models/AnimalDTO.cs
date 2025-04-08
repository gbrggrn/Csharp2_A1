using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Models
{
    /// <summary>
    /// Data transfer object definition used in JSON serialization class to get around polymorphic behavior
    /// </summary>
    internal class AnimalDTO
    {
        public string? Category { get; set; }
        public string? Species { get; set; }
        public bool IsDomesticated { get; set; }
        public string? Gender { get; set; }
        public string? EaterType { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? CategoryTrait { get; set; }
        public string? SpeciesTrait { get; set; }
    }
}
