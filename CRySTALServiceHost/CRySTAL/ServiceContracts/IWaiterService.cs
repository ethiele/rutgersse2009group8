// --------------------------------
// <copyright file="IWaiterService.cs" company="Rutgers Software Engineering (Group 8)">
//     The MIT License
// The MIT License
// Copyright (c) 2009 Edward Thiele (ethiele.com)
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights 
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
// </copyright>
// <author>Edward Thiele (EJ Thiele)</author>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    /// <summary>
    /// Defines a WCF service that contains methods used by the waiter client to accomplish the goals of the waiter role
    /// </summary>
    [ServiceContract]
    public interface IWaiterService
    {
        /// <summary>
        /// Places the order a new order, sends it to the cook and adds the items to the bill.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="order">The order to be placed.</param>
        [OperationContract]
        void PlaceOrder(string sessionID, FoodOrder order);
        /// <summary>
        /// Adds the item to bill and markes it as done. Does not send the order to the cook.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="order">The order to be added to the bill.</param>
        [OperationContract]
        void AddItemToBill(string sessionID, FoodOrder order);
        /// <summary>
        /// Gets the returned orders from the cook.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        [OperationContract]
        List<RejectedOrder> GetReturnedOrders(string sessionID);
        /// <summary>
        /// Gets the current tables assigned to this waiter.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        [OperationContract]
        List<int> GetCurrentTables(string sessionID);
        /// <summary>
        /// Gets the tables who have finished there order and who now need to pay
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        [OperationContract]
        List<int> GetInPaymentTables(string sessionID);
        /// <summary>
        /// Marks the order as paid and marks the table to be cleaned.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="tblNumber">The table number.</param>
        [OperationContract]
        void MarkPaid(string sessionID, int tblNumber);
        /// <summary>
        /// Gets the receipt.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="tblNumber">The table number.</param>
        /// <returns></returns>
        [OperationContract]
        List<BillItem> GetReceipt(string sessionID, int tblNumber);

    }
}
