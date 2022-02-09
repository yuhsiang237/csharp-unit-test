using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{

    public class Bar
    {
        public virtual Baz Baz { get; set; }
        public virtual bool Submit() { return false; }
    }

}
