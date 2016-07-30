using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

	    protected virtual void ExecuteNonQuery(SqliteCommand command)
	    {
			_connection.Open();
		    command.ExecuteNonQuery();
			_connection.Close();
	    }

		protected virtual void ExecuteNonQuery(string commandText)
		{
			var command = _connection.CreateCommand();
			command.CommandText = commandText;
			_connection.Open();
			command.ExecuteNonQuery();

			_connection.Close();
		}

		protected virtual SqliteDataReader ExecuteReader(SqliteCommand command)
	    {
			_connection.Open();
		    var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
			_connection.Close();

		    return reader;
	    }

		protected virtual SqliteDataReader ExecuteReader(string query)
		{
			var command = _connection.CreateCommand();
			command.CommandText = query;

			_connection.Open();
			var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
			_connection.Close();

			return reader;
		}

		protected abstract void CreateTable();
    }
}
