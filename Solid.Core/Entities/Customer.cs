using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone_num { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        //public List<Event> Events { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
 
    }
}
