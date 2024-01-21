using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entities
{
    public enum EventKind { Bar_Mitzva, Wedding, Sheva_Brachos, Brit, Pidyon, Other }

    public class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start_hour { get; set; }
        public DateTime End_hour { get; set; }
        public EventKind EventKind { get; set; }
        public int Sum { get; set; }
        public int HasPaid { get; set; }
        public int SumToPay { get => Sum - HasPaid; }
        //public Catering Catering { get; set; }
        public int CateringId { get; set; }
        //public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int AmountOfPortions { get; set; }
        public string Comments { get; set; }

        public override string ToString()
        {
            return "event number: " + Id + " on " + Date + " from houers";
        }
    }
}
