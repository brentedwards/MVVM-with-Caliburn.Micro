using Caliburn.Micro;
using Phonebook.CaliburnMicro.Messages;
using Phonebook.CaliburnMicro.Models;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class EditPersonViewModel : Screen
	{
		public const string EditPerson = "Edit Person";

		public EditPersonViewModel(IEventAggregator eventAggregator)
		{
			EventAggregator = eventAggregator;

			DisplayName = EditPerson;
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

				if (value != null)
				{
					DisplayName = string.Format("Edit {0}", value.Name);
				}
				else
				{
					DisplayName = EditPerson;
				}
			}
		}
	}
}
