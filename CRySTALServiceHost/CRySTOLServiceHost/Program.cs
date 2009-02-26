using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using CRySTAL;

namespace CRySTALServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(CRySTAL.CookService));

            host.Open();

            Console.WriteLine("CRySTAL:Cook is up and running...");

            Console.ReadLine();
            host.Close();

        }
    }
}
