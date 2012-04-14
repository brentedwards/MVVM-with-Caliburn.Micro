using System.Collections.ObjectModel;
using Caliburn.Micro;
using Phonebook.CaliburnMicro.Messages;
using Phonebook.CaliburnMicro.Models;
using Phonebook.CaliburnMicro.Repositories;
using System.Windows;

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
			// TODO: 3.Edit Refactored
			MessageBox.Show("Edit Clicked!");
		}

		public void View(Person person)
		{
			// TODO: 4. View Refactored
			MessageBox.Show("View Clicked!");
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
