using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entities
{
    public enum TypeFood { Dairy = 1, Fleshy, Parve }

    public class Catering
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeFood TypeFood { get; set; }
        public int PriceForPlate { get; set; }
        public bool Status { get; set; }
    
    }
}
