// --------------------------------
// <copyright file="MenuService.cs" company="Rutgers Software Engineering (Group 8)">
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
    /// Provides an implementation of the IMenuService
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MenuService : IMenuService
    {

        #region IMenuService Members

        /// <summary>
        /// Gets all menu items.
        /// </summary>
        /// <returns></returns>
        public List<MenuItem> getAllMenuItems()
        {
            List<MenuItem> returnList = new List<MenuItem>();
            CrystalMenuDataContext db = new CrystalMenuDataContext();
            var mainMenu = from p in db.Menus
                           where p.IsDefault == true
                           select p;
            int ID = mainMenu.First().ID;
            var menuItems = from p in db.MenuItems
                            where p.MenuID == ID
                            select p;
            foreach (var item in menuItems)
            {
                MenuItem it = new CRySTAL.MenuItem();
                it.price = (decimal)item.Price;
                it.servedDuring = (MenuItem.MealTimes)item.ServedDuring;
                it.subcategory1 = item.Subcategory1;
                it.category1 = item.Category1;
                it.description = item.Description;
                it.name = item.Name;
                it.productID = item.ID;
                returnList.Add(it);
            }

            return returnList;
        }

        /// <summary>
        /// Gets all menu items from a menu.
        /// </summary>
        /// <param name="menuName">Name of the menu.</param>
        /// <returns></returns>
        public List<MenuItem> getAllMenuItemsFromMenu(string menuName)
        {

            List<MenuItem> returnList = new List<MenuItem>();
            CrystalMenuDataContext db = new CrystalMenuDataContext();
            var mainMenu = from p in db.Menus
                           where p.Name==menuName
                           select p;
            if (mainMenu.Count() == 0) return new List<MenuItem>();
            int ID = mainMenu.First().ID;
            var menuItems = from p in db.MenuItems
                            where p.MenuID == ID
                            select p;
            
            foreach (var item in menuItems)
            {
                MenuItem it = new CRySTAL.MenuItem();
                it.price = (decimal)item.Price;
                it.servedDuring = (MenuItem.MealTimes)item.ServedDuring;
                it.subcategory1 = item.Subcategory1;
                it.category1 = item.Category1;
                it.description = item.Description;
                it.name = item.Name;
                it.productID = item.ID;
                returnList.Add(it);
            }
            return returnList;
        }

        /// <summary>
        /// Gets the menu names.
        /// </summary>
        /// <returns></returns>
        public List<string> getMenuNames()
        {
            CrystalMenuDataContext db = new CrystalMenuDataContext();
            var menuNames = from p in db.Menus
                           select p.Name;
            return menuNames.ToList();
        }

        /// <summary>
        /// Gets the menu categories.
        /// </summary>
        /// <returns></returns>
        public List<string> getMenuCategories()
        {
            List<MenuItem> returnList = new List<MenuItem>();
            CrystalMenuDataContext db = new CrystalMenuDataContext();
            var mainMenu = from p in db.Menus
                           where p.IsDefault == true
                           select p;
            if (mainMenu.Count() == 0) return new List<string>();
            int ID = mainMenu.First().ID;
            var catagories = (from p in db.MenuItems
                            where p.MenuID == ID
                            select p.Category1).Distinct();
            return catagories.ToList();
        }

        /// <summary>
        /// Gets the menu categories from a menu.
        /// </summary>
        /// <param name="menuName">Name of the menu.</param>
        /// <returns></returns>
        public List<string> getMenuCategoriesFromMenu(string menuName)
        {
            List<MenuItem> returnList = new List<MenuItem>();
            CrystalMenuDataContext db = new CrystalMenuDataContext();
            var mainMenu = from p in db.Menus
                           where p.Name==menuName
                           select p;
            if (mainMenu.Count() == 0) return new List<string>();
            int ID = mainMenu.First().ID;
            var catagories = (from p in db.MenuItems
                              where p.MenuID == ID
                              select p.Category1).Distinct();
            return catagories.ToList();
        }

        /// <summary>
        /// Gets the menu subcategories.
        /// </summary>
        /// <param name="Category">The category.</param>
        /// <returns></returns>
        public List<string> getMenuSubcategories(string Category)
        {
            List<MenuItem> returnList = new List<MenuItem>();
            CrystalMenuDataContext db = new CrystalMenuDataContext();
            var mainMenu = from p in db.Menus
                           where p.IsDefault == true
                           select p;
            if (mainMenu.Count() == 0) return new List<string>();
            int ID = mainMenu.First().ID;
            var catagories = (from p in db.MenuItems
                              where p.MenuID == ID &&
                              p.Category1 == Category
                              select p.Subcategory1).Distinct();
            return catagories.ToList();
        }

        /// <summary>
        /// Gets the menu subcategories from a menu.
        /// </summary>
        /// <param name="Category">The category.</param>
        /// <param name="menuName">Name of the menu.</param>
        /// <returns></returns>
        public List<string> getMenuSubcategoriesFromMenu(string Category, string menuName)
        {
            List<MenuItem> returnList = new List<MenuItem>();
            CrystalMenuDataContext db = new CrystalMenuDataContext();
            var mainMenu = from p in db.Menus
                           where p.Name == menuName
                           select p;
            if (mainMenu.Count() == 0) return new List<string>();
            int ID = mainMenu.First().ID;
            var catagories = (from p in db.MenuItems
                              where p.MenuID == ID &&
                              p.Category1 == Category
                              select p.Subcategory1).Distinct();
            return catagories.ToList();
        }

        #endregion
    }
}
