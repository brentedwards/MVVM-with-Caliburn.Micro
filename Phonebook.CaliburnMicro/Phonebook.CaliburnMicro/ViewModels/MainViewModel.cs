using Caliburn.Micro;
using Phonebook.CaliburnMicro.Messages;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class MainViewModel : Conductor<Screen>.Collection.OneActive,
		IHandle<EditPersonMessage>,
		IHandle<CloseEditPersonMessage>
	{
		public MainViewModel()
		{
			DisplayName = "Phonebook";
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			Items.Add(IoC.Get<AllFriendsViewModel>());
		}

		public void Handle(EditPersonMessage message)
		{
			var editPersonViewModel = IoC.Get<EditPersonViewModel>();
			editPersonViewModel.Person = message.Person;

			Items.Add(editPersonViewModel);

			ActivateItem(editPersonViewModel);
		}

		public void Handle(CloseEditPersonMessage message)
		{
			Items.Remove(message.PersonViewModel);
		}
	}
}
