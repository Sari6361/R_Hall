using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data
{
    public class DataContext
    {
        public List<Event> EventList { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<Catering> CateringList { get; set; }
        public DataContext()
        {
            EventList = new List<Event>(){
            new Event(1,DateTime.Now,EventKind.Other),
            new Event(2,DateTime.Now,EventKind.Brit),
            new Event(3,DateTime.Now,EventKind.Bar_Mitzva)
            };

            CustomerList = new List<Customer>(){
                new Customer(1,"sara","054840181","Mimon 10","s0556766361@gmail.com",new List<Event>(){new Event(3,DateTime.Now,EventKind.Sheva_Brachos)})
            };

            CateringList = new List<Catering>(){
                new Catering(1,"Shepsil",TypeFood.Parve,100),
                new Catering(2,"Salomon",TypeFood.Fleshy,200)
            };
        }
    }
}
