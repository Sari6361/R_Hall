using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime Start_hour { get; set; }

        public DateTime End_hour { get; set; }

        public EventKind EventKind { get; set; }

        public int Sum { get; set; }

        public int HasPaid { get; set; }

        public int SumToPay { get => Sum - HasPaid; }


        public int AmountOfPortions { get; set; }

        public string? Comments { get; set; }


    }
}
