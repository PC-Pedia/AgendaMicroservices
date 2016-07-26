﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroContacts.Data;
using MicroContacts.Models;
using MicroContacts.Services;

namespace MicroContactsServices
{
    public class ContactsService : IContactsService
    {
	    private readonly IContactsData _contactsData;

	    public ContactsService(IContactsData contactsData)
	    {
		    _contactsData = contactsData;
	    }

	    public IEnumerable<Contact> GetAll()
	    {
		    return _contactsData.GetAll();
	    }
    }
}