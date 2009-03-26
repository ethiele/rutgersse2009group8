using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Activities;
using System.Workflow.Runtime;

namespace WorkflowLocalService
{
    [ExternalDataExchange]
    public interface ICustomerLocalService
    {
        event EventHandler<FoodOrderEventArgs> PlaceFoodOrder;
        event EventHandler<FoodOrderEventArgs> AddFoodOrderToBill;
        event EventHandler<ExternalDataEventArgs> RequestCheck;
        event EventHandler<ExternalDataEventArgs> OrderPaied;
    }

    [Serializable]
    public class FoodOrderEventArgs : ExternalDataEventArgs
    {
        CRySTAL.FoodOrder order;
        public CRySTAL.FoodOrder Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
            }
        }

        public FoodOrderEventArgs(Guid instanceId, CRySTAL.FoodOrder foodOrder)
            : base(instanceId)
        {
            order = foodOrder;
        }
    }
}
