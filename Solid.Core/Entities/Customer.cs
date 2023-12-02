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
        public List<Event> Events { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public Customer()
        {

        }
        public Customer(int id, string name, string phone_num, string adress, string email, List<Event> events, string comment = "")
        {
            Id = id;
            Name = name;
            Phone_num = phone_num;
            Adress = adress;
            Email = email;
            Events = events;
            Status = true;
            Comment = comment;
        }
    }
}
