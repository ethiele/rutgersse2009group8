using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CRySTALWorkflow
{
	public sealed partial class CustomerWorkflow: SequentialWorkflowActivity
	{
		public CustomerWorkflow()
		{
			InitializeComponent();
		}


        public static DependencyProperty IsCheckRequestedProperty = DependencyProperty.Register("IsCheckRequested", typeof(bool), typeof(CustomerWorkflow));

        [DescriptionAttribute("IsCheckRequested")]
        [CategoryAttribute("IsCheckRequested Category")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public bool IsCheckRequested
        {
            get
            {
                return ((bool)(base.GetValue(CustomerWorkflow.IsCheckRequestedProperty)));
            }
            set
            {
                base.SetValue(CustomerWorkflow.IsCheckRequestedProperty, value);
            }
        }

        private void AddFoodOrderToBill(object sender, ExternalDataEventArgs e)
        {
            CRySTAL.FoodOrder order = (e as WorkflowLocalService.FoodOrderEventArgs).Order;
            CRySTALDataConnections.CRySTALDataSetTableAdapters.BillItemsTableAdapter bia = new CRySTALDataConnections.CRySTALDataSetTableAdapters.BillItemsTableAdapter();
            CRySTAL.CrystalMenuDataContext db = new CRySTAL.CrystalMenuDataContext();

            foreach (CRySTAL.ItemOrder item in order.FoodOrders)
            {
                var product = from p in db.MenuItems
                              where p.ID == item.productID
                              select p;
                if (product.Count() > 0)
                {
                    bia.InsertBillItem(e.InstanceId, product.First().Name, (decimal)product.First().Price, item.DeliverToPerson);
                }
            }
            order.orderStatus = CRySTAL.FoodOrder.OrderStatusList.orderServed;
            order.InsertToDatabase();

        }

        private void CheckRequest(object sender, ExternalDataEventArgs e)
        {
            CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter cta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter();
            cta.SetStatus(false, true, e.InstanceId);
            IsCheckRequested = true;
        }

        private void Paied(object sender, ExternalDataEventArgs e)
        {
            CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter cta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter();
            cta.SetStatus(false, false, e.InstanceId);
            CRySTALDataConnections.CRySTALDataSetTableAdapters.TablesTblTableAdapter tta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.TablesTblTableAdapter();
            CRySTALDataConnections.CRySTALDataSet.CustomerTransactionsDataTable ctd;
            ctd = cta.GetDataByWorkflowInstID(e.InstanceId);
            if (ctd.Rows.Count == 0) return;
            tta.SetStatus(2, ctd.First().TableNumber);
            cta.UpdateEndTime(DateTime.Now, e.InstanceId);
        }

        private void AddFoodRequest(object sender, ExternalDataEventArgs e)
        {
            CRySTAL.FoodOrder order = (e as WorkflowLocalService.FoodOrderEventArgs).Order;
            CRySTALDataConnections.CRySTALDataSetTableAdapters.BillItemsTableAdapter bia = new CRySTALDataConnections.CRySTALDataSetTableAdapters.BillItemsTableAdapter();
            CRySTAL.CrystalMenuDataContext db = new CRySTAL.CrystalMenuDataContext();

            foreach (CRySTAL.ItemOrder item in order.FoodOrders)
            {
                var product = from p in db.MenuItems
                              where p.ID == item.productID
                              select p;
                if (product.Count() > 0)
                {
                    bia.InsertBillItem(e.InstanceId, product.First().Name, (decimal)product.First().Price, item.DeliverToPerson);
                }
            }
            order.orderStatus = CRySTAL.FoodOrder.OrderStatusList.sentToCook;
            order.InsertToDatabase();
        }
        

	}

}
