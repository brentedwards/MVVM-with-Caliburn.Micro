using System.Collections.Generic;
using Phonebook.CaliburnMicro.Models;

namespace Phonebook.CaliburnMicro.Repositories
{
	public sealed class PersonRepository : IPersonRepository
	{
		public IEnumerable<Person> GetAllFriends()
		{
			var friends = new List<Person>();

			friends.Add(new Person { Name = "Bob Lablaw", PhoneNumber = "(555) 555-1234" });
			friends.Add(new Person { Name = "Peter Griffin", PhoneNumber = "(555) 555-1111" });
			friends.Add(new Person { Name = "Barney Stinson", PhoneNumber = "(555) 555-2222" });

			return friends;
		}
	}
}
