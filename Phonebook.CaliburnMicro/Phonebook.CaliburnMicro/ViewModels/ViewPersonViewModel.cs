using Caliburn.Micro;
using Phonebook.CaliburnMicro.Models;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class ViewPersonViewModel : Screen
	{
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
					DisplayName = value.Name;
				}
				else
				{
					DisplayName = string.Empty;
				}
			}
		}
	}
}
