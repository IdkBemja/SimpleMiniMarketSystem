using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLoginMySqlEncrypted.apps.utils
{
    public partial class test : Component
    {
        public test()
        {
        }

        static void Main()
        {
            int[] nums = CrearArray();
            ImprimirArray(nums);
        }

        static int[] CrearArray()
        {
            int[] numeros = { 10, 4, 20, 50, 100 };
            return numeros;
        }

        static void ImprimirArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}
