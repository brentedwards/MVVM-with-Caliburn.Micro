using System.Collections.Generic;
using Phonebook.CaliburnMicro.Models;

namespace Phonebook.CaliburnMicro.Repositories
{
	public interface IPersonRepository
	{
		IEnumerable<Person> GetAllFriends();
	}
}
