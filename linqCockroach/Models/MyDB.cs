/*
 * Created by SharpDevelop.
 * User: WaTo
 * Date: 2017/12/08
 * Time: 20:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using LinqToDB;
using LinqToDB.Mapping;

namespace linqCockroach.Models
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public partial class MyDB : LinqToDB.Data.DataConnection
	{
		
		public ITable<accounts> accounts { get { return this.GetTable<accounts>(); } }

		public MyDB()
		{
		}

		public MyDB(string configuration)
			: base(configuration)
		{
		}
	}
	
	[Table(Schema="bank", Name="accounts")]
	public partial class accounts {
		[PrimaryKey, NotNull] public int id {get;set;}
		[Column, Nullable] public decimal balance {get;set;}
		
		public override string ToString()
		{
			return string.Format("[accounts Id={0}, Balance={1}]", id, balance);
		}

	}
	[Table(Schema="bank", Name="accounts2")]
	public partial class accounts2 {
		[PrimaryKey, NotNull] public int id {get;set;}
		[Column, Nullable] public decimal balance {get;set;}
		
		public override string ToString()
		{
			return string.Format("[accounts Id={0}, Balance={1}]", id, balance);
		}

	}
}
