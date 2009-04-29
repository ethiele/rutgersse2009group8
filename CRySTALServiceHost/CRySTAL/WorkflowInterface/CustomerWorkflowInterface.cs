using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRySTAL.WorkflowInterface
{
    public class CustomerWorkflowInterface : WorkflowLocalService.ICustomerLocalService
    {


        public void RaisePlaceFoodOrder(WorkflowLocalService.FoodOrderEventArgs value)
        {
            PlaceFoodOrder(null, value);
        }
        public void RaiseAddFoodOrderToBill(WorkflowLocalService.FoodOrderEventArgs value)
        {
            AddFoodOrderToBill(null, value);
        }
        public void RaiseCheckRequest(System.Workflow.Activities.ExternalDataEventArgs value)
        {
            RequestCheck(null, value);
        }
        public void RaiseOrderPaied(System.Workflow.Activities.ExternalDataEventArgs value)
        {
            OrderPaied(null, value);
        }

        public event EventHandler<WorkflowLocalService.FoodOrderEventArgs> PlaceFoodOrder;

        public event EventHandler<WorkflowLocalService.FoodOrderEventArgs> AddFoodOrderToBill;

        public event EventHandler<System.Workflow.Activities.ExternalDataEventArgs> RequestCheck;

        public event EventHandler<System.Workflow.Activities.ExternalDataEventArgs> OrderPaied;

    }
}
