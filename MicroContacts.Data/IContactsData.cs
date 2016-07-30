using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroContacts.Models;

namespace MicroContacts.Data
{
    public interface IContactsData
    {
	    IEnumerable<Contact> GetAll();
	    void Add(Contact contact);
	    void Update(Contact contact);
    }
}
