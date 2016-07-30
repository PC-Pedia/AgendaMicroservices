using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MicroContacts.Models;
using Microsoft.Data.Sqlite;

namespace MicroContacts.Data
{
    public class ContactsData :AccessDataBase,	IContactsData
    {
	    public ContactsData()
	    {
		    CreateTable();
	    }
		protected override void CreateTable()
		{
			base.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Contacts(Id TEXT PRIMARY KEY, Name TEXT, Email TEXT)");
		}

	    public IEnumerable<Contact> GetAll()
	    {
			//TODO: Implement a database call to get all information

			var contacts = new List<Contact>();

			try
		    {
				using (var reader = base.ExecuteReader("SELECT Id, Name, Email FROM Contacts"))
				{
					while (reader.Read())
					{
						if(!reader.HasRows)
							continue;

						contacts.Add(new Contact
						{
							Id = new Guid(reader["Id"].ToString()),
							Name = reader["Name"].ToString(),
							Email = reader["Email"].ToString()
						});
					}
				}
		    }
		    catch (Exception ex)
		    {
			    throw new SqliteException(ex.Message, ex.HResult);
		    }
		   
		    return contacts;
	    }

		public void Add(Contact contact)
		{
			var query = $"INSERT INTO Contacts(Id, Name, Email) VALUES('{contact.Id}', '{contact.Name}', '{contact.Email}')";

			Save(query);
		}

	    public void Update(Contact contact)
	    {
		    var query = $"UPDATE Contacts SET Name='{contact.Name}', Email='{contact.Email}' WHERE Id = '{contact.Id}'";

			Save(query);
		}

	    private void Save(string query)
	    {
			try
			{
				base.ExecuteNonQuery(query);
			}
			catch (Exception ex)
			{
				throw new SqliteException(ex.Message, ex.HResult);
			}
		}

	}
}
