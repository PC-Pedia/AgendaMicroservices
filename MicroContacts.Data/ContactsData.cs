using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MicroContacts.Models;
using Microsoft.Data.Sqlite;

namespace MicroContacts.Data
{
	public class ContactsData : AccessDataBase, IContactsData
	{
		public ContactsData()
		{
			CreateTable();
		}
		protected override void CreateTable()
		{
			//base.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Contacts(Id TEXT PRIMARY KEY, Name TEXT, Email TEXT)");
			base.Save("CREATE TABLE IF NOT EXISTS Contacts(Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name TEXT, Email TEXT)");
		}

		public IEnumerable<Contact> GetAll()
		{
			try
			{
				return base.Query<Contact>("SELECT Id, Name, Email FROM Contacts");

			}
			catch (Exception ex)
			{
				throw new SqliteException(ex.Message, ex.HResult);
			}
		}

		public void Add(Contact contact)
		{
			var query = $"INSERT INTO Contacts(Name, Email) VALUES('{contact.Name}', '{contact.Email}')";

			try
			{
				base.Save(query);
			}
			catch (Exception ex)
			{
				throw new SqliteException(ex.Message, ex.HResult);
			}

		}

		public void Update(Contact contact)
		{
			var query = $"UPDATE Contacts SET Name='{contact.Name}', Email='{contact.Email}' WHERE Id = {contact.Id}";

			try
			{
				base.Save(query);
			}
			catch (Exception ex)
			{
				throw new SqliteException(ex.Message, ex.HResult);
			}
		}

	}
}
