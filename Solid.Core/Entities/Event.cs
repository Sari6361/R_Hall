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
        public TimeOnly Start_hour { get; set; }
        public TimeOnly End_hour { get; set; }
        public EventKind EventKind { get; set; }
        public int Sum { get; set; }
        public int HasPaid { get; set; }
        public int SumToPay { get => Sum - HasPaid; }
        public Catering Catering { get; set; }
        public Customer Customer { get; set; }
        public int AmountOfPortions { get; set; }
        public string Comments { get; set; }

        public Event(int id,
                     DateTime date,
                     TimeOnly start,
                     TimeOnly end,
                     EventKind kind,
                     int sum,
                     int paid,
                     Catering c,
                     Customer customer,
                     int amountOfPlates,
                     string commnts = "")
        {
            Id = id;
            Date = date;
            Start_hour = start;
            End_hour = end;
            EventKind = kind;
            Sum = sum;
            HasPaid = paid;
            Catering = c;
            Customer = customer;
            AmountOfPortions = amountOfPlates;
            Comments = commnts;
        }
        public Event(int id, DateTime date, EventKind kind)
        {
            Id = id;
            Date = date;
            EventKind = kind;
        }
        public override string ToString()
        {
            return "event number: " + Id + " on " + Date + " from houers";
        }
    }
}
