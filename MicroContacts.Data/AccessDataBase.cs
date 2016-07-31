using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MicroContacts.Models;
using Microsoft.Data.Sqlite;

namespace MicroContacts.Data
{
    public abstract class AccessDataBase
    {
	    private static SqliteConnection _connection;
	    public static SqliteConnection Connection => _connection;

	    protected AccessDataBase()
	    {
			//_connection = new SqliteConnection("Data Source=ContactsDb;Mode=Memory;Cache=Shared");
			_connection = new SqliteConnection("Data Source=ContactsDb.db");
	    }

	    protected virtual IEnumerable<T> Query<T>(string query) where T:IModel
	    {
		    _connection.Open();
		    var results = _connection.Query(query)
		                             .Select(x => ConvertTo<T>(x))
		                             .Cast<T>();
			_connection.Close();

			return results;
	    }

	    protected virtual void Save(string query)
	    {
		    _connection.Open();
		    _connection.Execute(query);
			_connection.Close();
	    }

		protected abstract void CreateTable();
	    protected abstract IModel ConvertTo<T>(dynamic value) where T: IModel;
    }
}
