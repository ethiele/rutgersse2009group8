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
        List<string> getMenuCategories();
        [OperationContract]
        List<string> getMenuCategoriesFromMenu(string menuName);
        [OperationContract]
        List<string> getMenuSubcategories(string Category);
        [OperationContract]
        List<string> getMenuSubcategoriesFromMenu(string Category, string menuName);
    }
}
