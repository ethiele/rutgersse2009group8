<%@ Application Language="C#" %>
<%@ Import Namespace="CRySTAL" %>
<%@ Import Namespace="System.Workflow.Runtime" %>
<%@ Import Namespace="System.Workflow.Runtime.Hosting" %>
<%@ Import Namespace="System.Workflow.Runtime.Tracking" %>
<%@ Import Namespace="System.Workflow.Activities" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        
        CRySTAL.WorkflowInterface.WorkflowInterface.CustomerWF = new CRySTAL.WorkflowInterface.CustomerWorkflowInterface();
        System.Workflow.Runtime.Configuration.WorkflowRuntimeSection wrs = new System.Workflow.Runtime.Configuration.WorkflowRuntimeSection();
        wrs.EnablePerformanceCounters = false;
        WorkflowRuntime workflowRuntime = new WorkflowRuntime(wrs);
        
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
        string connectionString = @"Data Source=8.8.246.10;Persist Security Info=True;User ID=et_admin;Password=Delta34PiA34lpha384";
        SqlWorkflowPersistenceService sqlPersistenceService =
            new SqlWorkflowPersistenceService(connectionString, true, ownershipDuration, reloadIntevral);
        workflowRuntime.AddService(sqlPersistenceService);
        workflowRuntime.AddService(new SharedConnectionWorkflowCommitWorkBatchService(connectionString));
        
        workflowRuntime.WorkflowIdled += new EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowIdled);

        SqlTrackingService sts = new SqlTrackingService(connectionString);
        workflowRuntime.AddService(sts);

        //Console.WriteLine("Starting Workflow Runtime...");
        workflowRuntime.StartRuntime();

    }

    void workflowRuntime_WorkflowIdled(object sender, WorkflowEventArgs e)
    {
        e.WorkflowInstance.Unload();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        WorkflowRuntime wf = (WorkflowRuntime)AppDomain.CurrentDomain.GetData("WorkflowRuntime");
        wf.StopRuntime();

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
