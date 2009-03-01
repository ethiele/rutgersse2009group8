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
            throw new NotImplementedException();
        }

        public List<MenuItem> getAllMenuItmesFromMenu(string menuName)
        {
            throw new NotImplementedException();
        }

        public List<string> getMenuNames()
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> getMenuCategories()
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> getMenuCategoriesFromMenu(string menuName)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> getMenuSubcetagories(string Category)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> getMenuSubcetagoriesFormMenu(string Category, string menuName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
