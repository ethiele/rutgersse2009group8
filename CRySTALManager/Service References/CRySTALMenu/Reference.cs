﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRySTALManager.CRySTALMenu {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MenuItem", Namespace="http://schemas.datacontract.org/2004/07/CRySTAL")]
    [System.SerializableAttribute()]
    public partial class MenuItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string category1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal priceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int productIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CRySTALManager.CRySTALMenu.MenuItem.MealTimes servedDuringField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string subcategory1Field;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string category1 {
            get {
                return this.category1Field;
            }
            set {
                if ((object.ReferenceEquals(this.category1Field, value) != true)) {
                    this.category1Field = value;
                    this.RaisePropertyChanged("category1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.descriptionField, value) != true)) {
                    this.descriptionField = value;
                    this.RaisePropertyChanged("description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal price {
            get {
                return this.priceField;
            }
            set {
                if ((this.priceField.Equals(value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int productID {
            get {
                return this.productIDField;
            }
            set {
                if ((this.productIDField.Equals(value) != true)) {
                    this.productIDField = value;
                    this.RaisePropertyChanged("productID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CRySTALManager.CRySTALMenu.MenuItem.MealTimes servedDuring {
            get {
                return this.servedDuringField;
            }
            set {
                if ((this.servedDuringField.Equals(value) != true)) {
                    this.servedDuringField = value;
                    this.RaisePropertyChanged("servedDuring");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string subcategory1 {
            get {
                return this.subcategory1Field;
            }
            set {
                if ((object.ReferenceEquals(this.subcategory1Field, value) != true)) {
                    this.subcategory1Field = value;
                    this.RaisePropertyChanged("subcategory1");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
        [System.FlagsAttribute()]
        [System.Runtime.Serialization.DataContractAttribute(Name="MenuItem.MealTimes", Namespace="http://schemas.datacontract.org/2004/07/CRySTAL")]
        public enum MealTimes : int {
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            breakfast = 1,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            lunch = 2,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            dinner = 4,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            latenight = 8,
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRySTALMenu.IMenuService")]
    public interface IMenuService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/getAllMenuItems", ReplyAction="http://tempuri.org/IMenuService/getAllMenuItemsResponse")]
        CRySTALManager.CRySTALMenu.MenuItem[] getAllMenuItems();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/getAllMenuItemsFromMenu", ReplyAction="http://tempuri.org/IMenuService/getAllMenuItemsFromMenuResponse")]
        CRySTALManager.CRySTALMenu.MenuItem[] getAllMenuItemsFromMenu(string menuName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/getMenuNames", ReplyAction="http://tempuri.org/IMenuService/getMenuNamesResponse")]
        string[] getMenuNames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/getMenuCategories", ReplyAction="http://tempuri.org/IMenuService/getMenuCategoriesResponse")]
        string[] getMenuCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/getMenuCategoriesFromMenu", ReplyAction="http://tempuri.org/IMenuService/getMenuCategoriesFromMenuResponse")]
        string[] getMenuCategoriesFromMenu(string menuName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/getMenuSubcategories", ReplyAction="http://tempuri.org/IMenuService/getMenuSubcategoriesResponse")]
        string[] getMenuSubcategories(string Category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuService/getMenuSubcategoriesFromMenu", ReplyAction="http://tempuri.org/IMenuService/getMenuSubcategoriesFromMenuResponse")]
        string[] getMenuSubcategoriesFromMenu(string Category, string menuName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IMenuServiceChannel : CRySTALManager.CRySTALMenu.IMenuService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class MenuServiceClient : System.ServiceModel.ClientBase<CRySTALManager.CRySTALMenu.IMenuService>, CRySTALManager.CRySTALMenu.IMenuService {
        
        public MenuServiceClient() {
        }
        
        public MenuServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MenuServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MenuServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MenuServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CRySTALManager.CRySTALMenu.MenuItem[] getAllMenuItems() {
            return base.Channel.getAllMenuItems();
        }
        
        public CRySTALManager.CRySTALMenu.MenuItem[] getAllMenuItemsFromMenu(string menuName) {
            return base.Channel.getAllMenuItemsFromMenu(menuName);
        }
        
        public string[] getMenuNames() {
            return base.Channel.getMenuNames();
        }
        
        public string[] getMenuCategories() {
            return base.Channel.getMenuCategories();
        }
        
        public string[] getMenuCategoriesFromMenu(string menuName) {
            return base.Channel.getMenuCategoriesFromMenu(menuName);
        }
        
        public string[] getMenuSubcategories(string Category) {
            return base.Channel.getMenuSubcategories(Category);
        }
        
        public string[] getMenuSubcategoriesFromMenu(string Category, string menuName) {
            return base.Channel.getMenuSubcategoriesFromMenu(Category, menuName);
        }
    }
}
