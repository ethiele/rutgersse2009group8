﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRySTAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="CRySTAL")]
	public partial class CrystalMenuDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public CrystalMenuDataContext() :
        base(global::CRySTALDataConnections.Properties.Settings.Default.CRySTALConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CrystalMenuDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CrystalMenuDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CrystalMenuDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CrystalMenuDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Menus> Menus
		{
			get
			{
				return this.GetTable<Menus>();
			}
		}
		
		public System.Data.Linq.Table<MenuItems> MenuItems
		{
			get
			{
				return this.GetTable<MenuItems>();
			}
		}
	}
	
	[Table(Name="dbo.Menus")]
	public partial class Menus
	{
		
		private int _ID;
		
		private string _Name;
		
		private string _Description;
		
		private System.Nullable<bool> _IsDefault;
		
		public Menus()
		{
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[Column(Storage="_Name", DbType="VarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[Column(Storage="_Description", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[Column(Storage="_IsDefault", DbType="Bit")]
		public System.Nullable<bool> IsDefault
		{
			get
			{
				return this._IsDefault;
			}
			set
			{
				if ((this._IsDefault != value))
				{
					this._IsDefault = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.MenuItems")]
	public partial class MenuItems
	{
		
		private int _ID;
		
		private int _MenuID;
		
		private string _Category1;
		
		private string _Subcategory1;
		
		private System.Nullable<int> _ServedDuring;
		
		private string _Name;
		
		private string _Description;
		
		private System.Nullable<decimal> _Price;
		
		public MenuItems()
		{
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[Column(Storage="_MenuID", DbType="Int NOT NULL")]
		public int MenuID
		{
			get
			{
				return this._MenuID;
			}
			set
			{
				if ((this._MenuID != value))
				{
					this._MenuID = value;
				}
			}
		}
		
		[Column(Storage="_Category1", DbType="VarChar(50)")]
		public string Category1
		{
			get
			{
				return this._Category1;
			}
			set
			{
				if ((this._Category1 != value))
				{
					this._Category1 = value;
				}
			}
		}
		
		[Column(Storage="_Subcategory1", DbType="VarChar(50)")]
		public string Subcategory1
		{
			get
			{
				return this._Subcategory1;
			}
			set
			{
				if ((this._Subcategory1 != value))
				{
					this._Subcategory1 = value;
				}
			}
		}
		
		[Column(Storage="_ServedDuring", DbType="Int")]
		public System.Nullable<int> ServedDuring
		{
			get
			{
				return this._ServedDuring;
			}
			set
			{
				if ((this._ServedDuring != value))
				{
					this._ServedDuring = value;
				}
			}
		}
		
		[Column(Storage="_Name", DbType="VarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[Column(Storage="_Description", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[Column(Storage="_Price", DbType="Money")]
		public System.Nullable<decimal> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this._Price = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
