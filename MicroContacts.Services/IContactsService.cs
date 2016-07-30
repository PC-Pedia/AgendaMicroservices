using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroContacts.Models;

namespace MicroContacts.Services
{
    public interface IContactsService
    {
	    IEnumerable<Contact> GetAll();
	    void Save(Contact contact);
    }
}
