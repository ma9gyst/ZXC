using System;

namespace Domain.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
    }
}
