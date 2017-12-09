/*
 * Created by SharpDevelop.
 * User: WaTo
 * Date: 2017/12/08
 * Time: 21:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			using(var db = new NpgsqlConnection("Server=localhost;Port=26257;User Id=root;Database=bank")){
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
		public void TestInsert(){
			using(var db = new MyDB("cnstrPostgreSQL")){
				var sw = new Stopwatch();
				foreach (var i in Enumerable.Range(1,10000)) {
					sw.Restart();
					db.accounts
						.Value(p => p.balance, i)
						.Insert();
					Console.WriteLine(i + "end" + sw.Elapsed.Milliseconds);
				}
				Console.WriteLine(db.accounts.Count());
			}
		}
		
		[Test]
		public void TestUpdate(){
			using(var db = new MyDB("cnstrPostgreSQL")){
				var sw = new Stopwatch();
				foreach (var i in Enumerable.Range(1,1000)) {
					sw.Restart();
					db.accounts
						.Where(w => w.balance == i)
						.Set(p => p.balance, -1*i)
						.Update();
					Console.WriteLine(i + "end" + sw.Elapsed.Milliseconds);
				}
				Console.WriteLine(db.accounts.Count());
			}
		}
		
		[Test]
		public void TestCreate(){
			using (var db = new MyDB("cnstrPostgreSQL")) {
				
				var sp = db.DataProvider.GetSchemaProvider();
//				db.Command.CommandText = "show databases;";
//				using(var cur = db.Command.ExecuteReader()){
//					Console.WriteLine(cur.FieldCount);
//					Console.WriteLine( cur.GetFieldType(0) );
//				}
				
				db.CreateTable<accounts>();
			}
		}
	}
}
