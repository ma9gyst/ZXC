using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Uploader { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
    }
}
