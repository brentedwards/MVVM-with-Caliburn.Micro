using System.Collections.ObjectModel;
using Caliburn.Micro;
using Phonebook.CaliburnMicro.Messages;
using Phonebook.CaliburnMicro.Models;
using Phonebook.CaliburnMicro.Repositories;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class AllFriendsViewModel : Screen
	{
		public AllFriendsViewModel(
			IPersonRepository personRepository,
			IEventAggregator eventAggregator)
		{
			PersonRepository = personRepository;
			EventAggregator = eventAggregator;

			DisplayName = "All Friends";

			Friends = new ObservableCollection<Person>();
		}

		public void Edit()
		{
			EventAggregator.Publish(new EditPersonMessage() { Person = SelectedPerson });
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
		private IEventAggregator EventAggregator { get; set; }

		public ObservableCollection<Person> Friends { get; private set; }

		private Person selectedPerson;
		public Person SelectedPerson
		{
			get { return selectedPerson; }
			set
			{
				selectedPerson = value;
				NotifyOfPropertyChange(() => SelectedPerson);
			}
		}
	}
}
