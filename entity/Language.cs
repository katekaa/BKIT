using System;
using System.Collections.Generic;
using System.Text;

namespace entity
{
    class Language
    {
        public int Id { get; set; }       
        public string Lang { get; set; }
        public List<Manager> Managers { get; set; } = new List<Manager>();
    }
}
