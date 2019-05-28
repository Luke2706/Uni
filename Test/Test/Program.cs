using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Test
{
    class MyProgram
    {
        static void Main(string[] args)
        {
            //Generic<int> gene = new Generic<int>();
            //gene.Test();
            List<int> Test = new List<int>(1);
            Test.Add(2);
            Test.Add(3);
            Test.Add(4);
            List<string> figgn = new List<string>();
            figgn.Add("Eric ist ein NUtTeNsOhn");
            figgn.Add("Eric ist ein NUtTeNsOhn");
            figgn.Add("Eric ist ein NUtTeNsOhn");
            figgn.Add("Eric ist ein NUtTeNsOhn");
            figgn.Add("Eric ist ein NUtTeNsOhn");
            figgn.Add("AMENAAAAAAA");

            var bla = Test.Count();
            
            foreach (int i in Test)
            {
                Console.WriteLine(i);
            }

            foreach (var VARIABLE in figgn)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.ReadLine();


        }
    }
}