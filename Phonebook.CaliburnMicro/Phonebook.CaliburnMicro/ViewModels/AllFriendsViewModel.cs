using System.Collections.ObjectModel;
using Caliburn.Micro;
using Phonebook.CaliburnMicro.Models;
using Phonebook.CaliburnMicro.Repositories;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class AllFriendsViewModel : Screen
	{
		public AllFriendsViewModel(IPersonRepository personRepository)
		{
			PersonRepository = personRepository;

			DisplayName = "All Friends";

			Friends = new ObservableCollection<Person>();
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			var friends = PersonRepository.GetAllFriends();
			foreach (var friend in friends)
			{
				Friends.Add(friend);
			}
		}

		private IPersonRepository PersonRepository { get; set; }

		public ObservableCollection<Person> Friends { get; private set; }
	}
}
