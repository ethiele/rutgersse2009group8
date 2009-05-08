// --------------------------------
// <copyright file="ITimeCardService.cs" company="Rutgers Software Engineering (Group 8)">
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
    /// Defines a WCF service that contains methods used by all client to accomplish to recorde shift data
    /// </summary>
    [ServiceContract]
    interface ITimeCardService
    {
        /// <summary>
        /// Starts a new shift of the given logged in in the given role.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="role">The role.</param>
        [OperationContract]
        void StampShiftStart(string sessionID, string role);

        /// <summary>
        /// Ends the shift of the given user if they are in a shift. 
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns>Returns true if the user's shift could be ended, else returns false</returns>
        [OperationContract]
        bool StampShiftEnd(string sessionID);

        /// <summary>
        /// Determines whether this instance can stamp out the current user.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns>
        /// 	<c>true</c> if this instance can stamp out the current user; otherwise, <c>false</c>.
        /// </returns>
        [OperationContract]
        bool CanStampOut(string sessionID);

        /// <summary>
        /// Gets the last weeks worth of shifts for the current user.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        [OperationContract]
        List<ShiftData> GetLastWeeksShifts(string sessionID);
    }
}
