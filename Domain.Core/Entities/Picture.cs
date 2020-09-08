using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Extension { get; set; }
    }
}