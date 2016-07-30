using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroContacts.Models
{
    public class Contact
    {
		public Guid Id { get; set; }
	    public string Name { get; set; }
	    public string Email { get; set; }
		
    }
}
