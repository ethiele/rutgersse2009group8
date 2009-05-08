using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Activities;
using CRySTAL;


namespace CRySTALServiceHost
{
    class Program
    {
        public static int debugOutputMode = 4;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting CRySTAL...");
            Console.WriteLine("Linking Workflow Runtime Services...");
            CRySTAL.WorkflowInterface.WorkflowInterface.CustomerWF = new CRySTAL.WorkflowInterface.CustomerWorkflowInterface();
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            AppDomain.CurrentDomain.SetData("WorkflowRuntime", workflowRuntime);
            ManualWorkflowSchedulerService manualScheduler =
                new ManualWorkflowSchedulerService(true);
            AppDomain.CurrentDomain.SetData("ManualScheduler", manualScheduler);
            workflowRuntime.AddService(manualScheduler);
            ExternalDataExchangeService des = new ExternalDataExchangeService();
            workflowRuntime.AddService(des);
            des.AddService(CRySTAL.WorkflowInterface.WorkflowInterface.CustomerWF);

            TimeSpan reloadIntevral = new TimeSpan(0, 0, 0, 20, 0);
            TimeSpan ownershipDuration = new TimeSpan(0, 0, 30, 0);
            string connectionString = @"Data Source=ETHIELE-LENOVO\SQLEXPRESS;Initial Catalog=WFTrackingAndPersistence;Integrated Security=True";
            SqlWorkflowPersistenceService sqlPersistenceService = 
                new SqlWorkflowPersistenceService(connectionString, true, ownershipDuration, reloadIntevral);
            workflowRuntime.AddService(sqlPersistenceService);

            SqlTrackingService sts = new SqlTrackingService(connectionString);
            workflowRuntime.AddService(sts);

            workflowRuntime.WorkflowCreated += new EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowCreated);
            workflowRuntime.WorkflowPersisted += new EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowPersisted);
            workflowRuntime.WorkflowLoaded += new EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowLoaded);
            workflowRuntime.WorkflowStarted += new EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowStarted);
            workflowRuntime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(workflowRuntime_WorkflowTerminated);
            workflowRuntime.WorkflowIdled += new EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowIdled);
            Console.WriteLine("Starting Workflow Runtime...");
            workflowRuntime.StartRuntime();

            //AppDomain.CurrentDomain.SetData("firstNamestr", "thisisatest");
            List<ServiceHost> hosts = new List<ServiceHost>();
            hosts.Add(new ServiceHost(typeof(CRySTAL.CookService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.BusBoyService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.HostService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.LoginService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.MenuService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.WaiterService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.TimeCardService)));
            hosts.Add(new ServiceHost(typeof(CRySTAL.ManagerService)));
           
            foreach (ServiceHost host in hosts)
            {
                
                host.Open();
                Console.WriteLine("CRySTAL: Service Running: " + host.BaseAddresses[0].ToString());
            }
            Console.WriteLine("CRySTAL Ready");

            Console.ReadLine();

            Console.WriteLine("Shutting down CRySTAL...");
            foreach (ServiceHost host in hosts)
            {
               
                host.Close();
                Console.WriteLine("CRySTAL: Shutingdown Service :" + host.BaseAddresses[0].ToString());
            }
            Console.WriteLine("Shutting down runtime...");
            workflowRuntime.StopRuntime();
            Console.WriteLine("CRySTAL shutdown complete");
            Console.ReadLine();
        }

        static void workflowRuntime_WorkflowIdled(object sender, WorkflowEventArgs e)
        {
            if (debugOutputMode > 3)
            {
                Console.WriteLine("[Workflow Runtime] Workflow Idled: " + e.WorkflowInstance.InstanceId.ToString());
            }
        }

        static void workflowRuntime_WorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            if (debugOutputMode > 3)
            {
                Console.WriteLine("[Workflow Runtime] Workflow Terminated: " + e.WorkflowInstance.InstanceId.ToString());
            }
        }

        static void workflowRuntime_WorkflowStarted(object sender, WorkflowEventArgs e)
        {
            if (debugOutputMode > 3)
            {
                Console.WriteLine("[Workflow Runtime] Workflow Started: " + e.WorkflowInstance.InstanceId.ToString());
            }
        }

        static void workflowRuntime_WorkflowLoaded(object sender, WorkflowEventArgs e)
        {
            if (debugOutputMode > 3)
            {
                Console.WriteLine("[Workflow Runtime] Workflow Loaded: " + e.WorkflowInstance.InstanceId.ToString());
            }
        }

        static void workflowRuntime_WorkflowPersisted(object sender, WorkflowEventArgs e)
        {
            if (debugOutputMode > 3)
            {
                Console.WriteLine("[Workflow Runtime] Workflow Persisted: " + e.WorkflowInstance.InstanceId.ToString());
            }
        }

        static void workflowRuntime_WorkflowCreated(object sender, WorkflowEventArgs e)
        {
            if (debugOutputMode > 3)
            {
                Console.WriteLine("[Workflow Runtime] Workflow Created: " + e.WorkflowInstance.InstanceId.ToString());
            }
        }



    }
}
