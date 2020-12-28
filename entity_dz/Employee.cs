using System;
using System.Collections.Generic;
using System.Text;

namespace entity
{
    class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        public int Age { get; set; }
        public string FullName { get; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
