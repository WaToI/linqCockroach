﻿/*
 * Created by SharpDevelop.
 * User: WaTo
 * Date: 2017/12/08
 * Time: 21:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using linqCockroach.Models;
using Npgsql;
using NUnit.Framework;
using LinqToDB;
using LinqToDB.Mapping;

namespace linqCockroach.Tests
{
	[TestFixture]
	public class MyDB_test
	{
		[Test]
		public void TestConnect()
		{
			using(var db = new NpgsqlConnection("Server=localhost;Port=26257;User Id=maxroach;Database=bank")){
				db.Open();
				Console.WriteLine( db.GetSchema() );
				Console.WriteLine("接続おっけー👌");
				db.Close();
			}
		}
		
		[Test]
		public void TestSelect(){
			using(var db = new MyDB("cnstrPostgreSQL")){
				
				var find = db.accounts.FirstOrDefault();
				Console.WriteLine(find.ToString());
			}
		}
		
		[Test]
		public void TestCreate(){
			using (var db = new MyDB("cnstrPostgreSQL")) {
				
				var sp = db.DataProvider.GetSchemaProvider();
				
				db.CreateTable<accounts2>();
//				var dbSchema = sp.GetSchema(db);
//				if(!dbSchema.Tables.Any(t => t.TableName == "accounts2"))
//				{
//					//no required table-create it
//					db.CreateTable<accounts>();
//				}
			}
		}
	}
}
