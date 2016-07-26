using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroContacts.Models;

namespace MicroContacts.Data
{
    public class ContactsData :IContactsData
    {
	    public void Save(Contact contact)
	    {
		    //Persist data
	    }

	    public IEnumerable<Contact> GetAll()
	    {
			//TODO: Implement a database call to get all information

		    //Get all contacts
		    return new[] {new Contact {Name = "Bla", Email = "bla@bla.com"}};
	    }
    }
}
