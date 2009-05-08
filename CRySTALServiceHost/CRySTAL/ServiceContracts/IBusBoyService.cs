// --------------------------------
// <copyright file="IBusBoyService.cs" company="Rutgers Software Engineering (Group 8)">
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
    /// Defines a WCF service that contains methods used by the busboy client to accomplish the goals of the waiter busboy
    /// </summary>
    [ServiceContract]
    public interface IBusBoyService
    {

        /// <summary>
        /// Returns all food orders with a status of readyToDelever and outForDelivery
        /// </summary>
        /// <param name="sessionID">The ID for this logged in session</param>
        /// <returns></returns>
        [OperationContract]
        List<FoodOrder> getAllFoodOrders(string sessionID);

        /// <summary>
        /// Returns all food orders with a status of readyToDelever and outForDelivery
        /// that have been added since the last call to this method
        /// </summary>
        /// <param name="sessionID">The ID for this logged in session</param>
        /// <returns></returns>
        [OperationContract]
        List<FoodOrder> getNewFoodOrders(string sessionID);

        /// <summary>
        /// Sets the selected orders status
        /// </summary>
        /// <param name="orderNumber">The order number who's status you wish to set</param>
        /// <param name="status">The status it is to be set to</param>
        [OperationContract]
        void MarkOrder(string sessionID, int orderNumber, FoodOrder.OrderStatusList status);

        /// <summary>
        /// Gets all tables.
        /// </summary>
        /// <param name="sessionID">The session ID.</param>
        /// <returns></returns>
        [OperationContract]
        Dictionary<int, TableTypes> getTables(string sessionID);

        /// <summary>
        /// Sets the table status.
        /// </summary>
        /// <param name="sessionID">The session ID.</param>
        /// <param name="tbl">The table number.</param>
        /// <param name="status">The new status of the table.</param>
        [OperationContract]
        void setTableStatus(string sessionID, int tbl, TableTypes status);

    }
}
