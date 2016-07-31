using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroContacts.Models
{
    public class Contact : IModel
	{
		public Guid Id { get; set; }
	    public string Name { get; set; }
	    public string Email { get; set; }
		
    }

	public interface IModel
	{
	}
}
