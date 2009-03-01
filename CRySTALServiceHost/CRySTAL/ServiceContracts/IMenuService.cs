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
        List<MenuItem> getAllMenuItmesFromMenu(string menuName);
        [OperationContract]
        List<string> getMenuNames();
        [OperationContract]
        List<MenuItem> getMenuCategories();
        [OperationContract]
        List<MenuItem> getMenuCategoriesFromMenu(string menuName);
        [OperationContract]
        List<MenuItem> getMenuSubcetagories(string Category);
        [OperationContract]
        List<MenuItem> getMenuSubcetagoriesFormMenu(string Category, string menuName);
    }
}
