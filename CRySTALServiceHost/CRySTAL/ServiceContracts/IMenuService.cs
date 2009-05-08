// --------------------------------
// <copyright file="IMenuService.cs" company="Rutgers Software Engineering (Group 8)">
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
    /// Defines a WCF service that contains methods used by the clients to access menu data
    /// </summary>
    [ServiceContract]
    interface IMenuService
    {
        /// <summary>
        /// Gets all menu items.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<MenuItem> getAllMenuItems();
        /// <summary>
        /// Gets all menu items from a menu.
        /// </summary>
        /// <param name="menuName">Name of the menu.</param>
        /// <returns></returns>
        [OperationContract]
        List<MenuItem> getAllMenuItemsFromMenu(string menuName);
        /// <summary>
        /// Gets the menu names.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<string> getMenuNames();
        /// <summary>
        /// Gets the menu categories.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<string> getMenuCategories();
        /// <summary>
        /// Gets the menu categories from a menu.
        /// </summary>
        /// <param name="menuName">Name of the menu.</param>
        /// <returns></returns>
        [OperationContract]
        List<string> getMenuCategoriesFromMenu(string menuName);
        /// <summary>
        /// Gets the menu subcategories.
        /// </summary>
        /// <param name="Category">The category.</param>
        /// <returns></returns>
        [OperationContract]
        List<string> getMenuSubcategories(string Category);
        /// <summary>
        /// Gets the menu subcategories from a menu.
        /// </summary>
        /// <param name="Category">The category.</param>
        /// <param name="menuName">Name of the menu.</param>
        /// <returns></returns>
        [OperationContract]
        List<string> getMenuSubcategoriesFromMenu(string Category, string menuName);
    }
}
