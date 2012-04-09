using Caliburn.Micro;
using Phonebook.CaliburnMicro.Models;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class EditPersonViewModel : Screen
	{
		public const string EditPerson = "Edit Person";

		public EditPersonViewModel()
		{
			DisplayName = EditPerson;
		}

		public void Close()
		{
			TryClose();
		}

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
