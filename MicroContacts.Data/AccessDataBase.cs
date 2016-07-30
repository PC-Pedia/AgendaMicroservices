using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
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

	    protected virtual IEnumerable<T> Query<T>(string query)
	    {
		    _connection.Open();
			var results = _connection.Query<T>(query);
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
    }
}
