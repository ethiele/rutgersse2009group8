using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MenuService : IMenuService
    {

        #region IMenuService Members

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
                returnList.Add(it);
            }

            return returnList;
        }

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
                returnList.Add(it);
            }
            return returnList;
        }

        public List<string> getMenuNames()
        {
            CrystalMenuDataContext db = new CrystalMenuDataContext();
            var menuNames = from p in db.Menus
                           select p.Name;
            return menuNames.ToList();
        }

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
