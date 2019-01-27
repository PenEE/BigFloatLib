using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigFloatLib;

namespace BigFloatSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            BigFloat t1 = new BigFloat(@"-.114514");
            BigFloat t2 = new BigFloat(@"-114514");
            var t3 = t1.Add(t2);
        }
    }
}
