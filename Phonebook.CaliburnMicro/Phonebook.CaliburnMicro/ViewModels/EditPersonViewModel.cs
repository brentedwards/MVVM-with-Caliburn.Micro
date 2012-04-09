using Caliburn.Micro;
using Phonebook.CaliburnMicro.Messages;
using Phonebook.CaliburnMicro.Models;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class EditPersonViewModel : Screen
	{
		public EditPersonViewModel(IEventAggregator eventAggregator)
		{
			EventAggregator = eventAggregator;
		}

		public void Close()
		{
			EventAggregator.Publish(new CloseEditPersonMessage { PersonViewModel = this });
		}

		private IEventAggregator EventAggregator { get; set; }

		private Person person;
		public Person Person
		{
			get { return person; }
			set
			{
				person = value;
				NotifyOfPropertyChange(() => Person);
			}
		}
	}
}
