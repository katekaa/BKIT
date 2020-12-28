using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Class1
    {
        public Class1() { }
        public Class1(string str) { }
        public string testSt() {return "test";}
        public double testIn() { return Math.Sqrt(v2); }
        [Attr()]
        public int v1 { get; set; }
        public int v2 { get { return v1 * 2; } }
        [Attr("описание свойства s1")]
        public string s1 { get; set; } = "propetry";
    }
}
