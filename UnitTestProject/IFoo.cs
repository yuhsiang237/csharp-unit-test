using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    public interface IFoo
    {
        Bar Bar { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        bool DoSomething(string value);
    }

}
