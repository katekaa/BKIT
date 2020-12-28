using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    [AttributeUsage (AttributeTargets.Property, AllowMultiple =false, Inherited =false)]
    class Attr:Attribute
    {
        public Attr() { }
        public Attr(string par) { descr = par; }
        public string descr { get; set; } = "описание";

    }
}
