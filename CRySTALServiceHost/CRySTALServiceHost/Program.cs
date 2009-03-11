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
            object[] services = { typeof(CRySTAL.CookService), 
                                    typeof(CRySTAL.BusBoyService),
                                    typeof(CRySTAL.HostService), 
                                    typeof(CRySTAL.LoginService), 
                                    typeof(CRySTAL.MenuItem),
                                    typeof(CRySTAL.WaiterService)};

            List<ServiceHost> hosts = new List<ServiceHost>();
            hosts.Add(new ServiceHost(typeof(CRySTAL.CookService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.BusBoyService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.HostService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.LoginService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.MenuService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.WaiterService)));
            foreach (ServiceHost host in hosts)
            {
                host.Open();
                Console.WriteLine("CRySTAL: Service Running: " + host.BaseAddresses[0].ToString());
            }


            Console.ReadLine();

            foreach (ServiceHost host in hosts)
            {
                host.Close();
                Console.WriteLine("CRySTAL: Shutingdown Service :" + host.BaseAddresses[0].ToString());
            }
            Console.ReadLine();
        }
    }
}
