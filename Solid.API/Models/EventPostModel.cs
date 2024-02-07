using Solid.Core.Entities;

namespace Solid.API.Models
{
    public class EventPostModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime Start_hour { get; set; }

        public DateTime End_hour { get; set; }

        public EventKind EventKind { get; set; }

        public int Sum { get; set; }

        public int HasPaid { get; set; }

        public int SumToPay { get => Sum - HasPaid; }

        //public int CustomerId { get; set; }

        //public int CateringId { get; set; }

        public int AmountOfPortions { get; set; }

        public string Comments { get; set; }

    }
}
