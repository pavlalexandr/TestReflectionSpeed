
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestReflectionSpeed
{
    public class Test
    {
        public string SomePropertyName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test() { SomePropertyName = "SomeValue" };
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = test.SomePropertyName;
            Console.WriteLine("Value = " + result);
            watch.Stop();
            Console.WriteLine("Direct = " + watch.ElapsedMilliseconds);
            watch = System.Diagnostics.Stopwatch.StartNew();
            var result2 = test.GetType().GetProperties().FirstOrDefault(o => o.Name == "SomePropertyName").GetValue(test).ToString();
            Thread.Sleep(10);
            Console.WriteLine("Value = " + result2);
            watch.Stop();
            Console.WriteLine("Reflection = " + watch.ElapsedMilliseconds);
        }

        /*
         *  Value = SomeValue
            Direct = 0
            Value = SomeValue
            Reflection = 0
            Для продолжения нажмите любую клавишу . . .
         */
    }
}
