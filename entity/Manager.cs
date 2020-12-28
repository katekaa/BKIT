using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace entity
{
    
    class Manager: Employee
    {
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
