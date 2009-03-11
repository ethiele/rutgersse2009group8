using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceContract]
    interface IMenuService
    {
        [OperationContract]
        List<MenuItem> getAllMenuItems();
        [OperationContract]
        List<MenuItem> getAllMenuItemsFromMenu(string menuName);
        [OperationContract]
        List<string> getMenuNames();
        [OperationContract]
        List<MenuItem> getMenuCategories();
        [OperationContract]
        List<MenuItem> getMenuCategoriesFromMenu(string menuName);
        [OperationContract]
        List<MenuItem> getMenuSubcategories(string Category);
        [OperationContract]
        List<MenuItem> getMenuSubcetagoriesFormMenu(string Category, string menuName);
    }
}
