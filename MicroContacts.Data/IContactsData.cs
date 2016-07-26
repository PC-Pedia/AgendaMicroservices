using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroContacts.Models;

namespace MicroContacts.Data
{
    public interface IContactsData
    {
	    void Save(Contact contact);
	    IEnumerable<Contact> GetAll();
    }
}
