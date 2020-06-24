using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        
        //public Picture Picture { get; set; }
       
    }
}
